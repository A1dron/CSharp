using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using Ter.Items;


//логика и прорисовка мира
namespace Ter
{
    class World : Transformable, Drawable
    {
        //кол-во плиток по ширине и высоте
        public const int WORLD_WIDTH = 300;
        public const int WORLD_HEIGHT = 100;

        public static Random Rand { private set; get; }

        //плитки
        Tile[,] tiles;

        //предметы
        List<Item> items = new List<Item>();

        public World()
        {
            tiles = new Tile[WORLD_WIDTH, WORLD_HEIGHT];
        }

        //генерим новый мир
        public void GenerateWorld(int seed = -1)
        {
            Rand = seed >= 0 ? new Random(seed): new Random ((int)DateTime.Now.Ticks);

            int groundLevelMax = Rand.Next(10, 20);
            int groundLevelMin = groundLevelMax + Rand.Next(10, 20);

            // генерация уровня ландшафта
            int[] arr = new int[WORLD_WIDTH];
            for (int i = 0; i < WORLD_WIDTH; i++)
            {
                int dir = Rand.Next(0, 2) == 1 ? 1 : -1;

                if (i > 0)
                {
                    if (arr[i - 1] + dir < groundLevelMax || arr[i - 1] + dir > groundLevelMin)
                        dir = -dir;

                    arr[i] = arr[i - 1] + dir;
                }

                else arr[i] = groundLevelMin;
            }
            //Сглаживание
            for (int i = 1; i < WORLD_WIDTH-1; i++)
            {
                float sum = arr[i];
                int count = 1;
                for (int k = 1; k <= 5; k++)
                {
                    int i1 = i - k;
                    int i2 = i + k;
                    if (i1>0)
                    {
                        sum += arr[i1];
                        count++;
                    }

                    if (i2<WORLD_WIDTH)
                    {
                        sum += arr[i2];
                        count++;
                    }
                }

                arr[i] = (int)(sum / count);
            }

            //ставим плитки на карту
            for (int i = 0; i < WORLD_WIDTH; i++)
            {
                SetTile(TileType.GRASS, i, arr[i]);

                for (int j = arr[i] + 1; j < WORLD_HEIGHT; j++)
                    SetTile(TileType.GROUND, i, j);
            }
        }


        //установить плитку
        public void SetTile(TileType type, int i, int j)
        {
            //находим соседей
            Tile upTile = GetTile(i, j-1);     //верхний сосед
            Tile downTile = GetTile(i, j+1);   //нижний сосед
            Tile leftTile = GetTile(i-1, j);   //левый сосед
            Tile rightTile = GetTile(i+1, j);  //правый сосед

            if (type != TileType.NONE)
            {
                var tile = new Tile(type, upTile, downTile, leftTile, rightTile);
                tile.Position = new Vector2f(i * Tile.TILE_SIZE, j * Tile.TILE_SIZE) + Position;
                tiles[i, j] = tile;
            }
            else
            {
                var tile = tiles[i, j];
                if (tile!=null)
                {
                    var item = new ItemTile(this, tile);
                    item.Position = tile.Position;
                    items.Add(item);
                }

                tiles[i, j] = null;
                //присваиваем соседей, а соседям плитку
                if (upTile != null) upTile.DownTile = null;
                if (downTile != null) downTile.UpTile = null;
                if (leftTile != null) leftTile.RightTile = null;
                if (rightTile != null) rightTile.LeftTile = null;
            }
        }

        //получить плитку по мировым кординатам
        public Tile GetTileByWorldPos(float x, float y)
        {
            int i = (int)(x / Tile.TILE_SIZE);
            int j = (int)(y / Tile.TILE_SIZE);
            return GetTile(i, j);
        }
        public Tile GetTileByWorldPos(Vector2f pos)
        {
            return GetTileByWorldPos(pos.X, pos.Y);
        }
        public Tile GetTileByWorldPos(Vector2i pos)
        {
            return GetTileByWorldPos(pos.X, pos.Y);
        }

        //получить плитку
        public Tile GetTile(int i, int j)
        {
            if (i >= 0 && j >= 0 && i < WORLD_WIDTH && j < WORLD_HEIGHT)
                return tiles[i, j];
            else return null;
        }
        

        //обновить мир
        public void Udate()
        {
            int i = 0;
            while(i<items.Count)
            {
                if (items[i].IsDestroyed)
                    items.RemoveAt(i);
                else
                {
                    items[i].Update();
                    i++;
                }
            }
        }

        //нарисовать мир
        public void Draw(RenderTarget target, RenderStates states)//метод отвечающий за прорисовку
        {
            //рисуем чанки
            for (int i = 0; i < Program.Window.Size.X / Tile.TILE_SIZE + 1; i++)
            {
                for (int j = 0; j < Program.Window.Size.Y / Tile.TILE_SIZE + 1; j++)
                {
                    if (tiles[i,j] != null)
                        target.Draw(tiles[i, j]);
                }
            }

            //рисуем вещи
            foreach (var item in items)
                target.Draw(item);
        }
    }
}
