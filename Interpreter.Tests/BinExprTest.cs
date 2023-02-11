using Interpreter;

namespace Interpreter.Tests;

public class BinExprTest
{
    [Fact(DisplayName = "128 + 256 == 384")]
    public void AddTest()
    {
        var evaluator = new Evaluator(BinExpr.TAdd(IntValue.TInt(128), IntValue.TInt(256)), new());
        Assert.Equal(384, evaluator.Evaluate());
    }

    [Fact(DisplayName = "1024 - 119 == 905")]
    public void SubTest()
    {
        var evaluator = new Evaluator(BinExpr.TSub(IntValue.TInt(1024), IntValue.TInt(119)), new());
        Assert.Equal(905, evaluator.Evaluate());
    }

    [Fact(DisplayName = "124 * 932 == 115568")]
    public void MultiplyTest()
    {
        var evaluator = new Evaluator(BinExpr.TMul(IntValue.TInt(124), IntValue.TInt(932)), new());
        Assert.Equal(115568, evaluator.Evaluate());
    }

    [Fact(DisplayName = "1920 / 15 == 128")]
    public void DivisionTest()
    {
        var evaluator = new Evaluator(BinExpr.TDiv(IntValue.TInt(1920), IntValue.TInt(15)), new());
        Assert.Equal(128, evaluator.Evaluate());
    }

    [Fact(DisplayName = "1 + (2 * 3) - 1) / 2 == 3")]
    public void ComplexTest()
    {
        var evaluator = new Evaluator
        (
            BinExpr.TAdd
            (
                IntValue.TInt(1),
                BinExpr.TDiv
                (
                    BinExpr.TSub
                    (
                        BinExpr.TMul(IntValue.TInt(2), IntValue.TInt(3)),
                        IntValue.TInt(1)
                    ),
                    IntValue.TInt(2)
                )
            ),
            new()
        );
        Assert.Equal(3, evaluator.Evaluate());
    }

    [Fact(DisplayName = "(1 < 2) == true")]
    public void LessThanTest()
    {
        var evaluator = new Evaluator(BinExpr.TLt(IntValue.TInt(1), IntValue.TInt(2)), new());
        Assert.Equal(true, evaluator.Evaluate());
    }

    [Fact(DisplayName = "(2 > 1) == true")]
    public void GreaterThanTest()
    {
        var evaluator = new Evaluator(BinExpr.TGt(IntValue.TInt(2), IntValue.TInt(1)), new());
        Assert.Equal(true, evaluator.Evaluate());
    }

    [Fact(DisplayName = "(1 <= 1) == true")]
    public void LessThanEqualTest()
    {
        var evaluator = new Evaluator(BinExpr.TLte(IntValue.TInt(1), IntValue.TInt(1)), new());
        Assert.Equal(true, evaluator.Evaluate());
    }

    [Fact(DisplayName = "(1 >= 1) == true")]
    public void GreaterThanEqualTest()
    {
        var evaluator = new Evaluator(BinExpr.TLte(IntValue.TInt(1), IntValue.TInt(1)), new());
        Assert.Equal(true, evaluator.Evaluate());
    }

    [Fact(DisplayName = "(1 == 1) == true")]
    public void EqualTest()
    {
        var evaluator = new Evaluator(BinExpr.TLte(IntValue.TInt(1), IntValue.TInt(1)), new());
        Assert.Equal(true, evaluator.Evaluate());
    }

    [Fact(DisplayName = "(1 != 2) == true")]
    public void NotEqualTest()
    {
        var evaluator = new Evaluator(BinExpr.TLte(IntValue.TInt(1), IntValue.TInt(1)), new());
        Assert.Equal(true, evaluator.Evaluate());
    }
}
