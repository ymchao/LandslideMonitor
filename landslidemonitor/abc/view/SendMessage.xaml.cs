using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;

namespace abc.view
{
    /// <summary>
    /// SensorSetUp.xaml 的交互逻辑
    /// </summary>
    public partial class SendMessage : Window
    {

        //        public static string PostUrl = "http://106.ihuyi.com/webservice/sms.php?method=Submit";
        //        public static string mobile;
        //        public static string content;
        //
        public SendMessage()
        {
            InitializeComponent();
        }

//        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
//        {
//            mobile = phoneTextBox + "," + phoneTextBox2;//手机号码，多个号码请用,隔开
//            content = messageTextBox.Text + "            【滑坡监测系统】";
//        }


        //public static void Sendmessage()
        //  {
        //      string account = "18977334332";//用户名是登录ihuyi.com账号名（例如：cf_demo123）
        //      string password = "e7c3a6ce46d5f4a7675d6efa94dca99c"; //请登录用户中心->验证码、通知短信->帐户及签名设置->APIKEY

        //      string postStrTpl = "account={0}&password={1}&mobile={2}&content={3}";

        //      UTF8Encoding encoding = new UTF8Encoding();
        //      byte[] postData = encoding.GetBytes(string.Format(postStrTpl, account, password, mobile, content));

        //      HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
        //      myRequest.Method = "POST";
        //      myRequest.ContentType = "application/x-www-form-urlencoded";
        //      myRequest.ContentLength = postData.Length;

        //      Stream newStream = myRequest.GetRequestStream();
        //      // Send the data.
        //      newStream.Write(postData, 0, postData.Length);
        //      newStream.Flush();
        //      newStream.Close();

        //      HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
        //      if (myResponse.StatusCode == HttpStatusCode.OK)
        //      {
        //          //                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
        //          //
        //          //                string res = reader.ReadToEnd();
        //          //                //Response.Write(res);
        //          //                int len1 = res.IndexOf("</code>");
        //          //                int len2 = res.IndexOf("<code>");
        //          //                string code = res.Substring((len2 + 6), (len1 - len2 - 6));
        //          //                System.Web.HttpContext.Current.Response.Write(code);
        //          //                int len3 = res.IndexOf("</msg>");
        //          //                int len4 = res.IndexOf("<msg>");
        //          //                string msg = res.Substring((len4 + 5), (len3 - len4 - 5));
        //          //                System.Web.HttpContext.Current.Response.Write(msg);
        //          //                System.Web.HttpContext.Current.Response.End();
        //                     }
        //                      else
        //                      {
        //              //访问失败
        //          }
        //      }


















        public static string url = "http://utf8.sms.webchinese.cn/?";
        private string strUid = "Uid=18589941336";
        private string strKey = "&key=a0d2d4c19022018e4475"; //这里*代表秘钥，由于从长有点麻烦，就不在窗口上输入了

        //18589941336
        //a0d2d4c19022018e4475

        //八月照相馆cc
        //4f6844ca9f21cccf00ea

        private string strMob = "&smsMob=";
        private string strContent = "&smsText=";
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (messageTextBox.Text.Trim() != "" && phoneTextBox.Text.Trim() != "" && phoneTextBox2.Text != null)
            {
                url = url + strUid + strKey + strMob + phoneTextBox.Text + strContent + messageTextBox.Text;
                MessageBox.Show("设置成功！");

            }
        }

        public static string GetHtmlFromUrl(string url)
        {
            string strRet = null;
            if (url == null || url.Trim() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch (Exception)
            {
                strRet = null;
            }
            return strRet;
        }


    }
}