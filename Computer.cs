using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp12.Interface
{
    
    public interface IComputer
    {
        string ComputerName { get; set; }
        float Sum(float a, float b);
        float Subtract(float a, float b);
        float Multiply(float a, float b);
        float SquareRoot(float a, float b);
        float Divide(float a, float b);
        float Sin(float a, float num2);
        float Cos(float a, float num2);
        float Tan(float a, float num2);
        float Sin(int v);
        float Cos(int v);
        float Tan(int v);
    }

    
    public class Computer : IComputer
    {
        public string ComputerName { get; set; } = "Калькулятор";

        public float Sum(float a, float b) => a + b;
        public float Subtract(float a, float b) => a - b;
        public float Multiply(float a, float b) => a * b;
        public float Divide(float a, float b)
        {
            if (b == 0) throw new DivideByZeroException("Деление на ноль");
            return a / b;
        }

        public float SquareRoot(float a)
        {
            if (a == 0) throw new ArgumentException("Невозможно вычислить квадратный корень из отрицательного числа");
            return (float)Math.Sqrt(a);
        }
        public float Sin(float a) => (float)Math.Sin(a);
        public float Cos(float a) => (float)Math.Cos(a);
        public float Tan(float a) => (float)Math.Tan(a);

        public float SquareRoot(float a, float b)
        {
            throw new NotImplementedException();
        }

        public float Sin(float a, float num2)
        {
            throw new NotImplementedException();
        }

        public float Cos(float a, float num2)
        {
            throw new NotImplementedException();
        }

        public float Tan(float a, float num2)
        {
            throw new NotImplementedException();
        }

        public float Sin(int v)
        {
            throw new NotImplementedException();
        }

        public float Cos(int v)
        {
            throw new NotImplementedException();
        }

        public float Tan(int v)
        {
            throw new NotImplementedException();
        }
    }

    
    public class Calculator
    {
        private readonly IComputer _computer;

        public Calculator(IComputer computer)
        {
            _computer = computer;
        }

        public float Calculate(float num1, float num2, string operation)
        {
            switch (operation)
            {
                case "+":
                    return _computer.Sum(num1, num2);
                case "-":
                    return _computer.Subtract(num1, num2);
                case "*":
                    return _computer.Multiply(num1, num2);
                case "/":
                    return _computer.Divide(num1, num2);
                case "√":
                    return _computer.SquareRoot(num1, num2);
                case "sin":
                    return _computer.Sin(num1, num2);
                case "cos":
                    return _computer.Cos(num1, num2);
                case "tan":
                    return _computer.Tan(num1, num2);
                default:
                    throw new InvalidOperationException("Неправильно");
            }
        }
    }

    
    class Program
    {
        static void House()
        {
            IComputer myComputer = new Computer();
            Calculator calc = new Calculator(myComputer);

            float result1 = calc.Calculate(10, 5, "+");
            float result2 = calc.Calculate(10, 5, "-");
            float result3 = calc.Calculate(10, 5, "*");
            float result4 = calc.Calculate(10, 5, "/");
            float result5 = calc.Calculate(10, 5, "√");
            float result6 = calc.Calculate(10, 5, "Sin");
            float result7 = calc.Calculate(10, 5, "Cos");
            float result8 = calc.Calculate(10, 5, "Tan");

            
            float sinResult = myComputer.Sin(10);
            float cosResult = myComputer.Cos(10);
            float tanResult = myComputer.Tan(10);

            Console.WriteLine($"Сложение: {result1}");
            Console.WriteLine($"Вычитание: {result2}");
            Console.WriteLine($"Умножение: {result3}");
            Console.WriteLine($"Деление: {result4}");
            Console.WriteLine($"Квадратный корень: {result5}");
            Console.WriteLine($"Sin(10): {sinResult}");
            Console.WriteLine($"Cos(10): {cosResult}");
            Console.WriteLine($"Tan(10): {tanResult}");
        }

        static void Main(string[] args)
        {
            House();
        }
    }
}
