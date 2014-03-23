module Utilities
    
    type FASTA = 
        {Name : string; Sequence : string}

    let parseDnaData (str : string) = 
        (str.Split('\n'))
        |> Array.toList
        |> (fun xs -> {Name = List.head xs; Sequence = xs |> List.tail |> List.reduce (+)})

    let parseAllData (str : string) = 
        (str.Split('>'))
        |> Array.filter ((<>) "")
        |> Array.Parallel.map parseDnaData

    let count pred xs = 
        xs |> Seq.filter pred |> Seq.length

    let cartesianProduct s1 s2 = 
        s1 |> Seq.collect (fun x -> s2 |> Seq.map (fun y -> x, y))

    let rec splitIntoSizedSeq n xs = 
        seq {
            
            if Seq.isEmpty xs = false && Seq.length xs >= n then
                yield (xs |> Seq.take n)
                yield! (splitIntoSizedSeq n (Seq.skip n xs))
        }

    let parseCodonMap (str : string) = 
        str.Split([|' ' ;'\n'; '\r'|])
        |> Array.filter ((<>) "") 
        |> splitIntoSizedSeq 2
        |> Seq.map (fun s -> (Seq.head s, Seq.head (Seq.skip 1 s)))
        |> Map.ofSeq

    let mapPartial f xs = 
        xs
        |> Seq.map f 
        |> Seq.filter ((<>) None)
        |> Seq.map (function | (Some x) -> x)

   

