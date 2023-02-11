namespace Interpleter;

public abstract class MIdent : Expr
{
    internal string Name { get; }

    internal MIdent(string name) : base(ExprType.MAssignment)
    {
        Name = name;
    }
}
