using System.Reactive.Linq;

var timesDeferedCalled = 0;
var observable = Observable.Defer(() => {
    Console.WriteLine($"Defered function is called '{timesDeferedCalled++}' times!");
    int i = 0;
    return Observable.Interval(TimeSpan.FromSeconds(1)).Take(3).Select(_ => i++);
})
.Publish()
.RefCount(); // !!!!!!!!!!!!!!!!!!!!!!!! Counts number of Subscribers!


Console.WriteLine("1. Subscribe;");
observable
    .Subscribe(i => 
    {
        Console.WriteLine($"{i} is arrived on First!");
    }, 
    () =>
    {
        Console.WriteLine("First is complete");
    });

Console.WriteLine("Await 3000 ms before connecting");

// NB: COMMENTED OUT! await tsc1.Task;

var tsc2 = new TaskCompletionSource();
Console.WriteLine("2. Subscribe;");
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
