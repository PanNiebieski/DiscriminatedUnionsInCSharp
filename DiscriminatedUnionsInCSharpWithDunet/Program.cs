
using Dunet;
using static Option<int>;

Option<int> ParseInt(string? value) =>
    int.TryParse(value, out var number)
        ? new Some(number)
        : new None();

string GetOutput(Option<int> number) =>
    number.Match(
        some => some.Value.ToString(),
        none => "Wrong input"
    );

var input = "NotANumber";
var result = ParseInt(input);
var output = GetOutput(result);
Console.WriteLine(output); //Wrong input"


[Union]
partial record Option<T>
{
    partial record Some(T Value);
    partial record None();
}