using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetMatrix matrix = new GetMatrix(6, 6);
            matrix.printMatrix();
            Console.WriteLine();
            
            //GetMatrix matrix1 = new GetMatrix(matrix, 3, GetMatrix.Operation.MULTIPLY);
            //matrix1.printMatrix();
            //Console.WriteLine();

            //GetMatrix matrix2 = new GetMatrix(matrix, 3, GetMatrix.Operation.SUM);
            //matrix2.printMatrix();
            //Console.WriteLine();


        }


        




    }
}











//    Random random = new Random();
//    string id = random.Next(100000000, 1000000000).ToString();
//    GenID gen = new GenID(id);

//    while (true)
//    {
//        int num1 = getNum("Введите 1-ое число: ");
//        int num2 = getNum("Введите 2-ое число: ");
//        Calculate calculate = new Calculate(num1, num2);                
//        string operat = Console.ReadLine();
//        switch (operat)
//        {
//            case "+":
//                Console.WriteLine(calculate.Sum());
//                break;
//            case "-":
//                Console.WriteLine(calculate.Minus());
//                break;
//            case "*":
//                Console.WriteLine(calculate.Umnozh());
//                break;
//            case "/":
//                Console.WriteLine(calculate.Delit());
//                break;
//            default:
//                return;
//        }
//    }

