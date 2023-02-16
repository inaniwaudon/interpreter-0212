namespace Interpreter;

public class Seq : Expr
{
    internal Expr[] Bodies { get; }

    public Seq(params Expr[] bodies) : base(ExprType.Seq)
    {
        Bodies = bodies;
    }

    public static Seq TSeq(params Expr[] bodies)
    {
        return new(bodies);
    }

    public override bool Equals(object? obj)
    {
        return obj is Seq seq && seq.Bodies.SequenceEqual(Bodies);
    }

    public override int GetHashCode()
    {
        return Bodies.GetHashCode();
    }
}
