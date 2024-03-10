// See https://aka.ms/new-console-template for more information
using EventHandlerExample;

Publisher publisher = new Publisher();

publisher.SampleEvent += (sender, args) =>
{
    Console.WriteLine(args.Text);
};


publisher.RaiseEvent();
publisher.RaiseEvent();
publisher.RaiseEvent();
