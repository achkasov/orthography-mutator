//best nenets latin orthography


let orthographyV20 = 
  let basicsLettersReplacement =
    [
    //Morpheme markers
    ("-", "")
    ("=", "-")

    //Consonants - Basics
    ("ŋ", "ŋ"); ("Ŋ", "Ŋ"); 
    ("h", "ŋ"); ("H", "Ŋ"); 
    ("x", "h"); ("X", "H"); 
    ("y", "j"); ("Y", "J"); 
    ("w", "v"); ("W", "V");

    //Vowels - Basics
    ("ʹa", "ä"); ("ʹA", "Ä"); ("a", "a"); ("A", "A"); 
    ("ʹe", "ë"); ("ʹE", "Ë"); ("e", "e"); ("E", "E"); 
    ("ʹo", "ö"); ("ʹO", "Ö"); ("o", "o"); ("O", "O"); 
    ("ʹi", "ï"); ("ʹI", "Ï"); ("i", "i"); ("I", "I"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 

    //Vowels - Short
    ("ʹ°", "'");              ("°", "°");             
    ("ʹə", "ÿ"); ("ʹƏ", "Ÿ"); ("ə", "y"); ("Ə", "Y"); 

    //Vowels - Long
    ("ʹī", "ïï"); ("ʹĪ", "Ïï"); ("ī", "ii"); ("Ī", "Ii"); 
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "æ");  ("Ǣ", "Æ"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let yDoublingReplacement = 
    //replace each Weak-Y with a doubled previous letter
    let weakY = "°"
    let letters = "aäæbcdeëfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.append (letters.ToUpper() |> Seq.toList)
    |> List.map string
    |> List.map (fun c -> (c+weakY, c+c.ToLower()))

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  let weakYDiaeresisReplacement =
    [ ("'", "j") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  let qMedialdReplacement =
    [
    ("qq","t'")
    ("q","t")
    ]

  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ yDoublingReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  @ weakYDiaeresisReplacement
  @ ngMedialdReplacement
  @ qMedialdReplacement

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
|> Array.map (apply orthographyV20)
|> Array.map (apply unmarkWords)
|> String.concat ""