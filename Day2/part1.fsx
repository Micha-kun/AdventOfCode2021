open System
open System.IO

seq {
    use reader = new StreamReader(File.OpenRead("input.txt"))
    while not reader.EndOfStream do
        yield reader.ReadLine()
}
|> Seq.map (fun x -> let temp = x.Split(" ") in (temp.[0], int temp.[1]))
|> Seq.fold (fun (x, y) (move, qty) -> 
    match move with
    | "forward" -> (x + qty, y)
    | "up" -> (x, y - qty)
    | "down" -> (x, y + qty)
    | _ -> (x, y)
) (0,0)
|> (fun (x,y) -> x*y)
|> printfn "%A"
