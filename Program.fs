// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

type ArgFlow =
  | Help
  | File of string 
  | UnknownArg of string array
  | UnexpectedArg of string
  | MissingFileName


let parseArgs (argv: string array) : ArgFlow =
  let argv =
    argv
    |> Array.collect (fun s -> s.Split ' ')
    |> List.ofArray

  match List.ofArray argv with
  | "-h" :: []
  | "--help" :: [] -> Help

  | "-h" :: a :: _ 
  | "--help" :: a :: _ -> UnexpectedArg a

  | a :: [] -> File a
  | "-f" :: f :: [] -> File a
  | "--file" ::
  | _ -> UnknownArg argv

let printHelp () =
  ()

[<EntryPoint>]
let main argv =
 
  0




