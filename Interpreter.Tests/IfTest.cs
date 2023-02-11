namespace Interpreter.Tests;

public class IfTest
{
    [Fact(DisplayName = "(if(1 > 2) 2 else 1) == 1")]
    public void Test()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate
        (
            If.TIf
            (
                BinExpr.TGt(IntValue.TInt(1), IntValue.TInt(2)),
                IntValue.TInt(2),
                IntValue.TInt(1)
            )
        );
        Assert.Equal(1, result);
    }
}
