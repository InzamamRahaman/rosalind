
let toStr ch = ch.ToString()
let complementNucleotide = function
    | 'A' -> 'T'
    | 'C' -> 'G'
    | 'G' -> 'C'
    | 'T' -> 'A'
    | _ -> failwith "Error, incorrect sequence"

let complementAndReverseDna xs =
    xs |> Seq.map (complementNucleotide >> toStr) |> List.ofSeq
       |> List.rev |> List.reduce (+)
complementAndReverseDna "AAAACCCGGT"
