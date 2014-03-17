#load "Utilities.fs"

type FASTA = Utilities.FASTA

let ($) f x = 
    f x

let fileContents = System.IO.File.ReadAllText "rosalind_gc.txt"
let data = Utilities.parseAllData fileContents

let getGCCount ({Name = n; Sequence = xs} : FASTA) = 
    xs |> (Utilities.count (function | 'G' | 'C' -> true | _ -> false)) |> float


let getGCContent x = 
    (getGCCount x) / (float (Seq.length x.Sequence)) * 100.00

let test = ({Name = "n"; Sequence = "AGCTATAG"} : FASTA) |> getGCContent


let getMaxByGCContent (xs : FASTA []) = 
    xs |> Array.maxBy getGCContent

let ans = data |> getMaxByGCContent |> (fun x -> x.Name, (getGCContent x))