using SFML.Graphics;
using SFML.System;

//плитка
namespace Ter
{
    enum TileType   //перечисление типов плиток
    {
        NONE,   //ничего
        GROUND, //почва
        GRASS   //TPABA
    }
    class Tile : Transformable, Drawable
    {
        public const int TILE_SIZE = 16;    //хранит размер тайла в ширину и высоту одновременно

        public SpriteSheet SpriteSheet { get; set; }            //набор спрайтов плитки
        TileType type = TileType.GROUND;    //описываем тип
        RectangleShape rectShape;           //объявляется прямоугольная форма плитки
        

        //Соседи
        Tile upTile = null;     //верхний сосед
        Tile downTile = null;   //нижний сосед
        Tile leftTile = null;   //левый сосед
        Tile rightTile = null;  //правый сосед

        //верхний сосед
        public Tile UpTile
        {
            set
            {
                upTile = value;
                UpdateView();//обновляем вид плитки
            }
            get { return upTile; }
        }

        //нижний сосед
        public Tile DownTile
        {
            set
            {
                downTile = value;
                UpdateView();//обновляем вид плитки
            }
            get { return downTile; }
        }

        //левый сосед
        public Tile LeftTile
        {
            set
            {
                leftTile = value;
                UpdateView();//обновляем вид плитки
            }
            get { return leftTile; }
        }

        //правый сосед
        public Tile RightTile
        {
            set
            {
                rightTile = value;
                UpdateView();//обновляем вид плитки
            }
            get { return rightTile; }
        }
        public Tile(TileType type, Tile upTile, Tile downTile, Tile leftTile, Tile rightTile) 
        {
            this.type = type;

            //присваиваем соседей, а соседям плитку
            if (upTile !=null)
            {
                this.upTile = upTile;
                this.upTile.DownTile = this; // для верхнего соседа эта плитка будет нижним соседом
            }
            if (downTile != null)
            {
                this.downTile = downTile;
                this.downTile.UpTile = this; // для нижнего соседа эта плитка будет верхним соседом
            }
            if (leftTile != null)
            {
                this.leftTile = leftTile;
                this.leftTile.RightTile = this; // для левого соседа эта плитка будет правым соседом
            }
            if (rightTile != null)
            {
                this.rightTile = rightTile;
                this.rightTile.LeftTile = this; // для правого соседа эта плитка будет левым соседом
            }

            rectShape = new RectangleShape(new Vector2f(TILE_SIZE, TILE_SIZE));
            switch (type)
            {
                case TileType.GROUND:
                    SpriteSheet = Content.ssTileGround;  //почва
                    break;
                case TileType.GRASS:
                    SpriteSheet = Content.ssTileGrass; //трава
                    break;
            }

            rectShape.Texture = SpriteSheet.Texture;

            //обновляем внешний вид плитки в зависимости от соседей
            UpdateView();
        }

        //обновляем внешний вид плитки в зависимости от соседей
        public void UpdateView()
        {
            //если у плитки есть все соседи
            if (upTile != null && downTile != null && leftTile != null && rightTile != null)
            {
                int i = World.Rand.Next(0, 3);
                rectShape.TextureRect = SpriteSheet.GetTextureRect(1 + i, 1);    // указывается фрагмент текстуры
            }
            //если у плитки отсутствуют все соседи
            else if (upTile == null && downTile == null && leftTile == null && rightTile == null)
            {
                int i = World.Rand.Next(0, 3);
                rectShape.TextureRect = SpriteSheet.GetTextureRect(9 + i, 3);
            }

            //-----------------------------------------------------------------------------------

            //если у плитки отсутствуюeт только верхний сосед
            else if (upTile == null && downTile != null && leftTile != null && rightTile != null)
            {
                int i = World.Rand.Next(0, 3);
                rectShape.TextureRect = SpriteSheet.GetTextureRect(1 + i, 0);
            }
            //если у плитки отсутствуюeт только нижний сосед
            else if (upTile != null && downTile == null && leftTile != null && rightTile != null)
            {
                int i = World.Rand.Next(0, 3);
                rectShape.TextureRect = SpriteSheet.GetTextureRect(1 + i, 2);
            }
            //если у плитки отсутствуюeт только левый сосед
            else if (upTile != null && downTile != null && leftTile == null && rightTile != null)
            {
                int i = World.Rand.Next(0, 3);
                rectShape.TextureRect = SpriteSheet.GetTextureRect(0,i);
            }
            //если у плитки отсутствуюeт только правый сосед
            else if (upTile != null && downTile != null && leftTile != null && rightTile == null)
            {
                int i = World.Rand.Next(0, 3);
                rectShape.TextureRect = SpriteSheet.GetTextureRect(4, i);
            }

            //-----------------------------------------------------------------------------------

            //если у плитки отсутствуюeт только верхний сосед и левый
            else if (upTile == null && downTile != null && leftTile == null && rightTile != null)
            {
                int i = World.Rand.Next(0, 3);
                rectShape.TextureRect = SpriteSheet.GetTextureRect(0+i*2, 3);
            }
            //если у плитки отсутствуюeт только верхний сосед и правый
            else if (upTile == null && downTile != null && leftTile != null && rightTile == null)
            {
                int i = World.Rand.Next(0, 3);
                rectShape.TextureRect = SpriteSheet.GetTextureRect(1 + i * 2, 3);
            }
            //если у плитки отсутствуюeт только нижний и левый сосед
            else if (upTile != null && downTile == null && leftTile == null && rightTile != null)
            {
                int i = World.Rand.Next(0, 3);
                rectShape.TextureRect = SpriteSheet.GetTextureRect(0 + i * 2, 4);
            }
            //если у плитки отсутствуюeт только нижний и правый сосед
            else if (upTile != null && downTile == null && leftTile != null && rightTile == null)
            {
                int i = World.Rand.Next(0, 3);
                rectShape.TextureRect = SpriteSheet.GetTextureRect(1 + i * 2, 4);
            }
        }

        

        //рисуем плитку
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(rectShape, states);
        }

        public FloatRect GetFloatRect()
        {
            return new FloatRect(Position, new Vector2f(TILE_SIZE, TILE_SIZE));
        }
    }
}
