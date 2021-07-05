using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FieldBoss_alarm
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool flagMutex;
            Mutex m_hMutex = new Mutex(true, "테일즈위버 보스알림", out flagMutex);
            if (flagMutex)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Tray());
                m_hMutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("이미 트레이에서 실행중입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
