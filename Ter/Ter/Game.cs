using SFML.System;
using System.Collections.Generic;
using Ter.NPC;
using Ter.UI;


//обрабатывается вся логика игры
namespace Ter
{
    class Game
    {
        public Player Player { get; private set; }// игрок


        World world;//мир
        NpcFastSlime slime;// слизь
        

        List<NpcSlime> slimes = new List<NpcSlime>();

        public Game()
        {
            //создаем мир и выполняем генерацию
            world = new World();
            world.GenerateWorld();

            // Cоздание игрока
            Player = new Player(world);
            Player.StartPosition = new Vector2f(300,150);
            Player.Spawn();

            // Cоздание fast слизня
            slime = new NpcFastSlime(world);
            slime.StartPosition = new Vector2f(500, 150);
            slime.Spawn();
            

            for (int i = 0; i < 4; i++)
            {
                var s = new NpcSlime(world);
                s.StartPosition = new Vector2f(World.Rand.Next(150, 600), 150);
                s.Direction = World.Rand.Next(0, 2) == 0 ? 1 : -1;
                s.Spawn();
                slimes.Add(s);
            }
            for (int i = 0; i < 3; i++)
            {
                var s = new NpcFastSlime(world);
                s.StartPosition = new Vector2f(World.Rand.Next(150, 600), 150);
                s.Direction = World.Rand.Next(0, 2) == 0 ? 1 : -1;
                s.Spawn();
                slimes.Add(s);
            }

            UIMahager.AddControl(new UIWindow());            
            //включаем прорисовку объектов для визуальной отладки
            DebugRender.Enabled = true;
        }

        

        //обновление логики игры
        public void Update()
        {
            world.Udate();
            Player.Update();
            slime.Update();


            foreach (var s in slimes)
                s.Update();

            //Обновляем UI
            UIMahager.UpdateOver();
            UIMahager.Update();
        }

        //прорисовка мира
        public void Draw()
        {
            Program.Window.Draw(world);//вызываем прорисовку мира
            Program.Window.Draw(Player); // вызываем прорисовку игрока
            Program.Window.Draw(slime); // вызываем прорисовку слизи

            foreach (var s in slimes)
                Program.Window.Draw(s);

            DebugRender.Draw(Program.Window);//рисуем объекты для визуальной отладки

            //рисуем UI
            UIMahager.Draw();
        }
    }
}
