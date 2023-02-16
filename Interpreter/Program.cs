namespace Interpreter;

public static class Program
{
    public static void Main(string[] args)
    {
        /*
        function pow(a, b) {
            i = 0
            sum = a
            while (i < b) {
                sum *= a
                i++
            }
            sum
        }

        pow(2, 8) // 256
        */

        var functions = new CustomFunction[] {
            CustomFunction.TFunction
            (
                "pow",
                new[] { "a", "b" },
                Seq.TSeq(new Expr[]
                {
                    Assignment.TAssign("i", IntValue.TInt(1)),
                    Assignment.TAssign("sum", Ident.TIdent("a")),
                    While.TWhile
                    (
                        BinExpr.TLt(Ident.TIdent("i"), Ident.TIdent("b")),
                        Seq.TSeq(new Expr[]
                        {
                            Assignment.TAssign
                                ("sum", BinExpr.TMul(Ident.TIdent("sum"), Ident.TIdent("a"))),
                            Assignment.TAssign
                                ("i", BinExpr.TAdd(Ident.TIdent("i"), IntValue.TInt(1))),
                        })
                    ),
                    Ident.TIdent("sum")
                })
            )
        };

        var bodies = new Seq
        (
            new Expr[]
            {
                Call.TCall("pow", new Expr[] { IntValue.TInt(2), IntValue.TInt(8) })
            }
        );

        var program = new CustomProgram(functions, bodies);
        var evaluator = new Evaluator();
        var result = evaluator.EvaluateProgram(program);
        if (result is not null)
        {
            Console.WriteLine(result);
        }
    }
}
