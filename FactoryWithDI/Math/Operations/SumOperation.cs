using FactoryWithDI.Math.Attributes;

namespace FactoryWithDI.Math.Operations;

[MathOperationType(MathOperationType.Sum)]
public class SumOperation : IMathOperation
{
    public SumOperation()
    {
        Console.WriteLine("{0} is created", GetType().Name);
    }

    public int Calculate(int a, int b)
    {
        return a + b;
    }
}