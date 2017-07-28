using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace abc.view
{
    /// <summary>
    /// SensorSetUp.xaml 的交互逻辑
    /// </summary>
    public partial class SetUp : Window
    {
        public SetUp()
        {
            InitializeComponent();
        }

        private void ConnectCloud_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("连接云服务器成功！");
            this.Close();
        }

        private void OpenCom_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("打开串口成功！");
            this.Close();
        }
    }
}
