
let addToCount (a, c, g, t) = function
    | 'A' -> (a + 1, c, g, t)
    | 'C' -> (a, c + 1, g, t)
    | 'G' -> (a, c, g + 1, t)
    | 'T' -> (a, c, g, t + 1)
    | _ ->  failwith "Incorrect nucleotide sequence considered"

let printCounts (a, c, g, t) = 
    //printfn "%d %d %d %d", a, c, g, t
    [a; c; g; t] |> List.iter (fun c -> printf "%d " c)

let countNucleotides = 
    Seq.toList >> List.fold addToCount (0, 0, 0, 0) >> printCounts

countNucleotides "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"
