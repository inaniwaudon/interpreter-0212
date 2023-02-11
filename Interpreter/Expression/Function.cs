namespace Interpreter;

public class Function
{
    internal string Name { get; }
    internal string[] Params { get; }
    internal Seq Bodies { get; }

    internal Function(string name, string[] pparams, Seq bodies)
    {
        Name = name;
        Params = pparams;
        Bodies = bodies;
    }

    public static Function TFunction(string name, string[] pparams, Seq bodies)
    {
        return new(name, pparams, bodies); ;
    }
}
