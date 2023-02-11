namespace Interpreter;

public abstract class Expr
{
    internal ExprType Type { get; }

    internal Expr(ExprType type)
    {
        Type = type;
    }
}
