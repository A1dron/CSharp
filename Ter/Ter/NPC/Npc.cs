using SFML.Graphics;
using SFML.System;

namespace Ter.NPC
{
    //от этого класса будут зависеть все боты в игре
    abstract class Npc : Entity
    {
        public Vector2f StartPosition;//хранит корды места возрождения
        public int Direction
        {
            set
            {
                int dir = value >= 0 ? 1 : -1;
                Scale = new Vector2f(dir, 1);
            }
            get
            {
                int dir = Scale.X >= 0 ? 1 : -1;
                return dir;
            }
        }

        public Npc(World world) : base(world)
        {
           
        }

        // Возрождение непеса
        public void Spawn()
        {
            Position = StartPosition;
            velocity = new Vector2f();
            // тут возможно будут спецэффекты
        }

        public override void Update()
        {
            UpdateNPC();

            base.Update();

            // Если игрок упал в пропасть
            if (Position.Y > Program.Window.Size.Y)
                OnKill();
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            if(isRectVisible)
                target.Draw(rect, states);

            DrawNPC(target, states);
        }

        public abstract void OnKill();//вызывается когда у персонажа значение жизней пришло к 0
        
        public abstract void UpdateNPC();//вызывается когда необходимо просчитать логику персонажа
        public abstract void DrawNPC(RenderTarget target, RenderStates states);//вызывается когда необходимо нарисовать персонажа на экран

    }
}
