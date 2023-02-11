namespace Interpreter;

public static class Program
{
    public static void Main(string[] args)
    {
        var lexer = new Lexer("1+2  +3+4");
        var tokens = lexer.Tokenize();
        var tokenizer = new Parser(tokens);
    }
}
