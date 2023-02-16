# interpreter-0212

筑波大学の講義 [ソフトウェアサイエンス特別講義A](https://kdb.tsukuba.ac.jp/syllabi/2022/GB27001/jpn/0) で紹介されていた [minis](https://github.com/kmizu/minis) の C# 実装

## 実行

[.NET 7.0](https://dotnet.microsoft.com/ja-jp/download/dotnet/7.0) が必要です。

```bash
cd Interpreter
dotnet run
```

詳しくは [usage.md](./usage.md) を参照。

`/Interpreter/Program.cs` に記述した抽象構文木が実行される。

## テスト

```
bash
cd Interpreter.Tests
dotnet test
```
