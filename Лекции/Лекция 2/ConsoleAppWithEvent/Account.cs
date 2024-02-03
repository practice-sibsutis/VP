namespace ConsoleAppWithEvent;

public class Account(decimal balance)
{
    public Account() : this(0.0m)
    { }

    public void ChangeBalance(decimal value)
    {
        balance += value;
        if (Notify != null)
        {
            Notify(this, balance);
        }
    }

    public event EventHandler<decimal>? Notify;
}