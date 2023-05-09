public class ServiceCollection
{
    private readonly List<ServiceDescriptor> _serviceDescriptors = new();

    public void AddSingleton<TService>()
    {
        _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService),
            LifeTime.Singleton));
    }
    public void AddTransient<TService>()
    {
        _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService),
            LifeTime.Transient));
    }
    public void AddSingleton<TService, TImplementation>() where TImplementation : TService
    {
        _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation),
            LifeTime.Singleton));
    }
    public void AddTransient<TService, TImplementation>() where TImplementation : TService
    {
        _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation),
            LifeTime.Transient));
    }
    public Container BuildServiceProvider()
    {
        return new Container(_serviceDescriptors);
    }
}