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
    public partial class Form1 : Form
    {
        private Mode1 mode1;

        private List<bool> listStates;

        public delegate void MyfoHandler(string message);

        public event MyfoHandler Notify;

        private RecordsDto recordsDto;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            moveConntrols();
            CreateMode1();
            Log("Form1 loaded");
        }


        public void SetListStates(List<bool> listStates)
        {
            this.listStates = listStates;
        }

        public void SetGamePassed(bool gamePassed)
        {
            Notify?.Invoke("Level passed");
            this.listStates[0] = gamePassed;
        }

        public void SetRecordsDto(RecordsDto recordsDto)
        {
            this.recordsDto = recordsDto;
        }

        public void SetPlayerName(string playerName)
        {
            mode1.SetPlayerName(playerName);
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _ = mode1.ChooseActionWithKeyDownAsync(sender, e);
        }

        private void CreateMode1()
        {
            mode1 = new Mode1(this, labFinal);
            mode1.SetRecordsDto(recordsDto);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormChooseLevel.SetNeedNewForm1(true);
        }
    }
}
