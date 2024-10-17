using System.Reactive.Linq;

// Uses current SynchronizationContext; SubscribeOn & ObserveOn

var eventSource = new SomeEventSource();
// Observable.FromEventPattern<SomeEventArg>(eventSource, nameof(SomeEventSource.OnEvent));
Observable.FromEventPattern<EventHandler<SomeEventArg>, SomeEventArg>(
        h => eventSource.OnEvent += h,
        h => eventSource.OnEvent -= h)
    .Select(x => x.EventArgs.When)
    .Subscribe(when => Console.WriteLine(when));

// Execute
eventSource.Trigger();
await Task.Delay(TimeSpan.FromSeconds(1));
eventSource.Trigger();
await Task.Delay(TimeSpan.FromSeconds(2));
eventSource.Trigger();

public class SomeEventArg : EventArgs 
{
    public DateTime When {get;set;} = DateTime.Now;
}
class SomeEventSource
{
    public event EventHandler<SomeEventArg>? OnEvent;

    public void Trigger() => OnEvent?.Invoke(this, new());
}