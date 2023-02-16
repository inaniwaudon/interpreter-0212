using System.Text;
namespace Interpreter;

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
            if (CurrentChar is '{' or '}' or '(' or ')')
            {
                tokens.Add(new Token(TokenType.Bracket, CurrentChar.ToString()));
                MoveNext();
            }
            else if (CurrentChar is ';')
            {
                tokens.Add(new Token(TokenType.Semicolon, ";"));
                MoveNext();
            }
            else if (CurrentChar is ',')
            {
                tokens.Add(new Token(TokenType.Comma, ","));
                MoveNext();
            }
            else if (CurrentChar is '=')
            {
                if (NextChar is '=')
                {
                    tokens.Add(new Token(TokenType.Sign, "=="));
                    MoveNext();
                }
                else
                {
                    tokens.Add(new Token(TokenType.Assignment, "="));
                }
                MoveNext();
            }
            else if (CurrentChar is '+' or '*' or '-' or '/')
            {
                tokens.Add(new Token(TokenType.Sign, CurrentChar.ToString()));
                MoveNext();
            }
            else if (CurrentChar is '<' or '>')
            {
                if (NextChar is '=')
                {
                    tokens.Add(new Token(TokenType.Sign, CurrentChar.ToString() + "="));
                    MoveNext();
                }
                else
                {
                    tokens.Add(new Token(TokenType.Sign, CurrentChar.ToString()));
                }
                MoveNext();
            }
            else if (StartsWithNumeric())
            {
                tokens.Add(GetTokenAsNumeric());
            }
            else
            {
                if (MatchesKeyword("function"))
                {
                    tokens.Add(new Token(TokenType.Function, "function"));
                    Skip(8);
                }
                else if (MatchesKeyword("if"))
                {
                    tokens.Add(new Token(TokenType.If, "if"));
                    Skip(2);
                }
                else if (MatchesKeyword("while"))
                {
                    tokens.Add(new Token(TokenType.While, "while"));
                    Skip(5);
                }
                else
                {
                    tokens.Add(GetTokenAsVariable());
                }
            }
            SkipSpaces();
        }
        return tokens;
    }

    private Token GetTokenAsNumeric()
    {
        var sb = new StringBuilder();
        while (!Ends() && StartsWithNumeric())
        {
            sb.Append(CurrentChar);
            MoveNext();
        }
        return new Token(TokenType.Numeric, sb.ToString());
    }

    private void MoveNext()
    {
        _currentPos++;
    }

    private bool StartsWithNumeric()
    {
        return char.GetNumericValue(CurrentChar) is not -1;
    }

    private bool StartsWithAlphabet()
    {
        return char.IsLetter(CurrentChar);
    }

    private bool MatchesKeyword(string keyword)
    {
        for (int i = 0; i < keyword.Length; i++)
        {
            if (_currentPos + i >= _text.Length || _text[_currentPos + i] != keyword[i])
            {
                return false;
            }
        }
        return _currentPos + keyword.Length >= _text.Length ||
            IsSpace(_text[_currentPos + keyword.Length]);
    }

    private Token GetTokenAsVariable()
    {
        var sb = new StringBuilder();
        while (!Ends() && StartsWithAlphabet())
        {
            sb.Append(CurrentChar);
            MoveNext();
        }
        if (sb.Length is 0)
        {
            throw new NotImplementedException();
        }
        return new Token(TokenType.Variable, sb.ToString());
    }

    private bool Ends()
    {
        return _currentPos >= _text.Length;
    }

    private void Skip(int count)
    {
        _currentPos += count;
    }

    private void SkipSpaces()
    {
        while (!Ends() && IsSpace(CurrentChar))
        {
            MoveNext();
        }
    }

    private static bool IsSpace(char c)
    {
        return c is ' ' or '\t' or '\n';
    }
}
