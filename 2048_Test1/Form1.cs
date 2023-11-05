using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Threading;
using System.Runtime;

// Нужно сделать:
//  1) Свичи ++
//  2) Пропорции
//  3) Счёт ++
//  4) Вывод в файл логера ++
//  5) Отлов окончания игры ++
//  6) Окно окончания игры +-
//  7) Внедрить окно окончание игры в код в нужное место ++
//  8) Сделать анимацию движения и появления 
//  9) Написать функцию всплывания Окна конца игры.
//  10) Написать начальное окно.

namespace _2048_Test1
{
    public partial class Form1 : Form
    {
        int hour, min, sek = 0;
        bool size_flag = false;
        bool mouseDo = false;
        bool drag = false;
        bool EndGame = false;
        Point startPoint = new Point(0, 0);
        Point mouseDown;
        Point mouseUp;
        Graphics gc;
        Bitmap bmp;
        int HighScore;
        int sizeBorder = 10;
        int sizeBlock = 60;
        Random rnd = new Random();
        Square[,] sqrs;


        public Form1()
        {
            InitializeComponent();

            // Установка свойства KeyPreview формы в true
            this.KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();

            

            btn_Exit.BackColor = Color.Transparent;
            btn_Exit.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Exit.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btn_Exit.png");

            btn_RollUp.BackColor = Color.Transparent;
            btn_RollUp.BackgroundImageLayout = ImageLayout.Zoom;
            btn_RollUp.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btn_RollUp.png");

            btn_deincrease.BackColor = Color.Transparent;
            btn_deincrease.BackgroundImageLayout = ImageLayout.Zoom;
            btn_deincrease.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btn_Deincrease.png");

            pnl_2048.BackColor = Color.Transparent;
            pnl_2048.BackgroundImageLayout = ImageLayout.Zoom;
            pnl_2048.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\2048.png");

            btnLeft.BackgroundImageLayout = ImageLayout.Zoom;
            btnLeft.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btnLeft.png");

            btnRight.BackgroundImageLayout = ImageLayout.Zoom;
            btnRight.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btnRight.png");

            btnUp.BackgroundImageLayout = ImageLayout.Zoom;
            btnUp.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btnUp.png");

            btnDown.BackgroundImageLayout = ImageLayout.Zoom;
            btnDown.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btnDown.png");

            this.Icon = new Icon(Application.StartupPath + @"\icons\2048.ico");
            //this.Size = new Size(800, 527);

            //picBox1.Size = new Size(290, 290);
            //picBox1.Location = new Point(255, 78);

            //btnRight.Size = new Size(90, 90);
            //btnRight.Location = new Point(455, 398);

            //btnDown.Size = new Size(90, 40);
            //btnDown.Location = new Point(355, 448);

            //btnUp.Size = new Size(90, 40);
            //btnUp.Location = new Point(355, 398);

            //btnLeft.Size = new Size(90, 90);
            //btnLeft.Location = new Point(255, 398);

            //Time_lbl.Size = new Size(120, 22);
            //Time_lbl.Location = new Point(407, 11);

            //Count_lbl.Size = new Size(63, 22);
            //Count_lbl.Location = new Point(273, 11);

            //pnl_2048.Size = new Size(90, 39);
            //pnl_2048.Location = new Point(20, 3);

            highscoreLbl.Text = Convert.ToString(Properties.Settings.Default.hhghscr);

            bmp = new Bitmap(picBox1.Width, picBox1.Height);
            gc = Graphics.FromImage(bmp);
            picBox1.Image = bmp;

            picBox1.BackColor = Color.FromArgb(128, 128, 128);
            //this.Opacity = 0;
            //while (this.Opacity != 100)
            //{
            //    Thread.Sleep(100);
            //    this.Opacity = this.Opacity + 10;
            //}

            DrawStartBlocks();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread t = new Thread(tt);
            t.Start();
            Time_lbl.Text = TimeToText();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            Time_lbl.Text = TimeToText();
        }

        private void btn_Exit_MouseEnter(object sender, EventArgs e)
        {
            btn_Exit.BackColor = Color.Transparent;
            btn_Exit.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Exit.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btn_Exit_Entry_v3.png");
        }

