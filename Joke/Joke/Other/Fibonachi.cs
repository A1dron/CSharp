using System;
using static Joke.ProjectMatrix.Utility;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.CompilerServices;

namespace Joke.Other
{
    class Fibonachi
    {
        private Random random = new Random();
        private int num;
        readonly int[] fibonachi;
        public Fibonachi(int length)
        {
            num = random.Next(0, 2);
            if (num == 2) num = 1;
            fibonachi = new int[length];
            fibonachi[0] = num;
            fibonachi[1] = 1;
            for (int i = 2; i < length; i++)
            {
                fibonachi[i] = fibonachi[i - 2] + fibonachi[i-1];
            }
        }

        public int[] spiralFibonachi()
        {
            
            int[] spiral = new int[fibonachi.Length];
            ArrayList rightNumbers = new ArrayList();
            ArrayList leftNumbers = new ArrayList();
            for (int i = 0; i < fibonachi.Length; i++)
            {
                if (i % 2 == 0) leftNumbers.Add(fibonachi[i]);
                else rightNumbers.Add(fibonachi[i]);
            }
            leftNumbers.Reverse();
            leftNumbers.AddRange(rightNumbers);
            for (int i = 0; i < fibonachi.Length; i++)
            {
                spiral[i] = (int)leftNumbers[i];
            }
            return spiral;
        }

        public void printFibonachi()
        {
            for (int i = 0; i < fibonachi.Length; i++)
            {
                Console.Write($"{fibonachi[i]} ");
            }
        }
    }
}
