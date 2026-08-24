using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WfGameProject.Util;

namespace WfGameProject
{
    class RecordRegistrationService
    {
        public static bool CheckAndRegWinResult(string playerName, long winGameTime, List<BestResult> bestResults)
        {
            if (winGameTime < bestResults[0].result)
            {
                Log("Новый чемпион!");
                bestResults[2].result = bestResults[1].result;
                bestResults[2].name = bestResults[1].name;
                bestResults[1].result = bestResults[0].result;
                bestResults[1].name = bestResults[0].name;
                bestResults[0].result = winGameTime;
                bestResults[0].name = playerName;
                Log("1 место: " + winGameTime);
                return true;
            }
            else if (winGameTime < bestResults[1].result)
            {
                bestResults[2].result = bestResults[1].result;
                bestResults[2].name = bestResults[1].name;
                bestResults[1].result = winGameTime;
                bestResults[1].name = playerName;
                Log("2 место: " + winGameTime);
                return true;
            }
            else if (winGameTime < bestResults[2].result)
            {
                bestResults[2].result = winGameTime;
                bestResults[2].name = playerName;
                Log("3 место: " + winGameTime);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void PrintRecordsToFile(string playerName, RecordsDto recordsDto)
        {
            string json = JsonConvert.SerializeObject(recordsDto);
            _ = FileUtils.WriteToFile(json);
            Log("Запись о результате игрока " + playerName);
        }
    }
}
