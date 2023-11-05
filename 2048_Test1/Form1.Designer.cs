namespace _2048_Test1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.Count_lbl = new System.Windows.Forms.Label();
            this.Time_lbl = new System.Windows.Forms.Label();
            this.pnl_2048 = new System.Windows.Forms.Panel();
            this.btn_RollUp = new System.Windows.Forms.Panel();
            this.btn_deincrease = new System.Windows.Forms.Panel();
            this.btn_Exit = new System.Windows.Forms.Panel();
            this.picBox1 = new System.Windows.Forms.PictureBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.highscoreLbl = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.Count_lbl);
            this.panel4.Controls.Add(this.Time_lbl);
            this.panel4.Controls.Add(this.pnl_2048);
            this.panel4.Controls.Add(this.btn_RollUp);
            this.panel4.Controls.Add(this.btn_deincrease);
            this.panel4.Controls.Add(this.btn_Exit);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(650, 45);
            this.panel4.TabIndex = 1;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseDown);
            this.panel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseMove);
            this.panel4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel4_MouseUp);
            // 
            // Count_lbl
            // 
            this.Count_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Count_lbl.AutoSize = true;
            this.Count_lbl.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Count_lbl.Location = new System.Drawing.Point(198, 11);
            this.Count_lbl.Margin = new System.Windows.Forms.Padding(0, 11, 51, 11);
            this.Count_lbl.Name = "Count_lbl";
            this.Count_lbl.Size = new System.Drawing.Size(65, 23);
            this.Count_lbl.TabIndex = 4;
            this.Count_lbl.Text = "Счёт: 0";
            this.Count_lbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Count_lbl_MouseDown);
            this.Count_lbl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Count_lbl_MouseMove);
            this.Count_lbl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Count_lbl_MouseUp);
            // 
            // Time_lbl
            // 
            this.Time_lbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Time_lbl.AutoSize = true;
            this.Time_lbl.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Time_lbl.Location = new System.Drawing.Point(332, 11);
            this.Time_lbl.Margin = new System.Windows.Forms.Padding(0, 11, 5, 11);
            this.Time_lbl.Name = "Time_lbl";
            this.Time_lbl.Size = new System.Drawing.Size(128, 23);
            this.Time_lbl.TabIndex = 2;
            this.Time_lbl.Text = "Время 0:00:00";
            this.Time_lbl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Time_lbl_MouseDown);
            this.Time_lbl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Time_lbl_MouseMove);
            this.Time_lbl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Time_lbl_MouseUp);
            // 
            // pnl_2048
            // 
            this.pnl_2048.Location = new System.Drawing.Point(20, 3);
            this.pnl_2048.Margin = new System.Windows.Forms.Padding(20, 3, 4, 3);
            this.pnl_2048.Name = "pnl_2048";
            this.pnl_2048.Size = new System.Drawing.Size(90, 39);
            this.pnl_2048.TabIndex = 4;
            this.pnl_2048.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_2048_MouseDown);
            this.pnl_2048.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_2048_MouseMove);
            this.pnl_2048.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnl_2048_MouseUp);
            // 
            // btn_RollUp
            // 
            this.btn_RollUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RollUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_RollUp.Location = new System.Drawing.Point(573, 10);
            this.btn_RollUp.Margin = new System.Windows.Forms.Padding(7, 10, 7, 10);
            this.btn_RollUp.Name = "btn_RollUp";
            this.btn_RollUp.Size = new System.Drawing.Size(25, 25);
            this.btn_RollUp.TabIndex = 1;
            this.btn_RollUp.Click += new System.EventHandler(this.btn_RollUp_Click);
            this.btn_RollUp.MouseEnter += new System.EventHandler(this.btn_RollUp_MouseEnter);
            this.btn_RollUp.MouseLeave += new System.EventHandler(this.btn_RollUp_MouseLeave);
            // 
            // btn_deincrease
            // 
            this.btn_deincrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deincrease.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_deincrease.Location = new System.Drawing.Point(541, 10);
            this.btn_deincrease.Margin = new System.Windows.Forms.Padding(5, 10, 0, 10);
            this.btn_deincrease.Name = "btn_deincrease";
            this.btn_deincrease.Size = new System.Drawing.Size(25, 25);
            this.btn_deincrease.TabIndex = 1;
            this.btn_deincrease.Click += new System.EventHandler(this.btn_deincrease_Click);
            this.btn_deincrease.MouseEnter += new System.EventHandler(this.btn_deincrease_MouseEnter);
            this.btn_deincrease.MouseLeave += new System.EventHandler(this.btn_deincrease_MouseLeave);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Exit.Location = new System.Drawing.Point(605, 10);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(0, 10, 20, 10);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(25, 25);
            this.btn_Exit.TabIndex = 0;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            this.btn_Exit.MouseEnter += new System.EventHandler(this.btn_Exit_MouseEnter);
            this.btn_Exit.MouseLeave += new System.EventHandler(this.btn_Exit_MouseLeave);
            // 
            // picBox1
            // 
            this.picBox1.Location = new System.Drawing.Point(180, 57);
            this.picBox1.Margin = new System.Windows.Forms.Padding(2, 10, 2, 0);
            this.picBox1.Name = "picBox1";
            this.picBox1.Size = new System.Drawing.Size(290, 290);
            this.picBox1.TabIndex = 2;
            this.picBox1.TabStop = false;
            this.picBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.picBox1_Paint);
            this.picBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBox1_MouseDown);
            this.picBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBox1_MouseMove);
            this.picBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBox1_MouseUp);
            this.picBox1.Resize += new System.EventHandler(this.picBox1_Resize);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUp.Location = new System.Drawing.Point(280, 372);
            this.btnUp.Margin = new System.Windows.Forms.Padding(10, 25, 10, 0);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(90, 40);
            this.btnUp.TabIndex = 0;
            this.btnUp.TabStop = false;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDown.Location = new System.Drawing.Point(280, 422);
            this.btnDown.Margin = new System.Windows.Forms.Padding(10, 10, 10, 25);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(90, 40);
            this.btnDown.TabIndex = 0;
            this.btnDown.TabStop = false;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLeft.Location = new System.Drawing.Point(180, 372);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(0, 25, 0, 25);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(90, 90);
            this.btnLeft.TabIndex = 0;
            this.btnLeft.TabStop = false;
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRight.Location = new System.Drawing.Point(380, 372);
            this.btnRight.Margin = new System.Windows.Forms.Padding(0, 25, 0, 25);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(90, 90);
            this.btnRight.TabIndex = 0;
            this.btnRight.TabStop = false;
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(17, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Лучший счет:";
            // 
            // highscoreLbl
            // 
            this.highscoreLbl.AutoSize = true;
            this.highscoreLbl.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.highscoreLbl.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.highscoreLbl.Location = new System.Drawing.Point(17, 79);
            this.highscoreLbl.Name = "highscoreLbl";
            this.highscoreLbl.Size = new System.Drawing.Size(81, 15);
            this.highscoreLbl.TabIndex = 9;
            this.highscoreLbl.Text = "Лучший счет:";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 487);
            this.Controls.Add(this.highscoreLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.picBox1);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2048";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress_2);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel btn_Exit;
        private System.Windows.Forms.Panel btn_deincrease;
        private System.Windows.Forms.Panel btn_RollUp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnl_2048;
        private System.Windows.Forms.Label Time_lbl;
        private System.Windows.Forms.Label Count_lbl;
        private System.Windows.Forms.PictureBox picBox1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label highscoreLbl;
        public System.Windows.Forms.Timer timer2;
    }
}

