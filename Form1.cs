using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //Очерёдность хода: ход крестиков
        bool moveX = true;

        //количество сделанных ходов
        int numMove = 0;

        //Свободные клетки
        bool buttonOn1 = true;
        bool buttonOn2 = true;
        bool buttonOn3 = true;
        bool buttonOn4 = true;
        bool buttonOn5 = true;
        bool buttonOn6 = true;
        bool buttonOn7 = true;
        bool buttonOn8 = true;
        bool buttonOn9 = true;

        enum XO
        {
            No,
            X,
            O
        }

        //Вертикали
        XO[] VLeft = new XO[4];
        XO[] VMid = new XO[4];
        XO[] VRight = new XO[4];
        //Горизонтали
        XO[] GTop = new XO[4];
        XO[] GMid = new XO[4];
        XO[] GBot = new XO[4];
        //Диагонали
        XO[] DLeftRight = new XO[4];
        XO[] DRightLeft = new XO[4];

        public void Zapolnenie()
        {
            int i;

            for (i = 1; i <= 3; i++)
            {
                VLeft[i] = x[1 + 3 *(i - 1)];
                VMid[i] = x[2 + 3 *(i - 1)];
                VRight[i] = x[3 + 3 *(i - 1)];

                GTop[i] = x[1 +(i - 1)];
                GMid[i] = x[4 +(i - 1)];
                GBot[i] = x[7 +(i - 1)];

                DLeftRight[i] = x[1 + 4 *(i - 1)];
                DRightLeft[i] = x[3 + 2 *(i - 1)];
            }

            GameEnd();
        }

        public void GameEnd()
        {
            bool win = false;
            //Победа крестиков
            if ((VLeft[1] == VLeft[2] && VLeft[2] == VLeft[3] && VLeft[3] == XO.X) ||
               (VMid[1] == VMid[2] && VMid[2] == VMid[3] && VMid[3] == XO.X) ||
               (VRight[1] == VRight[2] && VRight[2] == VRight[3] && VRight[3] == XO.X) ||
               (GTop[1] == GTop[2] && GTop[2] == GTop[3] && GTop[3] == XO.X) ||
               (GMid[1] == GMid[2] && GMid[2] == GMid[3] && GMid[3] == XO.X) ||
               (GBot[1] == GBot[2] && GBot[2] == GBot[3] && GBot[3] == XO.X) ||
               (DLeftRight[1] == DLeftRight[2] && DLeftRight[2] == DLeftRight[3] && DLeftRight[3] == XO.X) ||
               (DRightLeft[1] == DRightLeft[2] && DRightLeft[2] == DRightLeft[3] && DRightLeft[3] == XO.X))
            {
                label1.Text = "Победа!";
                label1.ForeColor = Color.Red;
                moveX = !moveX;
                Move(moveX);
                DisplayLine();
                ButtonOff();
                win = true;
            }

            //Победа ноликов
            if ((VLeft[1] == VLeft[2] && VLeft[2] == VLeft[3] && VLeft[3] == XO.O) ||
               (VMid[1] == VMid[2] && VMid[2] == VMid[3] && VMid[3] == XO.O) ||
               (VRight[1] == VRight[2] && VRight[2] == VRight[3] && VRight[3] == XO.O) ||
               (GTop[1] == GTop[2] && GTop[2] == GTop[3] && GTop[3] == XO.O) ||
               (GMid[1] == GMid[2] && GMid[2] == GMid[3] && GMid[3] == XO.O) ||
               (GBot[1] == GBot[2] && GBot[2] == GBot[3] && GBot[3] == XO.O) ||
               (DLeftRight[1] == DLeftRight[2] && DLeftRight[2] == DLeftRight[3] && DLeftRight[3] == XO.O) ||
               (DRightLeft[1] == DRightLeft[2] && DRightLeft[2] == DRightLeft[3] && DRightLeft[3] == XO.O))
            {
                label1.Text = "Победа!";
                label1.ForeColor = Color.Blue;
                moveX = !moveX;
                Move(moveX);
                DisplayLine();
                ButtonOff();
                win = true;
            }

            //Ничья
            if (!win && numMove == 9)
            {
                label1.Text = " Ничья";
                label1.ForeColor = Color.Green;
                label2.Text = "";
                ButtonOff();
            }

        }

        //Отображение линий
        public void DisplayLine()
        {
            //Красные линии (победа крестиков)
            if (VLeft[1] == VLeft[2] && VLeft[2] == VLeft[3] && VLeft[3] == XO.X)
            {
                pictureBox4.BackColor = Color.Red;
                pictureBox4.Visible = true;
            }               

            if (VMid[1] == VMid[2] && VMid[2] == VMid[3] && VMid[3] == XO.X)
            {
                pictureBox5.BackColor = Color.Red;
                pictureBox5.Visible = true;
            }                

            if (VRight[1] == VRight[2] && VRight[2] == VRight[3] && VRight[3] == XO.X)
            {
                pictureBox6.BackColor = Color.Red;
                pictureBox6.Visible = true;
            }                

            if (GTop[1] == GTop[2] && GTop[2] == GTop[3] && GTop[3] == XO.X)
            {
                pictureBox1.BackColor = Color.Red;
                pictureBox1.Visible = true;
            }                

            if (GMid[1] == GMid[2] && GMid[2] == GMid[3] && GMid[3] == XO.X)
            {
                pictureBox2.BackColor = Color.Red;
                pictureBox2.Visible = true;
            }               

            if (GBot[1] == GBot[2] && GBot[2] == GBot[3] && GBot[3] == XO.X)
            {
                pictureBox3.BackColor = Color.Red;
                pictureBox3.Visible = true;
            }                

            if (DLeftRight[1] == DLeftRight[2] && DLeftRight[2] == DLeftRight[3] && DLeftRight[3] == XO.X)
            {
                pictureBox7.BackColor = Color.Red;
                pictureBox7.Visible = true;
            }               

            if (DRightLeft[1] == DRightLeft[2] && DRightLeft[2] == DRightLeft[3] && DRightLeft[3] == XO.X)
            {
                pictureBox8.BackColor = Color.Red;
                pictureBox8.Visible = true;
            }


            //Синие линии (победа ноликов)
            if (VLeft[1] == VLeft[2] && VLeft[2] == VLeft[3] && VLeft[3] == XO.O)
            {
                pictureBox4.BackColor = Color.Blue;
                pictureBox4.Visible = true;
            }

            if (VMid[1] == VMid[2] && VMid[2] == VMid[3] && VMid[3] == XO.O)
            {
                pictureBox5.BackColor = Color.Blue;
                pictureBox5.Visible = true;
            }

            if (VRight[1] == VRight[2] && VRight[2] == VRight[3] && VRight[3] == XO.O)
            {
                pictureBox6.BackColor = Color.Blue;
                pictureBox6.Visible = true;
            }

            if (GTop[1] == GTop[2] && GTop[2] == GTop[3] && GTop[3] == XO.O)
            {
                pictureBox1.BackColor = Color.Blue;
                pictureBox1.Visible = true;
            }

            if (GMid[1] == GMid[2] && GMid[2] == GMid[3] && GMid[3] == XO.O)
            {
                pictureBox2.BackColor = Color.Blue;
                pictureBox2.Visible = true;
            }

            if (GBot[1] == GBot[2] && GBot[2] == GBot[3] && GBot[3] == XO.O)
            {
                pictureBox3.BackColor = Color.Blue;
                pictureBox3.Visible = true;
            }

            if (DLeftRight[1] == DLeftRight[2] && DLeftRight[2] == DLeftRight[3] && DLeftRight[3] == XO.O)
            {
                pictureBox7.BackColor = Color.Blue;
                pictureBox7.Visible = true;
            }

            if (DRightLeft[1] == DRightLeft[2] && DRightLeft[2] == DRightLeft[3] && DRightLeft[3] == XO.O)
            {
                pictureBox8.BackColor = Color.Blue;
                pictureBox8.Visible = true;
            }

        }

        public void ButtonOff()
        {
            buttonOn1 = false;
            buttonOn2 = false;
            buttonOn3 = false;
            buttonOn4 = false;
            buttonOn5 = false;
            buttonOn6 = false;
            buttonOn7 = false;
            buttonOn8 = false;
            buttonOn9 = false;
        }

        XO[] x = new XO[10];        

        private void Form1_Load(object sender, EventArgs e)
        {
            //label1.Size.Width = 100;
        }

        public void Move(bool MoveX)
        {
            if (moveX)
            {
                label2.Text = "X";
                label2.ForeColor = Color.Red;
                label1.ForeColor = Color.Red;
            }
            else
            {
                label2.Text = "O";
                label2.ForeColor = Color.Blue;
                label1.ForeColor = Color.Blue;
            }
               
        }

        #region Отображение крестиков и ноликов
        private void button1_Click(object sender, EventArgs e)
        {   
            if (buttonOn1)
            {
                if (moveX)
                {
                    button1.Text = "X";
                    button1.ForeColor = Color.Red;
                    x[1] = XO.X;
                }
                else
                {
                    button1.Text = "O";
                    button1.ForeColor = Color.Blue;
                    x[1] = XO.O;
                }

                numMove++;
                buttonOn1 = false;
                moveX = !moveX;
                Move(moveX);
                Zapolnenie();
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (buttonOn2)
            {
                if (moveX)
                {
                    button2.Text = "X";
                    button2.ForeColor = Color.Red;
                    x[2] = XO.X;
                }
                else
                {
                    button2.Text = "O";
                    button2.ForeColor = Color.Blue;
                    x[2] = XO.O;
                }

                numMove++;
                buttonOn2 = false;
                moveX = !moveX;
                Move(moveX);
                Zapolnenie();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (buttonOn3)
            {
                if (moveX)
                {
                    button3.Text = "X";
                    button3.ForeColor = Color.Red;
                    x[3] = XO.X;
                }
                else
                {
                    button3.Text = "O";
                    button3.ForeColor = Color.Blue;
                    x[3] = XO.O;
                }

                numMove++;
                buttonOn3 = false;
                moveX = !moveX;
                Move(moveX);
                Zapolnenie();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (buttonOn4)
            {
                if (moveX)
                {
                    button4.Text = "X";
                    button4.ForeColor = Color.Red;
                    x[4] = XO.X;
                }
                else
                {
                    button4.Text = "O";
                    button4.ForeColor = Color.Blue;
                    x[4] = XO.O;
                }

                numMove++;
                buttonOn4 = false;
                moveX = !moveX;
                Move(moveX);
                Zapolnenie();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (buttonOn5)
            {
                if (moveX)
                {
                    button5.Text = "X";
                    button5.ForeColor = Color.Red;
                    x[5] = XO.X;
                }
                else
                {
                    button5.Text = "O";
                    button5.ForeColor = Color.Blue;
                    x[5] = XO.O;
                }

                numMove++;
                buttonOn5 = false;
                moveX = !moveX;
                Move(moveX);
                Zapolnenie();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (buttonOn6)
            {
                if (moveX)
                {
                    button6.Text = "X";
                    button6.ForeColor = Color.Red;
                    x[6] = XO.X;
                }
                else
                {
                    button6.Text = "O";
                    button6.ForeColor = Color.Blue;
                    x[6] = XO.O;
                }

                numMove++;
                buttonOn6 = false;
                moveX = !moveX;
                Move(moveX);
                Zapolnenie();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (buttonOn7)
            {
                if (moveX)
                {
                    button7.Text = "X";
                    button7.ForeColor = Color.Red;
                    x[7] = XO.X;
                }
                else
                {
                    button7.Text = "O";
                    button7.ForeColor = Color.Blue;
                    x[7] = XO.O;
                }

                numMove++;
                buttonOn7 = false;
                moveX = !moveX;
                Move(moveX);
                Zapolnenie();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (buttonOn8)
            {
                if (moveX)
                {
                    button8.Text = "X";
                    button8.ForeColor = Color.Red;
                    x[8] = XO.X;
                }
                else
                {
                    button8.Text = "O";
                    button8.ForeColor = Color.Blue;
                    x[8] = XO.O;
                }

                numMove++;
                buttonOn8 = false;
                moveX = !moveX;
                Move(moveX);
                Zapolnenie();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (buttonOn9)
            {
                if (moveX)
                {
                    button9.Text = "X";
                    button9.ForeColor = Color.Red;
                    x[9] = XO.X;
                }
                else
                {
                    button9.Text = "O";
                    button9.ForeColor = Color.Blue;
                    x[9] = XO.O;
                }

                numMove++;
                buttonOn9 = false;
                moveX = !moveX;
                Move(moveX);
                Zapolnenie();
            }
        }
        #endregion

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            NewGame();       

        }

        public void NewGame()
        {
            int i;

            //Активация кнопок
            buttonOn1 = true;
            buttonOn2 = true;
            buttonOn3 = true;
            buttonOn4 = true;
            buttonOn5 = true;
            buttonOn6 = true;
            buttonOn7 = true;
            buttonOn8 = true;
            buttonOn9 = true;

            //Очистка содержимого кнопок
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            //1-ый ход крестиков
            moveX = true;            
            numMove = 0;

            //Фрагмент не требуется, т.к. пересчитывается каждый раз заново
            for (i = 1; i <= 3; i++)
            {
                VLeft[i] = XO.No;
                VMid[i] = XO.No;
                VRight[i] = XO.No;

                GTop[i] = XO.No;
                GMid[i] = XO.No;
                GBot[i] = XO.No;

                DLeftRight[i] = XO.No;
                DRightLeft[i] = XO.No;
            }

            //Очистка значений крестиков/ноликов предыдущей партии
            for (i = 1; i <= 9; i++)            
                x[i] = XO.No;            

            //Текст меток по умолчанию
            label1.Text = "   Ход:";
            label1.ForeColor = Color.Red;
            label2.Text = "X";
            label2.ForeColor = Color.Red;

            //Отключение видимости линий
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {            
            GraphicsPath pathD1 = new GraphicsPath();
            pathD1.AddPolygon(new Point[] {new Point(15, 17), new Point(17, 15), new Point(245, 243), new Point(243, 245) });
            Region regionD1 = new Region(pathD1);
            pictureBox7.Location = new Point(0, 0);
            pictureBox7.Size = new Size(250, 250);
            pictureBox7.Region = regionD1;           

            GraphicsPath pathD2 = new GraphicsPath();
            pathD2.AddPolygon(new Point[] { new Point(243, 15), new Point(245, 17), new Point(17, 245), new Point(15, 243) });
            Region regionD2 = new Region(pathD2);
            pictureBox8.Location = new Point(0, 0);
            pictureBox8.Size = new Size(340, 340);
            pictureBox8.Region = regionD2;
            //Icon.Size = new Size(256, 256);

            //System.Drawing.Drawing2D.GraphicsPath pathD1 = new System.Drawing.Drawing2D.GraphicsPath();
            //pathD1.AddPolygon(new System.Drawing.Point[] { new System.Drawing.Point(15, 17), new System.Drawing.Point(17, 15), new System.Drawing.Point(245, 243), new System.Drawing.Point(243, 245) });
            //System.Drawing.Region regionD1 = new System.Drawing.Region(pathD1);
            //pictureBox7.Region = regionD1;
            
            //System.Drawing.Drawing2D.GraphicsPath pathD2 = new System.Drawing.Drawing2D.GraphicsPath();
            //pathD2.AddPolygon(new System.Drawing.Point[] { new System.Drawing.Point(243, 15), new System.Drawing.Point(245, 17), new System.Drawing.Point(17, 245), new System.Drawing.Point(15, 243) });
            //System.Drawing.Region regionD2 = new System.Drawing.Region(pathD2);
            //pictureBox8.Region = regionD2;
        }                  
        
    }
}