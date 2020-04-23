using System;

namespace Bridge
{

    interface ICalculator
    {
        int add(int left, int right);
        int substract(int left, int right);
        int multiplay(int left, int by);
        int divide(int left, int by);

    }
    interface IcalculatorImplementation
    {
        int add(int left, int right);
        int substract(int left, int right);
        int multiplay(int left, int by);
        int divide(int left, int by);
    }


    interface Isciencecalculator
    {
        double log2(double left);
    }
    class ChineeseImplementation : IcalculatorImplementation
    {
        public int add(int left, int right)
        {
            return left + right;
        }

        public int divide(int left, int by)
        {
            int counter = 1;
            while (left > by)
            {
                left -= by;
                counter++;
            }
            return counter;
        }

        public int multiplay(int left, int by)
        {
            for (int i = 1; i < by; i++)
            {
                left += left;
            }
            return left;
        }

        public int substract(int left, int right)
        {
           return left + (~right )+ 1;
        }
    }

    class IndianImplementation : IcalculatorImplementation
    {
        public int add(int left, int right)
        {
            return left + right;
        }

        public int divide(int left, int by)
        {
            return left / by;
        }

        public int multiplay(int left, int by)
        {
            return left * by;
        }

        public int substract(int left, int right)
        {
            return left - right;
        }
    }

    class simplecalculator<T> : ICalculator where T : IcalculatorImplementation, new()
    {

        T implementation;

        public simplecalculator()
        {
            implementation = new T();
        }
        public int add(int left, int right)
        {
            return implementation.add(left, right);

        }

        public int divide(int left, int by)
        {
            return implementation.divide(left, by);
        }

        public int multiplay(int left, int by)
        {
            return implementation.multiplay(left, by);
        }

        public int substract(int left, int right)
        {
            return implementation.substract(left, right);
        }
    }

    class sciencecalculator : ICalculator, Isciencecalculator
    {
        public int add(int left, int right)
        {
            return left + right;
        }

        public int divide(int left, int by)
        {
            return left / by;
        }

        public double log2(double left)
        {
            return Math.Log2(left);
        }

        public int multiplay(int left, int by)
        {
            return left * by;
        }

        public int substract(int left, int right)
        {
            return left - right; 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICalculator calc = new simplecalculator<ChineeseImplementation>();
            ICalculator calc2 = new simplecalculator<IndianImplementation>();
            // int result = calc.add(12, 2);
            int result = calc.substract(12,2);
            //int result = calc.multiplay(12, 2);
            // int result = calc.divide(12, 2);
            Console.WriteLine("Chineese Calculator"); ;
            Console.WriteLine(result); ;
            Console.WriteLine("Indian Calculator"); ;
            int result2 = calc2.substract(2,4);
            Console.WriteLine(result2); ;
        }
    }
    }
