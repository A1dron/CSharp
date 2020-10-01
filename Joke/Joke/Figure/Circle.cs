using System;
using System.Collections.Generic;
using System.Text;

namespace Joke.Figure
{
    class Circle : iFigure
    {
        private int r;
        const int pi = 3;
        readonly int s;
        public Circle(int r)
        {
            this.r = r;
            s = Square();
        }

        
        public int Square()
        {
            int square;
            return square = pi *r*r;
        }
    }
}
