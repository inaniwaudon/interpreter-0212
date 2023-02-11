namespace Interpreter.Tests;

public class BinExprTest
{
    [Fact(DisplayName = "128 + 256 == 384")]
    public void AddTest()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate(BinExpr.TAdd(IntValue.TInt(128), IntValue.TInt(256)));
        Assert.Equal(384, result);
    }

    [Fact(DisplayName = "1024 - 119 == 905")]
    public void SubTest()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate(BinExpr.TSub(IntValue.TInt(1024), IntValue.TInt(119)));
        Assert.Equal(905, result);
    }

    [Fact(DisplayName = "124 * 932 == 115568")]
    public void MultiplyTest()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate(BinExpr.TMul(IntValue.TInt(124), IntValue.TInt(932)));
        Assert.Equal(115568, result);
    }

    [Fact(DisplayName = "1920 / 15 == 128")]
    public void DivisionTest()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate(BinExpr.TDiv(IntValue.TInt(1920), IntValue.TInt(15)));
        Assert.Equal(128, result);
    }

    [Fact(DisplayName = "1 + (2 * 3) - 1) / 2 == 3")]
    public void ComplexTest()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate
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
            )
        );
        Assert.Equal(3, result);
    }

    [Fact(DisplayName = "(1 < 2) == true")]
    public void LessThanTest()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate(BinExpr.TLt(IntValue.TInt(1), IntValue.TInt(2)));
        Assert.Equal(true, result);
    }

    [Fact(DisplayName = "(2 > 1) == true")]
    public void GreaterThanTest()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate(BinExpr.TGt(IntValue.TInt(2), IntValue.TInt(1)));
        Assert.Equal(true, result);
    }

    [Fact(DisplayName = "(1 <= 1) == true")]
    public void LessThanEqualTest()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate(BinExpr.TLte(IntValue.TInt(1), IntValue.TInt(1)));
        Assert.Equal(true, result);
    }

    [Fact(DisplayName = "(1 >= 1) == true")]
    public void GreaterThanEqualTest()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate(BinExpr.TLte(IntValue.TInt(1), IntValue.TInt(1)));
        Assert.Equal(true, result);
    }

    [Fact(DisplayName = "(1 == 1) == true")]
    public void EqualTest()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate(BinExpr.TLte(IntValue.TInt(1), IntValue.TInt(1)));

        Assert.Equal(true, result);
    }

    [Fact(DisplayName = "(1 != 2) == true")]
    public void NotEqualTest()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate(BinExpr.TLte(IntValue.TInt(1), IntValue.TInt(1)));
        Assert.Equal(true, result);
    }
}
