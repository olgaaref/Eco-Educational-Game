using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfGameProject
{
    class ProgressBar
    {

        private PictureBox backGround;
        private PictureBox front;
        private Label labPercentsBack;
        private Label labPercentsFront;

        private PictureBox control;
        private int Top = 34;
        private int Left = 39;
        private int Width = 128;
        private int Height = 22;
        private int maxCounterNumber;
        private int currentCounter = 0;
        private Color backColorOfBackGround = Color.White;
        private Color backColorOfFront = Color.Crimson;
        private bool showLabPercents = false;

        public ProgressBar(PictureBox control, int Top, int Left, int Width, int Height, int maxCounterNumber)
        {
            this.control = control;
            this.Top = Top;
            this.Left = Left;
            this.Width = Width;
            this.Height = Height;
            this.maxCounterNumber = maxCounterNumber;
            Init();
        }

        private void Init()
        {
            backGround = new PictureBox();
            backGround.BackColor = backColorOfBackGround;
            backGround.Top = Top;
            backGround.Left = Left;
            backGround.Width = Width;
            backGround.Height = Height;

            front = new PictureBox();
            front.BackColor = backColorOfFront;
            front.Top = backGround.Top;
            front.Left = backGround.Left;
            front.Width = 0;
            front.Height = backGround.Height;

            labPercentsFront = new Label();
            labPercentsFront.BackColor = Color.Transparent;
            labPercentsFront.ForeColor = backGround.BackColor;
            labPercentsFront.Width = 40;
            labPercentsFront.Height = 18;
            labPercentsFront.Top = 3;
            labPercentsFront.Left = (backGround.Width / 2) - (labPercentsFront.Width / 2) + 2;
            labPercentsFront.Text = "0%";
            labPercentsFront.TextAlign = ContentAlignment.MiddleCenter;

            labPercentsBack = new Label();
            labPercentsBack.BackColor = Color.Transparent;
            //labPercentsBack.ForeColor = front.BackColor;
            labPercentsBack.ForeColor = Color.Black;
            labPercentsBack.Width = 40;
            labPercentsBack.Height = 18;
            labPercentsBack.Top = 3;
            labPercentsBack.Left = (backGround.Width / 2) - (labPercentsBack.Width / 2) + 2;
            labPercentsBack.Text = "0%";
            labPercentsBack.TextAlign = ContentAlignment.MiddleCenter;

            control.Controls.Add(front);
            control.Controls.Add(backGround);
            front.Controls.Add(labPercentsFront);
            backGround.Controls.Add(labPercentsBack);
            backGround.BringToFront();
            front.BringToFront();
            labPercentsFront.BringToFront();
            labPercentsBack.BringToFront();
        }

      
        public void SetShowPercents(bool showLabPercents)
        {
            this.showLabPercents = showLabPercents;
        }

        public void SetBackColorOfBackGround(Color backColorOfBackGround)
        {
            this.backColorOfBackGround = backColorOfBackGround;
            backGround.BackColor = backColorOfBackGround;
            labPercentsFront.ForeColor = backGround.BackColor;
        }

        public void SetBackColorOfFront(Color backColorOfFront)
        {
            this.backColorOfFront = backColorOfFront;
            front.BackColor = backColorOfFront;
            //labPercentsBack.ForeColor = front.BackColor;
        }

        public void AddSteps(int stepCount)
        {
            int frontWidth = front.Width;
            int backGroundWidth = backGround.Width;
            if (frontWidth < backGroundWidth)
            {
                currentCounter += stepCount;
                front.Width = currentCounter * backGround.Width / maxCounterNumber;
                int percent = 100 * currentCounter / maxCounterNumber;
                labPercentsFront.Text = percent.ToString() + "%";
                labPercentsBack.Text = labPercentsFront.Text;
                if(frontWidth > backGroundWidth)
                {
                    front.Width = backGroundWidth;
                }
            } 
        }
    }
}
