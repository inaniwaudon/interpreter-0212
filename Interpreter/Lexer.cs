using System.Text;
namespace Interpleter;

public class Lexer
{
    private readonly string _text;
    private int _currentPos = 0;

    public Lexer(string text)
    {
        _text = text;
    }

    private char CurrentChar
    {
        get => _text[_currentPos];
    }

    private char? NextChar
    {
        get => _currentPos < _text.Length - 1 ? _text[_currentPos + 1] : null;
    }

    public List<Token> Tokenize()
    {
        var tokens = new List<Token>();
        SkipSpaces();
        while (!Ends())
        {
            if (CurrentChar is '+' or '*' or '-' or '/' or '<' or '>')
            {
                tokens.Add(new Token(TokenType.Sign, CurrentChar.ToString()));
                MoveNext();
            }
            else if (StartsWithNumeric())
            {
                tokens.Add(GetTokenAsNumeric());
            }
            else
            {
                throw new NotImplementedException();
            }
            SkipSpaces();
        }
        return tokens;
    }

    private Token GetTokenAsNumeric()
    {
        var sb = new StringBuilder();
        if (StartsWithNumeric())
        {
            sb.Append(CurrentChar);
            MoveNext();
        }
        return new Token(TokenType.Variable, sb.ToString());
    }

    private void MoveNext()
    {
        _currentPos++;
    }

    private bool StartsWithNumeric()
    {
        return char.GetNumericValue(CurrentChar) is not -1;
    }

    private bool Ends()
    {
        return _currentPos >= _text.Length;
    }

    private void SkipSpaces()
    {
        while (!Ends() && CurrentChar is ' ' or '\t' or '\n')
        {
            MoveNext();
        }
    }
}
