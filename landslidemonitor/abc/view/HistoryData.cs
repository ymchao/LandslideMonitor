using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace abc.view
{
    public partial class HistoryData : Form
    {

        public HistoryData()
        {
            InitializeComponent();
            InitChart();

        }

        /// <summary>
        /// 初始化图表
        /// </summary>
        private void InitChart()
        {
            //定义图表char1区域
            this.chart1.ChartAreas.Clear();
            ChartArea chartArea1 = new ChartArea("C1");
            this.chart1.ChartAreas.Add(chartArea1);
            //定义存储和显示点的容器
            this.chart1.Series.Clear();
            Series series1 = new Series("S1");
            series1.ChartArea = "C1";
            this.chart1.Series.Add(series1);
            //设置图表显示样式
            this.chart1.ChartAreas[0].AxisY.Minimum = -100;
            this.chart1.ChartAreas[0].AxisY.Maximum = 100;
            this.chart1.ChartAreas[0].AxisY.Interval = 100;
            this.chart1.ChartAreas[0].AxisX.Interval = 5;
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Transparent;


            //设置标题
            this.chart1.Titles.Clear();
            this.chart1.Titles.Add("S01");
            this.chart1.Titles[0].ForeColor = Color.RoyalBlue;
            this.chart1.Titles[0].Font = new Font("Microsoft Sans Serif", 15F);
            //设置图表显示样式
            this.chart1.Series[0].Color = Color.RoyalBlue;
            this.chart1.Titles[0].Text = "X通道微震数据波形";
            this.chart1.Series[0].ChartType = SeriesChartType.Line;
            this.chart1.Series[0].Points.Clear();

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
            this.chart2.ChartAreas[0].AxisY.Minimum = -100;
            this.chart2.ChartAreas[0].AxisY.Maximum = 100;
            this.chart2.ChartAreas[0].AxisY.Interval = 100;
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
            this.chart2.Titles[0].Text = "Y通道微震数据波形";
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
            this.chart3.ChartAreas[0].AxisY.Minimum = -100;
            this.chart3.ChartAreas[0].AxisY.Maximum = 100;
            this.chart3.ChartAreas[0].AxisY.Interval = 100;
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
            this.chart3.Titles[0].Text = "Z通道微震数据波形";
            this.chart3.Series[0].ChartType = SeriesChartType.Line;
            this.chart3.Series[0].Points.Clear();
        }


        /// <summary>
        /// 打开历史数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "历史数据";
            ofd.Filter = "txt文件|*.txt|所有文件|*.*";

            double[] temp = new double[1000];
            int Len = 0;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                string strLine;

                while (sr.EndOfStream == false)
                {
                    strLine = sr.ReadLine();
                    temp[Len] = Convert.ToDouble(strLine);
                    Len++;
                }
                sr.Dispose();
                fs.Dispose();

                label6.Text = "A山1号数据采集节点";
                label7.Text = "2017年6月15日11点25分";
                label8.Text = "110.388281, 25.29177";
                thermometer2.Value = 98;
                label10.Text = "98%";
                temperatureControl1.Temperature = 19.5f;
                label13.Text = "19.5℃";
                thermometer1.Value = 59;
                label12.Text = "59kPa";

            }

            for (int pointIndex = 0; pointIndex < Len; pointIndex++)
            {
                chart1.Series[0].Points.AddY(temp[pointIndex]);
                chart2.Series[0].Points.AddY(temp[pointIndex]);
                chart3.Series[0].Points.AddY(temp[pointIndex]);
            }
        }
    }
}
