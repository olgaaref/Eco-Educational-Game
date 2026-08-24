using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using static WfGameProject.Util;
using System.Drawing;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WfGameProject
{
    class Mode2
    {
        private IEnumerable controls;

        private Form2 form2;

        private bool isActiveGame = true;

        private List<PictureBox> listTrash;
        private List<PictureBox> listTrash1;
        private List<PictureBox> listTrash2;
        private List<PictureBox> listTrash3;
        private List<PictureBox> listTrash4;
        private List<PictureBox> listBaskets;
        private List<Image> listImageForTrash1;
        private List<Image> listImageForTrash2;
        private List<Image> listImageForTrash3;
        private List<Image> listImageForTrash4;

        private Dictionary<String, String> dictBaskets;

        private PictureBox pbBasket1;
        private PictureBox pbBasket2;
        private PictureBox pbBasket3;
        private PictureBox pbBasket4;
        private PictureBox pbGrass;

        private Label labFail;

        private bool isDown;

        private int stepLiderCounter;
        private int stepPlayerCounter;
        private int allTargetElementCount;

        private int imageCounterTrash1 = 0;
        private int imageCounterTrash2 = 0;
        private int imageCounterTrash3 = 0;
        private int imageCounterTrash4 = 0;

        ProgressBar progressBarPlayer;
        ProgressBar progressBarLider;

        private RecordsDto recordsDto;

        private string playerName;

        private long winGameTime;
        private Stopwatch stopwatch;

        private bool firstStep = true;

        private int trashLeft;
        private int trashTop;

        private Button btnContinue;

        public Mode2(Form2 form2, Label labFail)
        {
            this.form2 = form2;
            this.labFail = labFail;
            Init();
        }

        // Загрузка уровня 2
        public void Init()
        {
            controls = form2.Controls;
            GetListsOfDifferentTypesOfTrash(controls);
            GetListOfAllTypesOfTrash();
            SetTrashHandlers(listTrash);
            GetBasketsForDiffrentTypesOfTrash(controls);
            GetListOfAllBaskets();
            GetDictionaryOfCorrespondencesOfBasketsAndTypesOfTrash();
            pbGrass = getPbByName(controls, "pbGrass");
            btnContinue = getBtnByName(pbGrass.Controls, "btnContinue");
            allTargetElementCount = listTrash.Count;
            GetProgressBars();
            GetListsOfImagesForDiffrentTypesOfTrash();
            Log("Модуль уровня 2 успешно загружен");
        }

        // Получение списков картинок для разных видов мусора
        private void GetListsOfImagesForDiffrentTypesOfTrash()
        {
            listImageForTrash4 = new List<Image>();
            listImageForTrash4.Add(Properties.Resources.clipart160016);
            listImageForTrash4.Add(Properties.Resources.clipart33912);
            listImageForTrash4.Add(Properties.Resources.clipart869058);
            listImageForTrash3 = new List<Image>();
            listImageForTrash3.Add(Properties.Resources.clipart1871024);
            listImageForTrash3.Add(Properties.Resources.clipart2756361);
            listImageForTrash2 = new List<Image>();
            listImageForTrash2.Add(Properties.Resources.clipart3126672);
            listImageForTrash2.Add(Properties.Resources.clipart673791);
            listImageForTrash1 = new List<Image>();
            listImageForTrash1.Add(Properties.Resources.clipart65543);
            listImageForTrash1.Add(Properties.Resources.clipart1455120);
            listImageForTrash1.Add(Properties.Resources.clipart2368503);
        }

        // Получение прогресс-баров лидера и игрока
        private void GetProgressBars()
        {
            progressBarLider = new ProgressBar(pbGrass, pbGrass.Top + 20, pbGrass.Left + 20, 128, 22, allTargetElementCount);
            progressBarLider.SetBackColorOfFront(Color.Blue);
            progressBarPlayer = new ProgressBar(pbGrass, pbGrass.Top + 50, pbGrass.Left + 20, 128, 22, allTargetElementCount);
        }

        // Получение словаря соответствия корзин и видов мусора
        private void GetDictionaryOfCorrespondencesOfBasketsAndTypesOfTrash()
        {
            dictBaskets = new Dictionary<string, string>();
            dictBaskets.Add("Basket1", "Trash1");
            dictBaskets.Add("Basket2", "Trash2");
            dictBaskets.Add("Basket3", "Trash3");
            dictBaskets.Add("Basket4", "Trash4");
        }

        // Получение корзин для разных видов мусора
        private void GetBasketsForDiffrentTypesOfTrash(IEnumerable controls)
        {
            pbBasket1 = getPbByName(controls, "pbBasket1");
            pbBasket2 = getPbByName(controls, "pbBasket2");
            pbBasket3 = getPbByName(controls, "pbBasket3");
            pbBasket4 = getPbByName(controls, "pbBasket4");
        }

        // Получение списка всех корзин
        private void GetListOfAllBaskets()
        {
            listBaskets = new List<PictureBox>();
            listBaskets.Add(pbBasket1);
            listBaskets.Add(pbBasket2);
            listBaskets.Add(pbBasket3);
            listBaskets.Add(pbBasket4);
        }

        // Получение отдельных списков мусора по тэгам
        private void GetListsOfDifferentTypesOfTrash(IEnumerable controls)
        {
            listTrash1 = getListByTag(controls, Config.TAG_TRASH_1);
            listTrash2 = getListByTag(controls, Config.TAG_TRASH_2);
            listTrash3 = getListByTag(controls, Config.TAG_TRASH_3);
            listTrash4 = getListByTag(controls, Config.TAG_TRASH_4);
        }

        // Получение общего списка мусора
        private void GetListOfAllTypesOfTrash()
        {
            listTrash = new List<PictureBox>();
            listTrash.AddRange(listTrash1);
            listTrash.AddRange(listTrash2);
            listTrash.AddRange(listTrash3);
            listTrash.AddRange(listTrash4);
        }

        // Получение имени игрока из Form2
        public void SetPlayerName(string playerName)
        {
            this.playerName = playerName;
        }

        // Получение DTO рекордов из Form2
        public void SetRecordsDto(RecordsDto recordsDto)
        {
            this.recordsDto = recordsDto;
        }

        // Запускает и поддерживает прогресс-бар лидера
        private async Task StartProgressBarLiderAsync(long maxMiliSecondNumber, int allTargetElementCount)
        {
            if (!isActiveGame) return;
            int timeInterval = (int)maxMiliSecondNumber / allTargetElementCount;
            bool go = true;
            for (int i = 0; i < allTargetElementCount && go; i++)
            {
                if (!isActiveGame)
                {
                    break;
                }
                if (i == (allTargetElementCount - 1) || stepLiderCounter >= allTargetElementCount)
                {
                    go = false;
                    break;
                }
                await Task.Delay(timeInterval);
                progressBarLider.AddSteps(1);
                stepLiderCounter++;               
            }
            isActiveGame = false;
            stopwatch.Stop();
            if (!go) ShowFinalMessage(labFail, Config.MSG_FINAL_LIDER_WIN);
            btnContinue.Visible = true;
        }

        // Установка обработчиков для мусора
        private void SetTrashHandlers(List<PictureBox> listTrash)
        {
            foreach(PictureBox pb in listTrash)
            {
                pb.BackColor = Color.Gray;
                pb.MouseDown += TakeTrashHandler;
                pb.MouseMove += CarryTrashHandler;
                pb.MouseUp += DropTrashHandler;
            }
        }

        // Обработчик переноса мусора мышкой
        private void CarryTrashHandler(object sender, MouseEventArgs e)
        {
            Control c = sender as Control;
            if (isDown)
            {              
               c.Location = pbGrass.PointToClient(Control.MousePosition);
            }
        }

        // Контроль начала игры по первому шагу
        private void DoFirstStep()
        {
            if (firstStep)
            {
                firstStep = false;
                _ = StartProgressBarLiderAsync(Config.LIDER_WIN_TIME_LEVEL2, allTargetElementCount);
                stopwatch = new Stopwatch();
                stopwatch.Start();
            }
        }

        // Обработчик поднятия мусора мышкой
        private void TakeTrashHandler(object sender, MouseEventArgs e)
        {
            DoFirstStep();
            Control c = sender as Control;
            trashLeft = c.Left;
            trashTop = c.Top;
            isDown = true;
            _ = SelectTrashImage(sender, Config.IMAGE_DISPLAY_DELAY);
        }

        // Обработчик сброса мусора мышкой
        private void DropTrashHandler(object sender, MouseEventArgs e)
        {
            isDown = false;
            CheckCollisionWithBaskets(sender);
        }

        // Проверка попадания мусора в одну из корзин
        private void CheckCollisionWithBaskets(object sender)
        {
            if (!isActiveGame) return;
            PictureBox pbSender = sender as PictureBox;
            string senderTag = (string)pbSender.Tag;
            foreach(PictureBox basket in listBaskets)
            {
                if(IsCollision(pbSender, basket))
                {
                    if (dictBaskets[(string)basket.Tag].Equals(senderTag))
                    {
                        progressBarPlayer.AddSteps(1);
                       _ = MakeInvisibleElement(pbSender, Config.TRASH_HIDE_DELAY);
                        stepPlayerCounter++;
                        Log("Мусор успешно доставлен");
                        if (stepPlayerCounter >= allTargetElementCount)
                        {
                            isActiveGame = false;
                            ShowFinalMessage(labFail, Config.MSG_FINAL_WIN);
                            form2.SetGamePassed(true);
                            stopwatch.Stop();
                            winGameTime = stopwatch.ElapsedMilliseconds;
                            Log("Время - " + winGameTime);
                            if (RecordRegistrationService.CheckAndRegWinResult(playerName, winGameTime, recordsDto.listLevelRecords[1]["BestResult1"]))
                            {
                                RecordRegistrationService.PrintRecordsToFile(playerName, recordsDto);
                            }
                            btnContinue.Visible = true;
                            break;
                        }
                    }
                    else
                    {
                        pbSender.Left = trashLeft;
                        pbSender.Top = trashTop;
                        progressBarLider.AddSteps(1);
                        stepLiderCounter++;
                        Log("Мусор доставлен не в ту корзину");
                    }
                }
            }
        }

        // Авто-выбор картинок для мусора
        private async Task SelectTrashImage(object sender, int time)
        {
            PictureBox c = (PictureBox)sender;
            await Task.Delay(time);
            switch (c.Tag)
            {
                case Config.TAG_TRASH_1:
                    imageCounterTrash1 = SetTrashImage(c, imageCounterTrash1, listImageForTrash1);
                    break;

                case Config.TAG_TRASH_2:
                    imageCounterTrash2 = SetTrashImage(c, imageCounterTrash2, listImageForTrash2);
                    break;

                case Config.TAG_TRASH_3:
                    imageCounterTrash3 = SetTrashImage(c, imageCounterTrash3, listImageForTrash3);
                    break;

                case Config.TAG_TRASH_4:
                    imageCounterTrash4 = SetTrashImage(c, imageCounterTrash4, listImageForTrash4);
                    break;
            }
        }

        // Утилита. Установка картинки на PictureBox
        private int SetTrashImage(PictureBox c, int index, List<Image> list)
        {
            if (c.BackColor != Color.Transparent)
            {
                c.BackColor = Color.Transparent;
                c.Image = list[index++];
                if (index == list.Count) index = 0;
            }
            return index;
        }
    }
}
