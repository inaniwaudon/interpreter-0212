namespace Interpreter;

public class While : Expr
{
    internal Expr Condition { get; }
    internal Expr[] Bodies { get; }

    internal While(Expr condition, Expr[] bodies) : base(ExprType.IntValue)
    {
        Condition = condition;
        Bodies = bodies;
    }

    public static While TWhile(Expr condition, Expr[] bodies)
    {
        return new(condition, bodies);
    }
}
