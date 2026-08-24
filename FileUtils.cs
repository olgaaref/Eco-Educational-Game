using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WfGameProject.Util;

namespace WfGameProject
{
    public static class FileUtils
    {
        private static string txt_textToFile = "Текст записан в файл: ";
        private static string txt_textFromFile = "Текст прочитан из файла: ";

        public static async Task WriteToFile(string text)
        {
            string recordFileName = Config.RECORD_FILE_NAME;
            // если файл существует использовать FileMode.OpenOrCreate
            using (FileStream fstream = new FileStream(recordFileName, FileMode.Truncate))
            {
                // преобразуем строку в байты
                byte[] buffer = Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                await fstream.WriteAsync(buffer, 0, buffer.Length);
               Log(txt_textToFile + recordFileName);
            }
        }

        public static async Task CreateAndFillFile(string text)
        {
            string recordFileName = Config.RECORD_FILE_NAME;
            // если файл существует использовать FileMode.OpenOrCreate
            using (FileStream fstream = new FileStream(recordFileName, FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] buffer = Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                await fstream.WriteAsync(buffer, 0, buffer.Length);
                Log(txt_textToFile + recordFileName);
            }
        }

        public static async Task<string> ReadFile()
        {
            string res;
            string recordFileName = Config.RECORD_FILE_NAME;
            using (FileStream fstream = File.OpenRead(recordFileName))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                await fstream.ReadAsync(buffer, 0, buffer.Length);
                // декодируем байты в строку
                res = Encoding.Default.GetString(buffer);
                Log(txt_textFromFile + recordFileName);
            }
            return res;
        }

        public static string ChooseFileFullName(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog.FileName;
                }
            }
            return filePath;
        }

        //Получение данных о сохраненных рекордах из файла
        public static async Task GetRecordsDtoFromFile(RecordsDto recordsDto)
        {
            if (File.Exists(Config.RECORD_FILE_NAME))
            {
                recordsDto = JsonConvert.DeserializeObject<RecordsDto>(await ReadFile());
            }
            else
            {
                await CreateAndFillFile(JsonConvert.SerializeObject(recordsDto));
            }
        }
    }
}
