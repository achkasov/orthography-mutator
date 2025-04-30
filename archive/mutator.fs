module Mutator

let rec apply (occurences: List<string*string>) (inputText: string) =
  match occurences with
  | [] -> inputText
  | (a, b) :: rest -> inputText.Replace(a, b) |> apply rest