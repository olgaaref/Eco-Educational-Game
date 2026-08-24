using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfGameProject
{
    public partial class FormRecords : Form
    {
        private RecordsDto recordsDto;

        public FormRecords()
        {
            InitializeComponent();
        }

        private void FormRecords_Load(object sender, EventArgs e)
        {
        }

        public void SetRecordsDto(RecordsDto recordsDto)
        {
            this.recordsDto = recordsDto;
            ShowRecords(recordsDto);
        }

        private void ShowRecords(RecordsDto recordsDto)
        {
            labLevel1Name1.Text = recordsDto.listLevelRecords[0]["BestResult0"][0].name;    
            labLevel1Name2.Text = recordsDto.listLevelRecords[0]["BestResult0"][1].name;
            labLevel1Name3.Text = recordsDto.listLevelRecords[0]["BestResult0"][2].name;
            if (recordsDto.listLevelRecords[0]["BestResult0"][0].result != Config.DEFAULT_LIDER_RECORD_TIME)
            {
                labLevel1Time1.Text = recordsDto.listLevelRecords[0]["BestResult0"][0].result.ToString();
            }
            if (recordsDto.listLevelRecords[0]["BestResult0"][1].result != Config.DEFAULT_LIDER_RECORD_TIME)
            {
                labLevel1Time2.Text = recordsDto.listLevelRecords[0]["BestResult0"][1].result.ToString();
            }
            if (recordsDto.listLevelRecords[0]["BestResult0"][2].result != Config.DEFAULT_LIDER_RECORD_TIME)
            {
                labLevel1Time3.Text = recordsDto.listLevelRecords[0]["BestResult0"][2].result.ToString();
            }

            labLevel2Name1.Text = recordsDto.listLevelRecords[1]["BestResult1"][0].name;
            labLevel2Name2.Text = recordsDto.listLevelRecords[1]["BestResult1"][1].name;
            labLevel2Name3.Text = recordsDto.listLevelRecords[1]["BestResult1"][2].name;
            if (recordsDto.listLevelRecords[1]["BestResult1"][0].result != Config.DEFAULT_LIDER_RECORD_TIME)
            {
                labLevel2Time1.Text = recordsDto.listLevelRecords[1]["BestResult1"][0].result.ToString();
            }
            if (recordsDto.listLevelRecords[1]["BestResult1"][1].result != Config.DEFAULT_LIDER_RECORD_TIME)
            {
                labLevel2Time2.Text = recordsDto.listLevelRecords[1]["BestResult1"][1].result.ToString();
            }
            if (recordsDto.listLevelRecords[1]["BestResult1"][2].result != Config.DEFAULT_LIDER_RECORD_TIME)
            {
                labLevel2Time3.Text = recordsDto.listLevelRecords[1]["BestResult1"][2].result.ToString();
            }

            labLevel3Name1.Text = recordsDto.listLevelRecords[2]["BestResult2"][0].name;
            labLevel3Name2.Text = recordsDto.listLevelRecords[2]["BestResult2"][1].name;
            labLevel3Name3.Text = recordsDto.listLevelRecords[2]["BestResult2"][2].name;
            if (recordsDto.listLevelRecords[2]["BestResult2"][0].result != Config.DEFAULT_LIDER_RECORD_TIME)
            {
                labLevel3Time1.Text = recordsDto.listLevelRecords[2]["BestResult2"][0].result.ToString();
            }
            if (recordsDto.listLevelRecords[2]["BestResult2"][1].result != Config.DEFAULT_LIDER_RECORD_TIME)
            {
                labLevel3Time2.Text = recordsDto.listLevelRecords[2]["BestResult2"][1].result.ToString();
            }
            if (recordsDto.listLevelRecords[2]["BestResult2"][2].result != Config.DEFAULT_LIDER_RECORD_TIME)
            {
                labLevel3Time3.Text = recordsDto.listLevelRecords[2]["BestResult2"][2].result.ToString();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormRecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormStart.SetNeedNewFormRecords(true);
        }
    }
}
