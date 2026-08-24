using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WfGameProject
{
    static class Config
    {
        // --- Основные пользовательские настройки ---
        // Месторасположение файла для сохранения рекордов
        public static string RECORD_FILE_NAME = "temp.txt";

        // Пользовательские настройки уровня 1
        // Фраза персонажа при поднятии рыбы
        public static string PLAYER_MSG_FISH_COLISION = "Рыбу в реку!";
        // Фраза персонажа при поднятии мусора
        public static string PLAYER_MSG_TRASH_COLISION = "Мусор в бак!";
        // Пользовательские настройки уровня 2
        // Пользовательские настройки уровня 3

        // --- Основные служебные настройки ---
        public const string MSG_FINAL_FAIL = "Может в следующий раз получится!";
        public const string MSG_FINAL_WIN = "Вы выиграли!";
        public const string MSG_FINAL_LIDER_WIN = "Лидер выиграл";
        public const long DEFAULT_LIDER_RECORD_TIME = 180000;
        public const string DEFAULT_LIDER_NAME = "Unknown";
        public const int LEVEL_MAX_NUMBER = 3;
        public const string DEFAULT_RECORD_FILE_NAME = "temp.txt";

        // Служебные настройки уровня 1
        public const string MSG_FISH_FULL = "Рыба собрана";
        public const string MSG_TRASH_FULL = "Мусор собран";
        public const string MSG_FINAL_SNAKE = "Осторожнее! Не подходите к змеям!";
        public const string TAG_SNAKE = "Snake";
        public const string TAG_FISH = "Fish";
        public const string TAG_TRASH = "Trash";
        public const long LIDER_WIN_TIME_LEVEL1 = 120000;
        public const int LABEL_HIDE_DELAY = 3000;
        public const string DEFAULT_PLAYER_MSG_FISH_COLISION = "Рыбу в реку!";
        public const string DEFAULT_PLAYER_MSG_TRASH_COLISION = "Мусор в бак!";
        public const int PLAYER_MSG_CHAR_LIMIT = 50;

        // Служебные настройки уровня 2
        public const string TAG_TRASH_1 = "Trash1";
        public const string TAG_TRASH_2 = "Trash2";
        public const string TAG_TRASH_3 = "Trash3";
        public const string TAG_TRASH_4 = "Trash4";
        public const long LIDER_WIN_TIME_LEVEL2 = 120000;
        public const int IMAGE_DISPLAY_DELAY = 750;
        public const int TRASH_HIDE_DELAY = 100;

        // Служебные настройки уровня 3
        public const string TAG_GRASS = "Grass";
        public const string TAG_CROSSROADS = "Crossroad";
        public const long LIDER_WIN_TIME_LEVEL3 = 120000;

        }
}
