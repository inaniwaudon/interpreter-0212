namespace Interpreter;

public class CustomProgram
{
    public CustomFunction[] CustomFunctions { get; }
    public Expr[] Bodies { get; }

    public CustomProgram(CustomFunction[] functions, Seq bodies)
    {
        CustomFunctions = functions;
        Bodies = bodies.Bodies;
    }

    public static CustomProgram TProgram(CustomFunction[] functions, Seq bodies)
    {
        return new(functions, bodies);
    }

    public override bool Equals(object? obj)
    {
        return obj is CustomProgram cp &&
            cp.CustomFunctions.SequenceEqual(CustomFunctions) &&
            cp.Bodies.SequenceEqual(Bodies);
    }

    public override int GetHashCode()
    {
        return new { CustomFunctions, Bodies }.GetHashCode();
    }
}
