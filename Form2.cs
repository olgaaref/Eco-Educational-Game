using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WfGameProject.Util;

namespace WfGameProject
{
    public partial class Form2 : Form
    {
        private Mode2 mode;

        private List<bool> listStates;

        public delegate void MyfoHandler(string message);

        public event MyfoHandler Notify;

        private RecordsDto recordsDto;

        public Form2()
        {
            InitializeComponent();
        }

        public void SetListStates(List<bool> listStates)
        {
            this.listStates = listStates;
        }

        public void SetGamePassed(bool gamePassed)
        {
            Notify?.Invoke("Level passed");
            this.listStates[1] = gamePassed;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            moveConntrols();
            CreateMode2();
            Log("Form1 loaded");
        }

        private void moveConntrols()
        {
            if (this.Controls.Count <= 1) return;
            foreach (Control control in this.Controls)
            {
                if (control != pbGrass)
                {
                    pbGrass.Controls.Add(control);
                    Log("Add: " + control.Name);
                    moveConntrols();
                    break;
                }
            }
        }

        public void SetRecordsDto(RecordsDto recordsDto)
        {
            this.recordsDto = recordsDto;
        }

        private void CreateMode2()
        {
            mode = new Mode2(this, labFail);
            mode.SetRecordsDto(recordsDto);
        }

        public void SetPlayerName(string playerName)
        {
            mode.SetPlayerName(playerName);
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormChooseLevel.SetNeedNewForm2(true);
        }
    }
}
