using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfGameProject
{
    class TrafficLight
    {
        private bool activeGame = true;
        private bool freeCross = true;

        private int x;
        private int y;

        private PictureBox pbArea;
        private PictureBox pbBase = new PictureBox();
        private PictureBox pbRed = new PictureBox();
        private PictureBox pbYellow = new PictureBox();
        private PictureBox pbGreen = new PictureBox();

        public TrafficLight(PictureBox pbArea, int x, int y)
        {
            this.pbArea = pbArea;
            this.x = x;
            this.y = y;
            Init();
        }

        private void Init()
        {
            List<PictureBox> lights = new List<PictureBox>();
            lights.Add(pbRed);
            lights.Add(pbYellow);
            lights.Add(pbGreen);
            foreach(PictureBox pb in lights)
            {
                pbBase.Controls.Add(pb);
                pb.Width = 25;
                pb.Height = 25;
            }
            pbRed.Top = 0;
            pbRed.Left = 0;
            pbRed.BackColor = Color.Red;
            pbYellow.Top = pbRed.Bottom + 2;
            pbYellow.Left = 0;
            pbYellow.BackColor = Color.Gray;
            pbGreen.Top = pbYellow.Bottom + 2;
            pbGreen.Left = 0;
            pbGreen.BackColor = Color.Gray;
            pbBase.Width = pbRed.Width;
            pbBase.Height = pbGreen.Bottom;
            pbBase.Top = y;
            pbBase.Left = x;
            pbBase.BackColor = Color.Transparent;
            pbArea.Controls.Add(pbBase);
            pbBase.BringToFront();
            _ = SwitchColorAsync();
        }

        public bool GetFreeCross()
        {
            return freeCross;
        }

        public void SetActiveGame(bool activeGame)
        {
            this.activeGame = activeGame;
        }

        public async Task SwitchColorAsync()
        {
            while (activeGame)
            {
                freeCross = false;
                pbRed.BackColor = Color.Red;
                pbRed.BorderStyle = BorderStyle.FixedSingle;
                pbYellow.BackColor = Color.Gray;
                pbYellow.BorderStyle = BorderStyle.None;
                await Task.Delay(5000);

                pbRed.BackColor = Color.Gray;
                pbRed.BorderStyle = BorderStyle.None;
                pbYellow.BackColor = Color.Yellow;
                pbYellow.BorderStyle = BorderStyle.FixedSingle;
                await Task.Delay(2000);

                pbYellow.BackColor = Color.Gray;
                pbYellow.BorderStyle = BorderStyle.None;
                pbGreen.BackColor = Color.Lime;
                pbGreen.BorderStyle = BorderStyle.FixedSingle;
                freeCross = true;
                await Task.Delay(5000);

                pbGreen.BackColor = Color.Gray;
                pbGreen.BorderStyle = BorderStyle.None;
                pbYellow.BackColor = Color.Yellow;
                pbYellow.BorderStyle = BorderStyle.FixedSingle;
                await Task.Delay(2000);
            }
        }
    }
}
