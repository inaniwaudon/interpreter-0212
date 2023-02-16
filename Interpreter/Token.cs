namespace Interpreter;

public readonly struct Token
{
    internal TokenType Type { get; }
    internal string Value { get; }

    public Token(TokenType type, string value)
    {
        Type = type;
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is Token token && token.Type == Type && token.Value == Value;
    }

    public override int GetHashCode()
    {
        return new { Type, Value }.GetHashCode();
    }
}