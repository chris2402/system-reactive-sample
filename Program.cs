using System.Reactive.Linq;

Observable.Timer(TimeSpan.FromSeconds(1))
    .Subscribe(i => Console.WriteLine($"Timer {i} time"));

Observable.Interval(TimeSpan.FromSeconds(1))
    .Subscribe(i => Console.WriteLine($"Interval {i} time"));

var intialState = 5;
Observable.Generate(
    intialState, 
    state => state < 100,
    state => state + 5,
    state => state.ToString()
    // ,state => TimeSpan.FromSeconds(0.5)
    )
    .Subscribe(i => Console.WriteLine($"(Timed)Generate {i} time"));

await Task.Delay(6_000);