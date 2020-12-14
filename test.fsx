
// TEST


// ă > æ
// ț > ç
// â > ā
// î > ī
// x > cs
// ș > x



let rec replace occurences (input: string) =
  match occurences with
  | [] -> input
  | (a: string, b: string) :: remainder ->
    input.Replace(a, b) |> replace remainder 

let input: string = """Toate ființele umane se nasc libere și egale în demnitate și în drepturi. Ele sunt înzestrate cu rațiune și conștiință și trebuie să se comporte unele față de altele în spiritul fraternității."""

input
|> replace
  [
  ("ă", "æ"); ("ă", "Æ");
  ("ț", "ç"); ("Ț", "Ç"); ("ţ", "ç"); ("Ţ", "Ç");
  ("â", "ā"); ("Â", "ā");
  ("î", "ī"); ("Î", "ī");
  ("ș", "x"); ("Ș", "X"); ("ş", "x"); ("Ş", "X");
  ]
|> printfn "\n%s\n"

input
|> replace
  [
  ("ă", "œ"); ("ă", "Œ");
  ("ț", "ç"); ("Ț", "Ç"); ("ţ", "ç"); ("Ţ", "Ç");
  ("â", "æ"); ("Â", "Æ");
  ("î", "æ"); ("Î", "Æ");
  ("ș", "x"); ("Ș", "X"); ("ş", "x"); ("Ş", "X");
  ]
|> printfn "\n%s\n"


