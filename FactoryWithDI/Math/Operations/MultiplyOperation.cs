using FactoryWithDI.Math.Attributes;

namespace FactoryWithDI.Math.Operations;

[MathOperationType(MathOperationType.Multiply)]
public class MultiplyOperation : IMathOperation
{
    public MultiplyOperation()
    {
        Console.WriteLine("{0} is created", GetType().Name);
    }
    
    public int Calculate(int a, int b)
    {
        return a * b;
    }
}