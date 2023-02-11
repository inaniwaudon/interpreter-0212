namespace Interpleter;

public abstract class IntValue : Expr
{
    internal int Value { get; }

    internal IntValue(string type, int value) : base(ExprType.IntValue)
    {
        Value = value;
    }
}
