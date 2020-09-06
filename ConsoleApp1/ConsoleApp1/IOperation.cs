using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IOperation
    {
        int MaxElement(GetMatrix matrix);
        int MinElement(GetMatrix matrix);
        GetMatrix Multiply(GetMatrix matrix, int factor);
        GetMatrix Sum(GetMatrix matrix, int factor);


    }
}
