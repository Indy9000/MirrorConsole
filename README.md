## **MirrorConsole**

Mirrors Console output of an F# script to a file 

At the top of your script load this script:

```fsharp
#load "MirrorConsole.fsx"
```

Specify a folder for the output text files:

```fsharp
let mirror = new Tools.MirrorConsole("c:\\temp\")
```

Output file would look like this: 

```text
console.mirror-20150507T101118.6239884.txt
```

Do your magic ...

```fsharp
Console.WriteLine("before Hello Interactive")
printfn "before Hello printfn"
[|0..1000|] |> Array.Parallel.iteri(fun i k -> printfn "[%d] %d" i (k * k))
```

When you want to revert to just console output:

```fsharp
mirror.Close()
```

Rest of your magic

```fsharp
Console.WriteLine("after Hello Interactive")
printfn "after Hello printfn"
```