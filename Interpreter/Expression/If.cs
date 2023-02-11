namespace Interpreter;

public class If : Expr
{
    internal Expr Condition { get; }
    internal Expr ThenClause { get; }
    internal Expr ElseClause { get; }

    internal If(Expr condition, Expr thenClause, Expr elseClause) : base(ExprType.If)
    {
        Condition = condition;
        ThenClause = thenClause;
        ElseClause = elseClause;
    }

    public static If TIf(Expr condition, Expr thenClause, Expr elseClause)
    {
        return new(condition, thenClause, elseClause);
    }
}
