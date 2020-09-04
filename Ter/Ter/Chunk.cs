using SFML.Graphics;
using SFML.System;


//матрица состоящая из плиток
namespace Ter
{
    class Chunk : Transformable, Drawable
    {
        public const int CHUNK_SIZE = 25;//кол-во тайлов одинаковых в ширину и ввысоту

        Tile[][] tiles;//двумерный массив из плиток
        Vector2i chunkPos;//позиция чанка в масссиве мира

        public Chunk(Vector2i chunkPos)
        {
            //выставляем позицию чанка
            this.chunkPos = chunkPos;
            Position = new Vector2f(chunkPos.X * CHUNK_SIZE * Tile.TILE_SIZE, chunkPos.Y * CHUNK_SIZE * Tile.TILE_SIZE);
            //создаём двумерный маассив тайлов(плиток)
            tiles = new Tile[CHUNK_SIZE][];
            for (int i = 0; i < CHUNK_SIZE; i++)
                tiles[i] = new Tile[CHUNK_SIZE];//создается еще по одномерному массиву

        }

        //установить плитку в чанке
        public void SetTile(TileType type, int i, int j, Tile upTile, Tile downTile, Tile leftTile, Tile rightTile)
        {
            if (type != TileType.NONE)
            {
                tiles[i][j] = new Tile(type, upTile, downTile, leftTile, rightTile);
                tiles[i][j].Position = new Vector2f(i * Tile.TILE_SIZE, j * Tile.TILE_SIZE) + Position;
            }
            else
            {
                tiles[i][j] = null;

                if (upTile != null) upTile.DownTile = null;
                if (downTile != null) downTile.UpTile = null;
                if (leftTile != null) leftTile.RightTile = null;
                if (rightTile != null) rightTile.LeftTile = null;
            }
        }

        //получить плитку из чанка
        public Tile GetTile(int x, int y)
        {
            //если позиция плитки выходит за границу чанка
            if (x < 0 || y < 0 || x >= CHUNK_SIZE || y >= CHUNK_SIZE)
                return null;//возвращаем нулл

            //иначе возвращаем плитку если она даже равна нулл
            return tiles[x][y];
        }

        //рисуем чанк и его содержимое
        public void Draw(RenderTarget target, RenderStates states)
        {
            //рисуем тайлы
            for (int x = 0; x < CHUNK_SIZE; x++)
            {
                for (int y = 0; y < CHUNK_SIZE; y++)
                {
                    if (tiles[x][y] == null) continue;

                    target.Draw(tiles[x][y]);//перебираем все тайлы и рисуем на экран
                }
            }
        }
    }
}