        private void btn_Exit_MouseLeave(object sender, EventArgs e)
        {
            btn_Exit.BackColor = Color.Transparent;
            btn_Exit.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Exit.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btn_Exit.png");
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_RollUp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_RollUp_MouseEnter(object sender, EventArgs e)
        {
            btn_RollUp.BackColor = Color.Transparent;
            btn_RollUp.BackgroundImageLayout = ImageLayout.Zoom;
            btn_RollUp.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btn_RollUp_Entry_v2.png");
        }

        private void btn_RollUp_MouseLeave(object sender, EventArgs e)
        {
            btn_RollUp.BackColor = Color.Transparent;
            btn_RollUp.BackgroundImageLayout = ImageLayout.Zoom;
            btn_RollUp.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btn_RollUp.png");
        }

        private void btn_deincrease_Click(object sender, EventArgs e)
        {

            if (size_flag)
            {
                this.WindowState = FormWindowState.Normal;
                size_flag = false;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                size_flag = true;
            }

            int new_w = 0;
            new_w = this.Size.Width / 2;

            //Count_lbl.Location = new Point(new_w - 127, 11);
            //Time_lbl.Location = new Point(new_w + 9, 11);

        }

        private void btn_deincrease_MouseEnter(object sender, EventArgs e)
        {
            btn_deincrease.BackColor = Color.Transparent;
            btn_deincrease.BackgroundImageLayout = ImageLayout.Zoom;
            btn_deincrease.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btn_Deincrease_Entry_v2.png");
        }

        private void btn_deincrease_MouseLeave(object sender, EventArgs e)
        {
            btn_deincrease.BackColor = Color.Transparent;
            btn_deincrease.BackgroundImageLayout = ImageLayout.Zoom;
            btn_deincrease.BackgroundImage = Image.FromFile(Application.StartupPath + @"\icons\btn_Deincrease.png");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            Cursor = Cursors.Default;
        }

        private void Time_lbl_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Time_lbl_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void Time_lbl_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            Cursor = Cursors.Default;
        }

        private void Count_lbl_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Count_lbl_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void Count_lbl_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            Cursor = Cursors.Default;
        }

