using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ter.Items
{
    abstract class Item : Entity
    {
        public const float MOVE_DISTANCE_TO_PLAYER = 100f;      //Дистанция начала движения предмета в сторону игрока
        public const float TAKE_DISTANCE_TO_PLAYER = 20f;       //Дистанция побора предмета игроком

        public Item(World world, SpriteSheet spriteSheet, int i, int j) : base (world)
        {
            rect = new RectangleShape(new Vector2f(spriteSheet.SubWidth, spriteSheet.SubHeight));
            rect.Texture = spriteSheet.Texture;
            rect.TextureRect = spriteSheet.GetTextureRect(i, j);
        }

        public override void Update()
        {
            Vector2f playerPos = Program.Game.Player.Position;
            float dist = MathHelper.GetDistance(Position, playerPos);
            isGhost = dist < MOVE_DISTANCE_TO_PLAYER;
            if (isGhost)
            {
                if (dist < TAKE_DISTANCE_TO_PLAYER)
                {
                    //подбираем предмет
                    IsDestroyed = true;
                }
                else
                {
                    Vector2f dir = MathHelper.Normalize(playerPos - Position);
                    float speed = 1f - dist / MOVE_DISTANCE_TO_PLAYER;
                    velocity += dir * speed;
                }
            }

            base.Update();
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            if (isRectVisible)
                target.Draw(rect, states);
        }
    }
}
