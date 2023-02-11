namespace Interpreter.Tests;

public class IntValueTest
{
    [Fact(DisplayName = "12")]
    public void IntTest1()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate(IntValue.TInt(12));
        Assert.Equal(12, result);
    }

    [Fact(DisplayName = "65535")]
    public void IntTest2()
    {
        var evaluator = new Evaluator();
        var result = evaluator.Evaluate(IntValue.TInt(65535));
        Assert.Equal(65535, result);
    }
}
