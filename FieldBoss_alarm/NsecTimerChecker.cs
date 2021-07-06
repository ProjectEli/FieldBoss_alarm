using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldBoss_alarm
{
    public class NsecTimerChecker
    {
        public static List<string> 골론시간 = new List<string>() { "06:00:00", "12:00:00", "18:00:00", "23:59:59" }; // 24:00:00은 표현불가
        public static List<string> 골모답시간 = new List<string>() { "05:00:00","13:00:00", "21:00:00" };
        public static List<string> 아칸시간 = new List<string>() { "14:30:00", "21:30:00" };
        public static List<string> 스페르첸드시간 = new List<string>() { "01:00:00", "04:00:00", "08:00:00", "16:00:00", "19:00:00", "23:00:00" };
        public static List<string> 프라바방어전시간 = new List<string>() { "02:00:00", "04:00:00", "06:00:00", "08:00:00", "10:00:00", "12:00:00",
                                                                         "14:00:00", "16:00:00", "18:00:00", "20:00:00", "22:00:00", "23:59:59"};
        private static List<DateTime> _골론시간 = DateTime변환(골론시간);
        private static List<DateTime> _골모답시간 = DateTime변환(골모답시간);
        private static List<DateTime> _아칸시간 = DateTime변환(아칸시간);
        private static List<DateTime> _스페르첸드시간 = DateTime변환(스페르첸드시간);
        private static List<DateTime> _프라바방어전시간 = DateTime변환(프라바방어전시간);

        public bool 골론알림Enabled;
        public bool 골모답알림Enabled;
        public bool 아칸알림Enabled;
        public bool 스페르첸드알림Enabled;
        public bool 프라바방어전알림Enabled;
        private TimeSpan NsecTimeSpan;
        public NsecTimerChecker(int Nsec)
        {
            Initialize(Nsec);
        }

        private void Initialize(int Nsec)
        {
            골론알림Enabled = Tray.골론enabled;
            골모답알림Enabled = Tray.골모답enabled;
            아칸알림Enabled = Tray.아칸enabled;
            스페르첸드알림Enabled = Tray.스페르첸드enabled;
            프라바방어전알림Enabled = Tray.프라바방어전enabled;

            this.NsecTimeSpan = TimeSpan.FromSeconds(Nsec);
        }

        public List<string> 알람문자열확인(DateTime currentTime)
        {
            List<string> 알람문자열 = new List<string>{ };
            if (골론알림Enabled && isTimeToAlarm(currentTime, _골론시간, this.NsecTimeSpan))
            {
                알람문자열.Add("[베리넨 루미] 골론 " + makeMMssString(this.NsecTimeSpan));
            }
            if (골모답알림Enabled && isTimeToAlarm(currentTime, _골모답시간, this.NsecTimeSpan))
            {
                알람문자열.Add("[베리넨 루미] 골모답 " + makeMMssString(this.NsecTimeSpan));
            }
            if (아칸알림Enabled && isTimeToAlarm(currentTime, _아칸시간, this.NsecTimeSpan))
            {
                알람문자열.Add("[아크론 요새] 아칸 " + makeMMssString(this.NsecTimeSpan));
            }
            if (스페르첸드알림Enabled && isTimeToAlarm(currentTime, _스페르첸드시간, this.NsecTimeSpan))
            {
                알람문자열.Add("[아크론 지하요새] 스페르첸드 " + makeMMssString(this.NsecTimeSpan));
            }
            if (프라바방어전알림Enabled && isTimeToAlarm(currentTime, _프라바방어전시간, this.NsecTimeSpan))
            {
                알람문자열.Add("[프라바 전초기지] 프라바 방어전 " + makeMMssString(this.NsecTimeSpan));
            }
            return 알람문자열;
        }

        public bool isTimeToAlarm(DateTime currentTime, List<DateTime> referenceTimes,TimeSpan NsecTimeSpan)
        {
            foreach (DateTime referenceTime in referenceTimes)
            {
                int offBeforeCurrentTime = DateTime.Compare(referenceTime.Subtract(NsecTimeSpan), currentTime.AddMilliseconds(-Tray.TIMERINTERVAL));
                int onAfterCurrentTime = DateTime.Compare(referenceTime.Subtract(NsecTimeSpan), currentTime);
                if (offBeforeCurrentTime > 0 && onAfterCurrentTime <= 0) { return true; }
            }
            return false; // 결국 못찾았을 때
        }

        public static List<DateTime> DateTime변환(List<string> strings)
        {
            return strings.Select(timestring => DateTime.Parse(timestring)).ToList();
        }

        private string makeMMssString(TimeSpan timespan)
        {
            return (timespan.ToString("%m") + "분 " + timespan.ToString("%s") + "초 전!!" + Environment.NewLine);
        }
    }
}
