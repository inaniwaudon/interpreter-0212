using Interpreter;

namespace Interpreter.Tests;

public class IntValueTest
{
    [Fact(DisplayName = "12")]
    public void IntTest1()
    {
        var evaluator = new Evaluator(IntValue.TInt(12));
        Assert.Equal(12, evaluator.Evaluate());
    }

    [Fact(DisplayName = "65535")]
    public void IntTest2()
    {
        var evaluator = new Evaluator(IntValue.TInt(65535));
        Assert.Equal(65535, evaluator.Evaluate());
    }
}
