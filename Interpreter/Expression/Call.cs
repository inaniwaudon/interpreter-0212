namespace Interpreter;

public class Call : Expr
{
    internal string Name { get; }
    internal Expr[] Args { get; }

    internal Call(string name, Expr[] args) : base(ExprType.Call)
    {
        Name = name;
        Args = args;
    }

    public static Call TCall(string name, Expr[] args)
    {
        return new(name, args);
    }
}
