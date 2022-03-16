using FactoryWithDI.Math.Attributes;

namespace FactoryWithDI.Math.Operations;

[MathOperationType(MathOperationType.Division)]
public class DivisionOperation : IMathOperation
{
    public DivisionOperation()
    {
        Console.WriteLine("{0} is created", GetType().Name);
    }

    public int Calculate(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException();
        }

        return a / b;
    }
}