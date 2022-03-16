using FactoryWithDI.Math.Operations;

namespace FactoryWithDI.Math;

public class MathOperationFactory : IMathOperationFactory
{
    private readonly IReadOnlyDictionary<MathOperationType, Func<IMathOperation?>> _factories;

    public MathOperationFactory(IReadOnlyDictionary<MathOperationType, Func<IMathOperation?>> factories)
    {
        _factories = factories;
    }

    public IMathOperation Create(MathOperationType operationType)
    {
        if (_factories.TryGetValue(operationType, out Func<IMathOperation?>? factory))
        {
            IMathOperation? operation = factory();
            if (operation != null)
            {
                return operation;
            }
        }

        throw new ArgumentOutOfRangeException(nameof(operationType), $"Type '{operationType}' is not registered");
    }
}