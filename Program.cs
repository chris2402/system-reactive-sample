using System.Reactive.Linq;


var coldObservable = Observable.Return(42);

coldObservable.Subscribe(answer => 
    {
        Console.WriteLine("Answer to the Ultimate Question of Life, the Universe, and Everything:");
        Console.WriteLine(answer);        
    });

coldObservable.Subscribe(answer => 
    {
        Console.WriteLine("I said; Answer to the Ultimate Question of Life, the Universe, and Everything:");
        Console.WriteLine(answer);        
    });

coldObservable.Subscribe(answer => 
    {
        Console.WriteLine("ARE YOU DEAF?!");
        Console.WriteLine(answer);        
        Console.WriteLine("OKAY?!");
    });
