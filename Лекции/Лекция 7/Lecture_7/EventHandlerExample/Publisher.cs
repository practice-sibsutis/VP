namespace EventHandlerExample;

public class Publisher
{
    // Declare the event.
    public event EventHandler<SampleEventArgs> SampleEvent;

    public void RaiseEvent()
    {
        RaiseSampleEvent();
    }

    // Wrap the event in a protected virtual method
    // to enable derived classes to raise the event.
    protected virtual void RaiseSampleEvent()
    {
        // Raise the event in a thread-safe manner using the ?. operator.
        SampleEvent?.Invoke(this, new SampleEventArgs("Hello"));
    }
}