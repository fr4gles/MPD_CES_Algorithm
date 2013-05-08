using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace MPD_CES_Algorithm
{
    class GanttChart
    {
        public List<Task> TaskList;
        public Chart MyChart;

        private Int32 NumZad;


        public GanttChart(ref Chart myChart, List<Task> processorsList)
        {
            TaskList = new List<Task>(processorsList);
            MyChart = myChart;

            MyChart.Visible = true;

            MyChart.AutoSize = true;

            // Set automatic zooming
            MyChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            MyChart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            // Set automatic scrolling 
            MyChart.ChartAreas[0].CursorX.AutoScroll = true;
            MyChart.ChartAreas[0].CursorY.AutoScroll = true;

            // Allow user selection for Zoom
            MyChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            MyChart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;

            NumZad = 0;
        }

        public String MakeChart()
        {

            List<String> listString = new List<string>();

            MyChart.Series.Clear();
            var maxT = ObliczMaxT();

            //TaskList = TaskList.OrderBy(taks => taks.D).ThenByDescending(task => task.P).ToList();

            foreach (var task in TaskList)
                task.IloscPowtorzen = maxT/task.T;

            var listaCykli = new List<Int32>();
            var iloscCykli = ObliczIloscCykli();

            var sum = 0;
            for (int i = 0; i < iloscCykli; ++i)
            {
                listString.Add("Cykl: "+i+" \n");
                listaCykli.Add(sum);
                sum += TaskList[NumZad - 1].T;
            }

            foreach (var task in TaskList)
            {
                var increment = listaCykli.Count/task.IloscPowtorzen;
                for (int i = 0; i < listaCykli.Count; i += increment)
                {
                    listString[i] += "Zadanie: "+task.Number
                        +"   (p = "+task.P+
                    ", d = " + task.D + ", T = "+task.T+")\n";

                    var start = listaCykli[i];
                    if ((task.D < start) && (i == 0))
                        throw new Exception(
                            "BŁĄD! Zbyt duże czasy wykonań zadań! Zadanie nie może zostać wykonane w zadanym ograniczeniu czasowym!" +
                            "\nZADANIE NR: " + task.Number + " (p =" + task.P + ", d = )" + task.D + ", T = " + task.T + ")");

                    AddSeries(task, i);
                    var end = start + task.P;
                    MyChart.Series[MyChart.Series.Count - 1].Points.AddXY(0, new object[] {start, end});

                    listaCykli[i] += task.P;
                }
            }

            return listString.Aggregate("", (current, v) => current + (v + "\n"));
        }

        private void AddSeries(Task task, int cykl)
        {
            var s = new Series
            {
                Name = task.Number.ToString(CultureInfo.InvariantCulture) + " c: " + cykl,
                ChartType = SeriesChartType.RangeBar,
                Color = task.Color,
                BorderColor = Color.Black,
                BorderWidth = 2,
                MarkerStep = 1,
                Label = task.Number.ToString(CultureInfo.InvariantCulture),
                CustomProperties = "DrawSideBySide=False",
                ToolTip = "p = " + task.P + ", d = " + task.D + ", T = " + task.T,
                AxisLabel = "CPU"
            };
            MyChart.Series.Add(s);
        }

        private int ObliczMaxT()
        {
            var max = 0;
            foreach (var task in TaskList)
                max = Math.Max(task.T, max);
            return max;
        }

        private int ObliczIloscCykli()
        {
            var max = TaskList.Select(task => task.IloscPowtorzen).Concat(new[] { 0 }).Max();

            foreach (var task in TaskList.Where(task => max == task.IloscPowtorzen))
            {
                NumZad = task.Number;
            }

            return max;
        }
    }
}
