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

namespace WfGameProject
{
    class Mode3
    {
        public bool isWinForm3;

        private Form3 form3;
        Character character;

        private IEnumerable controls;

        private PictureBox pbPlayer;
        private PictureBox pbArea;
        private PictureBox pbWin;

        private int basePlayerWidth;
        private int basePlayerHeight;
        private int basePlayerLeft;
        private int basePlayerTop;

        private List<PictureBox> listGrass;
        private List<PictureBox> listCrossroads;

        private Label labFail;
        private Label labPlayer;

        private int stepMode = 2;

        bool isActiveGame = true;
        private bool isMove = true;
        private bool isUp = true;
        private bool isDown = true;
        private bool isLeft = true;
        private bool isRight = true;
        private bool isFreeCross = true;

        public int sec;

        private TrafficLight trafficLight1;
        private TrafficLight trafficLight2;
        private TrafficLight trafficLight3;
        private TrafficLight trafficLight4;

        private Button btnReset;

        private RecordsDto recordsDto;

        private string playerName;

        private long winGameTime;
        private long recordTime;
        private Stopwatch stopwatch;

        private bool firstStep = true;

        private Button btnContinue;

        public Mode3(Form3 form3, Label labFail)
        {
            this.form3 = form3;
            this.labFail = labFail;
            Init();
        }

        // Загрузка уровня 3
        private void Init()
        {
            controls = form3.Controls;
            GetListsOfDifferentObstacles();
            GetMainControls();
            GetPlayerBaseCoordinates();
            BringToFrontVisibleInGameControls();
            character = new Character(pbPlayer, labPlayer);
            GetTrafficLights();
            btnReset = getBtnByName(pbArea.Controls, "btnReset");
            btnReset.Visible = false;
            recordTime = Config.LIDER_WIN_TIME_LEVEL3;
        }

        // Получение светофоров
        private void GetTrafficLights()
        {
            trafficLight1 = new TrafficLight(pbArea, 182, 285);
            trafficLight2 = new TrafficLight(pbArea, 327, 67);
            trafficLight4 = new TrafficLight(pbArea, 971, 274);
            trafficLight3 = new TrafficLight(pbArea, 856, 490);
        }

        // Перенос видимых во время игры объектов на передний план
        private void BringToFrontVisibleInGameControls()
        {
            pbPlayer.BringToFront();
            labPlayer.BringToFront();
            pbWin.BringToFront();
            labFail.BringToFront();
        }

        // Получение базовых координат игрока
        private void GetPlayerBaseCoordinates()
        {
            basePlayerWidth = pbPlayer.Width;
            basePlayerHeight = pbPlayer.Height;
            basePlayerLeft = pbPlayer.Left;
            basePlayerTop = pbPlayer.Top;
        }

        // Получение основных контролов
        private void GetMainControls()
        {
            pbPlayer = getPbByName(controls, "pbPlayer");
            pbWin = getPbByName(controls, "pbWin");
            pbArea = getPbByName(controls, "pbArea");
            labPlayer = getLabByName(pbArea.Controls, "labPlayer");
            btnContinue = getBtnByName(pbArea.Controls, "btnContinue");
        }

        // Получение листов разных препятствий
        private void GetListsOfDifferentObstacles()
        {
            listGrass = getListByTag(controls, Config.TAG_GRASS, true);
            listCrossroads = getListByTag(controls, Config.TAG_CROSSROADS, true);
        }

        // Получение имени игрока из Form3
        public void SetPlayerName(string playerName)
        {
            this.playerName = playerName;
        }

        // Получение DTO рекордов из Form3
        public void SetRecordsDto(RecordsDto recordsDto)
        {
            this.recordsDto = recordsDto;
        }

        // Движение объекта по кнопке
        public async Task Form3KeyDownAsync(object sender, KeyEventArgs e)
        {
            DoFirstStep();
            if (!isActiveGame) return;
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
                stopwatch = new Stopwatch();
                stopwatch.Start();
            }
        }

        // Задаем направление движения вверх 
        private async Task MoveToUpAsync(int sign)
        {
            isUp = true;
            bool go = isUp;
            DropFlags();
            await Task.Delay(5);
            SetFlags();
            pbPlayer.Image = Image.FromFile("Resources/Truck_Up.png");
            pbPlayer.Width = basePlayerWidth;
            while (isActiveGame && isMove && isUp && go)
            {
                isMove = CheckCollisions(pbPlayer, pbArea);
                isMove = CheckWin();
                character.SetTop(character.GetTop() + sign * stepMode);
                await Task.Delay(5);
            }
        }

