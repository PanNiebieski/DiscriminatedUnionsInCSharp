// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

var result = TransformText("");

result.Switch((v) =>
    Console.WriteLine(v),
    () => Console.WriteLine("Error"));

var m = result.Match((v) => { return v; },
    () => { return "Error"; });
Console.WriteLine(m);

Result<string> TransformText(string? value)
{
    if (string.IsNullOrWhiteSpace(value)) return new Result<string>();
    return new Result<string>($"Add transformation {value}");
}

public class Result<T>
{
    public T Value { get; }
    public bool Success { get; }
    public Result(T value)
    {
        Value = value;
        Success = true;
    }

    public Result() => Success = false;

    public void Switch(Action<T> success, Action error) {
        if (Success) { success(Value); } else { error(); };
     }

    public TResult Match<TResult>(Func<T, TResult> success, Func<TResult> error)
    => Success ? success(Value) : error();
}

