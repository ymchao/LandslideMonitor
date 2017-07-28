using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using abc.Model;

namespace abc.view
{
    /// <summary>
    /// SetUp.xaml 的交互逻辑
    /// </summary>
    public partial class SensorQuery : Window
    {
        public SensorQuery()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<SensorInfo> list = new List<SensorInfo>();

            var image = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"\image");
            var battery1 = File.ReadAllBytes(image[0]);
            var battery2 = File.ReadAllBytes(image[1]);
            var battery3 = File.ReadAllBytes(image[2]);
            var status1 = File.ReadAllBytes(image[11]);
            var status2 = File.ReadAllBytes(image[13]);

            for (int i = 1; i < 16; i++)
            {
                if (i<=4)
                {
                    list.Add(new SensorInfo
                    {
                        Name =  i.ToString(),
                        StatusPhoto = status1,
                        BatteryPhoto = battery2,
                        Temperature = "23℃",
                        Dampness = "85%",
                        StorageStatus = "正常",
                        RemainStorage = 2 * i + 30 + "M",
                    });
                }

                if (i>4&&i<7)
                {
                    list.Add(new SensorInfo
                    {
                        Name =   i.ToString(),
                        StatusPhoto = status1,
                        BatteryPhoto = battery3,
                        Temperature = "23℃",
                        Dampness = "88%",
                        StorageStatus = "正常",
                        RemainStorage = 2 * i + 30 + "M",
                    });
                }

                if (i > 7 && i < 11)
                {
                    list.Add(new SensorInfo
                    {
                        Name = i.ToString(),
                        StatusPhoto = status2,
                        BatteryPhoto = battery3,
                        Temperature = "92℃",
                        Dampness = "15%",
                        StorageStatus = "故障",
                        RemainStorage = 2 * i + 30 + "M",
                    });
                }
                if (i > 11)
                {
                    list.Add(new SensorInfo
                    {
                        Name =  i.ToString(),
                        StatusPhoto = status1,
                        BatteryPhoto = battery1,
                        Temperature = "23℃",
                        Dampness = "91%",
                        StorageStatus = "正常",
                        RemainStorage = 2 * i + 30 + "M",
                    });
                }

            }
            DataGrid1.ItemsSource = list;
        }
    }
}