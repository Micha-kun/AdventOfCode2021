open System.IO

seq {
    use reader = new StreamReader(File.OpenRead("input.txt"))
    while not reader.EndOfStream do
        yield reader.ReadLine()
}
|> Seq.map int
|> Seq.windowed 2
|> Seq.choose (fun x -> if x.[0] < x.[1] then Some () else None)
|> Seq.length
|> printfn "%i"