# Code Review: takosama/Mos

Repository: https://github.com/takosama/Mos  
Reviewed files: `MOS.cs`, `Program.cs`

---

## Summary

Mo's algorithm の C# 実装。AtCoder ABC242-G の解答例付き。  
コアロジックは概ね正しく、奇偶ブロックの方向交互化（Hilbert curve 最適化）も実装されている。  
ただし、いくつかのバグ・設計上の問題がある。

---

## 問題点

### 1. ブロックサイズの計算が誤っている（パフォーマンスに影響）

```csharp
// 現在
int size = 1 + (int)Math.Sqrt(querys.Length);

// 正しくは
int size = 1 + (int)Math.Sqrt(_arr.Length);
```

Mo's algorithm の最適ブロックサイズは **配列長 N の平方根** `O(√N)` であり、クエリ数 Q の平方根ではない。  
N ≠ Q のケースで時間計算量が悪化する。クエリ数が少なくて配列が大きい場合、ブロックが小さすぎてポインタ移動量が増える。

---

### 2. byte オーバーフローによる潜在的バグ

`Program.cs` の `MyMos` は `MyArray<byte>` を使って出現回数を管理している。  
`byte` は最大 255 まで保持できるため、同じ色が 255 回登場した後にインクリメントすると 0 に折り返す。

この実装は加算も削除も `++_ptr[arr[i]]` で行う（偶奇の反転を利用するビットトリック）が、256 回目でパリティが壊れ誤答となる。  
配列長が 256 未満であれば問題ないが、ABC242-G の制約（N ≤ 3×10⁵）では理論上発生しうる。  
`int[]` または `short[]` への変更が安全。

---

### 3. `IsFirst` フラグによる再利用不可

```csharp
bool IsFirst = true;
```

`RunFold()` を複数回呼び出すと、2 回目以降は `IsFirst == false` のまま実行され、  
`_l`・`_r`・`result` が前回の状態を引き継いで誤った結果を返す。  
`RunFold()` の先頭で状態をリセットするか、フラグをなくして初期化を別メソッドに切り出すべき。

---

### 4. 初期ソートが冗長

```csharp
querys = querys.OrderBy(x => x.l).ToArray();
```

この行はブロック割り当て前の事前ソートだが、その後各ブロック内で `r` によるソートが行われるため不要。  
`l` で事前ソートしても最終的な処理順序は変わらず、配列の余分なアロケーションが発生する。

---

### 5. `unsafe` 修飾子が不要

`Mos<T, U>` クラスは `unsafe` と宣言されているが、クラス自身はポインタ演算や固定メモリを使用していない。  
`Span<T>` は安全なコードで使用可能。`where T : unmanaged` 制約も `unsafe` を必要としない。  
削除してよい。

---

### 6. インターフェースの命名が不明瞭

```csharp
interface IMosFunctions<T, U>
{
    U ComputeFoldL_L(Span<T> arr, U result);
    U ComputeFoldL_R(Span<T> arr, U result);
    U ComputeFoldR_L(Span<T> arr, U result);
    U ComputeFoldR_R(Span<T> arr, U result);
}
```

`L_L`・`L_R`・`R_L`・`R_R` がそれぞれ何を意味するか（左境界が左移動、左境界が右移動…）コメントなしでは判断できない。  
また、`SetLRFold` 内で R を先に調整してから L を調整する順序が正しさの前提になっているが、  
インターフェースのドキュメントにこの呼び出し順序の制約が記載されていない。実装者が混乱しやすい。

推奨する命名例:
```csharp
U AddLeft(Span<T> arr, U result);    // ComputeFoldL_L
U RemoveLeft(Span<T> arr, U result); // ComputeFoldL_R
U RemoveRight(Span<T> arr, U result);// ComputeFoldR_L
U AddRight(Span<T> arr, U result);   // ComputeFoldR_R
```

---

### 7. 入力バリデーションがない

クエリの `l > r` やインデックスが配列範囲外のケースでチェックなしに実行される。  
競技プログラミング向けであれば許容範囲だが、ライブラリとして公開するなら  
`ArgumentOutOfRangeException` のスローを検討すべき。

---

## 良い点

- **交互ソート最適化**: 偶数番ブロックは `r` 昇順、奇数番ブロックは `r` 降順で並べ替えており、ポインタのU字折り返しによる移動距離削減（Hilbert curve 型 Mo）が正しく実装されている。
- **ビットトリック**: 加算・削除両方を `++ptr` で実装し偶奇の反転を利用するアイデアは巧妙で、減算処理のブランチを削減している。
- **Span 活用**: 各クエリの処理に `Span<T>.Slice()` を使っており、余分なコピーが発生しない。

---

## 修正例（ブロックサイズ）

```csharp
public Mos(T[] arr, (int id, int l, int r)[] querys, IMosFunctions<T, U> functions)
{
    this._arr = arr;
    _QuerysLength = querys.Length;
-   int size = 1 + (int)Math.Sqrt(querys.Length);
+   int size = Math.Max(1, (int)Math.Sqrt(arr.Length));
    // ...
}
```
