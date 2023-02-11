using Interpreter;

namespace Interpreter.Tests;

public class WhileTest
{
    [Fact(DisplayName = "{i = 0; while(i < 10) { i = i + 1; }; i} == 10")]
    public void Test()
    {
        var evaluator = new Evaluator
        (
            Seq.TSeq
            (
                Assignment.TAssign("i", IntValue.TInt(0)),
                While.TWhile
                (
                    BinExpr.TLt(Ident.TIdent("i"), IntValue.TInt(10)),
                    new[]
                    {
                        Assignment.TAssign("i", BinExpr.TAdd(Ident.TIdent("i"), IntValue.TInt(1)))
                    }
                ),
                Ident.TIdent("i")
            ),
            new()
        );
        Assert.Equal(10, evaluator.Evaluate());
    }
}
