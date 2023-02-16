namespace Interpreter;

public class Assignment : Expr
{
    internal string Name { get; }
    internal Expr Expr { get; }

    internal Assignment(string name, Expr expr) : base(ExprType.Assignment)
    {
        Name = name;
        Expr = expr;
    }

    public static Assignment TAssign(string name, Expr expr)
    {
        return new(name, expr);
    }
}
