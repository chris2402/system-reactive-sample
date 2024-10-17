using System.Reactive.Disposables;
using System.Reactive.Linq;


var answerFromDeepThought = Observable.Return(42);

var answerFromUnivac = Observable.Never<int>();

var answerFromMyMachine = Observable.Throw<int>(new NotYourMachineException());

var answerFromChatGpt = Observable.Create<int>(observer => 
{
    observer.OnNext(42);
    observer.OnNext(69);
    observer.OnNext(420);
    observer.OnNext(1337);
    return Disposable.Empty;
});

Dictionary<string, IObservable<int>> observables = new()
{
    ["DeepThought"] = answerFromDeepThought,
    ["Univac"] = answerFromUnivac,
    ["My Machine"] = answerFromMyMachine,
    ["ChatGPT"] = answerFromChatGpt
};

foreach (var (n,o) in observables)
    o.Subscribe(
        x => Console.WriteLine($"{n} - {x}"),
        exc => Console.WriteLine($"{n} - {exc.GetType().Name}"));

class NotYourMachineException : Exception {}
