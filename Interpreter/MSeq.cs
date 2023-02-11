namespace Interpleter;

public abstract class MSeq : Expr
{
    internal Expr[] Bodies { get; }

    internal MSeq(params Expr[] bodies) : base(ExprType.MAssignment)
    {
        Bodies = bodies;
    }
}
