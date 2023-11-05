using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _2048_Test1
{
    public partial class EndGameForm : Form
    {
        delegate void Delegat();
        private System.Windows.Forms.Timer opacityTimer = new System.Windows.Forms.Timer();

        public EndGameForm()
        {
            InitializeComponent();

            opacityTimer.Interval = 100;
            // Установка обработчика события Tick
            opacityTimer.Tick += timer1_Tick;

        }

        private void EndGameForm_Load(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Transparent;
            panel3.BackgroundImageLayout = ImageLayout.Zoom;
            panel3.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\2048.png");

            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btn_Exit.png");

            //label1.Location = new Point( this.Width - label1.Size.Width/2, 70);
            this.Opacity = 0;
            opacityTimer.Start();


        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btn_Exit_Entry_v3.png");
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btn_Exit.png");
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            //var window = new Form1();
            //window.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Увеличение значения свойства Opacity на 10
            this.Opacity += 0.1;

            // Если значение свойства Opacity достигло максимального значения,
            // остановить таймер
            if (this.Opacity >= 1.0)
            {
                opacityTimer.Stop();
            }
        }
    }
}
