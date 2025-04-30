[<RequireQualifiedAccess>]
module Mutator

let rec apply (occurences: List<string*string>) (inputText: string) =
  match occurences with
  | [] -> inputText
  | (a, b) :: rest -> inputText.Replace(a, b) |> apply rest

let convertText ortho text =
  let markWords =
    [
    (" ", "# #");   ("\010", "#\n#"); ("\013", "");

    (".", "#.#"); (",", "#,#")
    ("?", "#?#"); ("!", "#!#")
    (";", "#;#"); (":", "#:#")
    ("“", "#”#"); ("”", "#”#")
    ]

  let unmarkWords =
    [
    ("#", "")
    ]

  text
    |> apply markWords
    |> fun s -> s.Split "#"
    |> Array.filter ((<>)"")
    |> Array.map (fun s -> String.concat "" [|"#";s;"#"|] )
    |> Array.map (apply ortho)
    |> Array.map (apply unmarkWords)
    |> String.concat ""


let renderToFile (fileName:string) text =
  use streamWriter = new System.IO.StreamWriter( fileName )
  text |> fprintfn streamWriter "%s"
  streamWriter.Close()  

let applyPerWord orthography text =
    let markWords =
        [
        (" ", "# #");   ("\010", "#\n#"); ("\013", "");
        (".", "#.#"); (",", "#,#")
        ("?", "#?#"); ("!", "#!#")
        (";", "#;#"); (":", "#:#")
        ("“", "#”#"); ("”", "#”#")
        ]
    let unmarkWords =
        [
        ("#", "")
        ]
    text
        |> apply markWords
        |> fun s -> s.Split "#"
        |> Array.filter ((<>)"")
        |> Array.map (fun s -> String.concat "" [|"#";s;"#"|] )
        |> Array.map (apply orthography)
        |> Array.map (apply unmarkWords)
        |> String.concat ""