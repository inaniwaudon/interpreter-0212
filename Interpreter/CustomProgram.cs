namespace Interpreter;

public class CustomProgram
{
    internal Function[] Functions { get; }
    internal Expr[] Bodies { get; }

    public CustomProgram(Function[] functions, Expr[] bodies)
    {
        Functions = functions;
        Bodies = bodies;
    }

    public static CustomProgram TProgram(Function[] functions, Expr[] bodies)
    {
        return new(functions, bodies);
    }
}
