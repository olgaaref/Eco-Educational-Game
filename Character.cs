using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfGameProject
{
    class Character
    {
        private PictureBox pbCharacter;
        private Label lab;

        public Character(PictureBox pbCharacter, Label lab)
        {
            this.pbCharacter = pbCharacter;
            this.lab = lab;
            Init();
        }

        public void Init()
        {
            lab.Width = 40;
            lab.Height = 16;
            SetLabel();
            _ = SetText("Привет!");
        }

        private void SetLabel()
        {
            lab.Left = pbCharacter.Left;
            lab.Top = pbCharacter.Top - lab.Height;
        }

        public void SetLeft(int left)
        {
            pbCharacter.Left = left;
            SetLabel();
        }

        public void SetTop(int top)
        {
            pbCharacter.Top = top;
            SetLabel();
        }

        public int GetLeft()
        {
            return pbCharacter.Left;
        }

        public int GetTop()
        {
            return pbCharacter.Top;
        }

        public void LabelVisible(bool isVisible)
        {
            lab.Visible = isVisible;
        }

        public async Task SetText(string text)
        {
            lab.Visible = true; 
            lab.Text = text;
            await Task.Delay(1000);
            lab.Text = "";
            lab.Visible = false;
        }
    }
}
