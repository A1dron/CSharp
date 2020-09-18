using System;
using SFML.Graphics;
using SFML.Window;

namespace Ter
{
    class Program
    {
        public static RenderWindow Window { private set; get; }//свойство которое возвращает текущий объект класса окна
        public static Game Game { private set; get; }//свойство которое возвращает текущий объект класса игры
        public static Random Rand { private set; get; }

        static void Main(string[] args)
        {
            Window = new RenderWindow(new VideoMode(800,600), "MyGame"); //создаём окно приложения
            Window.SetVerticalSyncEnabled(true);//говорим окну о необходимости вертикальной синхронизации

            Window.Closed += Win_Closed;//привязываем метод к обработчику событий окна, который будет вызываться при нажатии кнопки закрытия окна(верхняя правая часть окна)
            Window.Resized += Win_Resized;//cрабатывает при изменении размеров окна

            //загрузка контента
            Content.load();
            
            Game = new Game();
            

            while (Window.IsOpen)//цикл будет работать пока открыто окно
            {
                Window.DispatchEvents();//пресматривает все свои входящие сообщения окна о событиях(движения мышью, закрытие окна, нажатие клавиш и т.д.) 

                Game.Update();//метод обновления игры

                Window.Clear(Color.Black);//очистка области окна прорисовки в черный цвет

                Game.Draw();//метод рисуем здесь

                Window.Display();//отображение всего что нарисовано в окне

            }
        }

        private static void Win_Resized(object sender, SFML.Window.SizeEventArgs e)
        {
            Window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));//присваивает новый вид с измененным размером окна
        }

        private static void Win_Closed(object sender, EventArgs e)
        {
            Window.Close();//закрытие окна
        }
    }
}
