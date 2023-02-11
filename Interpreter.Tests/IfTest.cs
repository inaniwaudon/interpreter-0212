using Interpreter;

namespace Interpreter.Tests;

public class IfTest
{
    [Fact(DisplayName = "(if(1 > 2) 2 else 1) == 1")]
    public void Test()
    {
        var evaluator = new Evaluator
        (
            If.TIf
            (
                BinExpr.TGt(IntValue.TInt(1), IntValue.TInt(2)),
                IntValue.TInt(2),
                IntValue.TInt(1)
            ),
            new()
        );
        Assert.Equal(1, evaluator.Evaluate());
    }
}
