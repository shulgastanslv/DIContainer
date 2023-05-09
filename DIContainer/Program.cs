
var services = new ServiceCollection();

services.AddSingleton<IMessage, Message>();
services.AddTransient<IService, Service>();

var container = services.BuildServiceProvider();

var service1 = container.GetService<IService>();

service1.Show();    

    
public interface IService
{ 
    void Show();
}
public class Service : IService
{
    private readonly IMessage _message;
    public Service(IMessage message)
    {
        _message = message;
    }
    public void Show()
    {
        Console.WriteLine(_message.Text);
    }
}
public interface IMessage
{
    public string Text { get; set; }
}
public class Message : IMessage
{
    public string Text { get; set; }

    public Message()
    {
        Text = "Root";
    }
}

