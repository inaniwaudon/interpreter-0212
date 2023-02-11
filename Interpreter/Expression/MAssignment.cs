namespace Interpreter;

public class MAssignment : Expr
{
    internal string Name { get; }
    internal Expr Expr { get; }

    internal MAssignment(string name, Expr expr) : base(ExprType.MAssignment)
    {
        Name = name;
        Expr = expr;
    }
}
