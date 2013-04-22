using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MPD_CES_Algorithm
{
    public partial class Form1 : Form
    {
        //        private Int32 UID = 0;
        private CES_Algorithm cesAlgorithm;
        private List<Color> colors;

        public Form1()
        {
            InitializeComponent();

            GenerujWartosciPoczatkowe();
        }

        private void GenerujWartosciPoczatkowe()
        {
            dataGridView.Rows.Add(new object[] { "2", "1", "2" });
            dataGridView.Rows.Add(new object[] { "3", "1", "2" });
            dataGridView.Rows.Add(new object[] { "4", "2", "3" });

            setRowNumber(dataGridView);
        }

        private void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            //TODO: algorytm

            if (dataGridView.Rows.Count < 2)
            {
                MessageBox.Show("Błąd, za mała ilość zadań... Nie mam co robić :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dataGridView.Rows.Count < 3)
                return;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();



            if (cesAlgorithm != null)
                cesAlgorithm.ClearObj();

            cesAlgorithm = null;

            cesAlgorithm = new CES_Algorithm();


            for (var i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                var tVal = Int32.Parse(dataGridView.Rows[i].Cells[0].Value.ToString());
                var pVal = Int32.Parse(dataGridView.Rows[i].Cells[1].Value.ToString());
                var dVal = Int32.Parse(dataGridView.Rows[i].Cells[2].Value.ToString());

                var task = new Task { T = tVal, P = pVal, D = dVal, Color = GetFreeColor() };

                cesAlgorithm.TaskList.Add(task);
            }


            cesAlgorithm.Go();

            AddSeries();

            //            var ganttChart = new GanttChart(ref chart1, mcnaughton.ProcessorsList);
            //            ganttChart.MakeChart();
            //
            //            chart1.ChartAreas[0].AxisY.Maximum = McNaughtonAlgorithm.Cmax + 1;
            //            //            chart1.ChartAreas[0].AxisX.Maximum = mcnaughton.ProcessorsList.Count;
            //            chart1.ChartAreas[0].AxisX.Minimum = -1;
            //
            //            stopwatch.Stop();
            //
            //            PrepareInfoBox(ref mcnaughton, stopwatch.Elapsed);
            //            PrepareTitle();
            //
            //
            //            btnZapisz.Enabled = true;
        }

        private void AddSeries()
        {
            chart1.Series.Clear();
            var i = 0;
            for (; i < cesAlgorithm.TaskList.Count; ++i)
            {
                var s = new Series
                {
                    Name = i.ToString(CultureInfo.InvariantCulture),
                    ChartType = SeriesChartType.RangeBar,
                    Color = cesAlgorithm.TaskList[i].Color,
                    BorderColor = Color.Black,
                    BorderWidth = 2,
                    MarkerStep = 1,
                    CustomProperties = "DrawSideBySide=False",
                    //                    ToolTip = "Czas trwania zadania: " + cesAlgorithm.TaskList[i],
                    AxisLabel = "id: " + i.ToString(CultureInfo.InvariantCulture)
                };
                chart1.Series.Add(s);
            }
            chart1.Series.Add(new Series
            {
                Name = (++i).ToString(CultureInfo.InvariantCulture),
                ChartType = SeriesChartType.RangeBar,
                Color = GetFreeColor(),
                BorderColor = Color.Black,
                BorderWidth = 2,
                MarkerStep = 1,
                CustomProperties = "DrawSideBySide=False",
                //                ToolTip = "Czas trwania zadania: " + cesAlgorithm.TaskList[i].,
                AxisLabel = "id: " + i.ToString(CultureInfo.InvariantCulture)
            });
        }

        public Color GetFreeColor()
        {
            if (colors.Count < 1)
                GenerateColors();

            Random random = new Random();
            var index = random.Next(colors.Count - 1);
            var tmpcolor = colors[index];
            colors.RemoveAt(index);
            return tmpcolor;
        }

        private void GenerateColors()
        {
            var names = (KnownColor[])Enum.GetValues(typeof(KnownColor));

            foreach (var knownColor in names)
                colors.Add(Color.FromKnownColor(knownColor));
        }

        private void dataGridView_zadania_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if ((dataGridView.CurrentRow != null) && (dataGridView != null))
            {
                dataGridView.CurrentRow.HeaderCell.Value = String.Format("{0}", dataGridView.CurrentRow.Index + 1); ;

                //                if (generowanie)
                //                    btnStart.PerformClick();
            }
        }

        private void button_generateRndValues_Click(object sender, EventArgs e)
        {
            if (numericUpDown_max.Value < numericUpDown_min.Value)
            {
                MessageBox.Show("Błąd, pierwsze ograniczenie nie może być większe niż drugie :(", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dataGridView.Rows.Clear();

            //pi < di ≤ Ti
            var t = 0; var p = 0; var d = 0;

            var rnd = new Random();
            for (var i = 0; i < (int)numericUpDown_iloscZadan.Value; ++i)
            {
                t = rnd.Next((int)numericUpDown_min.Value, (int)numericUpDown_max.Value);
                d = rnd.Next(2, t);
                p = rnd.Next(1, d - 1);
                dataGridView.Rows.Add(new object[] { t.ToString(), p.ToString(), d.ToString() });
            }

            setRowNumber(dataGridView);
        }

        private void button_saveChart_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PNG Image|*.png";
            saveFileDialog1.Title = "Zapisz wykres Gantt'a jako plikPNG";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
                chart1.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Png);
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView.CurrentCell.Value != null)
            {
                CheckValues(e, true);
            }
            else
            {
                CheckValues(e,false);            
            }
        }

        private void CheckValues(DataGridViewCellEventArgs e, Boolean er)
        {
            if (!er)
                dataGridView.CurrentCell.Value = 0.ToString();

            var tVal = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            var dVal = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
            var pVal = Int32.Parse(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
            switch (e.ColumnIndex)
            {
                case 0:
                    if (tVal < dVal)
                    {
                        if(er)
                            MessageBox.Show(
                                "Błąd, T(i) nie może być większe od d(i) :(\nW złe pole zostanie wylosowana poprawna wartość",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView.CurrentCell.Value = new Random().Next(dVal, (int) numericUpDown_max.Value);
                    }
                    break;
                case 1:
                    if ((pVal >= dVal)
                        || (pVal < 1))
                    {
                        if (er)
                            MessageBox.Show(
                                "Błąd, musi być spełniony warunek: T(i) <= d(i) < p(i) :(\nW złe pole zostanie wylosowana poprawna wartość",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView.CurrentCell.Value = new Random().Next(1, dVal - 1);
                    }
                    break;
                case 2:
                    if ((!(tVal >= dVal))
                        || (dVal <= pVal))
                    {
                        if (er)
                            MessageBox.Show(
                                "Błąd, musi być spełniony warunek: T(i) <= d(i) < p(i) :(\nW złe pole zostanie wylosowana poprawna wartość",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView.CurrentCell.Value = new Random().Next(pVal + 1, tVal);
                    }
                    break;
            }
        }
    }
}
