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
            array array = new array(10);
            array.printDuplicatesInfo();


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


//    var test = new Test();
//    try
//    {
//        test.Print();
//    }
//    catch (Exception)
//    {
//        Console.Write("5");
//    }
//    finally
//    {
//        Console.Write("4");
//    }
//    Console.ReadLine();

//}

//private class Test
//{
//    public void Print()
//    {
//        try
//        {
//            throw new Exception();
//        }
//        catch (Exception)
//        {
//            Console.Write("9");
//            throw new Exception();
//        }
//        finally
//        {
//            Console.Write("2");
//        }
//    }
//}

//public static int getNum(string mes)
//{
//    Console.Write(mes);
//    return Convert.ToInt32(Console.ReadLine());
//}
