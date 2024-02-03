// See https://aka.ms/new-console-template for more information
using ConsoleAppWithEvent;

Account account = new Account(100.0m);
account.Notify += (sender, balance) =>
{
    Console.WriteLine($"Balance notification {balance}");
};

account.Notify += (sender, balance) =>
{
    if (balance < 50.0m)
    {
        Console.WriteLine($"Low balance {balance}");
    }
};

account.ChangeBalance(10.0m);
account.ChangeBalance(-30.0m);
account.ChangeBalance(-40.0m);
