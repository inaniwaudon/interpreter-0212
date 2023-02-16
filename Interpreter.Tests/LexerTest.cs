namespace Interpreter.Tests;

public class LexerTest
{
    [Fact(DisplayName = "function add(a, b) { a + b; } add(1, 2);")]
    public void Test1()
    {
        var lexer = new Lexer("    function add(a, b) { a + b; } add(1, 2);   ");
        var tokenized = lexer.Tokenize();
        var expected = new Token[]
        {
            new(TokenType.Function, "function"),
            new(TokenType.Variable, "add"),
            new(TokenType.Bracket, "("),
            new(TokenType.Variable, "a"),
            new(TokenType.Comma, ","),
            new(TokenType.Variable, "b"),
            new(TokenType.Bracket, ")"),
            new(TokenType.Bracket, "{"),
            new(TokenType.Variable, "a"),
            new(TokenType.Sign, "+"),
            new(TokenType.Variable, "b"),
            new(TokenType.Semicolon, ";"),
            new(TokenType.Bracket, "}"),
            new(TokenType.Variable, "add"),
            new(TokenType.Bracket, "("),
            new(TokenType.Numeric, "1"),
            new(TokenType.Comma, ","),
            new(TokenType.Numeric, "2"),
            new(TokenType.Bracket, ")"),
            new(TokenType.Semicolon, ";"),
        };

        Assert.Equal(expected, tokenized);
    }
}
