using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FieldBoss_alarm
{
    public partial class Tray : Form
    {
        private System.Timers.Timer timer;
        private NsecTimerChecker timerChecker10분;
        private NsecTimerChecker timerChecker5분;
        private NsecTimerChecker timerChecker3분;
        private NsecTimerChecker timerChecker1분;
        int errorcount = 0;
        int ERRORLIMIT = 5;
        private static int _TIMERINTERVAL = 5000; // ms
        public static int TIMERINTERVAL {  get { return _TIMERINTERVAL; } }

        private int DEFAULTTIMEOUT = 3000; // ms

        delegate void TimerInvoker();

        public static bool 골론enabled;
        public static bool 골모답enabled;
        public static bool 아칸enabled;
        public static bool 스페르첸드enabled;
        public static bool 프라바방어전enabled;

        public static bool 타이머10분enabled;
        public static bool 타이머5분enabled;
        public static bool 타이머3분enabled;
        public static bool 타이머1분enabled;


        public Tray()
        {
            InitializeComponent();
            StartAlarmSequence();
        }

        private void StartAlarmSequence()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Visible = false;

            notifyIcon1.Visible = true;
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.ShowBalloonTip(DEFAULTTIMEOUT, "실행 확인", "필드보스 알람 예약이 실행되었습니다.", ToolTipIcon.Info);

            골론enabled = 골론ToolStripMenuItem.Checked;
            골모답enabled = 골모답ToolStripMenuItem.Checked;
            아칸enabled = 아칸ToolStripMenuItem.Checked;
            스페르첸드enabled = 스페르첸드ToolStripMenuItem.Checked;
            프라바방어전enabled = 프라바방어전ToolStripMenuItem.Checked;

            타이머10분enabled = 타이머10분ToolStripMenuItem.Checked;
            타이머5분enabled = 타이머5분ToolStripMenuItem.Checked;
            타이머3분enabled = 타이머3분ToolStripMenuItem.Checked;
            타이머1분enabled = 타이머1분ToolStripMenuItem.Checked;

            timer = new System.Timers.Timer(); 
            timer.Interval = _TIMERINTERVAL; // define timer with interval [ms]
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = !알림OffToolStripMenuItem.Checked; // start the timer

            timerChecker10분 = new NsecTimerChecker(600);
            timerChecker5분 = new NsecTimerChecker(300);
            timerChecker3분 = new NsecTimerChecker(180);
            timerChecker1분 = new NsecTimerChecker(60);
        }

        private void OnTimedEvent(Object sender, EventArgs e)
        {
            String[] AlarmTextArray = new String[toolStripMenuItem1.DropDownItems.Count];
            DateTime currentTime = System.DateTime.Now;
            string 알람문자열종합 = "";
            if (타이머1분enabled)
            {
                알람문자열종합 += String.Join(Environment.NewLine, timerChecker1분.알람문자열확인(currentTime));
            }
            if (타이머3분enabled)
            {
                알람문자열종합 += String.Join(Environment.NewLine, timerChecker3분.알람문자열확인(currentTime));
            }
            if (타이머5분enabled)
            {
                알람문자열종합 += String.Join(Environment.NewLine, timerChecker5분.알람문자열확인(currentTime));
            }
            if (타이머10분enabled)
            {
                알람문자열종합 += String.Join(Environment.NewLine, timerChecker10분.알람문자열확인(currentTime));
            }
            if (! String.IsNullOrEmpty(알람문자열종합))
            {
                notifyIcon1.ShowBalloonTip(DEFAULTTIMEOUT, "보스 알림",
                    "현재시각: " + System.DateTime.Now.ToString("tt h:mm:ss") + Environment.NewLine + 알람문자열종합,ToolTipIcon.Info);
            }
        }

        private void Tray_Load(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!InfoWindow.Instance.Visible)
            {
                InfoWindow.Instance.ShowDialog();
            }
            else
            {
                InfoWindow.Instance.Activate();
            }
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 알림OffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = !알림OffToolStripMenuItem.Checked;
            if (timer.Enabled)
            {
                notifyIcon1.ShowBalloonTip(DEFAULTTIMEOUT, "필드보스 알림 재개", "모든 알림이 다시 정상 작동합니다.", ToolTipIcon.Info);
            }
            else
            {
                notifyIcon1.ShowBalloonTip(DEFAULTTIMEOUT, "필드보스 알림 일시중지", "모든 알림이 일시중지되었습니다.", ToolTipIcon.Info);
            }

        }

        private void 골론ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            골론ToolStripMenuItem.Checked = !골론ToolStripMenuItem.Checked;
            if (골론ToolStripMenuItem.Checked)
            {
                notifyIcon1.ShowBalloonTip(DEFAULTTIMEOUT, "골론 알림",
                String.Concat("베리넨 루미 골론 알림이 실행되었습니다.", Environment.NewLine,
                "현재시각: ", System.DateTime.Now.ToString("tt h:mm:ss")),
                ToolTipIcon.Info);
            }
            else
            {
                notifyIcon1.ShowBalloonTip(DEFAULTTIMEOUT, "골론 알림",
                String.Concat("베리넨 루미 골론 알림이 해제되었습니다.", Environment.NewLine,
                "현재시각: ", System.DateTime.Now.ToString("tt h:mm:ss")),
                ToolTipIcon.Info);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 골모답ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 아칸ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 스페르첸드ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 프라바방어전ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
