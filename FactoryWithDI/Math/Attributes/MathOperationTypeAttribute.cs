namespace FactoryWithDI.Math.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class MathOperationTypeAttribute : Attribute
{
    public MathOperationTypeAttribute(MathOperationType operationType)
    {
        OperationType = operationType;
    }
    
    public MathOperationType OperationType { get; }
}