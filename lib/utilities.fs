[<RequireQualifiedAccess>]
module Utilities

let readTextFile filename =
    let text = System.IO.File.ReadAllText(filename)
    text

let writeTextFile filename (text: string) =
    System.IO.File.WriteAllText(filename, text)
