using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfGameProject
{
    static class Util
    {
        public enum LOG
        {
            INFO,
            DEBUG,
            WARN,
            ERROR
        }

        public static void Log(string message, LOG log = LOG.INFO)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + " [" + log + "] " + message);
        }

        // Изменение видимости объекта
        public static async Task MakeInvisibleElement(Control control, int delay)
        {
            await Task.Delay(delay);
            control.Visible = false;
        }

        /** Проверка столкновения объекта с другим объектом из списка
         * 
         * @parameter PictureBox obj           - объект
         * @parameter List<PictureBox> targets - список других объектов
         * 
         * @return bool - true(столкновение есть), false(столкновения нет)
         */
        public static bool CheckCollisionsPbWithPbList(PictureBox obj, List<PictureBox> targets, bool ignore = false)
        {
            if(ignore)
            {
                return false;
            }
            foreach (PictureBox pb in targets)
            {
                if (pb.Visible && IsCollision(obj, pb))
                {
                    return true;
                }
            }
            return false;
        }

        /** Проверка столкновения объекта с другим объектом из списка
        * 
        * @parameter PictureBox obj           - объект
        * @parameter List<PictureBox> targets - список других объектов
        * 
        * @return PictureBox - объект, с которым произошло столкновение
        */
        public static PictureBox GetObjOfCollisionWithPictureboxList(PictureBox obj, List<PictureBox> targets)
        {
            foreach (PictureBox pb in targets)
            {
                if (pb.Visible && IsCollision(obj, pb))
                {
                    return pb;
                }
            }
            return null;
        }

        /** Проверка столкновения объекта с другим объектом
        * 
        * @parameter PictureBox obj        - объект
        * @parameter PictureBox target     - другой объект
        * 
        * @return bool - true(столкновение есть), false(столкновения нет)
        */
        public static bool IsCollision(PictureBox pb, PictureBox target)
        {
            return (pb.Left <= target.Right && pb.Right >= target.Left && pb.Top <= target.Bottom && pb.Bottom >= target.Top);
        }

        /** Проверка столкновения объекта с другим объектом
        * 
        * @parameter PictureBox obj        - объект
        * @parameter Label target          - другой объект
        * 
        * @return bool - true(столкновение есть), false(столкновения нет)
        */
        public static bool IsCollision(PictureBox pb, Label target)
        {
            return (pb.Left <= target.Right && pb.Right >= target.Left && pb.Top <= target.Bottom && pb.Bottom >= target.Top);
        }

        /** Проверка столкновения объекта с границей поля
        * 
        * @parameter PictureBox obj        - объект
        * @parameter PictureBox pbArea     - поле
        * 
        * @return bool - true(столкновение есть), false(столкновения нет)
        */
        public static bool CheckCollisionsInsidePbWithPbArea(PictureBox obj, PictureBox pbArea)
        {
            return (obj.Left <= pbArea.Left) ||
                (obj.Right >= pbArea.Right) ||
                (obj.Top <= pbArea.Top) ||
                (obj.Top + obj.Height >= pbArea.Top + pbArea.Height);
        }
        
        /**Получение листа по тэгу
         */
        public static List<PictureBox> getListByTag(IEnumerable controls, string tagContent, bool isTransparent = false)
        {
            List<PictureBox> list = new List<PictureBox>();
            foreach (PictureBox pb in controls.OfType<PictureBox>())
            {
                if (pb.Tag != null && (pb.Tag.Equals(tagContent)))
                {
                    if (isTransparent)
                    {
                        pb.BackColor = Color.Transparent;
                    }
                    list.Add(pb);
                }
                foreach (PictureBox pb2 in pb.Controls.OfType<PictureBox>())
                {
                    if (pb2.Tag != null && (pb2.Tag.Equals(tagContent)))
                    {
                        if (isTransparent)
                        {
                            pb2.BackColor = Color.Transparent;
                        }
                        list.Add(pb2);
                    }

                }
            }
            return list;
        }

        /** Получение объекта по имени из Controls 
         */
        public static PictureBox getPbByName(IEnumerable controls, string name)
        {
            foreach (PictureBox pb in controls.OfType<PictureBox>())
            {
                if (pb.Name != null && (pb.Name.Equals(name)))
                {
                    return pb;
                } else
                {
                    foreach (PictureBox pb2 in pb.Controls.OfType<PictureBox>())
                    {
                        if (pb2.Name != null && (pb2.Name.Equals(name)))
                        {
                            return pb2;
                        }
                    }
                }
            }
            return null;
        }

        /** Получение объекта по имени из Controls 
         */
        public static Button getBtnByName(IEnumerable controls, string name)
        {
            foreach (Button pb in controls.OfType<Button>())
            {
                if (pb.Name != null && (pb.Name.Equals(name)))
                {
                    return pb;
                }
                else
                {
                    foreach (Button pb2 in pb.Controls.OfType<Button>())
                    {
                        if (pb2.Name != null && (pb2.Name.Equals(name)))
                        {
                            return pb2;
                        }
                    }
                }
            }
            return null;
        }

        /** Получение Label по имени из Controls 
         */
        public static Label getLabByName(IEnumerable controls, string name)
        {
            foreach (Label pb in controls.OfType<Label>())
            {
                if (pb.Name != null && (pb.Name.Equals(name)))
                {
                    return pb;
                }
                else
                {
                    foreach (Label pb2 in pb.Controls.OfType<Label>())
                    {
                        if (pb2.Name != null && (pb2.Name.Equals(name)))
                        {
                            return pb2;
                        }
                    }
                }
            }
            return null;
        }

        // Выводим сообщение
        public static void ShowFinalMessage(Label label, string message)
        {
            label.Text = message;
            label.Visible = true;
            label.BringToFront();
        }
    }
}
