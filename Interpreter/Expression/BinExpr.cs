namespace Interpreter;

public class BinExpr : Expr
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

    public static BinExpr TAdd(Expr a, Expr b)
    {
        return new BinExpr("+", a, b);
    }

    public static BinExpr TSub(Expr a, Expr b)
    {
        return new BinExpr("-", a, b);
    }

    public static BinExpr TMul(Expr a, Expr b)
    {
        return new BinExpr("*", a, b);
    }

    public static BinExpr TDiv(Expr a, Expr b)
    {
        return new BinExpr("/", a, b);
    }
}
