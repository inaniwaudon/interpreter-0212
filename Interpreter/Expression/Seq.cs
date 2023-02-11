namespace Interpreter;

public class Seq : Expr
{
    internal Expr[] Bodies { get; }

    internal Seq(params Expr[] bodies) : base(ExprType.Seq)
    {
        Bodies = bodies;
    }

    public static Seq TSeq(params Expr[] bodies)
    {
        return new(bodies);
    }
}
