# MirrorConsole
Mirrors Console output to a file in a snap

Include the script like this:

    #load "MirrorConsole.fsx"

Specify a folder for the output text files:

    let mirror = new MirrorConsole(@"c:\temp\")
    
output file would look like this: `console.mirror-20150507100912.6548979.txt`

    Console.WriteLine("before Hello Interactive")
    printfn "before Hello printfn"
    [|0..1000|] |> Array.Parallel.iteri(fun i k -> printfn "[%d] %d" i (k * k))

When you want to revert to just console output

    mirror.Close()


    Console.WriteLine("after Hello Interactive")
    printfn "after Hello printfn"
