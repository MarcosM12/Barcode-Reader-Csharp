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
    public partial class HistogramAll : Form
    {
        public HistogramAll(int [] array,int [,] array2)
        {
            InitializeComponent();

            DataPointCollection listGray = chart1.Series[0].Points;
            DataPointCollection listBlue = chart1.Series[1].Points;
            DataPointCollection listGreen = chart1.Series[2].Points;
            DataPointCollection listRed = chart1.Series[3].Points;


            for (int i = 0; i < 256; i++)
            {
                listGray.AddXY(i, array[i]);
            }
            

            for (int i = 0; i < 256; i++)
            {
                listBlue.AddXY(i, array2[0, i]);
                listGreen.AddXY(i, array2[1, i]);
                listRed.AddXY(i, array2[2, i]);
            }

            chart1.Series[0].Color = Color.Gray;
            chart1.Series[1].Color = Color.Blue;
            chart1.Series[2].Color = Color.Green;
            chart1.Series[3].Color = Color.Red;


            chart1.ChartAreas[0].AxisX.Maximum = 255;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Title = "Intensidade";
            chart1.ChartAreas[0].AxisY.Title = "Numero Pixeis";
            chart1.ResumeLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
