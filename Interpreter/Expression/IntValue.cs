namespace Interpreter;

public class IntValue : Expr
{
    internal int Value { get; }

    internal IntValue(int value) : base(ExprType.IntValue)
    {
        Value = value;
    }

    public static IntValue TInt(int value)
    {
        return new IntValue(value);
    }
}
