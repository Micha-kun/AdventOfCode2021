open System
open System.IO

seq {
    use reader = new StreamReader(File.OpenRead("input.txt"))
    while not reader.EndOfStream do
        yield reader.ReadLine()
}
|> Seq.map (fun x -> let temp = x.Split(" ") in (temp.[0], int temp.[1]))
|> Seq.fold (fun (forward, depth, aim) (move, qty) ->
    printfn "%A" (forward, depth, aim, move, qty)
    match move with
    | "forward" -> (forward + qty, depth + (aim*qty), aim)
    | "up" -> (forward, depth, aim - qty)
    | "down" -> (forward, depth, aim + qty)
    | _ -> (forward, depth, aim)
) (0,0,0)
|> (fun x ->
    printfn "%A" x
    x)
|> (fun (x,y,_) -> x*y)
|> printfn "%A"
