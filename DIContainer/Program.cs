


var services = new ServiceCollection();

services.RegisterSingleton<Service>();



var container = new Container();

var service = container.GetService<Service>();


public class Service
{

}


//var services = new ServiceCollection();

//services.AddScoped<IMessage, Message>();
//services.AddScoped<IEmailService, EmailService>();


//var container = services.BuildServiceProvider();

//var email = container.GetRequiredService<IEnumerable<IEmailService>>();