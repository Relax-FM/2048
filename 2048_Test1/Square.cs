using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_Test1
{
    internal class Square
    {
        private int value = 0;
        static int blockSize = 60;
        static int borderSize = 10;
        static int globalCount = 0;
        static int fontSize = 11;
        static Graphics gc;
        static Bitmap bmp;
        static PictureBox picBox;
        //private Point txtIndent;
        private Point position;
        private Point pixelPosition;
        
        
        //private bool flagEnabled = false;
        private Color sqrColor = Color.FromArgb(255, 255, 255);
        private Color txtColor;
        private Font sqrFont = new Font(FontFamily.GenericSansSerif, fontSize, FontStyle.Bold);
        static Random rnd = new Random();

        public Square(int x, int y)
        {
            position = new Point(x, y);
            pixelPosition = StartPosition();
        }

        public int GetValue()
        {
            return value;
        }

        public static Square operator +(Square s1,Square s2)// Сложение квадратиков
        {
            int val = s1.value;
            globalCount += 2 * s1.value;
            if (globalCount >= Properties.Settings.Default.hhghscr)
            {
                Properties.Settings.Default.hhghscr = globalCount;
                Properties.Settings.Default.Save();
            }
            s1.value = s1.value + s2.value;
            s2.value = 0;

            //Logger.Info($"Сложил два квадрата {s1.position.X}x{s1.position.Y} и {s2.position.X}x{s2.position.Y} ");


            s1.CheckColor();
            s2.CheckColor();
            s1.Draw();
            s2.Draw();
            picBox.Image = bmp;

            //Bitmap bit = new Bitmap(picBox.Image, picBox.Size.Width, picBox.Size.Height);

            //MessageBox.Show("Vot!");

            //s1.DrawMoveSqrs(s2.position,val,bit);
            //s2.CheckColor();
            //s2.Draw();
            picBox.Image = bmp;
            return s1;
        }

        private async void DrawMoveSqrs(Point p2,int val,Bitmap bit)
        {
            Square s1 = new Square(p2.X, p2.Y);
            s1.CreateValue(val);
            //s1.CheckColor();

            

            int x, y,speed;
            speed = 0;
            x = s1.pixelPosition.X - pixelPosition.X;
            y = s1.pixelPosition.Y - pixelPosition.Y;

            if (x != 0)
            {
                if (x > 0)
                {
                    speed = -5;
                    MessageBox.Show("X speed -5");
                }
                else if (x < 0)
                {
                    speed = 5;
                    MessageBox.Show("X speed 5");
                }
                while (s1.pixelPosition.X != pixelPosition.X)
                {
                    gc.DrawImage(bit, new Point(0, 0));
                    picBox.Image = bmp;
                    s1.Draw();
                    s1.pixelPosition = new Point(s1.pixelPosition.X + speed, s1.pixelPosition.Y);
                    picBox.Image = bmp;
                    //MessageBox.Show("Move");
                    //await Task.Delay(100);
                }
            }
            else if (y != 0)
            {
                if (y > 0)
                {
                    speed = -5;
                    MessageBox.Show("Y speed -5");
                }
                else if (y < 0)
                {
                    speed = 5;
                    MessageBox.Show("Y speed 5");
                }
                while (s1.pixelPosition.Y != pixelPosition.Y)
                {
                    gc.DrawImage(bit, new Point(0, 0));
                    picBox.Image = bmp;
                    s1.Draw();
                    s1.pixelPosition = new Point(s1.pixelPosition.X, s1.pixelPosition.Y+ speed);
                    picBox.Image = bmp;
                    //MessageBox.Show("Move");
                    //await Task.Delay(100);
                }
            }
            Draw();
            picBox.Image = bmp;

            //Bitmap bmp2 = Bitmap;
        }

        public static void KnowSizes(int bordersize, int blocksize, Graphics gc_,PictureBox pic,Bitmap bm)// Узнать размер квадратов, рамки и графику
        {
            borderSize = bordersize;
            blockSize = blocksize;
            gc = gc_;
            picBox = pic;
            bmp = bm;
        }

        public static void KnowSizes(int bordersize, int blocksize)// Узнать размер квадратов и рамки
        {
            borderSize = bordersize;
            blockSize = blocksize;
        }

        public static int GetCount()// Для вывода общего счёта
        {
            return globalCount;
        }

        public void CreateValue()// Для создания цифры в квадратике
        {
                //rnd = new Random();
                if (rnd.Next(0, 10) < 9)
                {
                    value = 2;
                }
                else
                {
                    value = 4;
                }

            CheckColor();
            //Draw();
            CreateOneNewSqr();
            //Draw();

                //flagEnabled = true;
        }

        private async void CreateOneNewSqr()
        {
            Brush br = new SolidBrush(sqrColor);
            int x, y;
            x = 0;
            y = 0;
            Point LeftUpPoz = new Point(pixelPosition.X + (blockSize / 2) - x, pixelPosition.Y + (blockSize / 2) - y);
            Size RightDownPoz = new Size(x * 2, y * 2);
            Rectangle sqr = new Rectangle(LeftUpPoz, RightDownPoz);
            while(LeftUpPoz.X!=pixelPosition.X)
            {
                gc.FillRectangle(br, sqr);
                x+=2;
                y+=2;
                LeftUpPoz = new Point(pixelPosition.X + (blockSize / 2) - x, pixelPosition.Y + (blockSize / 2) - y);
                RightDownPoz = new Size(x * 2, y * 2);
                sqr = new Rectangle(LeftUpPoz, RightDownPoz);
                picBox.Image = bmp;
                //await Task.Delay(1);
                
            }
            Draw();
            picBox.Image = bmp;

        }

        public void CreateValue(int val)
        {

            value = val;
            CheckColor();
            //flagEnabled = true;
        }

        private void CheckColor()
        {
            if (value>0)
            {
                switch (value)
                {
                    case 2:
                        sqrColor = Color.FromArgb(0, 0, 0);
                        txtColor = Color.FromArgb(255, 255, 255);

                        //txtIndent = new Point(8, 10);
                        //txtIndent = new Point(IndentCount(value), 10);
                        break;
                    case 4:
                        sqrColor = Color.FromArgb(24, 24, 24);
                        txtColor = Color.FromArgb(255, 255, 255);
                        
                        //txtIndent = new Point(8, 10);
                        //txtIndent = new Point(IndentCount(value), 10);
                        break;
                    case 8:
                        sqrColor = Color.FromArgb(48, 48, 48);
                        txtColor = Color.FromArgb(255, 255, 255);
                        
                        //txtIndent = new Point(8, 10);
                        //txtIndent = new Point(IndentCount(value), 10);
                        break;
                    case 16:
                        sqrColor = Color.FromArgb(72, 72, 72);
                        txtColor = Color.FromArgb(255, 255, 255);
                        
                        //txtIndent = new Point(14, 10);
                        //txtIndent = new Point(IndentCount(value), 10);
                        break;
                    case 32:
                        sqrColor = Color.FromArgb(96, 96, 96);
                        txtColor = Color.FromArgb(255, 255, 255);
                        
                        //txtIndent = new Point(14, 10);
                        //txtIndent = new Point(IndentCount(value), 10);
                        break;
                    case 64:
                        sqrColor = Color.FromArgb(110, 110, 110);
                        txtColor = Color.FromArgb(255, 255, 255);
                        
                        //txtIndent = new Point(14, 10);
                        //txtIndent = new Point(IndentCount(value), 10);
                        break;
                    case 128:
                        sqrColor = Color.FromArgb(144, 144, 144);
                        txtColor = Color.FromArgb(0, 0, 0);
                        
                        //txtIndent = new Point(18, 10);
                        //txtIndent = new Point(IndentCount(value), 10);
                        break;
                    case 256:
                        sqrColor = Color.FromArgb(168, 168, 168);
                        txtColor = Color.FromArgb(0, 0, 0);
                        
                        //txtIndent = new Point(18, 10);
                        //txtIndent = new Point(IndentCount(value), 10);
                        break;
                    case 512:
                        sqrColor = Color.FromArgb(192, 192, 192);
                        txtColor = Color.FromArgb(0, 0, 0);
                        
                        //txtIndent = new Point(18, 10);
                        //txtIndent = new Point(IndentCount(value), 10);
                        break;
                    case 1024:
                        sqrColor = Color.FromArgb(215, 215, 215);
                        txtColor = Color.FromArgb(0, 0, 0);
                        
                        //txtIndent = new Point(22, 10);
                        //txtIndent = new Point(IndentCount(value), 10);
                        break;
                    case 2048:
                        sqrColor = Color.FromArgb(235, 235, 235);
                        txtColor = Color.FromArgb(0, 0, 0);
                       
                        //txtIndent = new Point(22, 10);
                        //txtIndent = new Point(IndentCount(value), 10);
                        break;
                    default:
                        sqrColor = Color.FromArgb(235, 235, 235);
                        txtColor = Color.FromArgb(0, 0, 0);
                       
                        //txtIndent = new Point(IndentCount(value), 10);
                        break;
                }
            }
            else
            {
                sqrColor = Color.FromArgb(255, 255, 255);
            }
        }

        //private int IndentCount(int value)
        //{
        //    int result = 0;
        //    while (value != 0)
        //    {
        //        result++;
        //        value /= 10;
        //    }

        //    result = (result - 4) * 5 + 22 + (result - 4);

        //    return result;
        //}

        private Point StartPosition()
        {
            Point strPstn;
            strPstn = new Point(borderSize + position.X * (blockSize + borderSize), borderSize + position.Y * (blockSize + borderSize));
            return strPstn;
        }

       

        public void Draw()
        {
            //this.CheckColor();
            Brush br = new SolidBrush(sqrColor);
            Rectangle rec;
            //pixelPosition = StartPosition();
            gc.FillRectangle(br, rec = new Rectangle((pixelPosition.X), (pixelPosition.Y), blockSize, blockSize));
            if (value>0)
            {
                Brush txtBr = new SolidBrush(txtColor);

                float x = gc.MeasureString(Convert.ToString(value), sqrFont).Width/2;
                float y = gc.MeasureString(Convert.ToString(value), sqrFont).Height/2;

                //if (gc.MeasureString(Convert.ToString(value), sqrFont).Width/2 >= (x + 0.5)) x++;
                //if (gc.MeasureString(Convert.ToString(value), sqrFont).Height/2 >= (y + 0.5)) y++;

                //txtIndent = new Point(x,y);
                gc.DrawString(Convert.ToString(value), sqrFont, txtBr, ((float)pixelPosition.X + (float)blockSize / 2 - x), ((float)pixelPosition.Y + (float)blockSize / 2 - y));
            }
        }
    }
}
