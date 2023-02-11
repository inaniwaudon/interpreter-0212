namespace Interpreter;

public class Evaluator
{
    private readonly Dictionary<string, dynamic?> _envs = new();

    public Evaluator() { }

    internal Evaluator(Dictionary<string, dynamic?> envs)
    {
        _envs = envs;
    }

    public dynamic? EvaluateProgram(CustomProgram program)
    {
        foreach (Function func in program.Functions)
        {
            _envs[func.Name] = func;
        }

        dynamic? result = null;
        foreach (Expr body in program.Bodies)
        {
            result = Evaluate(body);
        }
        return result;
    }

    public dynamic? Evaluate(Expr expr)
    {
        if (expr is BinExpr binExpr)
        {
            return EvaluateMathExpr(binExpr)
                ?? EvaluateCompExpr(binExpr)
                ?? throw new ArgumentException();
        }
        if (expr is IntValue intValue)
        {
            return intValue.Value;
        }
        if (expr is Seq seq)
        {
            return EvaluateExprs(seq.Bodies);
        }
        if (expr is Assignment assignment)
        {
            _envs[assignment.Name] = Evaluate(assignment.Expr);
            return _envs[assignment.Name];
        }
        if (expr is Ident ident)
        {
            return _envs[ident.Name];
        }
        if (expr is If iif)
        {
            dynamic? condition = Evaluate(iif.Condition);
            return Evaluate(condition ? iif.ThenClause : iif.ElseClause);
        }
        if (expr is While wwhile)
        {
            return EvaluateWhile(wwhile);
        }
        if (expr is Call call)
        {
            dynamic? item = _envs[call.Name];
            if (item is Function func)
            {
                dynamic?[] args = call.Args.Select(arg => Evaluate(arg)).ToArray();
                var newEnvs = new Dictionary<string, dynamic?>(_envs);
                for (int i = 0; i < func.Params.Length; i++)
                {
                    newEnvs[func.Params[i]] = i < args.Length ? args[i] : null;
                }
                var evaluator = new Evaluator(newEnvs);
                return evaluator.Evaluate(func.Bodies);
            }
        }
        throw new ArgumentException();
    }

    private dynamic? EvaluateMathExpr(BinExpr binExpr)
    {
        return binExpr.Op switch
        {
            "+" => Evaluate(binExpr.Lhs) + Evaluate(binExpr.Rhs),
            "*" => Evaluate(binExpr.Lhs) * Evaluate(binExpr.Rhs),
            "-" => Evaluate(binExpr.Lhs) - Evaluate(binExpr.Rhs),
            "/" => Evaluate(binExpr.Lhs) / Evaluate(binExpr.Rhs),
            _ => null,
        };
    }

    private dynamic? EvaluateCompExpr(BinExpr binExpr)
    {
        return binExpr.Op switch
        {
            "<" => Evaluate(binExpr.Lhs) < Evaluate(binExpr.Rhs),
            ">" => Evaluate(binExpr.Lhs) > Evaluate(binExpr.Rhs),
            "<=" => Evaluate(binExpr.Lhs) <= Evaluate(binExpr.Rhs),
            ">=" => Evaluate(binExpr.Lhs) >= Evaluate(binExpr.Rhs),
            "==" => Evaluate(binExpr.Lhs) == Evaluate(binExpr.Rhs),
            "!=" => Evaluate(binExpr.Lhs) != Evaluate(binExpr.Rhs),
            _ => null,
        };
    }

    private dynamic? EvaluateExprs(Expr[] exprs)
    {
        dynamic? result = null;
        foreach (var body in exprs)
        {
            result = Evaluate(body);
        }
        return result;
    }

    private dynamic? EvaluateWhile(While wwhile)
    {
        while (Evaluate(wwhile.Condition))
        {
            EvaluateExprs(wwhile.Bodies);
        }
        return null;
    }
}
