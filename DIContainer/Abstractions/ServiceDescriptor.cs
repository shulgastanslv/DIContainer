public class ServiceDescriptor
{
    public Type ServiceType { get; set; }
    public Type ImplementationType { get; set; }
    public object Implementation { get; set; }
    public LifeTime LifeTime { get; set; }

    public ServiceDescriptor(object implementation, LifeTime lifeTime)
    {
        ServiceType = implementation.GetType();
        Implementation = implementation;
        LifeTime = lifeTime;
    }

    public ServiceDescriptor(Type serviceType, Type implementationType , LifeTime lifeTime)
    {
        ServiceType = serviceType;
        ImplementationType = implementationType;
        LifeTime = lifeTime;
    }
}