        // Задаем направление движения вниз
        private async Task MoveToDownAsync(int sign)
        {
            isDown = true;
            bool go = isDown;
            DropFlags();
            await Task.Delay(5);
            SetFlags();
            pbPlayer.Image = Image.FromFile("Resources/Truck_Up.png");
            pbPlayer.Width = basePlayerWidth;
            while (isActiveGame && isMove && isDown && go)
            {
                isMove = CheckCollisions(pbPlayer, pbArea);
                isMove = CheckWin();
                character.SetTop(character.GetTop() + sign * stepMode);
                await Task.Delay(5);
            }
        }

        // Задаем направление движения налево
        private async Task MoveToLeftAsync(int sign)
        {
            isLeft = true;
            bool go = isLeft;
            DropFlags();
            await Task.Delay(5);
            SetFlags();
            pbPlayer.Image = Image.FromFile("Resources/Truck_Left.png");
            pbPlayer.Width = basePlayerWidth + 15;
            pbPlayer.Left -= 8;
            while (isActiveGame && isMove && isLeft && go)
            {
                isMove = CheckCollisions(pbPlayer, pbArea);
                isMove = CheckWin();
                character.SetLeft(character.GetLeft() + sign * stepMode);
                await Task.Delay(5);
            }
        }

        // Задаем направление движения направо
        private async Task MoveToRightAsync(int sign)
        {
            isRight = true;
            bool go = isRight;
            DropFlags();
            await Task.Delay(5);
            SetFlags();
            pbPlayer.Image = Image.FromFile("Resources/Truck_Right.png");
            pbPlayer.Width = basePlayerWidth + 15;
            pbPlayer.Left -= 8;
            while (isActiveGame && isMove && isRight && go)
            {
                isMove = CheckCollisions(pbPlayer, pbArea);
                isMove = CheckWin();
                character.SetLeft(character.GetLeft() + sign * stepMode);
                await Task.Delay(5);
            }
        }

        // Проверка на завершение игры с победой игрока 
        private bool CheckWin()
        {
            if (IsCollision(pbPlayer, pbWin))
            {
                isActiveGame = false;
                ShowFinalMessage(labFail, Config.MSG_FINAL_WIN);
                stopwatch.Stop();
                winGameTime = stopwatch.ElapsedMilliseconds;
                Log("Время - " + winGameTime);
                if (RecordRegistrationService.CheckAndRegWinResult(playerName, winGameTime, recordsDto.listLevelRecords[2]["BestResult2"]))
                {
                    RecordRegistrationService.PrintRecordsToFile(playerName, recordsDto);
                }
                btnContinue.Visible = true;
                return false;
            }
            else
            {
                return true;
            }
        }

        // Проверка всех столкновений
        private bool CheckCollisions(PictureBox pbPlayer, PictureBox pbArea)
        {
            if (CheckCollisionsInsidePbWithPbArea(pbPlayer, pbArea))
            {
                return DoIfCollisionWithBoard();
            }
            if (checkGrassCollision(pbPlayer) || (checCrossroadCollision(pbPlayer)))
            {
                pbPlayer.Image = Image.FromFile("Resources/Truck_Crash.png");
                pbPlayer.Width += 15;
                pbPlayer.Height += 15;
                StopGame();
                stopwatch.Stop();
                ShowFinalMessage(labFail, Config.MSG_FINAL_FAIL);
                btnReset.Visible = true;
                return false;
            }
                return true;
        }

        // Проверка столновения игрока с травой
        private bool checkGrassCollision(PictureBox pbPlayer)
        {
            return CheckCollisionsPbWithPbList(pbPlayer, listGrass);
        }

        // Проверка столкновения игрока с перекрестком
        private bool checCrossroadCollision(PictureBox pbPlayer)
        {
            return CheckCollisionsPbWithPbList(pbPlayer, listCrossroads, trafficLight1.GetFreeCross());
        }

        // Действие при столкновении с границами локации
        public bool DoIfCollisionWithBoard()
        {
            DropFlags();
            return false;
        }

        // Перезапуск игры
        public void Reset()
        {
            isActiveGame = true;
            isMove = true;
            trafficLight1.SetActiveGame(isActiveGame);
            trafficLight2.SetActiveGame(isActiveGame);
            trafficLight3.SetActiveGame(isActiveGame);
            trafficLight4.SetActiveGame(isActiveGame);
            pbPlayer.Width = basePlayerWidth;
            pbPlayer.Height = basePlayerHeight;
            pbPlayer.Left = basePlayerLeft;
            pbPlayer.Top = basePlayerTop;
            pbPlayer.Image = Image.FromFile("Resources/Truck_Up.png");
            labFail.Visible = false;
        }

        // Остановка процессов игры
        private void StopGame()
        {
            isActiveGame = false;
            trafficLight1.SetActiveGame(isActiveGame);
            trafficLight2.SetActiveGame(isActiveGame);
            trafficLight3.SetActiveGame(isActiveGame);
            trafficLight4.SetActiveGame(isActiveGame);
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
