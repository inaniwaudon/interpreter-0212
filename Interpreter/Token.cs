namespace Interpreter;

public readonly struct Token
{
    internal TokenType Type { get; }
    internal string Value { get; }

    internal Token(TokenType type, string value)
    {
        Type = type;
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}