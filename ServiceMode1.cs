using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WfGameProject.Util;

namespace WfGameProject
{
    static class ServiceMode1
    {

        public static bool DoIfCollisionWithBoard(PictureBox pbPlayer, Label label)
        {
            ShowFinalMessage(label, Config.MSG_FINAL_FAIL);
            return false;
        }

        public static bool DoIfCollisionWithSnake(PictureBox pbPlayer, PictureBox snake, Label label)
        {
            return false;
        }

        
    }
}
