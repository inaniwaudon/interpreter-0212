namespace Interpreter;

public class While : Expr
{
    internal Expr Condition { get; }
    internal Seq Bodies { get; }

    internal While(Expr condition, Seq bodies) : base(ExprType.While)
    {
        Condition = condition;
        Bodies = bodies;
    }

    public static While TWhile(Expr condition, Seq bodies)
    {
        return new(condition, bodies);
    }
}
