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
            NumZad = 0;
        }

        public void MakeChart()
        {
            MyChart.Series.Clear();
            var maxT = ObliczMaxT();

            TaskList = TaskList.OrderBy(taks => taks.D).ThenByDescending(task => task.P).ToList();

            //            var tmpTaskList = new List<Task>(TaskList);

            foreach (var task in TaskList)
                task.IloscPowtorzen = maxT/task.T;

            var listaCykli = new List<Int32>();
            var iloscCykli = ObliczIloscCykli();

            var sum = 0;
            for (int i = 0; i < iloscCykli; ++i)
            {
                listaCykli.Add(sum);
                sum += TaskList[NumZad - 1].T;
            }

            //            for(int i=0;i<listaCykli.Count;++i)
            //            {
            // cykl pierwszy

            foreach (var task in TaskList)
            {
                var increment = listaCykli.Count/task.IloscPowtorzen;
                for (int i = 0; i < listaCykli.Count; i += increment)
                {
                    var start = listaCykli[i];
//                    if ((task.D < start) && (i == 0))
//                        throw new Exception(
//                            "BŁĄD! Zbyt duże czasy wykonań zadań! Zadanie nie może zostać wykonane w zadanym ograniczeniu czasowym!" +
//                            "\nZADANIE NR: " + task.Number + " (p =" + task.P + ", d = )" + task.D + ", T = " + task.T + ")");

                    AddSeries(task, i);
                    var end = start + task.P;
                    MyChart.Series[MyChart.Series.Count - 1].Points.AddXY(0, new object[] {start, end});

                    listaCykli[i] += task.P;
                }
            }

            MyChart.Series.Add(
                new Series
                    {
                        ChartType = SeriesChartType.Line,
                        Color = Color.Black,
                        //                BorderColor = Color.Black,
                        //                BorderWidth = 2,
                        MarkerStep = 1,
                        //                Label = task.Number.ToString(CultureInfo.InvariantCulture),
                        //                CustomProperties = "DrawSideBySide=False",
                        //                ToolTip = "p = " + task.P + ", d = " + task.D + ", T = " + task.T,
                    });

            MyChart.Series[0].Points.AddXY(20, 0);
            MyChart.Series[0].Points.AddXY(20, 2);


            //            }



            //            var start = 0;
            //            var j = 0;
            //            foreach (var task in TaskList)
            //            {
            ////                if (task.D < start)
            ////                    throw new Exception("BŁĄD! Zbyt duże czasy wykonań zadań! Zadanie nie może zostać wykonane w zadanym ograniczeniu czasowym!" +
            ////                                                                                "\nZADANIE NR: " + task.Number + " (p =" + task.P + ", d = )" + task.D + ", T = " + task.T + ")");
            //
            //
            //                if (task.IloscPowtorzen <= 1)
            //                {
            //                    AddSeries(task, 0);
            //                    var end = start + task.P;
            //                    MyChart.Series[MyChart.Series.Count - 1].Points.AddXY(0, new object[] { start, end });
            //                    start = end;
            //                }
            //                else
            //                {
            //                    var tmpStart = start;
            //                    for (int i = 0; i < task.IloscPowtorzen; ++i)
            //                    {
            //                        if (i == 0)
            //                        {
            //                            AddSeries(task, 0);
            //                            var tmpEnd = tmpStart + task.P;
            //                            MyChart.Series[MyChart.Series.Count - 1].Points.AddXY(0, new object[] { tmpStart, tmpEnd });
            //                            tmpStart = tmpEnd;
            //                        }
            //                        else
            //                        {
            //                            tmpStart = task.T*i;
            //                            AddSeries(task, i);
            //                            var end = tmpStart + task.P;
            //                            MyChart.Series[MyChart.Series.Count-1].Points.AddXY(0, new object[] {tmpStart, end});
            //                            tmpStart = end;
            //                        }
            //                        j = i;
            //                    }
            //                    start = tmpStart;
            //                }
            //            }

            //            int j = 0;
            //            int tmp = MyChart.Series.Count;
            //            foreach (var p in ProcessorsList)
            //            {
            //                var start = 0.0;
            //
            //                foreach (var t in p.ProcessorTasksList)
            //                {
            //                    if (j < tmp - 1)
            //                    {
            //                        var end = start + t.Duration;
            //                        MyChart.Series[j].Points.AddXY(p.ProcessorNumber, new object[] { start, end });
            //                        MyChart.Series[j].Points[MyChart.Series[j].Points.Count - 1].Label = t.Name;
            //                        start = end;
            //                        j++;
            //                    }
            //                }
            //            }

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
