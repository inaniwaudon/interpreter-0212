namespace Interpreter.Tests;

public class CustomFunctionTest
{
    [Fact(DisplayName = "(function add(a, b) { return a + b; }, add(1, 2)) == 3")]
    public void Test()
    {
        var evaluator = new Evaluator();
        var func = CustomFunction.TFunction
        (
            "add",
            new[] { "a", "b" },
            Seq.TSeq(BinExpr.TAdd(Ident.TIdent("a"), Ident.TIdent("b")))
        );
        var program = CustomProgram.TProgram
        (
            new[] { func },
            new Seq(new[] { Call.TCall("add", new[] { IntValue.TInt(1), IntValue.TInt(2) }) })
        );
        var result = evaluator.EvaluateProgram(program);
        Assert.Equal(3, result);
    }
}
