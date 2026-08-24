using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WfGameProject.Util;

namespace WfGameProject
{
    public partial class FormChooseLevel : Form
    {
        private Form1 form1;
        private Form2 form2;
        private Form3 form3;

        private List<bool> listStates;
        private string playerName = "Unknown";

        private RecordsDto recordsDto;

        private static bool needNewForm1 = true;
        private static bool needNewForm2 = true;
        private static bool needNewForm3 = true;

        Dictionary<string, List<bool>> dictPlayers = new Dictionary<string, List<bool>>();

        public FormChooseLevel()
        {
            InitializeComponent();
        }

        private void FormChooseLevel_Load(object sender, EventArgs e)
        {
            CreateStateList();
            SetButtonColors(listStates);
            dictPlayers.Add(playerName, listStates);
        }

        public static void SetNeedNewForm3(bool needNewForm3ForSetter)
        {
            needNewForm3 = needNewForm3ForSetter;
        }

        public static void SetNeedNewForm2(bool needNewForm2ForSetter)
        {
            needNewForm2 = needNewForm2ForSetter;
        }

        public static void SetNeedNewForm1(bool needNewForm1ForSetter)
        {
            needNewForm1 = needNewForm1ForSetter;
        }

        public void SetListStates(List<bool> listStates)
        {
            this.listStates = listStates;
        }

        public List<bool> GetListStates()
        {
            return listStates;
        }

        private void SetButtonColors(List<bool> listStates)
        {
            if (!listStates[0])
            {
                button2.BackColor = Color.Gray;
            }
            if (!listStates[1])
            {
                button3.BackColor = Color.Gray;
            }
        }

        public void SetRecordsDto(RecordsDto recordsDto)
        {
            this.recordsDto = recordsDto;
        }

        private List<bool> CreateStateList()
        {
            listStates = new List<bool>
            {
                false,
                false,
                false
            };
            return listStates;
        }

        private void notifyHandlerForm1(string message)
        {
            button2.BackColor = Color.RosyBrown;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CreateForm1();
            form1.Notify += notifyHandlerForm1;
            form1.Show();
            form1.SetListStates(listStates);
            form1.SetPlayerName(playerName);
            new PreForm1().ShowDialog();
        }

        private void notifyHandlerForm2(string message)
        {
            button3.BackColor = Color.RosyBrown;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (listStates[0] || 1==1)
            {
                CreateForm2();
                form2.Notify += notifyHandlerForm2;
                form2.Show();
                form2.SetListStates(listStates);
                form2.SetPlayerName(playerName);
                new PreForm2().ShowDialog();
            }
        }

        private void notifyHandlerForm3(string message)
        {
            button3.BackColor = Color.RosyBrown;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (listStates[1] || 1==1)
            {
                CreateForm3();
                form3.Notify += notifyHandlerForm3;
                form3.Show();
                form3.SetListStates(listStates);
                form3.SetPlayerName(playerName);
                new PreForm3().ShowDialog();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TbPlayerName_TextChanged(object sender, EventArgs e)
        {
            playerName = tbPlayerName.Text;
            if(playerName.Length > 0)
            {
                if (dictPlayers.ContainsKey(playerName))
                {
                    listStates = dictPlayers[playerName];
                } else
                {
                    dictPlayers.Add(playerName, CreateStateList());
                }
                SetButtonColors(listStates);
            }
        }

        private void CreateForm1()
        {
            if (form1 == null || needNewForm1)
            {
                form1 = new Form1();
                form1.SetRecordsDto(recordsDto);
                needNewForm1 = false;
            }
        }

        private void CreateForm2()
        {
            if (form2 == null || needNewForm2)
            {
                form2 = new Form2();
                form2.SetRecordsDto(recordsDto);
                needNewForm2 = false;
            }
        }

        private void CreateForm3()
        {
            if (form3 == null || needNewForm3)
            {
                form3 = new Form3();
                form3.SetRecordsDto(recordsDto);
                needNewForm3 = false;
            }
        }

        private void FormChooseLevel_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormStart.SetNeedNewFormChooseLevel(true);
        }
    }
}
