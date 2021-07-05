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
        int errorcount = 0;
        int ERRORLIMIT = 5;
        private static int _TIMERINTERVAL = 5000; // ms
        public static int TIMERINTERVAL {  get { return _TIMERINTERVAL; } }

        int DEFAULTTIMEOUT = 3000; // ms


        TimeSpan tenminute = new System.TimeSpan(0, 0, 10, 0); // 10min
        TimeSpan fiveminute = new System.TimeSpan(0, 0, 5, 0); // 5min
        TimeSpan threeminute = new System.TimeSpan(0, 0, 3, 0); // 3min
        TimeSpan oneminute = new System.TimeSpan(0, 0, 1, 0); // 1min

        DateTime [] 골론시간= new DateTime[] {Convert.ToDateTime("06:00:00"), Convert.ToDateTime("12:00:00"),
            Convert.ToDateTime("18:00:00"), Convert.ToDateTime("23:59:59") }; // 24:00:00은 표현불가
        DateTime[] 골모답시간 = new DateTime[] {Convert.ToDateTime("05:00:00"), Convert.ToDateTime("13:00:00"),
            Convert.ToDateTime("21:00:00") };
        DateTime[] 아칸시간 = new DateTime[] {Convert.ToDateTime("14:30:00"), Convert.ToDateTime("21:30:00")};
        DateTime[] 스페르첸드시간 = new DateTime[] {Convert.ToDateTime("01:00:00"), Convert.ToDateTime("04:00:00"),
            Convert.ToDateTime("08:00:00"), Convert.ToDateTime("16:00:00"),
            Convert.ToDateTime("19:00:00"), Convert.ToDateTime("23:00:00") };
        DateTime[] 프라바방어전시간 = new DateTime[] {Convert.ToDateTime("02:00:00"), Convert.ToDateTime("04:00:00"),
            Convert.ToDateTime("06:00:00"), Convert.ToDateTime("08:00:00"),
            Convert.ToDateTime("10:00:00"), Convert.ToDateTime("12:00:00"),
            Convert.ToDateTime("14:00:00"), Convert.ToDateTime("16:00:00"),
            Convert.ToDateTime("18:00:00"), Convert.ToDateTime("20:00:00"),
            Convert.ToDateTime("22:00:00"), Convert.ToDateTime("23:59:59") };

        delegate void TimerInvoker();

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

            timer = new System.Timers.Timer(); 
            timer.Interval = _TIMERINTERVAL; // define timer with interval [ms]
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = !알림OffToolStripMenuItem.Checked; // start the timer
        }

        private void OnTimedEvent(Object sender, EventArgs e)
        {
            String[] AlarmTextArray = new String[toolStripMenuItem1.DropDownItems.Count];
            bool 시간10분전flag = 분전ToolStripMenuItem.Checked;
            bool 시간5분전flag = 분전ToolStripMenuItem1.Checked;
            bool 시간3분전flag = 분전ToolStripMenuItem2.Checked;
            bool 시간1분전flag = 분전ToolStripMenuItem3.Checked;
            DateTime currentTime = System.DateTime.Now;


            bool 골론flag = 골론061218시ToolStripMenuItem.Checked;
            bool 골모답flag = 베리넨루미골모답51321시ToolStripMenuItem.Checked;
            bool 아칸flag = 아크론요새아칸2시반9시반ToolStripMenuItem.Checked;
            bool 스페르첸드flag = 스페르첸드148161923시ToolStripMenuItem.Checked;
            bool 프라바방어전flag = 프라바방어전짝수시ToolStripMenuItem.Checked;

            if (골론flag) {
                for ( int i =0; i<골론시간.Length; i++)
                {
                    Console.WriteLine(i.ToString());
                    if (시간1분전flag)
                    {
                        if (isTimeToAlarm(currentTime, 골론시간[i], oneminute))
                        {
                            //AlarmTextArray[i] = "골론 1분 전!! 베리넨 루미로 가세요!";
                            notifyIcon1.ShowBalloonTip(DEFAULTTIMEOUT, "보스 알림",
                                String.Concat("골론 1분 전!! 베리넨 루미로 가세요!", Environment.NewLine,
                                "현재시각: ", System.DateTime.Now.ToString("tt h:mm:ss")),
                                ToolTipIcon.Info);
                        }
                    }
                    else if (시간3분전flag)
                    {
                        if (isTimeToAlarm(currentTime, 골론시간[i], threeminute))
                        {
                            AlarmTextArray[i] = "골론 3분 전!! 베리넨 루미로 가세요!";
                        }
                    }
                    else if (시간5분전flag)
                    {
                        if (isTimeToAlarm(currentTime, 골론시간[i], threeminute))
                        {
                            AlarmTextArray[i] = "골론 5분 전!! 베리넨 루미로 가세요!";
                        }
                    }
                    else if (시간10분전flag)
                    {
                        if (isTimeToAlarm(currentTime, 골론시간[i], threeminute))
                        {
                            AlarmTextArray[i] = "골론 10분 전!! 베리넨 루미로 가세요!";
                        }
                    }
                    else
                    {
                        notifyIcon1.ShowBalloonTip(DEFAULTTIMEOUT, "보스 알림",
                            String.Concat("골론 시간 아님", Environment.NewLine,
                            "현재시각: ", System.DateTime.Now.ToString("tt h:mm:ss")),
                            ToolTipIcon.Info);
                    }
                }
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
            timer.Enabled = false;
        }

        private void 골론061218시ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            골론061218시ToolStripMenuItem.Checked = !골론061218시ToolStripMenuItem.Checked;
            if (골론061218시ToolStripMenuItem.Checked)
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

        private void 베리넨루미골모답51321시ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 아크론요새아칸2시반9시반ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 스페르첸드148161923시ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 프라바방어전짝수시ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
