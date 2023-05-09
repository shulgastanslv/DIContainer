## Introduction
DI container written from scratch in .net 7.0 with the basic methods and features.

![Introduction](https://i.pinimg.com/originals/be/87/ac/be87ac77f74e075f225696d52542c425.gif)

## Installation
```
$ git clone https://github.com/akiroqw/DIContainer.git
```
To add a link to this project, follow these steps:
* Go to your project and click on the "Dependencies" button
* Add a link to the project
* Select the downloaded project

## Usage
```cs
var services = new ServiceCollection(); //Initializing a collection of services to register our services
```
After initialization, we can add some services and their implementations to our collection.
A simple example of a services:
```cs
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
        Text = "Message";
    }
}
```
Adding services to the collection
```cs
services.AddSingleton<IMessage, Message>();
services.AddTransient<IService, Service>();
```
After adding services, let's assemble our container
```cs
var container = services.BuildServiceProvider();
```
Our container contains the services that we just added, we can get one of these services using the `GetService` method

For example:
```cs
var service = container.GetService<IService>();
```
Our `service` variable stores an object of type `IService`, so that we can call those methods that are defined in our interface
```
service.Show(); //Output: Message
```


