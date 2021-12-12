open System
open System.IO

let items = 
    seq {
        use reader = new StreamReader(File.OpenRead("input.txt"))
        while not reader.EndOfStream do
            yield reader.ReadLine()
    }
    |> List.ofSeq

let getOxigenGeneratorCode items =
    let rec recursive (code, items: List<_>) =
        match items.[0] with
        | "" -> code
        | x -> 
            let subString =
                items 
                |> List.map (fun x -> x.[0], x.[1..])
                |> List.groupBy (fun (x,_) -> x)
                |> List.orderBy (fun (k, v) -> v |> list.length)
                |> List.head
                |> (fun (_, (_,x)) -> x |> List.head |> Array.head)