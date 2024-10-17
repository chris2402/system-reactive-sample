using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;


var observableAnswer = await Observable.Return(42);
var taskAnswer = await RequestAnswerOnMeaningOfLifeAsync();

// In fact, we can cast a Task to an Observable
var observableTask = await RequestAnswerOnMeaningOfLifeAsync().ToObservable();

Console.WriteLine($"Answer from observable is: {observableAnswer}");
Console.WriteLine($"Answer from task is: {taskAnswer}");
Console.WriteLine($"Answer from observable task is: {observableTask}");


Task<int> RequestAnswerOnMeaningOfLifeAsync() =>
    Task.FromResult(42);