using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using abc.UserControl;
using abc.view;
using Application = System.Windows.Application;

namespace abc
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private int monitorNumber;

        public event PropertyChangedEventHandler PropertyChanged;

        private Boolean change = true;

        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(0.5); //设置刷新的间隔时间
        }

        //A山一号触发器
        private void AAsensor_OnClick(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            onebutton.Background = new SolidColorBrush((Color) ColorConverter.ConvertFromString("#FF56CBFF"));
            Form a = new Form1();
            a.ShowDialog();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (change == true)
            {
                onebutton.Background = Brushes.Red;
                change = false;
            }
            else if (change == false)
            {
                onebutton.Background = Brushes.Lime;
                change = true;
            }
        }

        //系统设置按钮
        private void Setupbtn_OnClick(object sender, RoutedEventArgs e)
        {
            SetUp setUp = new SetUp();
            setUp.ShowDialog();
        }

        //传感器查询
        private void SensorQuery_OnClick(object sender, RoutedEventArgs e)
        {
            SensorQuery sensorQuery = new SensorQuery();
            sensorQuery.ShowDialog();
        }

        //A山信息
        private void Amountain_OnClick(object sender, RoutedEventArgs e)
        {
            //移动到A山
            BaiduMape.MovetoshanA(110.388281, 25.29177, 20);
            //列出A山传感器
            BaiduMape.Mark_Click(110.388281, 25.29177, "一号数据采集节点");
            BaiduMape.Mark_Click(110.389081, 25.29207, "二号数据采集节点");
            BaiduMape.Mark_Click(110.389381, 25.29217, "三号数据采集节点");
        }

        //B山信息
        private void Bmountain_OnClick(object sender, RoutedEventArgs e)
        {
            BaiduMape.MovetoshanB(110.293549, 25.2548, 19);
            //列出B山传感器
            BaiduMape.Mark_Click(110.292507, 25.253979, "一号数据采集终端");
            BaiduMape.Mark_Click(110.293028, 25.254151, "二号数据采集终端");
            BaiduMape.Mark_Click(110.291582, 25.25402, "三号数据采集终端");
            BaiduMape.Mark_Click(110.293854, 25.254534, "四号数据采集终端");
        }

        //发送预警短信
        private void SendMessage_OnClick(object sender, RoutedEventArgs e)
        {
            SendMessage sendMessage = new SendMessage();
            sendMessage.ShowDialog();
        }

        //隐藏按功能
        private void ButtonAChange_OnClick(object sender, RoutedEventArgs e)
        {
            //按钮闪动
            timer.Start();
            //移动到A山
            BaiduMape.MovetoshanA(110.388581, 25.29177, 20);
            //清除所有标点
            BaiduMape.Clear_Click2();
            //地图闪动
            BaiduMape.Mark_Click2(110.388281, 25.29177, "一号数据采集节点");
        }

        /// <summary>
        /// 现场图像查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenPicture_OnClick(object sender, RoutedEventArgs e)
        {
            string v_OpenFolderPath = @"C:\Users\machao\Documents\Visual Studio 2015\Projects\abc\Pictures";
            System.Diagnostics.Process.Start("explorer.exe", v_OpenFolderPath);
        }

        //历史数据查看
        private void OpenHistory_OnClick(object sender, RoutedEventArgs e)
        {
            HistoryData historyData = new HistoryData();
            historyData.Show();
        }

        //历史波形查看
        private void Historywave_OnClick(object sender, RoutedEventArgs e)
        {
            HistoryWave historyWave = new HistoryWave();
            historyWave.Show();
        }
    }
}