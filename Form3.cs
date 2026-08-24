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
    public partial class Form3 : Form
    {
        Mode3 mode;

        private RecordsDto recordsDto;

        private List<bool> listStates;

        public delegate void MyfoHandler(string message);

        public event MyfoHandler Notify;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            moveConntrols();
            CreateMode3();
            Log("Form1 loaded");
        }

        private void moveConntrols()
        {
            if (this.Controls.Count <= 1) return;
            foreach (Control control in this.Controls)
            {
                if (control != pbArea)
                {
                    pbArea.Controls.Add(control);
                    Log("Add: " + control.Name);
                    moveConntrols();
                    break;
                }
            }
            pbArea.BringToFront();
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            _ = mode.Form3KeyDownAsync(sender, e);
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            mode.Reset();
            btnReset.Visible = false;
            Focus();
        }

        public void SetRecordsDto(RecordsDto recordsDto)
        {
            this.recordsDto = recordsDto;
        }

        private void CreateMode3()
        {
            mode = new Mode3(this, labFinal);
            mode.SetRecordsDto(recordsDto);
        }

        public void SetPlayerName(string playerName)
        {
            mode.SetPlayerName(playerName);
        }

        public void SetListStates(List<bool> listStates)
        {
            this.listStates = listStates;
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormChooseLevel.SetNeedNewForm3(true);
        }
    }
}
