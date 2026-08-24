using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WfGameProject.Util;
using System.Drawing;
using System.Diagnostics;
using Newtonsoft.Json;

namespace WfGameProject
{
    class Mode1
    {
        private Form1 form1;

        ProgressBar progressBarPlayer;
        ProgressBar progressBarLider;
        Character character;

        bool isActiveGame = true;
        private bool isMove = true;
        private bool isUp = true;
        private bool isDown = true;
        private bool isLeft = true;
        private bool isRight = true;
        private bool flagShowLabelFullTrash = true;
        private bool flagShowLabelFullFish = true;
        private bool flagLiderWin = false;

        private int stepMode = 2;

        private List<PictureBox> listPbSnakes;
        private List<PictureBox> listPbFish;
        private List<PictureBox> listPbTrash;
        private PictureBox pbPlayer;
        private PictureBox pbGrass;
        private PictureBox pbTrashCan;
        private PictureBox pbRiver;

        private IEnumerable controls;

        private Label labFail;
        private Label labPlayer;

        private static int trashCounter = 0;
        private static int trashCanCounter = 0;
        private static int fishCounter = 0;
        private static int riverCounter = 0;
        private int allTargetElementCount;

        private long winGameTime;
        private long recordTime = 1000000;
        private Stopwatch stopwatch;

        private bool firstStep = true;

        private RecordsDto recordsDto;

        private string playerName;

        private Button btnContinue;

        public Mode1(Form1 form1, Label labFail)
        {
            this.form1 = form1;
            this.labFail = labFail;
            Init();
        }

        // Загрузка уровня 1
        private async void Init()
        {
            controls = form1.Controls;
            SetCounters();
            GetListsOfDifferentObjects();
            GetMainControls();
            allTargetElementCount = listPbFish.Count + listPbTrash.Count;
            GetProgressBars();
            character = new Character(pbPlayer, labPlayer);
            recordTime = Config.LIDER_WIN_TIME_LEVEL1;
            Log("Модуль уровня 1 успешно загружен");
        }

        // Получение прогресс-баров лидера и игрока
        private void GetProgressBars()
        {
            progressBarLider = new ProgressBar(pbGrass, pbGrass.Top + 20, pbGrass.Left + 20, 128, 22, allTargetElementCount);
            progressBarLider.SetBackColorOfFront(Color.Blue);
            progressBarPlayer = new ProgressBar(pbGrass, pbGrass.Top + 50, pbGrass.Left + 20, 128, 22, allTargetElementCount);
        }

        // Получение основных объектов уровня
        private void GetMainControls()
        {
            pbPlayer = getPbByName(controls, "pbPlayer");
            pbGrass = getPbByName(controls, "pbGrass");
            pbTrashCan = getPbByName(controls, "pbTrashCan");
            pbRiver = getPbByName(controls, "pbRiver");
            labPlayer = getLabByName(pbGrass.Controls, "labPlayer");
            btnContinue = getBtnByName(pbGrass.Controls, "btnContinue");
        }

        // Получение листов различных объектов (мусор, рыба, змеи)
        private void GetListsOfDifferentObjects()
        {
            listPbSnakes = getListByTag(controls, Config.TAG_SNAKE);
            listPbFish = getListByTag(controls, Config.TAG_FISH);
            listPbTrash = getListByTag(controls, Config.TAG_TRASH);
        }

        // Установка счетчиков для мусороа, рыб, мусорного контейнера и реки
        private void SetCounters()
        {
            trashCounter = 0;
            fishCounter = 0;
            trashCanCounter = 0;
            riverCounter = 0;
        }

        // Получение имени игрока из Form1
        public void SetPlayerName(string playerName)
        {
            this.playerName = playerName;
        }

        // Получение DTO рекордов из Form1
        public void SetRecordsDto(RecordsDto recordsDto)
        {
            this.recordsDto = recordsDto;
        }

        // Движение объекта по кнопке
        public async Task ChooseActionWithKeyDownAsync(object sender, KeyEventArgs e)
        {
            if (!isActiveGame) return;
            DoFirstStep();
            isMove = false;
            await Task.Delay(5);
            isMove = true;
            switch (e.KeyCode)
            {
                case Keys.W:
                    {
                        _ = MoveToUpAsync(-1);
                        break;
                    }
                case Keys.S:
                    {
                        _ = MoveToDownAsync(1);
                        break;
                    }
                case Keys.A:
                    {
                        _ = MoveToLeftAsync(-1);
                        break;
                    }
                case Keys.D:
                    {
                        _ = MoveToRightAsync(1);
                        break;
                    }
                case Keys.Z:
                    {
                        isMove = false;
                        break;
                    }
            }
        }

