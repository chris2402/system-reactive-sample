using System.Reactive.Linq;

Enumerable.Range(1, 100)
    .ToObservable()
    .Subscribe(Console.WriteLine);


foreach (var answer in Observable.Range(1, 100).ToEnumerable())
{
    Console.WriteLine(answer);
}

#region nuget:System.Linq.Async

// var asyncEnumerableObservable = Observable.Range(0, 100).ToAsyncEnumerable();
// await foreach (var answer in asyncEnumerableObservable)
// {
//     Console.WriteLine(answer);
// }
// 
// https://github.com/dotnet/reactive/blob/main/Ix.NET/Source/System.Linq.Async/System/Linq/Operators/ToAsyncEnumerable.Observable.cs

// var observableAsyncEnumerable = AsyncEnumerable.Range(1,100)
//      .ToObservable();
//
// https://github.com/dotnet/reactive/blob/main/Ix.NET/Source/System.Linq.Async/System/Linq/Operators/Range.cs
// https://github.com/dotnet/reactive/blob/main/Ix.NET/Source/System.Linq.Async/System/Linq/Operators/ToObservable.cs

# endregion