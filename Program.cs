using System;

namespace СonsoleApp13.Interface;

internal interface IComputer
{
    string ComputerName { get; set; }
    float Sum(float a, float b);
    float Subtract(float a, float b);
    float Multiply(float a, float b);
    float Divide(float a, float b);
    float SquareRoot(float num, float num2);
    float Sin(float angleInDegrees, float num2);
    float Cos(float angleInDegrees, float num2);
    float Tan(float angleInDegrees, float num2);
}

internal class Computer : IComputer
{
   
    
        public string ComputerName { get; set; } = "Калькулятор";

        public float Sum(float a, float b) => a + b;
        public float Subtract(float a, float b) => a - b;
        public float Multiply(float a, float b) => a * b;
        public float Divide(float a, float b)
        {
            if (b == 0)
                throw new DivideByZeroException("Деление на ноль");
            return a / b;
        }
        public float SquareRoot(float num)
        {
            if (num < 0)
                throw new ArgumentException("Невозможно извлечь корень из отрицательного числа");
            return (float)Math.Sqrt(num);
        }

        
        public float Sin(float angleInDegrees)
        {
            double radians = Math.PI * angleInDegrees / 180.0;
            return (float)Math.Sin(radians);
        }

        public float Cos(float angleInDegrees)
        {
            double radians = Math.PI * angleInDegrees / 180.0;
            return (float)Math.Cos(radians);
        }

        public float Tan(float angleInDegrees)
        {
            double radians = Math.PI * angleInDegrees / 180.0;
            
            double tanValue = Math.Tan(radians);
            if (double.IsInfinity(tanValue))
                throw new InvalidOperationException("Тангенс для этого угла не определен");
            return (float)tanValue;
        }

    public float SquareRoot(float num, float num2)
    {
        throw new NotImplementedException();
    }

    public float Sin(float angleInDegrees, float num2)
    {
        throw new NotImplementedException();
    }

    public float Cos(float angleInDegrees, float num2)
    {
        throw new NotImplementedException();
    }

    public float Tan(float angleInDegrees, float num2)
    {
        throw new NotImplementedException();
    }
}


class Program
{
    static void House()
    {
        IComputer calculator = new Computer();
        Console.WriteLine($"Начать решение в {calculator.ComputerName}");

        
        Console.Write("Введите первое число: ");
        if (!float.TryParse(Console.ReadLine(), out float num1))
        {
            Console.WriteLine("Некорректный ввод. Завершение.");
            return;
        }

        
        Console.Write("Введите второе число: ");
        if (!float.TryParse(Console.ReadLine(), out float num2))
        {
            Console.WriteLine("Некорректный ввод. Завершение.");
            return;
        }

       
        Console.WriteLine("Выберите операцию (+, -, *, /, √, sin, con, tan):");
        string op = Console.ReadLine();

        try
        {
            float result;
            switch (op)
            {
                case "+":
                    result = calculator.Sum(num1, num2);
                    break;
                case "-":
                    result = calculator.Subtract(num1, num2);
                    break;
                case "*":
                    result = calculator.Multiply(num1, num2);
                    break;
                case "/":
                    result = calculator.Divide(num1, num2);
                    break;
                case "√":
                    result = calculator.SquareRoot(num1, num2);
                    break;
                case "Sin":
                    result = calculator.Sin(num1, num2);
                    break;
                case "Cos":
                    result = calculator.Cos(num1, num2);
                    break;
                case "Tan":
                    result = calculator.Tan(num1, num2);
                    break;
                default:
                    Console.WriteLine("Неизвестная операция");
                    return;
            }

            Console.WriteLine($"Результат: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}