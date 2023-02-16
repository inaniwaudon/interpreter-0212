# 使用方法

`/Interpreter/Program.cs` に記述した抽象構文木が実行される。

## 実行例

```js
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
```

```csharp
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
```

## 二項演算

| 記述 | 想定される機能 |
| :--- | :--- |
| `BinExpr.TAdd(Expr a, Expr b)` | `a + b` |
| `BinExpr.TSub(Expr a, Expr b)` | `a - b` |
| `BinExpr.TMul(Expr a, Expr b)` | `a * b` |
| `BinExpr.TDiv(Expr a, Expr b)` | `a / b` |
| `BinExpr.TGt(Expr a, Expr b)` | `a > b` |
| `BinExpr.TLt(Expr a, Expr b)` | `a < b` |
| `BinExpr.TGt(Expr a, Expr b)` | `a > b` |
| `BinExpr.TLte(Expr a, Expr b)` | `a <= b` |
| `BinExpr.TGte(Expr a, Expr b)` | `a >= b` |
| `BinExpr.TEq(Expr a, Expr b)` | `a == b` |
| `BinExpr.TNeq(Expr a, Expr b)` | `a != b` |

## 変数

| 記述 | 想定される機能 |
| :--- | :--- |
| `Assignment.TAssign(string name, Expr expr)` | `name = expr` |
| `Ident.TIdent(string name)` | `name` |

## 制御文

| 記述 | 想定される機能 |
| :--- | :--- |
| `While.TWhile(Expr condition, Seq bodies)` | `while (condition) { bodies }` |
| `If.TIf(Expr condition, Expr thenClause, Expr elseClause)` | `if (condition) { thenClause } else { elseClause }` |

## 関数

| 記述 | 想定される機能 |
| :--- | :--- |
| `CustomFunction.TFunction(string name, string[] pparams, Seq bodies)` | `function name(params) { bodies }` |
| `Call.TCall(string name, Expr[] args)` | `name(...args)` |
