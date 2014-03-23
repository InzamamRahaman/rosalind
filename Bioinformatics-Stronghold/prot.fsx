
#load "Utilities.fs"

let codonTable = 
    System.IO.File.ReadAllText "codon_table.txt" 
    |> Utilities.parseCodonMap


let input = "AUGGCCAUGGCGCCCAGAACUGAGAUCAAUAGUACCCGUAUUAACGGGUGA"

let ans =
    input 
    |> Utilities.splitIntoSizedSeq 3 
    |> Seq.map (Seq.map (fun ch -> ch.ToString()))
    |> Seq.map (Seq.reduce (+))
    |> Utilities.mapPartial (fun str -> Map.tryFind str codonTable)
    |> Seq.takeWhile ((<>) "Stop")
    |> Seq.fold (+) ""



