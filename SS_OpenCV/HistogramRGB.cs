using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SS_OpenCV
{
    public partial class HistogramRGB : Form
    {
        public HistogramRGB(int [,] array)
        {
            InitializeComponent();

            DataPointCollection list1 = chart1.Series[0].Points;
            DataPointCollection list2 = chart1.Series[1].Points;
            DataPointCollection list3 = chart1.Series[2].Points;

            for (int i = 0; i < 256; i++)
            {
                list1.AddXY(i, array[0,i]);
                list2.AddXY(i, array[1,i]);
                list3.AddXY(i, array[2,i]);
            }

            chart1.Series[0].Color = Color.Blue;
            chart1.Series[1].Color = Color.Green;
            chart1.Series[2].Color = Color.Red;


            chart1.ChartAreas[0].AxisX.Maximum = 255;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Title = "Intensidade";
            chart1.ChartAreas[0].AxisY.Title = "Numero Pixeis";
            chart1.ResumeLayout();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void HistogramRGB_Load(object sender, EventArgs e)
        {

        }
    }
}
