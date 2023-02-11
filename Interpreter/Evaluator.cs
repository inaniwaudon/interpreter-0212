namespace Interpreter;

public class Evaluator
{
    private readonly Expr _expr;
    private static readonly Dictionary<string, dynamic?> Envs = new();

    public Evaluator(Expr expr)
    {
        _expr = expr;
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
            dynamic? result = null;
            foreach (var body in seq.Bodies)
            {
                var evaluator = new Evaluator(body);
                result = evaluator.Evaluate();
            }
            return result;
        }
        if (_expr is Assignment assignment)
        {
            var evaluator = new Evaluator(assignment.Expr);
            Envs[assignment.Name] = evaluator.Evaluate();
            return Envs[assignment.Name];
        }
        if (_expr is Ident ident)
        {
            return Envs[ident.Name];
        }
        if (_expr is If iif)
        {
            var conditionEvaluator = new Evaluator(iif.Condition);
            var condition = conditionEvaluator.Evaluate();
            var evaluator = new Evaluator(condition ? iif.ThenClause : iif.ElseClause);
            return evaluator.Evaluate();
        }
        throw new ArgumentException();
    }

    private static dynamic? EvaluateMathExpr(BinExpr binExpr)
    {
        var leftEvaluator = new Evaluator(binExpr.Lhs);
        var rightEvaluator = new Evaluator(binExpr.Rhs);
        return binExpr.Op switch
        {
            "+" => leftEvaluator.Evaluate() + rightEvaluator.Evaluate(),
            "*" => leftEvaluator.Evaluate() * rightEvaluator.Evaluate(),
            "-" => leftEvaluator.Evaluate() - rightEvaluator.Evaluate(),
            "/" => leftEvaluator.Evaluate() / rightEvaluator.Evaluate(),
            _ => null,
        };
    }

    private static dynamic? EvaluateCompExpr(BinExpr binExpr)
    {
        var leftEvaluator = new Evaluator(binExpr.Lhs);
        var rightEvaluator = new Evaluator(binExpr.Rhs);
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
}
