﻿using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ter
{

    enum DirectionType
    {
        Left, Right, Up, Down
    }

    abstract class Entity : Transformable, Drawable
    {
        public bool IsDestroyed = false;  //объект уничтожен?
        protected RectangleShape rect;
        protected Vector2f velocity;
        protected Vector2f movement;
        protected World world;
        protected bool isFly = true;
        protected bool isRectVisible = true;
        protected bool isGhost = false;  //режим призрака

        public Entity(World world)
        {
            this.world = world;
        }

        public virtual void Update()
        {
            updatePhysics();
        }

        private void updatePhysics()
        {
            //Ускорение
            velocity.X *= 0.99f;


            if (!isGhost)
            {
                //Гравитация

                velocity.Y += 0.55f;

                var offset = velocity + movement;
                float dist = MathHelper.GetDistance(offset);

                int countStep = 1;
                float stepSize = (float)Tile.TILE_SIZE / 2;
                if (dist > stepSize)
                    countStep = (int)(dist / stepSize);

                Vector2f nextPos = Position + offset;
                Vector2f stepPos = Position - rect.Origin;
                FloatRect stepRect = new FloatRect(nextPos, rect.Size);
                Vector2f stepVec = (nextPos - Position) / countStep;

                for (int step = 0; step < countStep; step++)
                {
                    bool isBreakStep = false;

                    stepPos += stepVec;
                    stepRect = new FloatRect(stepPos, rect.Size);
                    //DebugRender.AddRectangle(stepRect, Color.Blue);

                    int i = (int)((stepPos.X + rect.Size.X / 2) / Tile.TILE_SIZE);
                    int j = (int)((stepPos.Y + rect.Size.Y) / Tile.TILE_SIZE);
                    Tile tile = world.GetTile(i, j);

                    if (tile != null)
                    {
                        FloatRect tileRect = new FloatRect(tile.Position, new Vector2f(Tile.TILE_SIZE, Tile.TILE_SIZE));
                        DebugRender.AddRectangle(tileRect, Color.Red);

                        if (updateCollision(stepRect, tileRect, DirectionType.Down, ref stepPos))
                        {
                            velocity.Y = 0;
                            isFly = false;
                            isBreakStep = true;
                        }
                        else isFly = true;
                    }
                    else isFly = true;


                    if (updateWallCollision(i, j, (1), ref stepPos, stepRect) || updateWallCollision(i, j, -1, ref stepPos, stepRect))
                    {
                        OnWallColided();
                        isBreakStep = true;
                    }
                    if (isBreakStep)
                        break;

                }
                Position = stepPos + rect.Origin;
            }
            else Position += velocity + movement;

        }

        //проверяет столкновение персонажа со стеной
        bool updateWallCollision(int i, int j, int iOffset, ref Vector2f stepPos, FloatRect stepRect)
        {
            var dirType = iOffset > 0 ? DirectionType.Right : DirectionType.Left;

            Tile[] walls = new Tile[]
            {
                world.GetTile(i + iOffset, j - 1),
                world.GetTile(i + iOffset, j - 2),
                world.GetTile(i + iOffset, j - 3),
            };

            bool isWallCollided = false;
            foreach (Tile t in walls)
            {
                if (t == null) continue;

                FloatRect tileRect = new FloatRect(t.Position, new Vector2f(Tile.TILE_SIZE, Tile.TILE_SIZE));
                DebugRender.AddRectangle(tileRect, Color.Yellow);
                if (updateCollision(stepRect, tileRect, dirType, ref stepPos))
                    isWallCollided = true;
            }
            return isWallCollided;
        }

        bool updateCollision(FloatRect rectNPC, FloatRect rectTile, DirectionType direction, ref Vector2f pos)
        {
            if (rectNPC.Intersects(rectTile))
            {
                switch (direction)
                {
                    case DirectionType.Up: pos = new Vector2f(pos.X, rectTile.Top + rectTile.Height - 1); break;
                    case DirectionType.Down: pos = new Vector2f(pos.X, rectTile.Top - rectNPC.Height + 1); break;
                    case DirectionType.Left: pos = new Vector2f(rectTile.Left + rectTile.Width - 1, pos.Y); break;
                    case DirectionType.Right: pos = new Vector2f(rectTile.Left - rectNPC.Width + 1, pos.Y); break;
                }

                return true;
            }

            return false;
        }

        public abstract void OnWallColided();//вызывается когда персонаж врезался в стену

        public abstract void Draw(RenderTarget target, RenderStates states);
    }
}
