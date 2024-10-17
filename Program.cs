using System.Reactive.Linq;

Observable.Range(0, 100)
    .Buffer(5)
    .Subscribe(buffer => 
    {
        Console.WriteLine(string.Join(',', buffer));
    });

Console.ReadLine();

// Will only sometimes reach 5 events within the time window 
Observable.Interval(TimeSpan.FromSeconds(0.21)) 
    .Window(TimeSpan.FromSeconds(1), 5)
    .SelectMany(window => window.ToArray())
    .Subscribe(array => 
    {
        Console.WriteLine(string.Join(',', array));
    });

Console.ReadLine();