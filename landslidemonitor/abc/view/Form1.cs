using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using abc.UserControl;

namespace abc.view
{
    public partial class Form1 : Form
    {
        private Queue<double> dataQueue = new Queue<double>(300);

        private int curValue = 0;

        private Thread send;

        private int num = 5; //每次删除增加几个点

        public Form1()
        {
            InitializeComponent();
            InitChart();
            this.timer1.Start();


            label6.Text = "A山1号数据采集节点";
            label8.Text = "110.388281, 25.29177";
            thermometer2.Value = 92;
            label10.Text = "92%";
            temperatureControl1.Temperature = 20.5f;
            label13.Text = "20.5℃";
            thermometer1.Value = 53;
            label12.Text = "53kPa";
        }

        //十秒出一个波
        void StartMethod()
        {
            Thread.Sleep(1000);
            UpdateQueueValue1();
            send.Interrupt();
            //发短信
            //   SendMessage.GetHtmlFromUrl(SendMessage.url);
            //设定标注点，跳动
            //   BaiduMape.Mark_Click(110.292507, 25.253979, "一号信息采集终端");
        }

        /// <summary>
        /// 定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            UpdateQueueValue();

            this.chart1.Series[0].Points.Clear();
            this.chart2.Series[0].Points.Clear();
            this.chart3.Series[0].Points.Clear();

            for (int i = 0; i < dataQueue.Count; i++)
            {
                this.chart1.Series[0].Points.AddXY((i + 1), dataQueue.ElementAt(i));
                this.chart2.Series[0].Points.AddXY((i + 1), dataQueue.ElementAt(i));
                this.chart3.Series[0].Points.AddXY((i + 1), dataQueue.ElementAt(i));
            }
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
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;


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

        //更新队列中的值
        private void UpdateQueueValue()
        {
            if (dataQueue.Count > 300)
            {
                //先出列
                for (int i = 0; i < num; i++)
                {
                    dataQueue.Dequeue();
                }
            }

            Random r = new Random();
            for (int i = 0; i < num; i++)
            {
                dataQueue.Enqueue(r.Next(-15, 16));
            }
        }

        //更新队列中的值
        private void UpdateQueueValue1()
        {
            if (dataQueue.Count > 300)
            {
                //先出列
                for (int i = 0; i < num; i++)
                {
                    dataQueue.Dequeue();
                }
            }

            Random r = new Random();
            for (int i = 0; i < 25; i++)
            {
                if (i == 0)
                {
                    dataQueue.Enqueue(50);
                }
                else if (i == 1)
                {
                    dataQueue.Enqueue(-55);
                }
                else if (i == 2)
                {
                    dataQueue.Enqueue(75);
                }
                else if (i == 3)
                {
                    dataQueue.Enqueue(-75);
                }
                else if (i == 4)
                {
                    dataQueue.Enqueue(94);
                }
                else if (i == 5)
                {
                    dataQueue.Enqueue(-90);
                }
                else if (i == 6)
                {
                    dataQueue.Enqueue(79);
                }
                else if (i == 7)
                {
                    dataQueue.Enqueue(-82);
                }
                else if (i == 8)
                {
                    dataQueue.Enqueue(60);
                }
                else if (i == 9)
                {
                    dataQueue.Enqueue(-50);
                }
                else if (i == 10)
                {
                    dataQueue.Enqueue(48);
                }
                else if (i == 11)
                {
                    dataQueue.Enqueue(-35);
                }
                else if (i == 12)
                {
                    dataQueue.Enqueue(29);
                }
                else if (i == 13)
                {
                    dataQueue.Enqueue(-33);
                }
                else if (i == 14)
                {
                    dataQueue.Enqueue(30);
                }
                else if (i == 15)
                {
                    dataQueue.Enqueue(-35);
                }
                else if (i == 16)
                {
                    dataQueue.Enqueue(33);
                }
                else if (i == 17)
                {
                    dataQueue.Enqueue(-28);
                }
                else if (i == 18)
                {
                    dataQueue.Enqueue(27);
                }
                else if (i == 19)
                {
                    dataQueue.Enqueue(-26);
                }
                else if (i == 20)
                {
                    dataQueue.Enqueue(24);
                }
                else if (i == 21)
                {
                    dataQueue.Enqueue(-22);
                }
                else if (i == 22)
                {
                    dataQueue.Enqueue(21);
                }
                else if (i == 23)
                {
                    dataQueue.Enqueue(-19);
                }
                else if (i == 24)
                {
                    dataQueue.Enqueue(18);
                }
                else
                {
                    dataQueue.Enqueue(r.Next(-15, 15));
                }
            }
        }

        //停止按钮
        private void button2_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            if (send != null)
            {
                send.Interrupt();
            }
        }

        //开始按钮
        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //延时函数
            send = new Thread(new ThreadStart(StartMethod));
            send.Start();
        }
    }
}