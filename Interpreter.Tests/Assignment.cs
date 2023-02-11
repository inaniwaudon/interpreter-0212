using Interpreter;

namespace Interpreter.Tests;

public class AssignmentTest
{
    [Fact(DisplayName = "{a = 100; a} == 100")]
    public void Test1()
    {
        var evaluator = new Evaluator
        (
            Seq.TSeq
            (
                Assignment.TAssign("a", IntValue.TInt(100)),
                Ident.TIdent("a")
            ),
            new()
        );
        Assert.Equal(100, evaluator.Evaluate());
    }

    [Fact(DisplayName = "{a = 100; b = a + 1; b} == 101")]
    public void Test2()
    {
        var evaluator = new Evaluator
        (
            Seq.TSeq
            (
                Assignment.TAssign("a", IntValue.TInt(100)),
                Assignment.TAssign("b", BinExpr.TAdd(Ident.TIdent("a"), IntValue.TInt(1))),
                Ident.TIdent("b")
            ),
            new()
        );
        Assert.Equal(101, evaluator.Evaluate());
    }
}
