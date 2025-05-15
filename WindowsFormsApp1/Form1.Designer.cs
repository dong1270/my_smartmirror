namespace WindowsFormsApp1
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.today_temp = new System.Windows.Forms.Label();
            this.weather_icon = new System.Windows.Forms.Panel();
            this.weather_icon_des = new System.Windows.Forms.Label();
            this.position = new System.Windows.Forms.Label();
            this.celsius_text = new System.Windows.Forms.Label();
            this.weatherTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.weather_icon.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // today_temp
            // 
            this.today_temp.AutoSize = true;
            this.today_temp.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.today_temp.ForeColor = System.Drawing.SystemColors.Desktop;
            this.today_temp.Location = new System.Drawing.Point(43, 43);
            this.today_temp.Name = "today_temp";
            this.today_temp.Size = new System.Drawing.Size(107, 50);
            this.today_temp.TabIndex = 1;
            this.today_temp.Text = "TEST";
            this.today_temp.Click += new System.EventHandler(this.label1_Click);
            // 
            // weather_icon
            // 
            this.weather_icon.Controls.Add(this.weather_icon_des);
            this.weather_icon.Location = new System.Drawing.Point(41, 102);
            this.weather_icon.Name = "weather_icon";
            this.weather_icon.Size = new System.Drawing.Size(113, 108);
            this.weather_icon.TabIndex = 2;
            // 
            // weather_icon_des
            // 
            this.weather_icon_des.AutoSize = true;
            this.weather_icon_des.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.weather_icon_des.Location = new System.Drawing.Point(7, 44);
            this.weather_icon_des.Name = "weather_icon_des";
            this.weather_icon_des.Size = new System.Drawing.Size(96, 21);
            this.weather_icon_des.TabIndex = 0;
            this.weather_icon_des.Text = "날씨 아이콘";
            // 
            // position
            // 
            this.position.AutoSize = true;
            this.position.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.position.ForeColor = System.Drawing.SystemColors.Desktop;
            this.position.Location = new System.Drawing.Point(663, 52);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(94, 37);
            this.position.TabIndex = 3;
            this.position.Text = "label1";
            // 
            // celsius_text
            // 
            this.celsius_text.AutoSize = true;
            this.celsius_text.Font = new System.Drawing.Font("맑은 고딕", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.celsius_text.ForeColor = System.Drawing.SystemColors.Desktop;
            this.celsius_text.Location = new System.Drawing.Point(156, 42);
            this.celsius_text.Name = "celsius_text";
            this.celsius_text.Size = new System.Drawing.Size(57, 50);
            this.celsius_text.TabIndex = 4;
            this.celsius_text.Text = "℃";
            this.celsius_text.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // weatherTimer
            // 
            this.weatherTimer.Enabled = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.celsius_text);
            this.Controls.Add(this.position);
            this.Controls.Add(this.weather_icon);
            this.Controls.Add(this.today_temp);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.weather_icon.ResumeLayout(false);
            this.weather_icon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label today_temp;
        private System.Windows.Forms.Panel weather_icon;
        private System.Windows.Forms.Label weather_icon_des;
        private System.Windows.Forms.Label position;
        private System.Windows.Forms.Label celsius_text;
        private System.Windows.Forms.Timer weatherTimer;
    }
}

