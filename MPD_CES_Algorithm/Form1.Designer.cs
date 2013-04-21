namespace MPD_CES_Algorithm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_zadania = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chart_AlgoCES = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.numericUpDown_iloscZadan = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_saveChart = new System.Windows.Forms.Button();
            this.button_generateRndValues = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.T = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_zadania)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_AlgoCES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_iloscZadan)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView_zadania);
            this.groupBox1.Location = new System.Drawing.Point(459, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 254);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zadania";
            // 
            // dataGridView_zadania
            // 
            this.dataGridView_zadania.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_zadania.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_zadania.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.T,
            this.P,
            this.D});
            this.dataGridView_zadania.Location = new System.Drawing.Point(6, 19);
            this.dataGridView_zadania.Name = "dataGridView_zadania";
            this.dataGridView_zadania.Size = new System.Drawing.Size(195, 229);
            this.dataGridView_zadania.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.button_clear);
            this.groupBox2.Controls.Add(this.button_generateRndValues);
            this.groupBox2.Controls.Add(this.button_saveChart);
            this.groupBox2.Controls.Add(this.button_start);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.numericUpDown_iloscZadan);
            this.groupBox2.Location = new System.Drawing.Point(672, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 254);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opcje podstawowe";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chart_AlgoCES);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(441, 254);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Wykres";
            // 
            // chart_AlgoCES
            // 
            this.chart_AlgoCES.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart_AlgoCES.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_AlgoCES.Legends.Add(legend1);
            this.chart_AlgoCES.Location = new System.Drawing.Point(6, 19);
            this.chart_AlgoCES.Name = "chart_AlgoCES";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_AlgoCES.Series.Add(series1);
            this.chart_AlgoCES.Size = new System.Drawing.Size(429, 229);
            this.chart_AlgoCES.TabIndex = 0;
            this.chart_AlgoCES.Text = "chart1";
            // 
            // numericUpDown_iloscZadan
            // 
            this.numericUpDown_iloscZadan.Location = new System.Drawing.Point(95, 64);
            this.numericUpDown_iloscZadan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_iloscZadan.Name = "numericUpDown_iloscZadan";
            this.numericUpDown_iloscZadan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDown_iloscZadan.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_iloscZadan.TabIndex = 0;
            this.numericUpDown_iloscZadan.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ilość zadań:";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(6, 19);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(231, 39);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "Start algorytmu CES";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_saveChart
            // 
            this.button_saveChart.Location = new System.Drawing.Point(127, 107);
            this.button_saveChart.Name = "button_saveChart";
            this.button_saveChart.Size = new System.Drawing.Size(110, 23);
            this.button_saveChart.TabIndex = 0;
            this.button_saveChart.Text = "Zapisz wykres";
            this.button_saveChart.UseVisualStyleBackColor = true;
            // 
            // button_generateRndValues
            // 
            this.button_generateRndValues.Location = new System.Drawing.Point(6, 107);
            this.button_generateRndValues.Name = "button_generateRndValues";
            this.button_generateRndValues.Size = new System.Drawing.Size(116, 23);
            this.button_generateRndValues.TabIndex = 1;
            this.button_generateRndValues.Text = "Generuj wartości";
            this.button_generateRndValues.UseVisualStyleBackColor = true;
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(6, 136);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(231, 26);
            this.button_clear.TabIndex = 3;
            this.button_clear.Text = "Wyczyść";
            this.button_clear.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(219, 49);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.richTextBox1);
            this.groupBox4.Location = new System.Drawing.Point(6, 174);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(231, 74);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Szczegółowe wyniki";
            // 
            // T
            // 
            this.T.HeaderText = "T(i)";
            this.T.Name = "T";
            this.T.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.T.Width = 50;
            // 
            // P
            // 
            this.P.HeaderText = "p(i)";
            this.P.Name = "P";
            this.P.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.P.Width = 50;
            // 
            // D
            // 
            this.D.HeaderText = "d(i)";
            this.D.Name = "D";
            this.D.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.D.Width = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 278);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(943, 317);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_zadania)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_AlgoCES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_iloscZadan)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_zadania;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_AlgoCES;
        private System.Windows.Forms.Button button_generateRndValues;
        private System.Windows.Forms.Button button_saveChart;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_iloscZadan;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn T;
        private System.Windows.Forms.DataGridViewTextBoxColumn P;
        private System.Windows.Forms.DataGridViewTextBoxColumn D;
    }
}

