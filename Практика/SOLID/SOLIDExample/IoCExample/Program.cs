// See https://aka.ms/new-console-template for more information
using DIExample;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;



IServiceCollection services = new ServiceCollection();
services = services.AddTransient<ILogger, FileLogger>();
services = services.AddTransient<INotifyer, EmailNotifyer>(x => new EmailNotifyer("sdfsdf"));
services = services.AddTransient<Invoice>();

var serviceProvider = services.BuildServiceProvider();

Invoice invoice = serviceProvider.GetService<Invoice>();
Invoice invoice1 = new Invoice(new TelegramNotifyer("asdas"),
    new ConsoleLogger());

