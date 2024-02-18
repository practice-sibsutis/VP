// See https://aka.ms/new-console-template for more information
using DIExample;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;



IServiceCollection services = new ServiceCollection();
services = services.AddTransient<ILogger, ConsoleLogger>()
    .AddTransient<INotifyer, EmailNotifyer>(x => new EmailNotifyer("sdfsdf"))
    .AddTransient<Invoice>();

var serviceProvider = services.BuildServiceProvider();

Invoice invoice = serviceProvider.GetService<Invoice>();
Invoice invoice1 = new Invoice(new EmailNotifyer("asdas"),
    new ConsoleLogger());

