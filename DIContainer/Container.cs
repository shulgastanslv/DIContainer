public class Container
{
    private readonly List<ServiceDescriptor> _serviceDescriptors;

    public Container(List<ServiceDescriptor> serviceDescriptors)
    {
       _serviceDescriptors = serviceDescriptors;
    }

    public object GetService (Type serviceType)
    {
        var descriptor = _serviceDescriptors.SingleOrDefault(i => i.ServiceType == serviceType);

        if (descriptor.Implementation != null)
        {
            return descriptor.Implementation;
        }

        var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

        if (actualType.IsAbstract || actualType.IsInterface)
        {

        }

        var constructor = actualType.GetConstructors().First();

        var arguments = constructor.GetParameters().Select(i => GetService(i.ParameterType)).ToArray();

        var implementation = Activator.CreateInstance(actualType, arguments);

        if (descriptor.LifeTime == LifeTime.Singleton)
        {
            descriptor.Implementation = implementation;
        }

        if (implementation != null) return implementation;

        return default!;
    }

    public T GetService<T>()
    {
        return (T)GetService(typeof(T));
    }
}