using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FieldBoss_alarm
{
    public partial class InfoWindow : Form
    {
        public InfoWindow()
        {
            InitializeComponent();
            var ver = Assembly.GetExecutingAssembly().GetName().Version;
            var versionString = string.Format("v{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
            label1.Text = String.Concat(
                "테일즈위버 필드보스 알림 ",versionString, Environment.NewLine,
                Environment.NewLine,
                "made by [네냐플] 듀움", Environment.NewLine,
                "e - mail: projecteli@kakao.com", Environment.NewLine, Environment.NewLine,
                "최신 버전 다운");

        }

        // Singleton Form to avoid multiple window
        // https://curesawa.tistory.com/entry/%ED%94%84%EB%A1%9C%ED%8D%BC%ED%8B%B0%EB%A5%BC-%EC%9D%B4%EC%9A%A9%ED%95%9C-%EB%8B%A8-%ED%95%98%EB%82%98%EC%9D%98-%ED%8F%BC-%EC%97%B4%EA%B8%B0%EC%8B%B1%EA%B8%80-%ED%86%A4-%EB%94%94%EC%9E%90%EC%9D%B8-%ED%8C%A8%ED%84%B4-%EC%A0%81%EC%9A%A9
        private static InfoWindow _instance; 

        public static InfoWindow Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new InfoWindow();
                }
                return _instance;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ProjectEli/FieldBoss_alarm/releases/latest");
        }

    }

}
