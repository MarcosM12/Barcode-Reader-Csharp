﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SS_OpenCV
{
    public partial class Project_Y : Form
    {
        public Project_Y(int[] array, int height)
        {
            InitializeComponent();
            DataPointCollection list1 = chart1.Series[0].Points;
            for (int i = 0; i < array.Length; i++)
            {
                list1.AddXY(i, array[i]);
            }
            chart1.Series[0].Color = Color.Gray;
            chart1.ChartAreas[0].AxisX.Maximum = height;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Title = "Height";
            chart1.ChartAreas[0].AxisY.Title = "Contagem";
            chart1.ResumeLayout();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
