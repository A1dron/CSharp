using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class array
    {
        private int[] _array { get; set; }
        public array( int length)
        {
            _array = getArray(length);
        }

        public void printDuplicatesInfo()
        {
            Dictionary<int, int> DuplicatesInfo = new Dictionary<int, int>();
            for (int i = 0; i < _array.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < _array.Length; j++)
                {
                    if (_array[i] == _array[j]) count++;
                }
                if (!DuplicatesInfo.ContainsKey(_array[i])) DuplicatesInfo.Add(_array[i], count);

            }
            var items = from pair in DuplicatesInfo orderby pair.Value descending select pair; // сортировка LINQ
            /*foreach (KeyValuePair<int, int> keyValue in DuplicatesInfo)
            {
                Console.WriteLine($"{keyValue.Key} - {keyValue.Value} раз");
            }*/
            foreach (KeyValuePair<int, int> keyValue in items)
            {
                Console.WriteLine($"{keyValue.Key} - {keyValue.Value} раз");
            }

        }

        private int[] getArray(int length)
        {
            int[] array = new int[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(0, 11);
            }
            return array;
        }

        public void printArray(int[] array)
        {
            foreach (var i in array)
            {
                Console.Write($"{array[i]}; ");
            }
        }


    }






    
}
