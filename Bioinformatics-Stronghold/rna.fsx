
 

let translate xs =
    xs |> Seq.map (function | 'T' -> "U" | ch -> ch.ToString()) |> Seq.reduce (+)
translate "GATGGAACTTGACTACGTAAATT"
