using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Calculate
    {
        private double num1;
        private double num2;

        public Calculate(double num1, double num2){
            this.num1 = num1;
            this.num2 = num2;            
        }


        public double Sum()
        {
            return num1 + num2;
        }

        public double Minus()
        {
            return num1 - num2;
        }

        public double Umnozh()
        {
            return num1 * num2;
        }

        public double Delit()
        {
            return num1 / num2;
        }


    }
}
