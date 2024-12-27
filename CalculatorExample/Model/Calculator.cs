namespace CalculatorExample
{
    internal class Calculator
    {
        private ILogger _logger;
        public Calculator(ILogger logger)
        {
            _logger = logger;
        }
        public float Divide(float number1, float number2)
        {
            _logger.WriteLine($"Деление: {number1} / {number2}");
            return number1 / number2;
        }

        public float Multiply(float number1, float number2)
        {
            _logger.WriteLine($"Умножение: {number1} * {number2}");
            return number1 * number2;
        }

        public float Add(float number1, float number2)
        {
            _logger.WriteLine($"Сложение: {number1} + {number2}");
            return number1 + number2;
        }

        public float Subtract(float number1, float number2)
        {
            _logger.WriteLine($"Вычитание: {number1} - {number2}");
            return number1 - number2;
        }
    }
}
