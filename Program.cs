using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

Console.WriteLine("Should we throw Y/[N]?");
var shouldThrow = (Console.ReadLine() ?? "").Trim().ToUpper() == "Y"; 

async Task SomeDangerousOperation()
{
    if (shouldThrow) throw new Exception();
    else await Task.Yield();
}


#region Conventional try await Task catch   
try
{
    var taskResult = await RequestAnswerOnMeaningOfLifeAsync();
}
catch
{
    // Handle error
}
# endregion

# region Observable Exception Handling

// In subcribers
RequestAnswerOnMeaningOfLifeObservable()
    .Subscribe(
        observableResult =>
            Console.WriteLine($"Observable Result: {observableResult}"),
        exception =>
            Console.WriteLine($"Observable.OnError handling - Woopsie!"));
            



// Catch via Observables
RequestAnswerOnMeaningOfLifeObservable()
    .Catch<int, Exception>(exception => Observable.Empty<int>()) // Catches all Exceptions
    .Subscribe(
        observableResult =>
            Console.WriteLine(shouldThrow ? "I will never be called!" : $"Observable (with catch) Result: {observableResult}"),
        exception =>
            Console.WriteLine($"I will never be called!"));




// Retry 
var retries = 0;
RequestAnswerOnMeaningOfLifeObservable()
    .Do(_ => {}, ex => Console.WriteLine($"Observable (with retry) has failed '{++retries}' times!"))
    .Retry(3) // or RetryWhen<T, Any>(Func<IObservable<Exception>, IObservable<Any>>): IObservable<T>
    .Subscribe(
        observableResult =>
            Console.WriteLine($"Observable (with retry) Result: {observableResult}"),
        exception =>
            Console.WriteLine($"Observable.OnError (with retry) handling - Woopsie!"));

// There are probably more

#endregion

#region API's
// API's
IObservable<int> RequestAnswerOnMeaningOfLifeObservable() 
{
    return SomeDangerousOperation()
        .ToObservable()
        .Select(_ => 42);
}

async Task<int> RequestAnswerOnMeaningOfLifeAsync() 
{
    await SomeDangerousOperation();

    return 42;
}

#endregion