using System.Reactive.Linq;


Observable.Return(42)
    .Subscribe(answer => 
    {
        Console.WriteLine("Answer to the Ultimate Question of Life, the Universe, and Everything:");
        Console.WriteLine(answer);        
    });

