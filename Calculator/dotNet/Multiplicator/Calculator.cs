
namespace Multiplicator
{
    public class Calculator
    {
        public enum Operation
        {
            Multiplication,
            Division,
            Addition,
            Substraction
        }

        public static double Calculate(Operation operation, int operand1, int operand2)
        {
            double result = 0.0;
            switch (operation)
            {
                case Operation.Multiplication:
                    Multiplicator instance = new Multiplicator();
                    result = instance.Multiply(operand1, operand2);
                    break;

            }

            return result;
        }
    }
}
