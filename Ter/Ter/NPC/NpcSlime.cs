using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;

namespace Ter.NPC
{
    class NpcSlime : Npc
    {

        const float TIME_WAIT_JUMP = 1f;
        SpriteSheet spriteSheet;
        float waitTimer = 0f;

        public NpcSlime(World world) : base (world)
        {
            spriteSheet = Content.ssNpcSlime;

           // rect = new RectangleShape(new Vector2f(Tile.TILE_SIZE * 1.5f, Tile.TILE_SIZE * 1f));

            rect = new RectangleShape(new Vector2f(spriteSheet.SubWidth/1.5f, spriteSheet.SubHeight/1.5f));
            rect.Origin = new Vector2f(rect.Size.X/2,0); //указываем его центр
            rect.FillColor = new Color(0, 255, 0, 150);

            rect.Texture = spriteSheet.Texture;
            rect.TextureRect = spriteSheet.GetTextureRect(0, 0);
        }

        public override void OnKill()
        {
            Spawn();
        }

        public override void OnWallColided()
        {
            Direction *= -1;//меняю направление на противоположное
            velocity = new Vector2f(-velocity.X * 0.8f, velocity.Y);
        }

        public override void UpdateNPC()
        {
            if (!isFly)
            {
                if (waitTimer >= TIME_WAIT_JUMP)
                {
                    velocity = GetJumpVelocity();
                    waitTimer = 0f;
                }
                else
                {
                    waitTimer += 0.05f;
                    velocity.X = 0f;
                }
                rect.TextureRect = spriteSheet.GetTextureRect(0, 0);
            }
            else rect.TextureRect = spriteSheet.GetTextureRect(0, 1);
        }

        public override void DrawNPC(RenderTarget target, RenderStates states)
        {
        }

        public virtual Vector2f GetJumpVelocity()
        {
            return new Vector2f(Direction * World.Rand.Next(1, 15), -World.Rand.Next(8, 15));
        }
    }
}
