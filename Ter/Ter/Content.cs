using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace Ter
{
    class Content
    {
        public const string CONTENT_DIR = "..\\Content\\";//путь к папке контент

        public static SpriteSheet ssTileGround;//хранит текстуру земли
        public static SpriteSheet ssTileGrass;//хранит текстуру травы


        //NPC
        public static SpriteSheet ssNpcSlime;//слизь


        //Игрок
        public static SpriteSheet ssPlayerHair;            // Волосы
        public static SpriteSheet ssPlayerHands;           // Кисти рук
        public static SpriteSheet ssPlayerHead;            // Голова
        public static SpriteSheet ssPlayerLegs;            // Ноги
        public static SpriteSheet ssPlayerShirt;           // Рубашка
        public static SpriteSheet ssPlayerShoes;           // Обувь
        public static SpriteSheet ssPlayerUndershirt;      // Рукава
        

        public static void load()//загрузка ресурсов в память ПК
        {
            ssTileGround = new SpriteSheet(Tile.TILE_SIZE, Tile.TILE_SIZE, false, 1, new Texture(CONTENT_DIR + "Textures\\Tiles_0.png"));
            ssTileGrass = new SpriteSheet(Tile.TILE_SIZE, Tile.TILE_SIZE, false, 1, new Texture(CONTENT_DIR + "Textures\\Tiles_2.png"));


            //NPC
            ssNpcSlime = new SpriteSheet(1,2, true, 0, new Texture(CONTENT_DIR + "Textures\\NPC\\slime.png"));



            //Player
            ssPlayerHead = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\Player\\head.png"));
            ssPlayerHair = new SpriteSheet(1,14, true, 0, new Texture(CONTENT_DIR + "Textures\\Player\\hair.png"));
            ssPlayerShirt = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\Player\\shirt.png"));
            ssPlayerUndershirt = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\Player\\undershirt.png"));
            ssPlayerHands = new SpriteSheet(1,20, true, 0, new Texture(CONTENT_DIR + "Textures\\Player\\hands.png"));
            ssPlayerLegs = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\Player\\legs.png"));            
            ssPlayerShoes = new SpriteSheet(1, 20, true, 0, new Texture(CONTENT_DIR + "Textures\\Player\\shoes.png"));
        }
    }
}
