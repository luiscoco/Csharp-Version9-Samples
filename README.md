# C# Version 9.0 – Feature Samples (VS 2019 / .NET 5)

This solution contains **mini projects P137–P153**, each demonstrating a C# 9.0 feature.  
`LangVersion` is set to **9.0**, and nullable reference types are **enabled**.

## Feature Index

### Records & Object Initialization
- **P137_Records** — Records with value equality, `with`-expressions, and deconstruction.
- **P138_InitOnlySetters** — `init` accessors for immutable object setup.
- **P146_TargetTypedNew** — Target-typed `new()`.

### Top-level & Partial methods
- **P139_TopLevelStatements** — “Hello world” without a `Main` method.
- **P145_PartialMethodsNew** — Partial methods can be public and return values.

### Pattern Matching Enhancements
- **P140_Patterns_Relational_Logical** — Relational (`<`, `>=`), and logical (`and`, `or`, `not`) patterns; also shows type patterns.
- **P153_Patterns_More** — Additional examples (reachable ordering with `int n when ...`, plus grouped logical patterns).

### Performance & Interop
- **P141_NativeSizedIntegers** — `nint` / `nuint` with platform-sized integers.
- **P142_FunctionPointers** *(unsafe)* — `delegate*` function pointers, no delegate allocations.
- **P143_SuppressLocalsInit** *(unsafe)* — `[SkipLocalsInit]` to skip zeroing locals for perf.
- **P144_ModuleInitializers** — `[ModuleInitializer]` runs before `Main`.

### Lambdas & Local Functions
- **P147_StaticAnonymousFunctions** — `static` lambdas that don’t capture.
- **P151_LambdaDiscardParams** — Discard parameters in lambdas: `(_, _) => ...`.
- **P152_AttributesOnLocalFunctions** — Attributes applied to local functions.

### Fit-and-Finish
- **P148_TargetTypedConditional** — Conditional expressions that target the expected type.
- **P149_CovariantReturnTypes** — Overriding methods with more derived return types.
- **P150_ExtensionGetEnumerator** — `foreach` works with an extension `GetEnumerator`.

## Build & Run

From the solution root:

```bash
dotnet restore
dotnet build
dotnet run --project P137_Records
# try others:
dotnet run --project P140_Patterns_Relational_Logical
```

> **Note:** Projects **P142_FunctionPointers** and **P143_SuppressLocalsInit** compile with `AllowUnsafeBlocks=true` by design.

## Teaching Tips

- **Patterns:** Emphasize the order of switch arms. Put specific relational/type guards (e.g., `int n when n <= 10`) before broader type patterns like `int _`.
- **Records vs classes:** Show value equality and non-destructive mutation with `with`.
- **Init-only:** Demonstrate immutability by attempting a post-init assignment (commented to keep sample compiling).
