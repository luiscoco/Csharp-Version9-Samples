# C# 9 Features – Sample Projects

This repository contains hands-on examples of the new features introduced in **C# version 9** (shipped with .NET 5).  
Each project P141 - P157 illustrates one feature with runnable code.

---

## New Features in C# 9

### Records & Object Initialization

#### P141_Records
- **What’s new**: `record` types give you value-based equality, built-in `Deconstruct`, and `with` expressions.  
- **Example**:
  ```csharp
  public record Person(string FirstName, string LastName);

  var p1 = new Person("Ada", "Lovelace");
  var p2 = p1 with { LastName = "Byron" };

  Console.WriteLine(p1 == p2); // False
  ```

#### P142_InitOnlySetters
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

#### P150_TargetTypedNew
- **What’s new**: The `new()` expression can infer its type from the context.  
- **Example**:
  ```csharp
  List<string> names = new();
  Dictionary<int,string> map = new() { [1] = "one" };
  ```

---

### Top-level & Partial Methods

#### P143_TopLevelStatements
- **What’s new**: Eliminate the `Program`/`Main` boilerplate for simple apps.  
- **Example**:
  ```csharp
  Console.WriteLine("Hello, world!");
  ```

#### P149_PartialMethodsNew
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

#### P144_Patterns_Relational_Logical
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

#### P157_Patterns_More
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

#### P145_NativeSizedIntegers
- **What’s new**: `nint` and `nuint` scale with platform pointer size.  
- **Example**:
  ```csharp
  nint counter = 0;
  nuint length = (nuint)"hello".Length;
  ```

#### P146_FunctionPointers
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

#### P147_SuppressLocalsInit
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

#### P148_ModuleInitializers
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

#### P151_StaticAnonymousFunctions
- **What’s new**: `static` lambdas can’t capture state → allocation-free delegates.  
- **Example**:
  ```csharp
  Func<int,int,int> add = static (a, b) => a + b;
  ```

#### P155_LambdaDiscardParams
- **What’s new**: Use `_` to discard unused lambda parameters.  
- **Example**:
  ```csharp
  Action<int,int> ignore = (_, _) => Console.WriteLine("ignored");
  ```

#### P156_AttributesOnLocalFunctions
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

#### P152_TargetTypedConditional
- **What’s new**: Conditional expressions can target the expected type more flexibly.  
- **Example**:
  ```csharp
  bool flag = true;
  IEnumerable<int> seq = flag ? new[] {1,2,3} : new List<int> {1,2,3};
  ```

#### P153_CovariantReturnTypes
- **What’s new**: Overrides can return a more derived type.  
- **Example**:
  ```csharp
  abstract class Animal { public abstract Animal Clone(); }
  class Cat : Animal
  {
      public override Cat Clone() => new Cat();
  }
  ```

#### P154_ExtensionGetEnumerator
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

## Repository Structure

- `P141_Records` → records with equality and `with` expressions  
- `P142_InitOnlySetters` → init-only setters
- `P143_TopLevelStatements` → top-level statements
- `P144_Patterns_Relational_Logical` → relational & logical patterns
- `P145_NativeSizedIntegers` → native-sized integers  
- `P146_FunctionPointers` → unsafe function pointers  
- `P147_SuppressLocalsInit` → skip locals init  
- `P148_ModuleInitializers` → module initializers     
- `P149_PartialMethodsNew` → extended partial methods 
- `P150_TargetTypedNew` → target-typed `new`  
- `P151_StaticAnonymousFunctions` → static lambdas  
- `P152_TargetTypedConditional` → target-typed conditional expressions  
- `P153_CovariantReturnTypes` → covariant return types  
- `P154_ExtensionGetEnumerator` → extension-based foreach  
- `P155_LambdaDiscardParams` → discard parameters in lambdas  
- `P156_AttributesOnLocalFunctions` → attributes on local functions  
- `P157_Patterns_More` → additional pattern examples  





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

