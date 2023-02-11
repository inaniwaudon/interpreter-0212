using Interpreter;

namespace Interpreter.Tests;

public class BinExprTest
{
    [Fact(DisplayName = "128 + 256 = 384")]
    public void AddTest()
    {
        var evaluator = new Evaluator(BinExpr.TAdd(IntValue.TInt(128), IntValue.TInt(256)));
        Assert.Equal(384, evaluator.Evaluate());
    }

    [Fact(DisplayName = "1024 - 119 = 905")]
    public void SubTest()
    {
        var evaluator = new Evaluator(BinExpr.TSub(IntValue.TInt(1024), IntValue.TInt(119)));
        Assert.Equal(905, evaluator.Evaluate());
    }

    [Fact(DisplayName = "124 * 932 = 115568")]
    public void MultiplyTest()
    {
        var evaluator = new Evaluator(BinExpr.TMul(IntValue.TInt(124), IntValue.TInt(932)));
        Assert.Equal(115568, evaluator.Evaluate());
    }

    [Fact(DisplayName = "1920 / 15 = 128")]
    public void DivisionTest()
    {
        var evaluator = new Evaluator(BinExpr.TDiv(IntValue.TInt(1920), IntValue.TInt(15)));
        Assert.Equal(128, evaluator.Evaluate());
    }
}