        private void pnl_2048_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void pnl_2048_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void pnl_2048_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            Cursor = Cursors.Default;
        }

        private void picBox1_Resize(object sender, EventArgs e)
        {

        }

        private void tt()
        {
            sek++;
            if (sek == 60)
            { sek = 0; min++; }
            else if (min == 60) { min = 0; hour++; }
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            RightSwitch();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {

            UpSwitch();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            DownSwitch();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            LeftSwitch();
        }

        private string TimeToText()
        {
            string FinalText;
            FinalText = "Время " + Convert.ToString(hour) + ":";
            if (min < 10) FinalText += "0" + Convert.ToString(min) + ":";
            else FinalText += Convert.ToString(min) + ":";
            if (sek < 10) FinalText += "0" + Convert.ToString(sek);
            else FinalText += Convert.ToString(sek);
            return FinalText;
        }

        private void picBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void DrawStartingGrid()
        //{
        //    gc.Clear(Color.Transparent);
        //    int x, y;
        //    x = picBox1.Size.Width;
        //    y = picBox1.Size.Height;

        //    Rectangle rec = new Rectangle(0, 0, x, y);
        //    SolidBrush forColumn = new SolidBrush(Color.FromArgb(128, 128, 128));
        //    gc.FillRectangle(forColumn, rec);

        //    Rectangle sqrRecs;
        //    SolidBrush forBlocks = new SolidBrush(Color.White);
        //    int y1 = sizeBorder;
        //    int x1;
        //    for (int i=0;i<4;i++)
        //    {
        //        x1 = sizeBorder;
        //        for (int j=0;j<4;j++)
        //        {
        //            gc.FillRectangle(forBlocks, sqrRecs = new Rectangle(x1, y1, sizeBlock, sizeBlock));
        //            x1 += sizeBlock + sizeBorder;
        //        }
        //        y1 += sizeBorder + sizeBlock;
        //    }



        //    picBox1.Image = bmp;
        //}

        public void DrawStartBlocks()
        {
            //int val = 4;

            int x1 = rnd.Next(0, 4);
            int y1 = rnd.Next(0, 4);
            int x2 = rnd.Next(0, 4);
            int y2 = rnd.Next(0, 4);

            if ((x1 == x2) && (y1 == y2))
            {
                x2 = (x2 + 1) % 4;
                y2 = (y2 + 1) % 4;
            }

            //int x1 = 0;
            //int y1 = 0;
            //int x2 = 1;
            //int y2 = 1;


            //DrawStartingGrid();
            sqrs = new Square[4, 4];
            Square.KnowSizes(sizeBorder, sizeBlock, gc, picBox1,bmp);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    sqrs[i, j] = new Square(i, j);
                    //if (((i == x1) && (j == y1)) || ((i == x2) && (j == y2)))
                    //{
                        //sqrs[i, j].CreateValue(val);
                    //}

                    //else
                        //val *= 2;
                    sqrs[i, j].Draw();
                }
            }

            sqrs[x1, y1].CreateValue();
            sqrs[x2, y2].CreateValue();

            //gc.DrawLine(Pens.Red, 10, 270, 70, 270);


            //picBox1.Image = bmp;
        }

        private void Refreshing()
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    sqrs[i, j].Draw();
                }
            }
            picBox1.Image = bmp;
        }

        private void DownSwitch()
        {
            bool midNumFlag = false;
            bool oneAddFlag = false;
            bool oneTabFlag = false;
           // Logger.Info("Сделал движение вниз ");

            for (int i = 0; i < 4; i++)
            {
                midNumFlag = false;
                for (int j = 3; j > 0; j--)
                {
                    midNumFlag = false;
                    oneAddFlag = false;
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (sqrs[i, k].GetValue() > 0)
                        {
                            if ((sqrs[i, j].GetValue() > 0) && (sqrs[i, j].GetValue() != sqrs[i, k].GetValue()))
                            {
                                midNumFlag = true;
                            }

                            if ((sqrs[i, k].GetValue() == sqrs[i, j].GetValue()) && (midNumFlag == false) && (oneAddFlag == false))
                            {
                                sqrs[i, j] = sqrs[i, j] + sqrs[i, k];
                                midNumFlag = false;
                                oneAddFlag = true;
                                oneTabFlag = true;

                            }

                            if /*(*/(sqrs[i, j].GetValue() == 0)/* && (midNumFlag==false))*/
                            {
                                sqrs[i, j] = sqrs[i, j] + sqrs[i, k];
                                oneTabFlag = true;
                            }

                        }
                        else continue;
                    }
                }
            }

            if (oneTabFlag)
            {
                Count_lbl.Text = "Счет: " + Convert.ToString(Square.GetCount());
                highscoreLbl.Text = Convert.ToString(Properties.Settings.Default.hhghscr);
                CreateOneNew();
                //Refreshing();
            }


        }

        private void UpSwitch()
        {
            bool midNumFlag = false;
            bool oneAddFlag = false;
            bool oneTabFlag = false;
            //Logger.Info("Сделал движение вверх "); капитальный красавчик вообще

            for (int i = 0; i < 4; i++)
            {
                midNumFlag = false;
                for (int j = 0; j < 3; j++)
                {
                    midNumFlag = false;
                    oneAddFlag = false;
                    for (int k = j + 1; k <= 3; k++)
                    {
                        if (sqrs[i, k].GetValue() > 0)
                        {
                            if ((sqrs[i, j].GetValue() > 0) && (sqrs[i, j].GetValue() != sqrs[i, k].GetValue()))
                            {
                                midNumFlag = true;
                            }

                            if ((sqrs[i, k].GetValue() == sqrs[i, j].GetValue()) && (midNumFlag == false) && (oneAddFlag == false))
                            {
                                sqrs[i, j] = sqrs[i, j] + sqrs[i, k];
                                midNumFlag = false;
                                oneAddFlag = true;
                                oneTabFlag = true;

                            }

                            if /*(*/(sqrs[i, j].GetValue() == 0)/* && (midNumFlag==false))*/
                            {
                                sqrs[i, j] = sqrs[i, j] + sqrs[i, k];
                                oneTabFlag = true;
                            }

                        }
                        else continue;
                    }
                }
            }

            if (oneTabFlag)
            {
                Count_lbl.Text = "Счет: " + Convert.ToString(Square.GetCount());
                highscoreLbl.Text = Convert.ToString(Properties.Settings.Default.hhghscr);
                CreateOneNew();
                //Refreshing();
            }
            
        }

        private void LeftSwitch()
        {
            bool midNumFlag = false;
            bool oneAddFlag = false;
            bool oneTabFlag = false;
            //Logger.Info("Сделал движение влево ");

            for (int j = 0; j < 4; j++)
            {
                midNumFlag = false;
                for (int i = 0; i < 3; i++)
                {
                    midNumFlag = false;
                    oneAddFlag = false;
                    for (int k = i + 1; k <= 3; k++)
                    {
                        if (sqrs[k, j].GetValue() > 0)
                        {
                            if ((sqrs[i, j].GetValue() > 0) && (sqrs[i, j].GetValue() != sqrs[k, j].GetValue()))
                            {
                                midNumFlag = true;
                            }

                            if ((sqrs[i, j].GetValue() == sqrs[k, j].GetValue()) && (midNumFlag == false) && (oneAddFlag == false))
                            {
                                sqrs[i, j] = sqrs[i, j] + sqrs[k, j];
                                midNumFlag = false;
                                oneAddFlag = true;
                                oneTabFlag = true;
                            }

                            if /*(*/(sqrs[i, j].GetValue() == 0)/* && (midNumFlag==false))*/
                            {
                                sqrs[i, j] = sqrs[i, j] + sqrs[k, j];
                                oneTabFlag = true;
                            }

                        }
                        else continue;
                    }
                }
            }

            if (oneTabFlag)
            {
                Count_lbl.Text = "Счет: " + Convert.ToString(Square.GetCount());
                highscoreLbl.Text = Convert.ToString(Properties.Settings.Default.hhghscr);
                //Refreshing();
                CreateOneNew();
                //Refreshing();
            }
            
        }

        private void RightSwitch()
        {
            bool midNumFlag = false;
            bool oneAddFlag = false;
            bool oneTabFlag = false;
            //Logger.Info("Сделал движение вправо ");

            for (int j = 0; j < 4; j++)
            {
                midNumFlag = false;
                for (int i = 3; i > 0; i--)
                {
                    midNumFlag = false;
                    oneAddFlag = false;
                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (sqrs[k, j].GetValue() > 0)
                        {
                            if ((sqrs[i, j].GetValue() > 0) && (sqrs[i, j].GetValue() != sqrs[k, j].GetValue()))
                            {
                                midNumFlag = true;
                            }

                            if ((sqrs[i, j].GetValue() == sqrs[k, j].GetValue()) && (midNumFlag == false) && (oneAddFlag == false))
                            {
                                sqrs[i, j] = sqrs[i, j] + sqrs[k, j];
                                midNumFlag = false;
                                oneAddFlag = true;
                                oneTabFlag = true;

                            }

                            if /*(*/(sqrs[i, j].GetValue() == 0)/* && (midNumFlag==false))*/
                            {
                                sqrs[i, j] = sqrs[i, j] + sqrs[k, j];
                                oneTabFlag = true;
                            }

                        }
                        else continue;
                    }
                }
            }

            if (oneTabFlag)
            {
                Logger.Info("Прошел на создание нового квадратика ");
                Count_lbl.Text = "Счет: " + Convert.ToString(Square.GetCount());
                highscoreLbl.Text = Convert.ToString(Properties.Settings.Default.hhghscr);
                CreateOneNew();
                //Refreshing();
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void picBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == Button.MouseButtons && EndGame==false)
            {
                //MessageBox.Show("нажата кнопка мышки", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mouseDown = new Point(e.X, e.Y);
                mouseDo = true;
            }
        }

        private void picBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void picBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseDo == true)
            {
                mouseDo = false;
                mouseUp = e.Location;
                //MessageBox.Show($"Point : {mouseUp.X}x{mouseUp.Y}");
                Point result = new Point(mouseUp.X - mouseDown.X, mouseUp.Y - mouseDown.Y);
                ChooseToDo(result);
            }
        }

        private void ChooseToDo(Point p)
        {
            int x, y;
            x = p.X;
            y = p.Y;
            
            if ((Math.Abs(x) > 40) || (Math.Abs(y) > 40))
            {
                if (Math.Abs(x) > Math.Abs(y))
                {
                    if (x > 0) RightSwitch();
                    else LeftSwitch();
                }
                else if (Math.Abs(y) > Math.Abs(x))
                {
                    if (y > 0) DownSwitch();
                    else UpSwitch();
                }
            } 
        }

        private void Form1_KeyPress_2(object sender, KeyPressEventArgs e)
        {
            
            //MessageBox.Show("Ri");
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (EndGame == false)
            //{
            //    switch (e.KeyCode)
            //    {
            //        case Keys.Left:
                        
            //            // Предотвращение выбора кнопок
            //            LeftSwitch();
            //            Console.WriteLine("Left");
            //            break;
            //        case Keys.Up:
            //            UpSwitch();
            //            Console.WriteLine("Up");
            //            break;
            //        case Keys.Down:
            //            DownSwitch();
            //            Console.WriteLine("Down");
            //            break;
            //        case Keys.Right:
            //            RightSwitch();
            //            Console.WriteLine("Right");
            //            break;
            //    }
            //}
        }

            private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            // Goood work

            //MessageBox.Show("Down");
            //MessageBox.Show($"{e.KeyCode}  {Keys.Down}");
            if (EndGame == false)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        LeftSwitch();
                        break;
                    case Keys.W:
                        UpSwitch();
                        break;
                    case Keys.S:
                        DownSwitch();
                        break;
                    case Keys.D:
                        RightSwitch();
                        break;
                    case Keys.Left:
                        // Предотвращение выбора кнопок
                        //e.Handled = true;
                        LeftSwitch();
                        break;
                    case Keys.Up:
                        // Предотвращение выбора кнопок
                        //e.Handled = true;
                        UpSwitch();
                        break;
                    case Keys.Down:
                        // Предотвращение выбора кнопок
                       //e.Handled = true;
                        DownSwitch();
                        break;
                    case Keys.Right:
                        
                        RightSwitch();
                       // e.Handled = true;
                        break;
                }
            }
            
        }

        private void CreateOneNew()
        {
            List<Point> freePnts = new List<Point>();
            for (int i=0;i<4;i++)
            {
                for(int j=0;j<4;j++)
                {
                    if (sqrs[i,j].GetValue()==0)
                    {
                        Point addP = new Point(i, j);
                        freePnts.Add(addP);
                    }
                }
            }

            if (freePnts.Count > 0)
            {
                int pos = rnd.Next(0, freePnts.Count);
                sqrs[freePnts[pos].X, freePnts[pos].Y].CreateValue();

                //Logger.Info("создал квадратик ");

                if (freePnts.Count == 1)
                {

                    //Logger.Info("Проверка на конец игры ");

                    CheckForEndTheGame();
                }

            }

        }

      
        private void CheckForEndTheGame()
        {
            
            var cansellationTokenSource = new CancellationTokenSource();
            var token = cansellationTokenSource.Token;

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 3; j > 0; j--)
                    {
                        int k = j - 1;
                        
                            if (sqrs[i, k].GetValue() == sqrs[i, j].GetValue()) // Проверка снизу
                            {
                                
                                cansellationTokenSource.Cancel();
                                if (token.IsCancellationRequested)
                                    token.ThrowIfCancellationRequested();
                            }

                            if (sqrs[k, i].GetValue() == sqrs[j, i].GetValue()) // Проверка справа
                            {
                                
                                cansellationTokenSource.Cancel();
                                if (token.IsCancellationRequested)
                                    token.ThrowIfCancellationRequested();
                            }
                        
                    }
                }
                try
                {
                    Logger.Info("Не нашел свободного места для нового квадрата - вы проиграли! ");

                    var window = new EndGameForm();
                    //CreateEndWindow();
                    window.Show();
                    Logger.Info("По идее создал окно проигрыша ");
                    window.Location = new Point(this.Location.X + this.Size.Width / 2 - window.Size.Width/2, this.Location.Y + this.Size.Height / 2 - window.Size.Height/2);
                    picBox1.Enabled = false;
                    btnDown.Enabled = false;
                    btnUp.Enabled = false;
                    btnRight.Enabled = false;
                    btnLeft.Enabled = false;
                    timer1.Stop();
                    EndGame = true;
                    // this.Close();
                    
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }

            }


            


            catch (OperationCanceledException)
            {
                Logger.Info("Удачно завершил проверку квадратов ");
            }
            finally
            {
                cansellationTokenSource.Dispose();
                Logger.Info("Очистил CansellToken");
            }
        }

        //async void CreateEndWindow()
        //{
        //    var win = new EndGameForm();
        //    win.Opacity = 0;
        //    win.Location = new Point(this.Location.X + this.Size.Width / 2 - win.Size.Width / 2, this.Location.Y + this.Size.Height / 2 - win.Size.Height / 2);
        //    win.Show();
        //    while (win.Opacity != 100)
        //    {
        //        await Task.Delay(100);
        //        win.Opacity += 10;
        //    }

        //}

    }
}
