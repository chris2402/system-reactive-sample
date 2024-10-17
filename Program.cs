using System.Reactive.Linq;

// Uses current SynchronizationContext; SubscribeOn & ObserveOn

var eventSource = new SomeEventSource();

_ = Task.Run(async () => 
{
    while(true)
    {
        eventSource.Trigger();
        await Task.Delay(TimeSpan.FromSeconds(1));
    }
});

var hotObservable = Observable.FromEventPattern<EventHandler<SomeEventArg>, SomeEventArg>(
        h => eventSource.OnEvent += h,
        h => eventSource.OnEvent -= h)
    .Select(x => x.EventArgs.When);

await Task.Run(() => 
{
    bool shouldSubscribe = true;
    while (shouldSubscribe)
    {
        Console.WriteLine("Starting subscription, hit enter to unsubscribe");
        var subscription = hotObservable.Subscribe(when => Console.WriteLine(when));
        Console.ReadLine();
        subscription.Dispose();
        Console.WriteLine("Subscription stopped, resubscribe? [Y]/n");
        shouldSubscribe = (Console.ReadLine() ?? "").Trim().ToUpper() != "N";
    }
});

public class SomeEventArg : EventArgs 
{
    public DateTime When {get;set;} = DateTime.Now;
}
class SomeEventSource
{
    public event EventHandler<SomeEventArg>? OnEvent;

    public void Trigger() => OnEvent?.Invoke(this, new());
}