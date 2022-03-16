using FactoryWithDI.Math.Attributes;

namespace FactoryWithDI.Math.Operations;

[MathOperationType(MathOperationType.Subtract)]
public class SubtractOperation: IMathOperation
{
    public SubtractOperation()
    {
        Console.WriteLine("{0} is created", GetType().Name);
    }

    public int Calculate(int a, int b)
    {
        return a - b;
    }
}