        // Контроль начала игры по первому шагу
        private void DoFirstStep()
        {
            if (firstStep)
            {
                firstStep = false;
                _ = StartProgressBarLiderAsync(recordTime, allTargetElementCount);
                stopwatch = new Stopwatch();
                stopwatch.Start();
            }
        }

        // Задаем направление движения вверх
        private async Task MoveToUpAsync(int sign)
        {
            bool go = isUp;
            pbPlayer.Image = Properties.Resources.man_arms_up;
            DropFlags();
            await Task.Delay(5);
            SetFlags();
            while (isActiveGame && isMove && isUp && go)
            {
                isMove = CheckColisions();
                isMove = CheckWin();
                isMove = CheckLiderWin();
                character.SetTop(character.GetTop() + sign * stepMode);
                await Task.Delay(5);
            }
        }

        // Задаем направление движения вниз
        private async Task MoveToDownAsync(int sign)
        {
            bool go = isDown;
            pbPlayer.Image = Properties.Resources.man_arms_up;
            DropFlags();
            await Task.Delay(5);
            SetFlags();
            while (isActiveGame && isMove && isDown && go)
            {
                isMove = CheckColisions();
                isMove = CheckWin();
                isMove = CheckLiderWin();
                character.SetTop(character.GetTop() + sign * stepMode);
                await Task.Delay(5);
            }
        }

        // Задаем направление движения влево
        private async Task MoveToLeftAsync(int sign)
        {
            bool go = isLeft;
            pbPlayer.Image = Properties.Resources.Human_Left;
            DropFlags();
            await Task.Delay(5);
            SetFlags();
            while (isActiveGame && isMove && isLeft && go)
            {
                isMove = CheckColisions();
                isMove = CheckWin();
                isMove = CheckLiderWin();
                character.SetLeft(character.GetLeft() + sign * stepMode);
                await Task.Delay(5);
            }
        }

        // Задаем направление движения вправо
        private async Task MoveToRightAsync(int sign)
        {
            bool go = isRight;
            pbPlayer.Image = Properties.Resources._76846;
            DropFlags();
            await Task.Delay(5);
            SetFlags();
            while (isActiveGame && isMove && isRight && go)
            {
                isMove = CheckColisions();
                isMove = CheckWin();
                isMove = CheckLiderWin();
                character.SetLeft(character.GetLeft() + sign * stepMode);
                await Task.Delay(5);
            }
        }

        // Проверка на завершение игры с победой игрока
        private bool CheckWin()
        {
            if ((riverCounter == listPbFish.Count && trashCanCounter == listPbTrash.Count))
            {
                ShowFinalMessage(labFail, Config.MSG_FINAL_WIN);
                isActiveGame = false;
                form1.SetGamePassed(true);
                stopwatch.Stop();
                winGameTime = stopwatch.ElapsedMilliseconds;
                Log("Время - " + winGameTime);
                if (RecordRegistrationService.CheckAndRegWinResult(playerName, winGameTime, recordsDto.listLevelRecords[0]["BestResult0"]))
                {
                    RecordRegistrationService.PrintRecordsToFile(playerName, recordsDto);
                }
                btnContinue.Visible = true;
                return false;
            }
            return true;
        }

        // Проверка на завершение игры с победой лидера
        private bool CheckLiderWin()
        {
            if (flagLiderWin)
            {
                // TODO: MSG_FINAL_LIDER_WIN используется дважды

                ShowFinalMessage(labFail, Config.MSG_FINAL_LIDER_WIN);
                btnContinue.Visible = true;
                return false;
            }
            return true;
        }

        // Запускает и поддерживает прогресс-бар лидера
        private async Task StartProgressBarLiderAsync(long maxMilliSecondNumber, int allTargetElementCount)
        {
            int timeInterval = (int)maxMilliSecondNumber / allTargetElementCount;
            bool go = true;
            for (int i = 0; i < allTargetElementCount && go; i++)
            {
                if (!isActiveGame)
                {
                    break;
                }
                await Task.Delay(timeInterval);
                progressBarLider.AddSteps(1);
                if (i == (allTargetElementCount - 1))
                {
                    go = false;
                }
            }
            isActiveGame = false;
            stopwatch.Stop();
            if (!go) ShowFinalMessage(labFail, Config.MSG_FINAL_LIDER_WIN);
            btnContinue.Visible = true;
        }

