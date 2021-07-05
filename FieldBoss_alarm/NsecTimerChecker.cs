using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldBoss_alarm
{
    public class NsecTimerChecker
    {
        public NsecTimerChecker(String[] timeArray,int Nsec)
        {
            DateTime[] 시간목록 = new DateTime[timeArray.Length];
            for (int i=0; i<timeArray.Length; i++)
            {
                시간목록[i] = Convert.ToDateTime(timeArray);
            }
        }

        private bool isTimeToAlarm(DateTime currentTime, DateTime [] referenceTimes,TimeSpan NsecTimeSpan)
        {
            foreach (DateTime referenceTime in referenceTimes)
            {
                int offBeforeCurrentTime = DateTime.Compare(referenceTime.Subtract(NsecTimeSpan), currentTime.AddMilliseconds(-Tray.TIMERINTERVAL));
                int onAfterCurrentTime = DateTime.Compare(referenceTime.Subtract(NsecTimeSpan), currentTime);
                return offBeforeCurrentTime > 0 && onAfterCurrentTime <= 0;
            }
            return false; // 결국 못찾았을 때
        }
    }
}
