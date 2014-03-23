
open System.Text.RegularExpressions

let input = "GATATATGCATATACTT"
let substring = "ATAT"
let rx = new Regex(substring)

let rec getAllLocations str (rx : Regex) start = 
    let m = rx.Match(str, start)
    if m.Success = false then
        []
    else
        m.Index :: (getAllLocations str rx (m.Index + 1))

getAllLocations input rx 0
|> List.map ((+) 1)
|> List.iter (printfn "%d")
        
    