        // Проверка столкновения игрока с границами локации
        private bool IsCollisionsInsidePbWithPbAreaMode1()
        {
            if (CheckCollisionsInsidePbWithPbArea(pbPlayer, pbGrass))
            {
                isActiveGame = false;
                stopwatch.Stop();
                ShowFinalMessage(labFail, Config.MSG_FINAL_FAIL);
                btnContinue.Visible = true;
                return true;
            }
            return false;
        }

        // Проверка столкновения игрока со змеями
        private bool IsColisionsWithSnake()
        {
            PictureBox snake = GetObjOfCollisionWithPictureboxList(pbPlayer, listPbSnakes);
            if (snake != null)
            {
                isActiveGame = false;
                stopwatch.Stop();
                ShowFinalMessage(labFail, Config.MSG_FINAL_SNAKE);
                btnContinue.Visible = true;
                return true;
            }
            return false;
        }

        // Проверка всех столкновений
        private bool CheckColisions()
        {
            if (IsCollisionsInsidePbWithPbAreaMode1() || IsColisionsWithSnake())
            {
                return false;
            }
            PictureBox trash = GetObjOfCollisionWithPictureboxList(pbPlayer, listPbTrash);
            if (trash != null)
            {
                return DoIfCollisionWithTrash(pbPlayer, trash);
            }
            PictureBox fish = GetObjOfCollisionWithPictureboxList(pbPlayer, listPbFish);
            if (fish != null)
            {
                return DoIfCollisionWithFish(pbPlayer, fish);
            }
            if (IsCollision(pbPlayer, pbTrashCan))
            {
                return DoIfCollisionWithTrashCan(pbPlayer);
            }
            if (IsCollision(pbPlayer, pbRiver))
            {
                return DoIfCollisionWithRiver(pbPlayer);
            }
            return true;
        }

        // Действие при столкновении игрока с рыбой
        private bool DoIfCollisionWithFish(PictureBox pbPlayer, PictureBox fish)
        {
            if (fishCounter < 2 && trashCounter == 0)
            {
                fishCounter++;
                fish.Visible = false;
                _ = character.SetText(Config.PLAYER_MSG_FISH_COLISION);
            }
            return true;
        }

        // Действие при столкновении игрока с мусором
        private bool DoIfCollisionWithTrash(PictureBox pbPlayer, PictureBox trash)
        {
            if (trashCounter < 2 && fishCounter == 0)
            {
                trashCounter++;
                trash.Visible = false;
                _ = character.SetText(Config.PLAYER_MSG_TRASH_COLISION);
            }
            return true;
        }

        // Действие при столкновении игрока с мусорным контейнером
        private bool DoIfCollisionWithTrashCan(PictureBox pbPlayer)
        {
            trashCanCounter += trashCounter;
            if (trashCounter > 0)
            {
                progressBarPlayer.AddSteps(trashCounter);
                Console.WriteLine("Доставлено мусора(штук): " + trashCounter);
            }
            trashCounter = 0;

            if (flagShowLabelFullTrash && trashCanCounter == listPbTrash.Count)
            {
                flagShowLabelFullTrash = false;
                ShowFinalMessage(labFail, Config.MSG_TRASH_FULL);
                _ = MakeInvisibleElement(labFail, Config.LABEL_HIDE_DELAY);

            }
            return true;
        }

        // Действие при столкновении игрока с рекой
        private bool DoIfCollisionWithRiver(PictureBox pbPlayer)
        {
            isUp = false;
            riverCounter += fishCounter;
            if (fishCounter > 0)
            {
                progressBarPlayer.AddSteps(fishCounter);
                Console.WriteLine("Доставлено рыб(штук): " + fishCounter);
            }
            fishCounter = 0;
            if (flagShowLabelFullFish && riverCounter == listPbFish.Count)
            {
                flagShowLabelFullFish = false;
                ShowFinalMessage(labFail, Config.MSG_FISH_FULL);
                _ = MakeInvisibleElement(labFail, Config.LABEL_HIDE_DELAY);
            }
            return true;
        }

        // Сбрасывание разрешающих движение флагов по всем направлениям
        public void DropFlags()
        {
            isUp = false;
            isDown = false;
            isLeft = false;
            isRight = false;
        }

        // Установка разрешающих движение флагов по всем направлениям
        public void SetFlags()
        {
            isUp = isDown = isLeft = isRight = true;
        }
    }
}

