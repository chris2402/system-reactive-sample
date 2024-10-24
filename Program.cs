using System.Reactive.Linq;

var timesDeferedCalled = 0;
var observable = Observable.Defer(() => {
    Console.WriteLine($"Defered function is called '{timesDeferedCalled++}' times!");
    int i = 0;
    return Observable.Interval(TimeSpan.FromSeconds(1)).Take(3).Select(_ => i++);
})
.Publish();


Console.WriteLine("1. Subscribe;");
var tsc1 = new TaskCompletionSource();
observable
    .Subscribe(i => 
    {
        Console.WriteLine($"{i} is arrived on First!");
    }, 
    () =>
    {
        Console.WriteLine("First is complete");
        tsc1.SetResult();
    });

Console.WriteLine("Await 3000 ms before connecting");

await Task.Delay(3000);
observable.Connect();
await tsc1.Task;

var tsc2 = new TaskCompletionSource();
observable
    .Subscribe(i => 
    {
        Console.WriteLine($"{i} is arrived on Second!");
    }, 
    () =>
    {
        Console.WriteLine("Second is complete");
        tsc2.SetResult();
    });

await tsc2.Task;
