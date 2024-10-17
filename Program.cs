using System.Reactive.Linq;
using System.Reactive.Subjects;

// NB RUN IN CONSOLE > dotnet run 


// Create a subject that will take string inputs
var subject = new Subject<string>();
int maxLengthSoFar = 0;

// Set up an observable that emits on the first change,
// then debounces for Xms with the latest value.
var debouncedObservable = subject
    .Throttle(TimeSpan.FromMilliseconds(250)) 
    .DistinctUntilChanged(); 

debouncedObservable.Subscribe(v =>
{            
    int currentLineCursor = Console.CursorTop;
    Console.SetCursorPosition(0, currentLineCursor);
    Console.Write(new string(' ', v.Length + 100));
    Console.SetCursorPosition(0, currentLineCursor);
    Console.Write(v);
});

Console.WriteLine("Start typing!");
string inputBuffer = string.Empty;
while (true)
{
    // Read a key without displaying it in the console
    var keyInfo = Console.ReadKey(intercept: true);
    if (keyInfo.Key == ConsoleKey.Backspace && inputBuffer.Length > 0)
    {
        inputBuffer = inputBuffer.Substring(0, inputBuffer.Length - 1);  // Remove last character
        subject.OnNext(inputBuffer);  // Emit the updated string
    }

    // If the key is a valid character, add it to the input buffer and the subject
    if (!char.IsControl(keyInfo.KeyChar))  // Only add printable characters
    {
        inputBuffer += keyInfo.KeyChar;
        maxLengthSoFar = Math.Max(inputBuffer.Length, maxLengthSoFar);
        subject.OnNext(inputBuffer);  // Emit the current buffer
    }
}