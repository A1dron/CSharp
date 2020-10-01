using System;
using System.Collections.Generic;
using System.Text;

namespace Joke.Figure
{
    class Rectangle : iFigure
    {
        private int a, b;
        readonly int s;
        public Rectangle(int a)
        {
            this.a = a;
            s = Square();
        }

        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
            s = Square();
        }


        public int Square()
        {
            int square;
            if (b == 0) b = 1;
            return square = a*b;
        }
    }
}
