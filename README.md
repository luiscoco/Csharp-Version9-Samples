# C# 9 Features – Sample Projects

This repository contains hands-on examples of the new features introduced in **C# version 9** (shipped with .NET 5).  
Each project (`P137`, `P138`, …) illustrates one feature with runnable code.

---

## 🚀 New Features in C# 9

### Records & Object Initialization

#### 1) Records (`P137_Records`)
- **What’s new**: `record` types give you value-based equality, built-in `Deconstruct`, and `with` expressions.  
- **Example**:
  ```csharp
  public record Person(string FirstName, string LastName);

  var p1 = new Person("Ada", "Lovelace");
  var p2 = p1 with { LastName = "Byron" };

  Console.WriteLine(p1 == p2); // False
  ```

#### 2) Init-only Setters (`P138_InitOnlySetters`)
- **What’s new**: Properties marked `init` can only be set during initialization.  
- **Example**:
  ```csharp
  public class Customer
  {
      public string Name { get; init; }
  }

  var c = new Customer { Name = "Contoso" };
  // c.Name = "Other"; // ❌ not allowed
  ```

#### 3) Target-typed `new` (`P146_TargetTypedNew`)
- **What’s new**: The `new()` expression can infer its type from the context.  
- **Example**:
  ```csharp
  List<string> names = new();
  Dictionary<int,string> map = new() { [1] = "one" };
  ```

---

### Top-level & Partial Methods

#### 4) Top-level Statements (`P139_TopLevelStatements`)
- **What’s new**: Eliminate the `Program`/`Main` boilerplate for simple apps.  
- **Example**:
  ```csharp
  Console.WriteLine("Hello, world!");
  ```

#### 5) Extended Partial Methods (`P145_PartialMethodsNew`)
- **What’s new**: Partial methods can now be public, return values, and have attributes.  
- **Example**:
  ```csharp
  public partial class Generator
  {
      public partial string GetStamp();
  }

  public partial class Generator
  {
      public partial string GetStamp() => DateTime.UtcNow.ToString("O");
  }
  ```

---

### Pattern Matching Enhancements

#### 6) Relational & Logical Patterns (`P140_Patterns_Relational_Logical`)
- **What’s new**: Support for relational operators (`<`, `>`, …) and logical operators (`and`, `or`, `not`) in patterns.  
- **Example**:
  ```csharp
  static string Classify(int n) => n switch
  {
      < 0         => "negative",
      0           => "zero",
      > 0 and <10 => "small positive",
      _           => "large"
  };
  ```

#### 7) More Pattern Examples (`P153_Patterns_More`)
- **What’s new**: Additional use cases like grouped patterns and ordering rules.  
- **Example**:
  ```csharp
  int n = 5;
  var result = n switch
  {
      < 0 => "negative",
      >= 0 and < 10 => "one digit",
      _ => "other"
  };
  ```

---

### Performance & Interop

#### 8) Native-sized Integers (`P141_NativeSizedIntegers`)
- **What’s new**: `nint` and `nuint` scale with platform pointer size.  
- **Example**:
  ```csharp
  nint counter = 0;
  nuint length = (nuint)"hello".Length;
  ```

#### 9) Function Pointers (unsafe) (`P142_FunctionPointers`)
- **What’s new**: Support for unmanaged function pointers via `delegate*`.  
- **Example**:
  ```csharp
  unsafe
  {
      delegate*<int,int,int> add = &Add;
      Console.WriteLine(add(2, 3));
  }
  static int Add(int a, int b) => a + b;
  ```

#### 10) Skip Locals Init (unsafe) (`P143_SuppressLocalsInit`)
- **What’s new**: `[SkipLocalsInit]` disables default zero-initialization of locals for performance-critical methods.  
- **Example**:
  ```csharp
  using System.Runtime.CompilerServices;

  class Fast
  {
      [SkipLocalsInit]
      static unsafe void Work() { /* ... */ }
  }
  ```

#### 11) Module Initializers (`P144_ModuleInitializers`)
- **What’s new**: Run code once at assembly load.  
- **Example**:
  ```csharp
  using System.Runtime.CompilerServices;

  public static class Boot
  {
      [ModuleInitializer]
      public static void Init() => Console.WriteLine("Module initialized");
  }
  ```

---

### Lambdas & Local Functions

#### 12) Static Anonymous Functions (`P147_StaticAnonymousFunctions`)
- **What’s new**: `static` lambdas can’t capture state → allocation-free delegates.  
- **Example**:
  ```csharp
  Func<int,int,int> add = static (a, b) => a + b;
  ```

#### 13) Lambda Discard Parameters (`P151_LambdaDiscardParams`)
- **What’s new**: Use `_` to discard unused lambda parameters.  
- **Example**:
  ```csharp
  Action<int,int> ignore = (_, _) => Console.WriteLine("ignored");
  ```

#### 14) Attributes on Local Functions (`P152_AttributesOnLocalFunctions`)
- **What’s new**: Local functions can now have attributes.  
- **Example**:
  ```csharp
  void Log(string message)
  {
      [Obsolete]
      static void Local() => Console.WriteLine("local");
      Local();
  }
  ```

---

### Fit-and-Finish

#### 15) Target-typed Conditionals (`P148_TargetTypedConditional`)
- **What’s new**: Conditional expressions can target the expected type more flexibly.  
- **Example**:
  ```csharp
  bool flag = true;
  IEnumerable<int> seq = flag ? new[] {1,2,3} : new List<int> {1,2,3};
  ```

#### 16) Covariant Return Types (`P149_CovariantReturnTypes`)
- **What’s new**: Overrides can return a more derived type.  
- **Example**:
  ```csharp
  abstract class Animal { public abstract Animal Clone(); }
  class Cat : Animal
  {
      public override Cat Clone() => new Cat();
  }
  ```

#### 17) Extension GetEnumerator (`P150_ExtensionGetEnumerator`)
- **What’s new**: `foreach` works with an extension `GetEnumerator` method.  
- **Example**:
  ```csharp
  public static class Extensions
  {
      public static IEnumerator<int> GetEnumerator(this int value)
      {
          for (int i = 0; i < value; i++) yield return i;
      }
  }

  foreach (var i in 5) Console.WriteLine(i); // 0,1,2,3,4
  ```

---

## 📂 Repository Structure

- `P137_Records` → records with equality and `with` expressions  
- `P138_InitOnlySetters` → init-only setters  
- `P146_TargetTypedNew` → target-typed `new`  
- `P139_TopLevelStatements` → top-level statements  
- `P145_PartialMethodsNew` → extended partial methods  
- `P140_Patterns_Relational_Logical` → relational & logical patterns  
- `P153_Patterns_More` → additional pattern examples  
- `P141_NativeSizedIntegers` → native-sized integers  
- `P142_FunctionPointers` → unsafe function pointers  
- `P143_SuppressLocalsInit` → skip locals init  
- `P144_ModuleInitializers` → module initializers  
- `P147_StaticAnonymousFunctions` → static lambdas  
- `P151_LambdaDiscardParams` → discard parameters in lambdas  
- `P152_AttributesOnLocalFunctions` → attributes on local functions  
- `P148_TargetTypedConditional` → target-typed conditional expressions  
- `P149_CovariantReturnTypes` → covariant return types  
- `P150_ExtensionGetEnumerator` → extension-based foreach  

---

## 🔧 Requirements

- .NET 5 SDK  
- C# 9 language version  

To build & run a sample:
```bash
dotnet restore
dotnet build
dotnet run --project P137_Records
```

---

## 📖 References

- What’s new in C# 9 – Microsoft Learn  
- “Welcome to C# 9” – .NET Blog  

