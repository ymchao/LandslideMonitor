using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace abc.view
{
    public partial class HistoryWave : Form
    {
        public HistoryWave()
        {
            InitializeComponent();
            InitChart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            for (int i = 0; i < 62; i++)
            {
                chart1.Series[0].Points.AddY(r.Next(-25,25));
                chart1.Series[1].Points.AddY(r.Next(-25, 25));
                chart3.Series[0].Points.AddY(r.Next(50, 55));
            }

            List<double> list5 = new List<double>();
            for (int i = 0; i < 20; i++)
            {
                list5.Add(r.Next(-50, 25));
            }
            for (int i = 20; i < 40; i++)
            {
                list5.Add(r.Next(-100, -50));
            }
            for (int i = 40; i < 62; i++)
            {
                list5.Add(r.Next(-200, -100));
            }
            for (int i = 0; i < 62; i++)
            {
                chart1.Series[2].Points.AddY(list5[i]);
            }



            List<double> list = new List<double>();
            for (int i = 0; i <20 ; i++)
            {
                list.Add(r.Next(90,95));
            }
            for (int i = 20; i < 40; i++)
            {
                list.Add(r.Next(80, 85));
            }
            for (int i = 40; i < 62; i++)
            {
                list.Add(r.Next(90, 95));
            }
            for (int i = 0; i < 62; i++)
            {
                chart2.Series[0].Points.AddY(list[i]);
            }

            List<double> list2 = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                list2.Add(r.Next(10,15));
            }
            for (int i = 10; i < 40; i++)
            {
                list2.Add(r.Next(18, 25));
            }
            for (int i = 40; i < 62; i++)
            {
                list2.Add(r.Next(10, 15));
            }
            for (int i = 0; i < 62; i++)
            {
                chart4.Series[0].Points.AddY(list2[i]);
            }

        }


        /// <summary>
        /// 初始化图表
        /// </summary>
        private void InitChart()
        {
            //定义图表char1区域
            this.chart1.ChartAreas.Clear();
            ChartArea ChartArea1 = new ChartArea("ChartArea1");
            this.chart1.ChartAreas.Add(ChartArea1);

            
            
            //定义存储和显示点的容器
            this.chart1.Series.Clear();
            Series series1 = new Series("X轴方向");
            series1.ChartArea = "ChartArea1";
            this.chart1.Series.Add(series1);


            Series s2 = new Series("Y轴方向");
            s2.ChartArea = "ChartArea1";
            this.chart1.Series.Add(s2);

            Series s3 = new Series("垂直方向");
            s3.ChartArea = "ChartArea1";
            this.chart1.Series.Add(s3);

            //设置图表显示样式
            this.chart1.ChartAreas[0].AxisY.Minimum = -500;
            this.chart1.ChartAreas[0].AxisY.Maximum = 500;
            this.chart1.ChartAreas[0].AxisY.Interval = 100;
            this.chart1.ChartAreas[0].AxisX.Interval = 5;
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            //设置标题
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("S01");
            this.chart1.Titles[0].ForeColor = Color.RoyalBlue;
            this.chart1.Titles[0].Font = new Font("Microsoft Sans Serif", 15F);
            //设置图表显示样式
            this.chart1.Titles[0].Text = "GPS偏移趋势图";

            this.chart1.Series[0].Color = Color.RoyalBlue;
            this.chart1.Series[0].ChartType = SeriesChartType.Line;
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[2].Legend = "Legend1";


            this.chart1.Series[1].Color = Color.DarkRed;
            this.chart1.Series[1].ChartType = SeriesChartType.Line;
            this.chart1.Series[1].Points.Clear();
            this.chart1.Series[2].Legend = "Legend2";


            this.chart1.Series[2].Color = Color.Gold;
            this.chart1.Series[2].ChartType = SeriesChartType.Line;
            this.chart1.Series[2].Points.Clear();
            this.chart1.Series[2].Legend = "Legend3";




            //定义图表char2区域
            this.chart2.ChartAreas.Clear();
            ChartArea chartArea2 = new ChartArea("C1");
            this.chart2.ChartAreas.Add(chartArea2);
            //定义存储和显示点的容器
            this.chart2.Series.Clear();
            Series series2 = new Series("S1");
            series2.ChartArea = "C1";
            this.chart2.Series.Add(series2);
            //设置图表显示样式
            this.chart2.ChartAreas[0].AxisY.Minimum = 0;
            this.chart2.ChartAreas[0].AxisY.Maximum = 100;
            this.chart2.ChartAreas[0].AxisY.Interval = 10;
            this.chart2.ChartAreas[0].AxisX.Interval = 5;
            this.chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
            this.chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Transparent;
            //设置标题
            this.chart2.Titles.Clear();
            this.chart2.Titles.Add("S01");
            this.chart2.Titles[0].ForeColor = Color.Magenta;
            this.chart2.Titles[0].Font = new Font("Microsoft Sans Serif", 15F);
            //设置图表显示样式
            this.chart2.Series[0].Color = Color.Magenta;
            this.chart2.Titles[0].Text = "土壤湿度趋势图";
            this.chart2.Series[0].ChartType = SeriesChartType.Line;
            this.chart2.Series[0].Points.Clear();

            //定义图表char3区域
            this.chart3.ChartAreas.Clear();
            ChartArea chartArea3 = new ChartArea("C1");
            this.chart3.ChartAreas.Add(chartArea3);
            //定义存储和显示点的容器
            this.chart3.Series.Clear();
            Series series3 = new Series("S1");
            series3.ChartArea = "C1";
            this.chart3.Series.Add(series3);
            //设置图表显示样式
            this.chart3.ChartAreas[0].AxisY.Minimum = 0;
            this.chart3.ChartAreas[0].AxisY.Maximum = 100;
            this.chart3.ChartAreas[0].AxisY.Interval = 10;
            this.chart3.ChartAreas[0].AxisX.Interval = 5;
            this.chart3.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
            this.chart3.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Transparent;
            //设置标题
            this.chart3.Titles.Clear();
            this.chart3.Titles.Add("S01");
            this.chart3.Titles[0].ForeColor = Color.ForestGreen;
            this.chart3.Titles[0].Font = new Font("Microsoft Sans Serif", 15F);
            //设置图表显示样式
            this.chart3.Series[0].Color = Color.ForestGreen;
            this.chart3.Titles[0].Text = "土壤压力趋势图";
            this.chart3.Series[0].ChartType = SeriesChartType.Line;
            this.chart3.Series[0].Points.Clear();

            //定义图表char4区域
            this.chart4.ChartAreas.Clear();
            ChartArea chartArea4 = new ChartArea("C1");
            this.chart4.ChartAreas.Add(chartArea4);
            //定义存储和显示点的容器
            this.chart4.Series.Clear();
            Series series4 = new Series("S1");
            series4.ChartArea = "C1";
            this.chart4.Series.Add(series4);
            //设置图表显示样式
            this.chart4.ChartAreas[0].AxisY.Minimum = -10;
            this.chart4.ChartAreas[0].AxisY.Maximum = 50;
            this.chart4.ChartAreas[0].AxisY.Interval = 10;
            this.chart4.ChartAreas[0].AxisX.Interval = 5;
            this.chart4.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
            this.chart4.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Transparent;
            //设置标题
            this.chart4.Titles.Clear();
            this.chart4.Titles.Add("S01");
            this.chart4.Titles[0].ForeColor = Color.OrangeRed;
            this.chart4.Titles[0].Font = new Font("Microsoft Sans Serif", 15F);
            //设置图表显示样式
            this.chart4.Series[0].Color = Color.OrangeRed;
            this.chart4.Titles[0].Text = "土壤温度趋势图";
            this.chart4.Series[0].ChartType = SeriesChartType.Line;
            this.chart4.Series[0].Points.Clear();
        }

      
    }
}