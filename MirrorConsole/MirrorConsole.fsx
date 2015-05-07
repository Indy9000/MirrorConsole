namespace Tools
open System
open System.IO

type TwinWriter(t1:TextWriter, t2:TextWriter) =
    inherit TextWriter()

    let textWriter1 = t1
    let textWriter2 = t2

    override u.Encoding with get() = t1.Encoding
    override u.Flush() = t1.Flush();  t2.Flush()
    override u.Write(c:char) = t1.Write(c); t2.Write(c)

type MirrorConsole(outputPath:string) as self =
    
    let filename = sprintf "console.mirror-%s.txt" (DateTime.UtcNow.ToString("yyyyMMddTHHmmss.fffffff"))
    let pathFileName = System.IO.Path.Combine(outputPath,filename)
    let fWriter = File.CreateText(pathFileName)
    let stdOut = Console.Out
    do
        fWriter.AutoFlush <- true
        let tw = new TwinWriter(TextWriter.Synchronized(fWriter),stdOut)
        Console.SetOut(tw)

    interface System.IDisposable with
        member this.Dispose() = 
            Console.SetOut(stdOut)
            fWriter.Dispose()

    member this.Close() =
        self :> IDisposable |> fun k-> k.Dispose()

(**
Usage

let mirror = new Tools.MirrorConsole(@"c:\temp\")

Console.WriteLine("before Hello World Interactive")
printfn "before Hello printfn"

[|0..1000|] |> Array.Parallel.iteri(fun i k -> printfn "[%d] %d" i (k * k))

mirror.Close()

Console.WriteLine("after Hello World Interactive")
printfn "after Hello printfn"
*)
