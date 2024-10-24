using System.Reactive.Linq;

var timesDeferedCalled = 0;
var observable = Observable.Defer(() => {
    Console.WriteLine($"Defered function is called '{timesDeferedCalled++}' times!");
    int i = 0;
    return Observable.Interval(TimeSpan.FromSeconds(1)).Take(3).Select(_ => i++);
});


Console.WriteLine("1. Subscribe;");
var tsc1 = new TaskCompletionSource();
observable
    .Subscribe(i => 
    {
        Console.WriteLine($"{i} is arrived on First!");
    }, 
    () => tsc1.SetResult());

await tsc1.Task;

var tsc2 = new TaskCompletionSource();
observable
    .Subscribe(i => 
    {
        Console.WriteLine($"{i} is arrived on Second!");
    }, 
    () => tsc2.SetResult());

await tsc2.Task;
