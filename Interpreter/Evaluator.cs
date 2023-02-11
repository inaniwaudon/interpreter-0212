namespace Interpreter;

public class Evaluator
{
    private readonly Expr _expr;
    private readonly Dictionary<string, dynamic?> _envs;

    public Evaluator(Expr expr, Dictionary<string, dynamic?> envs)
    {
        _expr = expr;
        _envs = envs;
    }

    public dynamic? Evaluate()
    {
        if (_expr is BinExpr binExpr)
        {
            return EvaluateMathExpr(binExpr)
                ?? EvaluateCompExpr(binExpr)
                ?? throw new ArgumentException();
        }
        if (_expr is IntValue intValue)
        {
            return intValue.Value;
        }
        if (_expr is Seq seq)
        {
            return EvaluateExprs(seq.Bodies);
        }
        if (_expr is Assignment assignment)
        {
            var evaluator = new Evaluator(assignment.Expr, _envs);
            _envs[assignment.Name] = evaluator.Evaluate();
            return _envs[assignment.Name];
        }
        if (_expr is Ident ident)
        {
            return _envs[ident.Name];
        }
        if (_expr is If iif)
        {
            var conditionEvaluator = new Evaluator(iif.Condition, _envs);
            var condition = conditionEvaluator.Evaluate();
            var evaluator = new Evaluator(condition ? iif.ThenClause : iif.ElseClause, _envs);
            return evaluator.Evaluate();
        }
        if (_expr is While wwhile)
        {
            return EvaluateWhile(wwhile);
        }
        throw new ArgumentException();
    }

    private dynamic? EvaluateMathExpr(BinExpr binExpr)
    {
        var leftEvaluator = new Evaluator(binExpr.Lhs, _envs);
        var rightEvaluator = new Evaluator(binExpr.Rhs, _envs);
        return binExpr.Op switch
        {
            "+" => leftEvaluator.Evaluate() + rightEvaluator.Evaluate(),
            "*" => leftEvaluator.Evaluate() * rightEvaluator.Evaluate(),
            "-" => leftEvaluator.Evaluate() - rightEvaluator.Evaluate(),
            "/" => leftEvaluator.Evaluate() / rightEvaluator.Evaluate(),
            _ => null,
        };
    }

    private dynamic? EvaluateCompExpr(BinExpr binExpr)
    {
        var leftEvaluator = new Evaluator(binExpr.Lhs, _envs);
        var rightEvaluator = new Evaluator(binExpr.Rhs, _envs);
        return binExpr.Op switch
        {
            "<" => leftEvaluator.Evaluate() < rightEvaluator.Evaluate(),
            ">" => leftEvaluator.Evaluate() > rightEvaluator.Evaluate(),
            "<=" => leftEvaluator.Evaluate() <= rightEvaluator.Evaluate(),
            ">=" => leftEvaluator.Evaluate() >= rightEvaluator.Evaluate(),
            "==" => leftEvaluator.Evaluate() == rightEvaluator.Evaluate(),
            "!=" => leftEvaluator.Evaluate() != rightEvaluator.Evaluate(),
            _ => null,
        };
    }

    private dynamic? EvaluateExprs(Expr[] exprs)
    {
        dynamic? result = null;
        foreach (var body in exprs)
        {
            var evaluator = new Evaluator(body, _envs);
            result = evaluator.Evaluate();
        }
        return result;
    }

    private dynamic? EvaluateWhile(While wwhile)
    {
        var condition = new Evaluator(wwhile.Condition, _envs);
        while (condition.Evaluate())
        {
            EvaluateExprs(wwhile.Bodies);
        }
        return null;
    }
}
