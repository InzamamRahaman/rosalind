
let count pred = 
    Seq.filter pred >> Seq.length
let getHammingCode xs ys = 
    Seq.zip xs ys |> count (fun (x, y) -> x <> y)
getHammingCode "GAGCCTACTAACGGGAT" "CATCGTAATGACGGCCT"
