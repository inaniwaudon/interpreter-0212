namespace Interpreter;

public abstract class Expr : Ast
{
    internal Expr(ExprType type)
    {
        Type = type;
    }
}
