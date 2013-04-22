using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPD_CES_Algorithm
{
    public partial class Form1 : Form
    {
        private Int32 UID = 0;
        public Form1()
        {
            InitializeComponent();

            GenerujWartosciPoczatkowe();
        }

        private void GenerujWartosciPoczatkowe()
        {
            dataGridView.Rows.Add(new object[] { "1", "2", "3" });
            dataGridView.Rows.Add(new object[] { "2", "3", "4" });
            dataGridView.Rows.Add(new object[] { "1", "4", "6" });

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
            for (var i = 0; i < (int) numericUpDown_iloscZadan.Value; ++i)
            {
                t = rnd.Next((int)numericUpDown_min.Value, (int)numericUpDown_max.Value);
                d = rnd.Next(2, t);
                p = rnd.Next(1, d - 1);
                dataGridView.Rows.Add(new object[] { t.ToString(), p.ToString(), d.ToString() });
            }

            setRowNumber(dataGridView);
        }

        private void dataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            
        }
    }
}
