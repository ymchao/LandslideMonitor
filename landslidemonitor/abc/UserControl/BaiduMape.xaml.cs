using System;
using System.Windows;

namespace abc.UserControl
{
    /// <summary>
    /// BaiduMape.xaml 的交互逻辑
    /// </summary>
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class BaiduMape : System.Windows.Controls.UserControl
    {
        private static System.Windows.Forms.WebBrowser webBrowser = new System.Windows.Forms.WebBrowser();

        public BaiduMape()
        {
            InitializeComponent();
            this.host.Child = webBrowser;
            webBrowser.Navigate(new Uri(Environment.CurrentDirectory + @"/BMap.html", UriKind.RelativeOrAbsolute));
            //获取根目录的日历文件  

            this.Loaded += (s, e) => { webBrowser.ObjectForScripting = this; };
        }

        private void Move_Click(object sender, RoutedEventArgs e)
        {
            object[] objs = new object[2]
            {
                double.Parse(this.jin.Text),
                double.Parse(this.wei.Text)
            };
            webBrowser.Document.InvokeScript("MoveToPoint", objs);
        }

        //给定坐标A山
        public static void MovetoshanA(double a, double b, double c)
        {
            object[] objs = new object[3] {a, b, c};
            webBrowser.Document.InvokeScript("setSize", objs);
        }

        //给定坐标B山
        public static void MovetoshanB(double a, double b, int c)
        {
            object[] objs = new object[3] {a, b, c};
            webBrowser.Document.InvokeScript("setSize", objs);
        }


        private void Mark_Click(object sender, RoutedEventArgs e)
        {
            object[] objs = new object[2]
            {
                double.Parse(this.jin.Text),
                double.Parse(this.wei.Text)
            };
            webBrowser.Document.InvokeScript("addMarker", objs);
        }

        public static void Mark_Click(double a, double b, string c)
        {
            object[] objs = new object[4] {a, b,null, c};
            webBrowser.Document.InvokeScript("addMarker2", objs);
        }

        public static void Mark_Click2(double a, double b, string c)
        {
            object[] objs = new object[4] { a, b, null, c };
            webBrowser.Document.InvokeScript("addMarker3", objs);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            webBrowser.Document.InvokeScript("removeOverlay", null);
        }

        public static void Clear_Click2()
        {
            webBrowser.Document.InvokeScript("removeOverlay", null);
        }
    }
}