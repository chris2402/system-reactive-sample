using System.Reactive.Linq;

var timesDeferedCalled = 0;
var observable = Observable.Defer(() => {
    Console.WriteLine($"Defered function is called '{timesDeferedCalled++}' times!");
    int i = 0;
    return Observable.Interval(TimeSpan.FromSeconds(1)).Select(_ => i++); // Does not end!
})
.Publish()
.RefCount(); // !!!!!!!!!!!!!!!!!!!!!!!! Counts number of Subscribers!


Console.WriteLine("1. Subscribe;");
var subs1 = observable
    .Subscribe(i => 
    {
        Console.WriteLine($"{i} is arrived on First!");
    }, 
    () =>
    {
        Console.WriteLine("First is complete");
    });

Console.WriteLine("Await 3000 ms before connecting");

Console.WriteLine("2. Subscribe;");
var subs2 = observable
    .Subscribe(i => 
    {
        Console.WriteLine($"{i} is arrived on Second!");
    }, 
    () =>
    {
        Console.WriteLine("Second is complete");
    });

Console.WriteLine("Waiting 5000ms");
await Task.Delay(5000);

Console.WriteLine("Disposing sub for 1 & 2");
subs1.Dispose();
subs2.Dispose();


Console.WriteLine("3. Subscribe;");
var subs3 = observable
    .Subscribe(i => 
    {
        Console.WriteLine($"{i} is arrived on Second!");
    }, 
    () =>
    {
        Console.WriteLine("Second is complete");
    });



await Task.Delay(3000);