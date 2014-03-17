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

   

