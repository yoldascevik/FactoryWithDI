using System.Reflection;
using FactoryWithDI.Math.Attributes;
using FactoryWithDI.Math.Operations;

namespace FactoryWithDI.Math.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterMathOperations(this IServiceCollection services, Assembly assembly)
    {
        List<Type> operationTypes = assembly.GetTypes()
            .Where(t => typeof(IMathOperation).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
            .ToList();

        if (!operationTypes.Any())
            return services;

        operationTypes.ForEach(operationType => services.AddSingleton(operationType));
        
        services.AddSingleton<IMathOperationFactory>(ctx =>
        {
            var factories = new Dictionary<MathOperationType, Func<IMathOperation?>>();

            foreach (Type operationType in operationTypes)
            {
                var operationTypeAttribute = operationType.GetCustomAttribute<MathOperationTypeAttribute>();
                if (operationTypeAttribute is null)
                    throw new ArgumentException($"{nameof(MathOperationTypeAttribute)} is not specified for type {operationType.Name}");

                Func<IMathOperation?> operationFactory = () => (IMathOperation?)ctx.GetService(operationType);

                if (!factories.TryAdd(operationTypeAttribute.OperationType, operationFactory))
                    throw new ArgumentException($"OperationType {operationTypeAttribute.OperationType} multiple defined!");
            }

            return new MathOperationFactory(factories);
        });

        return services;
    }
}