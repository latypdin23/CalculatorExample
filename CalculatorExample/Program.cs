using Microsoft.Extensions.DependencyInjection;
using System;

namespace CalculatorExample
{
    internal class Program
    {
        #region Вспомогательные методы
        private static float GetNumber(string message)
        {
            var isValid = false;
            while (!isValid)
            {
                Console.Write(message);
                var input = Console.ReadLine();
                isValid = float.TryParse(input, out var number);
                if (isValid)
                    return number;

                Console.WriteLine("Введите число:");
            }

            return -1;
        }

        private static char GetOperator()
        {
            var isValid = false;
            while (!isValid)
            {
                Console.Write("Please type the operator (/*+-) > ");
                var input = Console.ReadKey();
                Console.WriteLine();
                var operation = input.KeyChar.ToString();
                if ("/*+-".Contains(operation))
                {
                    isValid = true;
                    return operation[0];
                }

                Console.WriteLine("Введите оператор (/, *, +, -). ");
            }

            return ' ';
        }

        private static float GetResult(Calculator calc, float number1, float number2,
            char operation)
        {
            switch (operation)
            {
                case '/': return calc.Divide(number1, number2);
                case '*': return calc.Multiply(number1, number2);
                case '+': return calc.Add(number1, number2);
                case '-': return calc.Subtract(number1, number2);
                default:
                    throw new InvalidOperationException("Неверная операция: " +
                                                        operation);
            }
        }
        #endregion
        static void Variant1()
        {
            var number1 = GetNumber("Введите первое число: > ");
            var number2 = GetNumber("Введите второе число: > ");
            var operation = GetOperator();

            var logger = new ConsoleLogger();
            var calc = new Calculator(logger);

            var result = GetResult(calc, number1, number2, operation);
            Console.WriteLine($"{number1} {operation} {number2} = {result}");
            Console.ReadKey();
        }
        static void Variant2()
        {
            var number1 = GetNumber("Введите первое число: > ");
            var number2 = GetNumber("Введите второе число: > ");
            var operation = GetOperator();

            var services = new ServiceCollection()
                                    .AddTransient<ILogger, FileLogger>();

            var serviceProvider = services.BuildServiceProvider();
            var calc = new Calculator(serviceProvider.GetRequiredService<ILogger>());

            var result = GetResult(calc, number1, number2, operation);
            Console.WriteLine($"{number1} {operation} {number2} = {result}");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Variant2();
        }
    }
}
