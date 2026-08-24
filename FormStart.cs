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
using static WfGameProject.FileUtils;

namespace WfGameProject
{
    public partial class FormStart : Form
    {
        private FormRecords formRecords;
        private FormChooseLevel formChooseLevel;
        private FormOptions formOptions;
        private FormAbout formAbout;
        private RecordsDto recordsDto;

        private static bool needNewFormChooseLevel = true;
        private static bool needNewFormOptions = true;
        private static bool needNewFormRecords = true;
        private static bool needNewFormAbout = true;

        public FormStart()
        {
            InitializeComponent();
        }

        //Создание и инициализация объекта с сохраненными записями рекордов (recordsDto)
        private void FormStart_Load(object sender, EventArgs e)
        {
            recordsDto = GetRecordsDtoBlank();
            _ = GetRecordsDtoFromFile(recordsDto);
        }

        public static void SetNeedNewFormAbout(bool needNewFormAboutForSetter)
        {
            needNewFormAbout = needNewFormAboutForSetter;
        }

        public static void SetNeedNewFormRecords(bool needNewFormRecordsForSetter)
        {
            needNewFormRecords = needNewFormRecordsForSetter;
        }

        public static void SetNeedNewFormOptions(bool needNewFormOptionsForSetter)
        {
            needNewFormOptions = needNewFormOptionsForSetter;
        }

        public static void SetNeedNewFormChooseLevel(bool needNewFormChooseLevelForSetter)
        {
            needNewFormChooseLevel = needNewFormChooseLevelForSetter;
        }

        //Создание и открытие формы выбора уровня игры (formChooseLevel)
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            this.CreateFormChooseLevel();
            formChooseLevel.Show();
        }

        //Создание и открытие формы об игре (formAbout)
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormAbout();
            formAbout.Show();
        }

        //Создание и открытие формы рекордов (formRecords)
        private void RecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormRecords();
            formRecords.Show();
        }

        //Создание и открытие формы настроек (formOptions)
        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateFormOptions();
            formOptions.Show();
        }

        //Закрытие приложения
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Создание дефолтного объекта для хранения инфоромации о рекордах
        private RecordsDto GetRecordsDtoBlank()
        {
            long lTime = Config.DEFAULT_LIDER_RECORD_TIME;
            string name = Config.DEFAULT_LIDER_NAME;
            List<Dictionary<string, List<BestResult>>> listOfLevelRecords = new List<Dictionary<string, List<BestResult>>>(); 
            for (int i = 0; i < Config.LEVEL_MAX_NUMBER; i++)
            {
                string listName = "BestResult" + i;
                List<BestResult> list = new List<BestResult>();
                Dictionary<string, List<BestResult>> map = new Dictionary<string, List<BestResult>>();
                for (int j = 0; j < 3; j++)
                {
                    BestResult bestResult = new BestResult();
                    bestResult.name = name;
                    bestResult.result = lTime;
                    list.Add(bestResult);
                }
                map.Add(listName, list);
                listOfLevelRecords.Add(map);
            }

            recordsDto = new RecordsDto(listOfLevelRecords);
            return recordsDto;
        }

        private void CreateFormAbout()
        {
            if (formAbout == null || needNewFormAbout)
            {
                formAbout = new FormAbout();
                needNewFormAbout = false;
            }
        }

        //Создание формы рекордов (formRecords) с передачей информации о рекордах
        private void CreateFormRecords()
        {
            if (formRecords == null || needNewFormRecords)
            {
                formRecords = new FormRecords();
                formRecords.SetRecordsDto(recordsDto);
                needNewFormRecords = false;
            }
        }

        //Создание формы выбора уровня (formChooseLevel) с передачей информации о рекордах
        private void CreateFormChooseLevel()
        {
            if (formChooseLevel == null || needNewFormChooseLevel)
            {
                formChooseLevel = new FormChooseLevel();
                formChooseLevel.SetRecordsDto(recordsDto);
                needNewFormChooseLevel = false;
            }
        }

        private void CreateFormOptions()
        {
            if (formOptions == null || needNewFormOptions)
            {
                formOptions = new FormOptions();
                formOptions.SetRecordsDto(recordsDto);
                needNewFormOptions = false;
            }
        }

        private void MenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
