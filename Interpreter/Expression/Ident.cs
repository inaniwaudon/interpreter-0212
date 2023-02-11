namespace Interpreter;

public class Ident : Expr
{
    internal string Name { get; }

    internal Ident(string name) : base(ExprType.Ident)
    {
        Name = name;
    }

    public static Ident TIdent(string name)
    {
        return new(name);
    }
}
