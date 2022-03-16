using FactoryWithDI.Math.Operations;

namespace FactoryWithDI.Math;

public interface IMathOperationFactory
{
    IMathOperation Create(MathOperationType operationType);
}