﻿using SFML.Graphics;
using System;

namespace Ter
{
    class SpriteSheet
    {

        public int SubWidth { get; private set; }
        public int SubHeight { get; private set; }
        public int SubCountX { get; private set; }
        public int SubCountY { get; private set; }

        public Texture Texture;

        int borderSize; //толщина рамки между фрагментами(sprites)

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="a">Кол-во фрагментов(спрайтов) по Х или размер одного фрагмента в пикселях по ширине</param>
        /// <param name="b">Кол-во фрагментов(спрайтов) по Y или размер одного фрагмента в пикселях по высоте</param>
        /// <param name="abIsCount">a и b - это количество фрагментов по X & Y?</param>
        /// <param name="borderSize">Толщина рамки между фрагментами</param>
        /// <param name="texture">текстуры</param>
        /// <param name="isSmooth">сглаживание текстуры</param>
        public SpriteSheet(int a, int b, bool abIsCount, int borderSize, Texture texture, bool isSmooth = true)
        {
            Texture = texture;
            texture.Smooth = isSmooth;

            if (borderSize > 0)
            {
                this.borderSize = borderSize + 1;
            }
            else
            {
                this.borderSize = 0;
            }

            if (abIsCount)
            {
                SubWidth = (int)Math.Ceiling((float)texture.Size.X / a);
                SubHeight = (int)Math.Ceiling((float)texture.Size.Y / b);
                SubCountX = a;
                SubCountY = b;
            }
            else
            {
                SubWidth  = a;
                SubHeight = b;
                SubCountX = (int)Math.Ceiling((float)texture.Size.X / a);
                SubCountY = (int)Math.Ceiling((float)texture.Size.Y / b);
            }
        }

        public void Dispose()
        {
            Texture.Dispose();
            Texture = null; 
        }

        //получаем фрагмент текстуры по номеру столбца и строки
        public IntRect GetTextureRect(int i, int j)
        {
            int x = i * SubWidth + i * borderSize;
            int y = j * SubHeight + j * borderSize;

            return new IntRect(x, y, SubWidth, SubHeight);
        }
    }

}