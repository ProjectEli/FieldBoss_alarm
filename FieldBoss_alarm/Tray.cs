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
            UpdateBossEnabled(timerChecker10분);
            UpdateBossEnabled(timerChecker5분);
            UpdateBossEnabled(timerChecker3분);
            UpdateBossEnabled(timerChecker1분);

            DateTime currentTime = System.DateTime.UtcNow;
            currentTime= currentTime.AddHours(9);
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
        
        private void UpdateBossEnabled(NsecTimerChecker timerChecker)
        {
            timerChecker.골론알림Enabled = 골론enabled;
            timerChecker.골모답알림Enabled = 골모답enabled;
            timerChecker.아칸알림Enabled = 아칸enabled;
            timerChecker.스페르첸드알림Enabled = 스페르첸드enabled;
            timerChecker.프라바방어전알림Enabled = 프라바방어전enabled;
        }

        private void Tray_Load(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!InfoWindow.Instance.Visible)
            {
                InfoWindow.Instance.ShowDialog();
                InfoWindow.Instance.Activate();
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
            // 골론ToolStripMenuItem.Checked = !골론ToolStripMenuItem.Checked; // 아예 메뉴 아이템 속성에 클릭하면 체크되게 넣어버렸음
            if (골론ToolStripMenuItem.Checked)
            {
                알림표시("골론", "[베리넨 루미] 골론", true);
            }
            else
            {
                알림표시("골론", "[베리넨 루미] 골론", false);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 골모답ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (골모답ToolStripMenuItem.Checked)
            {
                알림표시("골모답", "[베리넨 루미] 골모답", true);
            }
            else
            {
                알림표시("골모답", "[베리넨 루미] 골모답", false);
            }
        }

        private void 아칸ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (아칸ToolStripMenuItem.Checked)
            {
                알림표시("아칸", "[아크론 요새] 아칸", true);
            }
            else
            {
                알림표시("아칸", "[아크론 요새] 아칸", false);
            }
        }

        private void 스페르첸드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (스페르첸드ToolStripMenuItem.Checked)
            {
                알림표시("스페르첸드", "[아크론 지하요새] 스페르첸드", true);
            }
            else
            {
                알림표시("스페르첸드", "[아크론 지하요새] 스페르첸드", false);
            }
        }

        private void 프라바방어전ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (프라바방어전ToolStripMenuItem.Checked)
            {
                알림표시("프라바방어전", "[프라바 전초기지] 프라바방어전", true);
            }
            else
            {
                알림표시("프라바방어전", "[프라바 전초기지] 프라바방어전", false);
            }
        }

        private void 알림표시(string bossName, string bossString, bool 실행flag)
        {
            string 실행string;
            if (실행flag) { 실행string = "실행"; }
            else { 실행string = "해제"; }

            notifyIcon1.ShowBalloonTip(DEFAULTTIMEOUT, bossName + " 알림",
                String.Concat(bossString, " 알림이 ", 실행string, "되었습니다.", Environment.NewLine,
                "현재시각: ", System.DateTime.Now.ToString("tt h:mm:ss")),
                ToolTipIcon.Info);
        }

        private void 타이머10분ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            타이머10분enabled = 타이머10분ToolStripMenuItem.Checked;
            if (타이머10분ToolStripMenuItem.Checked)
            {
                알림표시("시간 설정", "10분 전", true);
            }
            else
            {
                알림표시("시간 설정", "10분 전", false);
            }
        }

        private void 타이머5분ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            타이머5분enabled = 타이머5분ToolStripMenuItem.Checked;
            if (타이머5분ToolStripMenuItem.Checked)
            {
                알림표시("시간 설정", "5분 전", true);
            }
            else
            {
                알림표시("시간 설정", "5분 전", false);
            }
        }

        private void 타이머3분ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            타이머3분enabled = 타이머3분ToolStripMenuItem.Checked;
            if (타이머3분ToolStripMenuItem.Checked)
            {
                알림표시("시간 설정", "3분 전", true);
            }
            else
            {
                알림표시("시간 설정", "3분 전", false);
            }
        }

        private void 타이머1분ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            타이머1분enabled = 타이머1분ToolStripMenuItem.Checked;
            if (타이머1분ToolStripMenuItem.Checked)
            {
                알림표시("시간 설정", "1분 전", true);
            }
            else
            {
                알림표시("시간 설정", "1분 전", false);
            }
        }

        private void 버전정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!InfoWindow.Instance.Visible)
            {
                InfoWindow.Instance.ShowDialog();
                InfoWindow.Instance.Activate();
            }
            else
            {
                InfoWindow.Instance.Activate();
            }
        }

        private void 샘플알림보기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(DEFAULTTIMEOUT, "(샘플) 골론 알림",
                String.Concat("[베리넨 루미] 골론 10분 0초 전!!", Environment.NewLine,
                "현재시각: ", System.DateTime.Now.ToString("tt h:mm:ss")),
                ToolTipIcon.Info);
        }

        private void 윈도우시작시자동실행ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (윈도우시작시자동실행ToolStripMenuItem.Checked)
            {
                시작프로그램등록("TW_FieldBoss_Alarm", Application.ExecutablePath);
            }
            else
            {
                시작프로그램등록해제("TW_FieldBoss_Alarm", Application.ExecutablePath);
            }
        }

        private void 시작프로그램등록해제(string programName, string executablePath)
        {
            using (var regKey = GetRegKey(_startupRegPath, true))
            {
                try
                {
                    if (regKey.GetValue(programName) != null)
                    {
                        regKey.DeleteValue(programName,false);
                    }
                    regKey.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static readonly string _startupRegPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private Microsoft.Win32.RegistryKey GetRegKey(string regPath, bool writable)
        {
            return Microsoft.Win32.Registry.CurrentUser.OpenSubKey(regPath, writable);
        }
        private void 시작프로그램등록(string programName, string executablePath)
        {
            using (var regKey = GetRegKey(_startupRegPath, true))
            {
                try
                {
                    if (regKey.GetValue(programName) == null)
                    {
                        regKey.SetValue(programName, executablePath);
                    }
                    regKey.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
