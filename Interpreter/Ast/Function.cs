namespace Interpreter;

public class CustomFunction
{
    public string Name { get; }
    public string[] Params { get; }
    public Seq Bodies { get; }

    public CustomFunction(string name, string[] pparams, Seq bodies)
    {
        Name = name;
        Params = pparams;
        Bodies = bodies;
    }

    public static CustomFunction TFunction(string name, string[] pparams, Seq bodies)
    {
        return new(name, pparams, bodies); ;
    }

    public override bool Equals(object? obj)
    {
        return obj is CustomFunction cf &&
            cf.Name == Name &&
            cf.Params.SequenceEqual(Params) &&
            cf.Bodies.Equals(Bodies);
    }

    public override int GetHashCode()
    {
        return new { Name, Params, Bodies }.GetHashCode();
    }
}
