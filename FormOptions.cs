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
using static WfGameProject.FileUtils;
using static WfGameProject.Util;

namespace WfGameProject
{
    public partial class FormOptions : Form
    {
        private RecordsDto recordsDto;
        private string fullFileName;
        private string characterTextFish;
        private string characterTextTrash;

        public FormOptions()
        {
            InitializeComponent();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            GetDataFromConfig();
            SetData();
        }

        private void GetDataFromConfig()
        {
            fullFileName = Config.DEFAULT_RECORD_FILE_NAME;
            characterTextFish = Config.DEFAULT_PLAYER_MSG_FISH_COLISION;
            characterTextTrash = Config.DEFAULT_PLAYER_MSG_TRASH_COLISION;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveData();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string path = ChooseFileFullName(sender, e);
            if (path == null || path == "")
            {
                tbFullFileName.Text = fullFileName;
            }
            else
            {
                tbFullFileName.Text = path;
            }
        }

        public void SetRecordsDto(RecordsDto recordsDto)
        {
            this.recordsDto = recordsDto;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            SetDefaultData();
        }

        private void SetData()
        {
            tbFullFileName.Text = Config.RECORD_FILE_NAME;
            tbCharacterTextFish.Text = Config.PLAYER_MSG_FISH_COLISION;
            tbCharacterTextTrash.Text = Config.PLAYER_MSG_TRASH_COLISION;
        }

        private void SetDefaultData()
        {
            tbFullFileName.Text = fullFileName;
            tbCharacterTextFish.Text = characterTextFish;
            tbCharacterTextTrash.Text = characterTextTrash;
        }

        private void SaveData()
        {
            Config.RECORD_FILE_NAME = tbFullFileName.Text;
            _ = GetRecordsDtoFromFile(recordsDto);
            Log("new record file name is " + Config.RECORD_FILE_NAME);
            Config.PLAYER_MSG_FISH_COLISION = tbCharacterTextFish.Text;
            Config.PLAYER_MSG_TRASH_COLISION = tbCharacterTextTrash.Text;
        }

        private void TbCharacterTextFish_TextChanged(object sender, EventArgs e)
        {
            if(tbCharacterTextFish.Text.Length > Config.PLAYER_MSG_CHAR_LIMIT)
            {
                tbCharacterTextFish.Text = tbCharacterTextFish.Text.Substring(0, Config.PLAYER_MSG_CHAR_LIMIT);
                tbCharacterTextFish.SelectionStart = tbCharacterTextFish.Text.Length;
                labUnderCharacterTextFish.Text = "* Ой-ой. Длина текста не должна превышать " + Config.PLAYER_MSG_CHAR_LIMIT + " символов";
            }
            else
            {
                labUnderCharacterTextFish.Text = "";
            }
        }

        private void TbCharacterTextTrash_TextChanged(object sender, EventArgs e)
        {
            if (tbCharacterTextTrash.Text.Length > Config.PLAYER_MSG_CHAR_LIMIT)
            {
                tbCharacterTextTrash.Text = tbCharacterTextTrash.Text.Substring(0, Config.PLAYER_MSG_CHAR_LIMIT);
                tbCharacterTextTrash.SelectionStart = tbCharacterTextTrash.Text.Length;
                labUnderCharacterTextTrash.Text = "* Ой-ой. Длина текста не должна превышать " + Config.PLAYER_MSG_CHAR_LIMIT + " символов";
            } else
            {
                labUnderCharacterTextTrash.Text = "";
            }
        }

        private void FormOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormStart.SetNeedNewFormOptions(true);
        }
    }
}
