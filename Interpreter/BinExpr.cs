namespace Interpleter;

public abstract class BinExpr : Expr
{
    internal string Op { get; }
    internal Expr Lhs { get; }
    internal Expr Rhs { get; }

    internal BinExpr(string op, Expr lhs, Expr rhs) : base(ExprType.BinExpr)
    {
        Op = op;
        Lhs = lhs;
        Rhs = rhs;
    }
}
