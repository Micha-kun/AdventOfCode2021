open System
open System.IO

seq {
    use reader = new StreamReader(File.OpenRead("input.txt"))
    while not reader.EndOfStream do
        yield reader.ReadLine()
}
|> Seq.map (fun x -> 
    x
    |> Seq.map (function | '0' -> (1,0)
                         | '1' -> (0,1) 
                         | x -> (0,0))
)
|> Seq.reduce (fun x y -> 
    Seq.zip x y
    |> Seq.map (fun (x, y) -> (fst x + fst y, snd x + snd y))
)
|> Seq.map (fun (zero, ones) -> if zero > ones then ('0', '1') else ('1', '0'))
|> List.ofSeq
|> List.unzip
|> (fun (x,y) -> new String(x |> Array.ofList), new String(y |> Array.ofList))
|> (fun (x,y) -> Convert.ToInt32(x, 2) * Convert.ToInt32(y, 2))
|> printfn "%A"