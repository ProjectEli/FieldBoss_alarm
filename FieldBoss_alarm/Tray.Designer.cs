﻿
namespace FieldBoss_alarm
{
    partial class Tray
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tray));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.골론ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.골모답ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.아칸ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.스페르첸드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.프라바방어전ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.타이머10분ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.타이머5분ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.타이머3분ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.타이머1분ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.알림OffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.샘플알림보기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.버전정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.윈도우시작시자동실행ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.파멸의기원ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.알림OffToolStripMenuItem,
            this.샘플알림보기ToolStripMenuItem,
            this.버전정보ToolStripMenuItem,
            this.윈도우시작시자동실행ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(203, 180);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.골론ToolStripMenuItem,
            this.골모답ToolStripMenuItem,
            this.아칸ToolStripMenuItem,
            this.스페르첸드ToolStripMenuItem,
            this.프라바방어전ToolStripMenuItem,
            this.파멸의기원ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem1.Text = "알림종류";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 골론ToolStripMenuItem
            // 
            this.골론ToolStripMenuItem.Checked = true;
            this.골론ToolStripMenuItem.CheckOnClick = true;
            this.골론ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.골론ToolStripMenuItem.Name = "골론ToolStripMenuItem";
            this.골론ToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.골론ToolStripMenuItem.Text = "베리넨 루미 골론(0,6,12,18시)";
            this.골론ToolStripMenuItem.Click += new System.EventHandler(this.골론ToolStripMenuItem_Click);
            // 
            // 골모답ToolStripMenuItem
            // 
            this.골모답ToolStripMenuItem.Checked = true;
            this.골모답ToolStripMenuItem.CheckOnClick = true;
            this.골모답ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.골모답ToolStripMenuItem.Name = "골모답ToolStripMenuItem";
            this.골모답ToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.골모답ToolStripMenuItem.Text = "베리넨 루미 골모답(5,13,21시)";
            this.골모답ToolStripMenuItem.Click += new System.EventHandler(this.골모답ToolStripMenuItem_Click);
            // 
            // 아칸ToolStripMenuItem
            // 
            this.아칸ToolStripMenuItem.Checked = true;
            this.아칸ToolStripMenuItem.CheckOnClick = true;
            this.아칸ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.아칸ToolStripMenuItem.Name = "아칸ToolStripMenuItem";
            this.아칸ToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.아칸ToolStripMenuItem.Text = "아크론 요새 아칸(2시반,9시반)";
            this.아칸ToolStripMenuItem.Click += new System.EventHandler(this.아칸ToolStripMenuItem_Click);
            // 
            // 스페르첸드ToolStripMenuItem
            // 
            this.스페르첸드ToolStripMenuItem.Checked = true;
            this.스페르첸드ToolStripMenuItem.CheckOnClick = true;
            this.스페르첸드ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.스페르첸드ToolStripMenuItem.Name = "스페르첸드ToolStripMenuItem";
            this.스페르첸드ToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.스페르첸드ToolStripMenuItem.Text = "아크론 지하요새 스페르첸드(1,4,8,16,19,23시)";
            this.스페르첸드ToolStripMenuItem.Click += new System.EventHandler(this.스페르첸드ToolStripMenuItem_Click);
            // 
            // 프라바방어전ToolStripMenuItem
            // 
            this.프라바방어전ToolStripMenuItem.Checked = true;
            this.프라바방어전ToolStripMenuItem.CheckOnClick = true;
            this.프라바방어전ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.프라바방어전ToolStripMenuItem.Name = "프라바방어전ToolStripMenuItem";
            this.프라바방어전ToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.프라바방어전ToolStripMenuItem.Text = "프라바 전초기지 프라바방어전(짝수시)";
            this.프라바방어전ToolStripMenuItem.Click += new System.EventHandler(this.프라바방어전ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.타이머10분ToolStripMenuItem,
            this.타이머5분ToolStripMenuItem,
            this.타이머3분ToolStripMenuItem,
            this.타이머1분ToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem2.Text = "알림시간";
            // 
            // 타이머10분ToolStripMenuItem
            // 
            this.타이머10분ToolStripMenuItem.Checked = true;
            this.타이머10분ToolStripMenuItem.CheckOnClick = true;
            this.타이머10분ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.타이머10분ToolStripMenuItem.Name = "타이머10분ToolStripMenuItem";
            this.타이머10분ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.타이머10분ToolStripMenuItem.Text = "10분전";
            this.타이머10분ToolStripMenuItem.Click += new System.EventHandler(this.타이머10분ToolStripMenuItem_Click);
            // 
            // 타이머5분ToolStripMenuItem
            // 
            this.타이머5분ToolStripMenuItem.CheckOnClick = true;
            this.타이머5분ToolStripMenuItem.Name = "타이머5분ToolStripMenuItem";
            this.타이머5분ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.타이머5분ToolStripMenuItem.Text = "5분전";
            this.타이머5분ToolStripMenuItem.Click += new System.EventHandler(this.타이머5분ToolStripMenuItem_Click);
            // 
            // 타이머3분ToolStripMenuItem
            // 
            this.타이머3분ToolStripMenuItem.Checked = true;
            this.타이머3분ToolStripMenuItem.CheckOnClick = true;
            this.타이머3분ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.타이머3분ToolStripMenuItem.Name = "타이머3분ToolStripMenuItem";
            this.타이머3분ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.타이머3분ToolStripMenuItem.Text = "3분전";
            this.타이머3분ToolStripMenuItem.Click += new System.EventHandler(this.타이머3분ToolStripMenuItem_Click);
            // 
            // 타이머1분ToolStripMenuItem
            // 
            this.타이머1분ToolStripMenuItem.Checked = true;
            this.타이머1분ToolStripMenuItem.CheckOnClick = true;
            this.타이머1분ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.타이머1분ToolStripMenuItem.Name = "타이머1분ToolStripMenuItem";
            this.타이머1분ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.타이머1분ToolStripMenuItem.Text = "1분전";
            this.타이머1분ToolStripMenuItem.Click += new System.EventHandler(this.타이머1분ToolStripMenuItem_Click);
            // 
            // 알림OffToolStripMenuItem
            // 
            this.알림OffToolStripMenuItem.CheckOnClick = true;
            this.알림OffToolStripMenuItem.Name = "알림OffToolStripMenuItem";
            this.알림OffToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.알림OffToolStripMenuItem.Text = "전체알림 일시정지";
            this.알림OffToolStripMenuItem.Click += new System.EventHandler(this.알림OffToolStripMenuItem_Click);
            // 
            // 샘플알림보기ToolStripMenuItem
            // 
            this.샘플알림보기ToolStripMenuItem.Name = "샘플알림보기ToolStripMenuItem";
            this.샘플알림보기ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.샘플알림보기ToolStripMenuItem.Text = "샘플 알림 보기";
            this.샘플알림보기ToolStripMenuItem.Click += new System.EventHandler(this.샘플알림보기ToolStripMenuItem_Click);
            // 
            // 버전정보ToolStripMenuItem
            // 
            this.버전정보ToolStripMenuItem.Name = "버전정보ToolStripMenuItem";
            this.버전정보ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.버전정보ToolStripMenuItem.Text = "버전정보";
            this.버전정보ToolStripMenuItem.Click += new System.EventHandler(this.버전정보ToolStripMenuItem_Click);
            // 
            // 윈도우시작시자동실행ToolStripMenuItem
            // 
            this.윈도우시작시자동실행ToolStripMenuItem.CheckOnClick = true;
            this.윈도우시작시자동실행ToolStripMenuItem.Name = "윈도우시작시자동실행ToolStripMenuItem";
            this.윈도우시작시자동실행ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.윈도우시작시자동실행ToolStripMenuItem.Text = "윈도우 시작시 자동실행";
            this.윈도우시작시자동실행ToolStripMenuItem.Click += new System.EventHandler(this.윈도우시작시자동실행ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "테일즈위버 필드보스 알림";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // 파멸의기원ToolStripMenuItem
            // 
            this.파멸의기원ToolStripMenuItem.Checked = true;
            this.파멸의기원ToolStripMenuItem.CheckOnClick = true;
            this.파멸의기원ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.파멸의기원ToolStripMenuItem.Name = "파멸의기원ToolStripMenuItem";
            this.파멸의기원ToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.파멸의기원ToolStripMenuItem.Text = "중앙군영 파멸의기원(00:30, 11시, 20시)";
            this.파멸의기원ToolStripMenuItem.Click += new System.EventHandler(this.파멸의기원StripMenuItem_Click);
            // 
            // Tray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 192);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tray";
            this.Text = "테일즈위버 필드보스 알림";
            this.Load += new System.EventHandler(this.Tray_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 알림OffToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 골론ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 타이머10분ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 타이머5분ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 타이머3분ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 타이머1분ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 골모답ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 아칸ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 스페르첸드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 프라바방어전ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 버전정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 샘플알림보기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 윈도우시작시자동실행ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파멸의기원ToolStripMenuItem;
    }
}

