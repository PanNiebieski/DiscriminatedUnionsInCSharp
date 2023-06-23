
using OneOf;

var result = ExampleCreatingUser(3);
result.Switch(
    done => { Console.WriteLine(done.Value); },
    less => { Console.WriteLine("Less than one"); },
    exist => { Console.WriteLine("Exist"); }
);

OneOf<Done<int>, IdLessThanOne, 
    IdAlreadyExist> ExampleCreatingUser(int id)
{
    if (id == 3)
        return new IdAlreadyExist();
    if (id >= 1)
        return new Done<int>(1);
    else
        return new IdLessThanOne();
}

public record IdLessThanOne();
public record IdAlreadyExist();
public record Done<T>(T Value);



