#load "../lib/mutator.fs"
#load "./text/nenets.text.fs"
open Mutator
open NenetsText
open System.IO
// Example: Tudra Nenets 


let orthography_salminen = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "H"); ("h", "h");
  ("X", "X"); ("x", "x");
  ("Y", "Ÿ"); ("y", "ÿ");

  ("ʹA", "Ya"); ("ʹa", "yá"); ("A", "A"); ("a", "a");
  ("ʹE", "Ye"); ("ʹe", "ye"); ("E", "E"); ("e", "e");
  ("ʹO", "Yo"); ("ʹo", "yo"); ("O", "O"); ("o", "o");
  ("ʹI", "Yi"); ("ʹi", "yi"); ("I", "I"); ("i", "i"); 
  ("ʹU", "Yu"); ("ʹu", "yu"); ("U", "U"); ("u", "u"); 
  ("ʹƏ", "Yə"); ("ʹə", "yə"); ("Ə", "Ə"); ("ə", "ə");
  ("ʹ°", "y°"); ("°", "°");
  ("Ǣ", "Æ"); ("ǣ", "æ");
  ("ʹĪ", "Yí"); ("ʹī", "yí"); ("Ī", "Í"); ("ī", "í"); 
  ("ʹŪ", "Yú"); ("ʹū", "yú"); ("Ū", "Ú"); ("ū", "ú"); 

  ("-", "")
  ("=", "")
  ]

let orthography_internal = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "H"); ("h", "h");
  ("X", "X"); ("x", "x");
  ("Y", "J"); ("y", "j");

  ("A", "A"); ("a", "a"); ("ʹA", "Ä"); ("ʹa", "ä"); 
  ("E", "E"); ("e", "e"); ("ʹE", "Ë"); ("ʹe", "ë");
  ("I", "Y"); ("i", "y"); ("ʹY", "I"); ("ʹy", "i");
  ("O", "O"); ("o", "o"); ("ʹO", "Ö"); ("ʹo", "ö"); 
  ("U", "U"); ("u", "u"); ("ʹU", "Ü"); ("ʹu", "ü");
  ("Ə", "À"); ("ə", "à"); ("ʹÀ", "Ȁ"); ("ʹà", "ȁ");
              ("°", "è");              ("ʹè", "ȅ");
  ("Ǣ", "Æ"); ("ǣ", "æ");
  ("Ī", "Ý"); ("ī", "ý"); ("ʹÝ", "Í"); ("ʹý", "í");
  ("Ū", "Ú"); ("ū", "ú"); ("ʹÚ", "Ű"); ("ʹú", "ű");

  ("-", "")
  ("=", "")
  ]

let orthography_internal2 = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "Ŋ"); ("h", "ŋ");
  ("X", "H"); ("x", "h");
  ("Y", "J"); ("y", "j");

  ("A", "A"); ("a", "a"); ("ʹA", "Ä"); ("ʹa", "ä"); 
  ("E", "E"); ("e", "e"); ("ʹE", "Ë"); ("ʹe", "ë");
  ("I", "Y"); ("i", "y"); ("ʹY", "I"); ("ʹy", "i");
  ("O", "O"); ("o", "o"); ("ʹO", "Ö"); ("ʹo", "ö"); 
  ("U", "U"); ("u", "u"); ("ʹU", "Ü"); ("ʹu", "ü");
  ("Ə", "À"); ("ə", "à"); ("ʹÀ", "Ȁ"); ("ʹà", "ȁ");
              ("°", "è");              ("ʹè", "ȅ");
  ("Ǣ", "Æ"); ("ǣ", "æ");
  ("Ī", "Ý"); ("ī", "ý"); ("ʹÝ", "Í"); ("ʹý", "í");
  ("Ū", "Ú"); ("ū", "ú"); ("ʹÚ", "Ű"); ("ʹú", "ű");

  ("-", "")
  ("=", "")
  ]



let orthographyV21 = 
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
    ("ʹe", "ȅ"); ("ʹE", "Ȅ"); ("e", "è"); ("E", "È"); 
    ("ʹo", "ö"); ("ʹO", "Ö"); ("o", "o"); ("O", "O"); 
    ("ʹi", "ï"); ("ʹI", "Ï"); ("i", "i"); ("I", "I"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 

    //Vowels - Short
    ("ʹ°", "'");              ("°", "°");             
    ("ʹə", "ë"); ("ʹƏ", "Ë"); ("ə", "e"); ("Ə", "e"); 

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
    let letters = "aäæbcdeëèȅfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.append (letters.ToUpper() |> Seq.toList)
    |> List.map string
    |> List.map (fun c -> (c+weakY, c+c.ToLower()))

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèȅfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèȅfghiïjklmnŋoöpqrstuüvwxyÿz°'"
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
|> Array.map (apply orthographyV21)
|> Array.map (apply unmarkWords)
|> String.concat ""



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

let text_converted =
  text
    |> apply markWords
    |> fun s -> s.Split "#"
    |> Array.filter ((<>)"")
    |> Array.map (fun s -> String.concat "" [|"#";s;"#"|] )
    |> Array.map (apply orthographyV20)
    |> Array.map (apply unmarkWords)
    |> String.concat ""


let _ =
  use streamWriter = new System.IO.StreamWriter(@".\\nenets.text-V20.txt")
  text_converted |> fprintfn streamWriter "%s"
  streamWriter.Close()


let orthographyV20a = 
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
    ("ʹi", "ÿ"); ("ʹI", "Ÿ"); ("i", "y"); ("I", "Y"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 

    //Vowels - Short
    ("ʹ°", "'");              ("°", "°");             
    ("ʹə", "ṏ"); ("ʹƏ", "Ṏ"); ("ə", "õ"); ("Ə", "Õ"); 

    //Vowels - Long
    ("ʹī", "y̋"); ("ʹĪ", "Y̋"); ("ī", "ý"); ("Ī", "Ý"); 
    ("ʹū", "ű"); ("ʹŪ", "Ű"); ("ū", "ú"); ("Ū", "Ú"); 
                                ("ǣ", "á");  ("Ǣ", "Á"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let yDoublingReplacement = 
    //replace each Weak-Y with a doubled previous letter
    let weakY = "°"
    let letters = "aáõṏäæbcdeëfghiïjklmnŋoöpqrstuüvwxyýÿz°'"
    letters
    |> Seq.toList
    |> List.append (letters.ToUpper() |> Seq.toList)
    |> List.map string
    |> List.map (fun c -> (c+weakY, c+c.ToLower()))

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aáõṏäæbcdeëfghiïjklmnŋoöpqrstuüvwxyýÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aáõṏäæbcdeëfghiïjklmnŋoöpqrstuüvwxyýÿz°'"
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

let text_converted =
  text
    |> apply markWords
    |> fun s -> s.Split "#"
    |> Array.filter ((<>)"")
    |> Array.map (fun s -> String.concat "" [|"#";s;"#"|] )
    |> Array.map (apply orthographyV20a)
    |> Array.map (apply unmarkWords)
    |> String.concat ""


let _ =
  use streamWriter = new System.IO.StreamWriter(@".\\nenets.text-V20a.txt")
  text_converted |> fprintfn streamWriter "%s"
  streamWriter.Close()




let orthographyV22 = 
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
    ("ʹe", "é"); ("ʹE", "É"); ("e", "è"); ("E", "È"); 
    ("ʹo", "ö"); ("ʹO", "Ö"); ("o", "o"); ("O", "O"); 
    ("ʹi", "ï"); ("ʹI", "Ï"); ("i", "i"); ("I", "I"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 

    //Vowels - Short
    ("ʹ°", "'");              ("°", "°");             
    ("ʹə", "ë"); ("ʹƏ", "Ë"); ("ə", "e"); ("Ə", "E"); 

    //Vowels - Long
    ("ʹī", "ïï"); ("ʹĪ", "Ïï"); ("ī", "ii"); ("Ī", "Ii"); 
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "æ");  ("Ǣ", "Æ"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let eDoublingReplacement = 
    //replace each Weak-E with a doubled previous letter
    let weakY = "°"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.append (letters.ToUpper() |> Seq.toList)
    |> List.map string
    |> List.map (fun c -> (c+weakY, c+c.ToLower()))

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  let weakEDiaeresisReplacement =
    [ ("'", "j") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ŋ")
    ]

  let qMedialdReplacement =
    [
    ("qq","t'")
    ("q","t")
    ]

  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ eDoublingReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  @ weakEDiaeresisReplacement
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


let text_converted =
  text
    |> apply markWords
    |> fun s -> s.Split "#"
    |> Array.filter ((<>)"")
    |> Array.map (fun s -> String.concat "" [|"#";s;"#"|] )
    |> Array.map (apply orthographyV22)
    |> Array.map (apply unmarkWords)
    |> String.concat ""


let _ =
  use streamWriter = new System.IO.StreamWriter(@".\\nenets.text-V22.txt")
  text_converted |> fprintfn streamWriter "%s"
  streamWriter.Close()



let orthographyV23 = 
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
    ("ʹe", "æ̈"); ("ʹE", "Æ̈"); ("e", "æ"); ("E", "Æ"); 
    ("ʹo", "ö"); ("ʹO", "Ö"); ("o", "o"); ("O", "O"); 
    ("ʹi", "ï"); ("ʹI", "Ï"); ("i", "i"); ("I", "I"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 

    //Vowels - Short
    ("ʹ°", "'");              ("°", "°");             
    ("ʹə", "ë"); ("ʹƏ", "Ë"); ("ə", "e"); ("Ə", "E"); 

    //Vowels - Long
    ("ʹī", "ïï"); ("ʹĪ", "Ïï"); ("ī", "ii"); ("Ī", "Ii"); 
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "aa");  ("Ǣ", "Aa"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let eDoublingReplacement = 
    //replace each Weak-E with a doubled previous letter
    let weakY = "°"
    let letters = "bcdfghjklmnŋpqrstvwxz°'"
    letters
    |> Seq.toList
    |> List.append (letters.ToUpper() |> Seq.toList)
    |> List.map string
    |> List.map (fun c -> (c+weakY, c+c.ToLower()))

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  let weakEDiaeresisReplacement =
    [ ("'", "j") ]

  let weakEReplacement =
    [ ("°", "e") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ŋ")
    ]

  let qMedialdReplacement =
    [
    ("qq","t'")
    ("q","t")
    ]

  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ eDoublingReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  @ weakEDiaeresisReplacement
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement

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


let text_converted =
  text
    |> apply markWords
    |> fun s -> s.Split "#"
    |> Array.filter ((<>)"")
    |> Array.map (fun s -> String.concat "" [|"#";s;"#"|] )
    |> Array.map (apply orthographyV23)
    |> Array.map (apply unmarkWords)
    |> String.concat ""


let _ =
  use streamWriter = new System.IO.StreamWriter(@".\\nenets.text-V23.txt")
  text_converted |> fprintfn streamWriter "%s"
  streamWriter.Close()




let orthographyV30Dictonary = 
  let breve = "\u0306"

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
    ("ʹe", "é"); ("ʹE", "É"); ("e", "è"); ("E", "È"); 
    ("ʹo", "ö"); ("ʹO", "Ö"); ("o", "o"); ("O", "O"); 
    ("ʹi", "ï"); ("ʹI", "Ï"); ("i", "i"); ("I", "I"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 

    //Vowels - Short
    ("ʹ°", "'");              ("°", "°");             
    ("ʹə", "ë"); ("ʹƏ", "Ë"); ("ə", "e"); ("Ə", "E"); 

    //Vowels - Long
    ("ʹī", "ïï"); ("ʹĪ", "Ïï"); ("ī", "ii"); ("Ī", "Ii"); 
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "æ");  ("Ǣ", "Æ"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t"+breve+"#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "n"+breve+"#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()+"\u0303"))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c+"\u0303"))

  let weakEReplacement =
    [ ("°", "e"+breve) ]

  let weakEDiaeresisReplacement =
    [ ("'", "ë"+breve) ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  let qMedialdReplacement =
    [
    ("qe"+breve,"t"+breve+"'")
    ("q","t"+breve)
    ]

  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  @ weakEReplacement
  @ weakEDiaeresisReplacement
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


let text_converted =
  text
    |> apply markWords
    |> fun s -> s.Split "#"
    |> Array.filter ((<>)"")
    |> Array.map (fun s -> String.concat "" [|"#";s;"#"|] )
    |> Array.map (apply orthographyV30Dictonary)
    |> Array.map (apply unmarkWords)
    |> String.concat ""


let _ =
  use streamWriter = new System.IO.StreamWriter(@".\\nenets.text-V30-dict.txt")
  text_converted |> fprintfn streamWriter "%s"
  streamWriter.Close()


let orthographyV30 = 
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
    ("ʹe", "é"); ("ʹE", "É"); ("e", "è"); ("E", "È"); 
    ("ʹo", "ö"); ("ʹO", "Ö"); ("o", "o"); ("O", "O"); 
    ("ʹi", "ï"); ("ʹI", "Ï"); ("i", "i"); ("I", "I"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 

    //Vowels - Short
    ("ʹ°", "'");              ("°", "°");             
    ("ʹə", "ë"); ("ʹƏ", "Ë"); ("ə", "e"); ("Ə", "E"); 

    //Vowels - Long
    ("ʹī", "ïï"); ("ʹĪ", "Ïï"); ("ī", "ii"); ("Ī", "Ii"); 
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "æ");  ("Ǣ", "Æ"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  let weakEDiaeresisReplacement =
    [ ("'", "ë") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  let qMedialdReplacement =
    [
    ("q°","t'")
    ("q","t")
    ]

  let weakEReplacement =
    [ ("°", "e") ]


  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  @ weakEDiaeresisReplacement
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement

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


let text_converted =
  text
    |> apply markWords
    |> fun s -> s.Split "#"
    |> Array.filter ((<>)"")
    |> Array.map (fun s -> String.concat "" [|"#";s;"#"|] )
    |> Array.map (apply orthographyV30)
    |> Array.map (apply unmarkWords)
    |> String.concat ""

let _ =
  use streamWriter = new System.IO.StreamWriter(@".\\nenets.text-V30.txt")
  text_converted |> fprintfn streamWriter "%s"
  streamWriter.Close()




let orthographyV31 = 
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
    [ ("'", "ÿ") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  let qMedialdReplacement =
    [
    ("q°","t'")
    ("q","t")
    ]

  let weakYReplacement =
    [ ("°", "y") ]


  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  @ weakYDiaeresisReplacement
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakYReplacement

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


let text_converted =
  text
    |> apply markWords
    |> fun s -> s.Split "#"
    |> Array.filter ((<>)"")
    |> Array.map (fun s -> String.concat "" [|"#";s;"#"|] )
    |> Array.map (apply orthographyV31)
    |> Array.map (apply unmarkWords)
    |> String.concat ""

let _ =
  use streamWriter = new System.IO.StreamWriter(@".\\nenets.text-V31.txt")
  text_converted |> fprintfn streamWriter "%s"
  streamWriter.Close()




///
let orthographyV32 = 
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
    ("ʹe", "æ̈"); ("ʹE", "Æ̈"); ("e", "æ"); ("E", "Æ"); 
    ("ʹo", "ö"); ("ʹO", "Ö"); ("o", "o"); ("O", "O"); 
    ("ʹi", "ÿ"); ("ʹI", "Ÿ"); ("i", "y"); ("I", "Y"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 

    //Vowels - Short
    ("ʹ°", "'");              ("°", "°");             
    ("ʹə", "ë"); ("ʹƏ", "Ë"); ("ə", "e"); ("Ə", "E"); 

    //Vowels - Long
    ("ʹī", "ÿÿ"); ("ʹĪ", "Ÿÿ"); ("ī", "yy"); ("Ī", "Yy"); 
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "aa");  ("Ǣ", "Aa"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  let weakEDiaeresisReplacement =
    [ ("'", "ë") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  let qMedialdReplacement =
    [
    ("q°","t'")
    ("q","t")
    ]

  let weakEReplacement =
    [ ("°", "e") ]


  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  @ weakEDiaeresisReplacement
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement

let _ =
  let fileName = @".\\nenets.text-V32.txt"
  let ortho = orthographyV32

  text
  |> convertText ortho
  |> renderToFile fileName



let orthographyV33 = 
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
    ("ʹo", "ő"); ("ʹO", "Ő"); ("o", "ó"); ("O", "Ó"); 
    ("i", "y"); ("I", "Y");  ("ʹy", "i"); ("ʹY", "I");
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 

    //Vowels - Short
    ("ʹ°", "'");              ("°", "°");             
    ("ʹə", "ö"); ("ʹƏ", "Ö"); ("ə", "ò"); ("Ə", "Ò"); 

    //Vowels - Long
    ("ʹī", "ii"); ("ʹĪ", "Ii"); ("ī", "yy"); ("Ī", "Yy"); 
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "aa");  ("Ǣ", "Aa"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoòöőõṏpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoòöőõṏpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  let weakEDiaeresisReplacement =
    [ ("'", "j") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  let qMedialdReplacement =
    [
    ("q°","t'")
    ("q","t")
    ]

  let weakEReplacement =
    [ ("°", "o") ]


  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  @ weakEDiaeresisReplacement
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement

let _ =
  let fileName = @".\\nenets.text-V33.txt"
  let ortho = orthographyV33

  text
  |> convertText ortho
  |> renderToFile fileName
  


let orthographyV34 = 
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
    ("ʹo", "ö"); ("ʹO", "Ö"); ("o", "o"); ("O", "Ö"); 
    ("ʹi", "ÿ"); ("ʹI", "Ÿ"); ("i", "y"); ("I", "Y");  
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 

    //Vowels - Short
    ("ʹ°", "'");              ("°", "°");             
    ("ʹə", "œ"); ("ʹƏ", "Œ"); ("ə", "ǽ"); ("Ə", "Ǽ"); 

    //Vowels - Long
    ("ʹī", "ÿÿ"); ("ʹĪ", "Ÿÿ"); ("ī", "yy"); ("Ī", "Yy"); 
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "aa");  ("Ǣ", "Aa"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoòöőõṏœpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoòöőõṏœpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  let weakEDiaeresisReplacement =
    [ ("'", "j") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  let qMedialdReplacement =
    [
    ("q°","t'")
    ("q","t")
    ]

  let weakEReplacement =
    [ ("°", "æ") ]


  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  @ weakEDiaeresisReplacement
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement

let _ =
  let fileName = @".\\nenets.text-V34.txt"
  let ortho = orthographyV34

  text
  |> convertText ortho
  |> renderToFile fileName
  




/// Palatal Assymetrical
let orthographyV4 = 
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
    ("i", "y"); ("I", "Y"); ("ʹy", "i"); ("ʹY", "I"); ("jy","ji"); ("Jy","Ji")
    ("ʹa", "ia"); ("ʹA", "Ia"); ("a", "a"); ("A", "A"); 
    ("ʹe", "iä"); ("ʹE", "Iä"); ("e", "ä"); ("E", "ä"); 
    ("ʹo", "io"); ("ʹO", "Io"); ("o", "o"); ("O", "O"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 



    //Vowels - Short
    ("ʹ°", "'");              ("°", "°");             
    ("ʹə", "ie"); ("ʹƏ", "Ie"); ("ə", "e"); ("Ə", "E"); 

    //Vowels - Long
    ("ī", "yy"); ("Ī", "Yy"); ("ʹyy", "ii"); ("ʹYy", "Ii"); 
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "ää");  ("Ǣ", "Ää"); 
    ]

  let qFinalReplacement =
    [ ("q#", "q#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "q#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  // let weakEDiaeresisReplacement =
  //   [ ("'", "ë") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  // let qMedialdReplacement =
  //   [
  //   ("q°","t'")
  //   ("q","t")
  //   ]

  let weakEReplacement =
    [ ("°", "e") ]


  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  // @ weakEDiaeresisReplacement
  @ ngMedialdReplacement
  // @ qMedialdReplacement
  @ weakEReplacement

let _ =
  let fileName = @".\\nenets.text-V4.txt"
  let ortho = orthographyV4

  text
  |> convertText ortho
  |> renderToFile fileName
  


/// Palatal Assymetrical
let orthographyV4b = 
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
    ("i", "y"); ("I", "Y"); ("ʹy", "i"); ("ʹY", "I"); ("jy","ji"); ("Jy","Ji")
    ("ʹa", "ia"); ("ʹA", "Ia"); ("a", "a"); ("A", "A"); 
    ("ʹe", "ie"); ("ʹE", "Ie"); ("e", "e"); ("E", "E"); 
    ("ʹo", "io"); ("ʹO", "Io"); ("o", "o"); ("O", "O"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 



    //Vowels - Short
    let combiningCaron = "\u030C"
    let combiningAcute = "\u0301"
    ("ʹ°", "j");              ("°", "'");             
    ("ʹə", "iä"); ("ʹƏ", "Iä"); ("ə", "ä"); ("Ə", "Ä"); 

    //Vowels - Long
    ("ī", "yy"); ("Ī", "Yy"); ("ʹyy", "ii"); ("ʹYy", "Ii"); ("jyy","jii"); ("Jyy","jii")
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "aa");  ("Ǣ", "Aa"); 
    ]

  let qFinalReplacement =
    [ ("q#", "q#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "q#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  // let weakEDiaeresisReplacement =
  //   [ ("'", "ë") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  // let qMedialdReplacement =
  //   [
  //   ("q°","t'")
  //   ("q","t")
  //   ]

  // let weakEReplacement =
  //   [ ("°", "ä") ]


  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  // @ weakEDiaeresisReplacement
  @ ngMedialdReplacement
  // @ qMedialdReplacement
  // @ weakEReplacement

let _ =
  let fileName = @".\\nenets.text-V4b.txt"
  let ortho = orthographyV4b

  text
  |> convertText ortho
  |> renderToFile fileName
  


/// Palatal Assymetrical
let orthographyV4c = 
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
    ("i", "y"); ("I", "Y"); ("ʹy", "i"); ("ʹY", "I"); ("jy","ji"); ("Jy","Ji")
    ("ʹa", "iä"); ("ʹA", "Iä"); ("a", "ä"); ("A", "Ä"); 
    ("ʹe", "ie"); ("ʹE", "Ie"); ("e", "e"); ("E", "E"); 
    ("ʹo", "io"); ("ʹO", "Io"); ("o", "o"); ("O", "O"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 



    //Vowels - Short
    let combiningCaron = "\u030C"
    let combiningAcute = "\u0301"
    ("ʹ°", combiningAcute);              ("°", "a");             
    ("ʹə", "ia"); ("ʹƏ", "Ia"); ("ə", "a"); ("Ə", "A"); 

    //Vowels - Long
    ("ī", "yy"); ("Ī", "Yy"); ("ʹyy", "ii"); ("ʹYy", "Ii"); ("jyy","jii"); ("Jyy","jii")
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "ää");  ("Ǣ", "Ää"); 
    ]

  let qFinalReplacement =
    [ ("q#", "q#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "q#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  // let weakEDiaeresisReplacement =
  //   [ ("'", "ë") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  // let qMedialdReplacement =
  //   [
  //   ("q°","t'")
  //   ("q","t")
  //   ]

  // let weakEReplacement =
  //   [ ("°", "ä") ]


  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  // @ weakEDiaeresisReplacement
  @ ngMedialdReplacement
  // @ qMedialdReplacement
  // @ weakEReplacement

let _ =
  let fileName = @".\\nenets.text-V4c.txt"
  let ortho = orthographyV4c

  text
  |> convertText ortho
  |> renderToFile fileName
  


/// Palatal Assymetrical
let orthographyV4d = 
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
    ("i", "y"); ("I", "Y"); ("ʹy", "i"); ("ʹY", "I"); ("jy","ji"); ("Jy","Ji")
    ("ʹa", "ia"); ("ʹA", "Ia"); ("a", "a"); ("A", "A"); 
    ("ʹe", "iæ"); ("ʹE", "Iæ"); ("e", "æ"); ("E", "Æ"); 
    ("ʹo", "io"); ("ʹO", "Io"); ("o", "o"); ("O", "O"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 



    //Vowels - Short
    let combiningCaron = "\u030C"
    let combiningAcute = "\u0301"
    ("ʹ°", "j");              ("°", "e");             
    ("ʹə", "iä"); ("ʹƏ", "Iä"); ("ə", "ä"); ("Ə", "Ä"); 

    //Vowels - Long
    ("ī", "yy"); ("Ī", "Yy"); ("ʹyy", "ii"); ("ʹYy", "Ii"); ("jyy","jii"); ("Jyy","jii")
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "aa");  ("Ǣ", "Aa"); 
    ]

  let qFinalReplacement =
    [ ("q#", "q#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "q#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  // let weakEDiaeresisReplacement =
  //   [ ("'", "ë") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  // let qMedialdReplacement =
  //   [
  //   ("q°","t'")
  //   ("q","t")
  //   ]

  // let weakEReplacement =
  //   [ ("°", "ä") ]


  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  // @ weakEDiaeresisReplacement
  @ ngMedialdReplacement
  // @ qMedialdReplacement
  // @ weakEReplacement

let _ =
  let fileName = @".\\nenets.text-V4d.txt"
  let ortho = orthographyV4d

  text
  |> convertText ortho
  |> renderToFile fileName
  



/// Palatal Assymetrical
let orthographyV4e = 
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
    ("i", "y"); ("I", "Y"); ("ʹy", "i"); ("ʹY", "I"); ("jy","ji"); ("Jy","Ji")
    ("ʹa", "ia"); ("ʹA", "Ia"); ("a", "a"); ("A", "a"); 
    ("ʹe", "iä"); ("ʹE", "Iä"); ("e", "ä"); ("E", "ä"); 
    ("ʹo", "io"); ("ʹO", "Io"); ("o", "o"); ("O", "O"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 



    //Vowels - Short
    let combiningCaron = "\u030C"
    let combiningAcute = "\u0301"
    ("ʹ°", combiningCaron);              ("°", "°");             
    ("ʹə", "ië"); ("ʹƏ", "Ië"); ("ə", "ë"); ("Ə", "Ë"); 

    //Vowels - Long
    ("ī", "yy"); ("Ī", "Yy"); ("ʹyy", "ii"); ("ʹYy", "Ii"); ("jyy","jii"); ("Jyy","jii")
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "aa");  ("Ǣ", "Aa"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  // let weakEDiaeresisReplacement =
  //   [ ("'", "ë") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  let qMedialdReplacement =
    [
    ("q°","qe")
    ("q","t")
    ]

  let weakEReplacement =
    [ ("°", "e") ]


  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  // @ weakEDiaeresisReplacement
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement

let _ =
  let fileName = @".\\nenets.text-V4e.txt"
  let ortho = orthographyV4e

  text
  |> convertText ortho
  |> renderToFile fileName
  

/// Palatal Assymetrical
let orthographyV4f = 
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
    ("ʹi", "ÿ"); ("ʹI", "Ÿ"); ("i", "y"); ("I", "Y");
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 
    ("ʹa", "ia"); ("ʹA", "Ia"); ("a", "a"); ("A", "a"); 
    ("ʹe", "iä"); ("ʹE", "Iä"); ("e", "ä"); ("E", "ä"); 
    ("ʹo", "io"); ("ʹO", "Io"); ("o", "o"); ("O", "O"); 



    //Vowels - Short
    let combiningCaron = "\u030C"
    let combiningAcute = "\u0301"
    ("ʹ°", "j");              ("°", "°");             
    ("ʹə", "ië"); ("ʹƏ", "Ië"); ("ə", "ë"); ("Ə", "Ë"); 

    //Vowels - Long
    ("ʹī", "ÿÿ"); ("ʹĪ", "Ÿÿ"); ("ī", "yy"); ("Ī", "Yy"); 
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "aa");  ("Ǣ", "Aa"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  // let weakEDiaeresisReplacement =
  //   [ ("'", "ë") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  let qMedialdReplacement =
    [
    ("q°","t'e")
    ("q","t")
    ]

  let weakEReplacement =
    [ ("°", "e") ]


  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  // @ weakEDiaeresisReplacement
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement

let _ =
  let fileName = @".\\nenets.text-V4f.txt"
  let ortho = orthographyV4f

  text
  |> convertText ortho
  |> renderToFile fileName
  


let orthographyV5a = 
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
    ("ʹi", "yi"); ("ʹI", "Yi"); ("i", "i"); ("I", "I");
    ("ʹu", "yu"); ("ʹU", "Yu"); ("u", "u"); ("U", "U"); 
    ("ʹa", "yä"); ("ʹA", "Yä"); ("a", "ä"); ("A", "ä"); 
    ("ʹe", "ye"); ("ʹE", "ye"); ("e", "e"); ("E", "e"); 
    ("ʹo", "yo"); ("ʹO", "Yo"); ("o", "o"); ("O", "O"); 



    //Vowels - Short
    let combiningCaron = "\u030C"
    let combiningAcute = "\u0301"
    ("ʹ°", "ÿ");              ("°", "°");             
    ("ʹə", "ia"); ("ʹƏ", "Ia"); ("ə", "a"); ("Ə", "A"); 

    //Vowels - Long
    ("ʹī", "yí"); ("ʹĪ", "Yí"); ("ī", "í"); ("Ī", "Í"); 
    ("ʹū", "yú"); ("ʹŪ", "Yú"); ("ū", "ú"); ("Ū", "Ú"); 
                                ("ǣ", "á");  ("Ǣ", "Á"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ]

  let ngFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aàáäæbcdeëèéfghiíïjklmnŋoöpqrstuúüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aàáäæbcdeëèéfghiíïjklmnŋoöpqrstuúüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  // let weakEDiaeresisReplacement =
  //   [ ("'", "ë") ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ng")
    ]

  let qMedialdReplacement =
    [
    ("q°","t'à")
    ("q","t")
    ]

  let weakEReplacement =
    [ ("°", "à") ]


  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  // @ weakEDiaeresisReplacement
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement

let _ =
  let fileName = @".\\nenets.text-V5a.txt"
  let ortho = orthographyV5a

  text
  |> convertText ortho
  |> renderToFile fileName
  




/// Palatal Assymetrical
let orthographyCyr1 = 
  let basicsLettersReplacement =
    [
    //Morpheme markers
    ("-", "")
    ("=", "-")

    ( "B", "Б")
    ( "W", "В")
    ( "G", "Г")
    ( "D", "Д")
    ( "Z", "З")
    ( "Y", "Й")
    ( "K", "К")
    ( "L", "Л")
    ( "M", "М")
    ( "N", "Н")
    ( "P", "П")
    ( "R", "Р")
    ( "S", "С")
    ( "Y", "Т")
    ( "F", "Ф")
    ( "X", "Х")
    ( "C", "Ц")
    ( "Q", "Ҡ")
    ( "Ŋ", "Ҥ");
    ( "b", "б")
    ( "w", "в")
    ( "g", "г")
    ( "d", "д")
    ( "z", "з")
    ( "y", "й")
    ( "k", "к")
    ( "l", "л")
    ( "m", "м")
    ( "n", "н")
    ( "p", "п")
    ( "r", "р")
    ( "s", "с")
    ( "t", "т")
    ( "f", "ф")
    ( "x", "х")
    ( "c", "ц")
    ( "H", "Ҥ");
    ( "h", "ҥ");
    ( "ŋ", "ҥ");
    ( "q", "ҡ")
    

    ("A", "А"); ("a", "а"); ("ʹА", "Я"); ("ʹа", "я"); // ok
    ("E", "Э"); ("e", "э"); ("ʹЭ", "Е"); ("ʹэ", "е"); // ok
    ("I", "Ы"); ("i", "ы"); ("ʹЫ", "И"); ("ʹы", "и"); // ok
    ("Ə", "Ъ"); ("ə", "ъ"); ("ʹЪ", "Ь"); ("ʹъ", "ь"); // ok
                ("ʹ°", "ь"); ("°", "ъ");              
    ("O", "О"); ("o", "о"); ("ʹО", "Ë"); ("ʹо", "ë"); // ok
    ("U", "У"); ("u", "у"); ("ʹУ", "Ю"); ("ʹу", "ю"); // ok
    ("Ǣ", "Ээ"); ("ǣ", "ээ");                         // ok
    ("Ī", "Ыы"); ("ī", "ыы"); ("ʹЫы", "Ии"); ("ʹыы", "ии"); // ok
    ("Ū", "Уу"); ("ū", "уу"); ("ʹУу", "Юю"); ("ʹуу", "юю"); // o
    ]

  let qFinalReplacement =
    [ ("ҡ#", "ҡ#"); ]

  let ngFinalReplacement =
    [ ("ҥ#", "ҥ#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ҥ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ҥ"
    let letters = "aäæbcdeëèéfghiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  // let weakEDiaeresisReplacement =
  //   [ ("'", "ë") ]

  let ngMedialdReplacement =
    [
    ("ҥк", "нк")
    ("ҥ", "ҥ")
    ]

  // let qMedialdReplacement =
  //   [
  //   ("q°","t'")
  //   ("q","t")
  //   ]

  // let weakEReplacement =
  //   [ ("°", "ä") ]


  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  // @ weakEDiaeresisReplacement
  @ ngMedialdReplacement
  // @ qMedialdReplacement
  // @ weakEReplacement

let _ =
  let fileName = @".\\nenets.text-cyr1.txt"
  let ortho = orthographyCyr1

  text
  |> convertText ortho
  |> renderToFile fileName
  




let orthographyTDQN =
  [
  ("àqè","à'è")
  ("ëqè","ë'è")
  ("q","t")
  ("h#", "ŋ#");  
  ]


let orthographyDoubleCons =
  [
  ("À", "Y"); ("ə", "à"); ("ʹÀ", "Ÿ"); ("ʹà", "ȁ");
              ("°", "è");              ("ʹè", "ȅ");  
  ]


let reducedOTilde =
  [
  ("à","õ"); ("è","õ̯");
  ("ȁ","ṏ"); ("ȅ","ṏ̯");
  ]

let reducedOITildeBreve =
  [
  ("à","õ"); ("è","ŏ");
  ("ȁ","ĩ"); ("ȅ","ĭ");
  ]


let reducedY =
  [
  ("i","ï"); ("y", "i")
  ("à","y"); ("è","y̆");
  ("ȁ","ÿ"); ("ȅ","ÿ̆");
  ]

let reducedE =
  [
  ("è","*")
  ("e","è"); ("ë","é")
  ("à","e"); ("*","ĕ");
  ("ȁ","ë"); ("ȅ","ë̆");    
  ]

let reducedARing =
  [
  ("à","å"); ("è","å̯");
  ("ȁ","â"); ("ȅ","â̯");
  ]

let reducedA =
  [

  ("a","aa"); ("ä","ää")

  ("à","a"); ("è","ă");
  ("ȁ","ä"); ("ȅ","ä̆");

  ]

let longDoubled =
  [
  ("í","ii")
  ("ý","yy")
  ]

let orthographyI =
  [
  ("Ji","Jy");("ji","jy")
  ("i","ï"); ("y","i")
  ]

let orthographyZ = [("C","Z"); ("c","z")]

let orthographyV = [ ("W","V"); ("w", "v") ]
let orthographyH = [ ("X","H"); ("x","h") ]
let orthographyJi = [ ("Jy","ji"); ("jy", "ji") ] 

text
|> apply markWords
|> fun s -> s.Split "#"
|> Array.map (fun s -> String.concat "" [|"#";s;"#"|] )
|> Array.map (orthography_internal
            @ reducedOITildeBreve
            @ orthographyTDQN
            @ longDoubled
            @ orthographyJi
            @ orthographyI
            @ orthographyV
            @ orthographyH
            |> apply)
|> Array.map (apply unmarkWords)
|> String.concat ""



let orthography_v1a = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "Ŋ"); ("h", "ŋ");
  ("X", "H"); ("x", "h");
  ("Y", "J"); ("y", "j");

  ("ʹA", "Ää"); ("ʹa", "ää"); ("A", "Aa"); ("a", "aa");
  ("ʹE", "Ëë"); ("ʹe", "ëë"); ("E", "Ee"); ("e", "ee");
  ("ʹO", "Öö"); ("ʹo", "öö"); ("O", "Oo"); ("o", "oo");
  ("ʹI", "Ï"); ("ʹi", "ï"); ("I", "I"); ("i", "i"); 
  ("ʹU", "Ü"); ("ʹu", "ü"); ("U", "U"); ("u", "u"); 
  ("ʹƏ", "Ä"); ("ʹə", "ä"); ("Ə", "A"); ("ə", "a");
  ("ʹ°", "ë"); ("°", "e");
  ("Ǣ", "Æ"); ("ǣ", "æ");
  ("ʹĪ", "Ïï"); ("ʹī", "ïï"); ("Ī", "Ii"); ("ī", "ii"); 
  ("ʹŪ", "Üü"); ("ʹū", "üü"); ("Ū", "Uu"); ("ū", "uu"); 

  ("-", "")
  ("=", "")
  ]

let orthography_v1b = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "Ŋ"); ("h", "ŋ");
  ("X", "H"); ("x", "h");
  ("Y", "J"); ("y", "j");

  ("ʹA", "Ää"); ("ʹa", "ää"); ("A", "Aa"); ("a", "aa");
  ("E", "Ëë"); ("e", "ëë"); ("ʹËë", "Ee"); ("ʹëë", "ee");
  ("ʹO", "Öö"); ("ʹo", "öö"); ("O", "Oo"); ("o", "oo");
  ("I", "Õ"); ("i", "õ"); ("ʹÕ", "I"); ("ʹõ", "i");
  ("ʹU", "Y"); ("ʹu", "y"); ("U", "U"); ("u", "u"); 
  ("ʹƏ", "Ä"); ("ʹə", "ä"); ("Ə", "A"); ("ə", "a");
  ("ʹ°", "e"); ("°", "ë");
  ("Ǣ", "Æ"); ("ǣ", "æ");
  ("Ī", "Õõ"); ("ī", "õõ"); ("ʹÕõ", "Ii"); ("ʹõõ", "ii");
  ("Ū", "Uu"); ("ū", "uu"); ("ʹUu", "Yy"); ("ʹuu", "yy");

  ("-", "")
  ("=", "")
  ]

let orthography_v1c = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "Ŋ"); ("h", "ŋ");
  ("X", "H"); ("x", "h");
  ("Y", "J"); ("y", "j");

  ("A", "A"); ("a", "a"); ("ʹA", "Ä"); ("ʹa", "ä"); 
  ("E", "Æ"); ("e", "æ"); ("ʹÆ", "E"); ("ʹæ", "e");
  ("O", "O"); ("o", "o"); ("ʹO", "Ö"); ("ʹo", "ö"); 
  ("I", "Õ"); ("i", "õ"); ("ʹÕ", "i"); ("ʹõ", "i");
  ("U", "U"); ("u", "u"); ("ʹU", "Ü"); ("ʹu", "ü");
  ("Ə", "À"); ("ə", "à"); ("ʹÀ", "Ȁ"); ("ʹà", "ȁ");
  ("°", "'");             ("ʹ'", "ë");
  ("Ǣ", "Ää"); ("ǣ", "ä");
  ("Ī", "Õõ"); ("ī", "õõ"); ("ʹÕõ", "Ii"); ("ʹõõ", "ii");
  ("Ū", "Uu"); ("ū", "uu"); ("ʹUu", "Üü"); ("ʹuu", "üü");

  ("-", "")
  ("=", "")
  ]

let orthography_v2a = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "Ŋ"); ("h", "ŋ");
  ("X", "H"); ("x", "h");
  ("Y", "J"); ("y", "j");
  ("W", "V"); ("w", "v");

  ("A", "Á"); ("a", "á"); ("ʹÁ", "A̋"); ("ʹá", "a̋"); 
  ("E", "É"); ("e", "é"); ("ʹÉ", "E̋"); ("ʹé", "e̋");
  ("O", "Ó"); ("o", "ó"); ("ʹÓ", "Ő"); ("ʹó", "ő"); 
  ("I", "I"); ("i", "i"); ("ʹI", "Ï"); ("ʹi", "ï");
  ("U", "U"); ("u", "u"); ("ʹU", "Ü"); ("ʹu", "ü");
  ("Ə", "A"); ("ə", "a"); ("ʹA", "Ä"); ("ʹa", "ä");
  ("ʹ°", "ë"); ("°", "e");
  ("Ǣ", "Æ"); ("ǣ", "æ");
  ("Ī", "Í"); ("ī", "í"); ("ʹÍ", "I̋"); ("ʹí", "i̋");
  ("Ū", "Ú"); ("ū", "ú"); ("ʹÚ", "Ű"); ("ʹú", "ű");

  ("-", "")
  ("=", "")
  ]


let orthography_v2b = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "Ŋ"); ("h", "ŋ");
  ("X", "H"); ("x", "h");
  ("Y", "J"); ("y", "j");

  ("A", "A"); ("a", "a"); ("ʹA", "Ä"); ("ʹa", "ä"); 
  ("E", "È"); ("e", "è"); ("ʹÈ", "E"); ("ʹè", "e");
  ("O", "O"); ("o", "o"); ("ʹO", "Ö"); ("ʹo", "ö"); 
  ("I", "Y"); ("i", "y"); ("ʹY", "I"); ("ʹy", "i");
  ("U", "U"); ("u", "u"); ("ʹU", "Ü"); ("ʹu", "ü");
  ("Ə", "Â"); ("ə", "â"); ("ʹÂ", "Ȁ"); ("ʹâ", "ȁ");
  ("ʹ°", "''"); ("°", "'");
  ("Ǣ", "Æ"); ("ǣ", "æ");
  ("Ī", "Yy"); ("ī", "yy"); ("ʹYy", "Ii"); ("ʹyy", "ii");
  ("Ū", "Uu"); ("ū", "uu"); ("ʹUu", "Üü"); ("ʹuu", "üü");

  ("-", "")
  ("=", "")
  ]

let orthography_v2c = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "Ŋ"); ("h", "ŋ");
  ("X", "H"); ("x", "h");
  ("Y", "J"); ("y", "j");

  ("I", "Y"); ("i", "y"); ("ʹY", "Iy"); ("ʹy", "iy");
  ("A", "A"); ("a", "a"); ("ʹA", "Ia"); ("ʹa", "ia"); 
  ("E", "E"); ("e", "e"); ("ʹE", "Ie"); ("ʹe", "ie");
  ("O", "O"); ("o", "o"); ("ʹO", "Io"); ("ʹo", "io"); 
  ("U", "U"); ("u", "u"); ("ʹU", "Iu"); ("ʹu", "iu");
  ("Ə", "Â"); ("ə", "â"); ("ʹÂ", "Iâ"); ("ʹâ", "iâ");
  ("ʹ°", "i'"); ("°", "'");
  ("Ǣ", "Æ"); ("ǣ", "æ");
  ("Ī", "Yy"); ("ī", "yy"); ("ʹYy", "Iyy"); ("ʹyy", "iyy");
  ("Ū", "Uu"); ("ū", "uu"); ("ʹUu", "Iuu"); ("ʹuu", "iuu");

  ("-", "")
  ("=", "")
  ]

let orthography_v3a = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "Ŋ"); ("h", "ŋ");
  ("X", "H"); ("x", "h");
  ("Y", "J"); ("y", "j");
  ("W", "V"); ("w", "v");

  ("O", "Ó"); ("o", "ó"); ("ʹÓ", "Ő"); ("ʹó", "ő"); //ok
  ("Ə", "O"); ("ə", "o"); ("ʹO", "Ö"); ("ʹo", "ö"); //ok
              ("°", "o");              ("ʹo", "ö"); //ok
  ("A", "A"); ("a", "a"); ("ʹA", "Ä"); ("ʹa", "ä"); //ok
  ("E", "E"); ("e", "e"); ("ʹE", "Ë"); ("ʹe", "ë"); //ok
  ("I", "Y"); ("i", "y"); ("ʹY", "I"); ("ʹy", "i");
  ("U", "U"); ("u", "u"); ("ʹU", "Ü"); ("ʹu", "ü");
  ("Ǣ", "Æ"); ("ǣ", "æ");
  ("Ī", "Yy"); ("ī", "yy"); ("ʹYy", "Ii"); ("ʹyy", "ii");
  ("Ū", "Uu"); ("ū", "uu"); ("ʹUu", "Üü"); ("ʹuu", "üü");

  ("-", "")
  ("=", "")
  ]


let orthography_v3b = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "Ŋ"); ("h", "ŋ");
  ("X", "H"); ("x", "h");
  ("Y", "J"); ("y", "j");
  ("W", "V"); ("w", "v");

  ("E", "Æ"); ("e", "æ"); ("ʹÆ", "É"); ("ʹæ", "é"); // ok
  ("I", "Y"); ("i", "y"); ("ʹY", "I"); ("ʹy", "i"); // ok
  ("Ə", "E"); ("ə", "e"); ("ʹE", "Ë"); ("ʹe", "ë"); // ok
              ("°", "e");              ("ʹe", "ë"); // ok
  ("O", "O"); ("o", "o"); ("ʹO", "Ö"); ("ʹo", "ö"); // ok
  ("A", "A"); ("a", "a"); ("ʹA", "Ä"); ("ʹa", "ä"); // ok
  ("U", "U"); ("u", "u"); ("ʹU", "Ü"); ("ʹu", "ü"); // ok
  ("Ǣ", "Ǽ"); ("ǣ", "ǽ");                         // ok
  ("Ī", "Yy"); ("ī", "yy"); ("ʹYy", "Ii"); ("ʹyy", "ii"); // ok
  ("Ū", "Uu"); ("ū", "uu"); ("ʹUu", "Üü"); ("ʹuu", "üü"); // ok

  ("-", "")
  ("=", "")
  ]

let orthography_v3c = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "Ŋ"); ("h", "ŋ");
  ("X", "H"); ("x", "h");
  ("Y", "J"); ("y", "j");
  ("W", "V"); ("w", "v");

  ("E", "Æ"); ("e", "æ"); ("ʹÆ", "Æ̈"); ("ʹæ", "æ̈"); // ok
  ("I", "Y"); ("i", "y"); ("ʹY", "I"); ("ʹy", "i"); // ok
  ("Ə", "E"); ("ə", "e"); ("ʹE", "Ë"); ("ʹe", "ë"); // ok
              ("°", "e");              ("ʹe", "ë"); // ok
  ("O", "O"); ("o", "o"); ("ʹO", "Ö"); ("ʹo", "ö"); // ok
  ("A", "A"); ("a", "a"); ("ʹA", "Ä"); ("ʹa", "ä"); // ok
  ("U", "U"); ("u", "u"); ("ʹU", "Ü"); ("ʹu", "ü"); // ok
  ("Ǣ", "Ää"); ("ǣ", "ää");                         // ok
  ("Ī", "Yy"); ("ī", "yy"); ("ʹYy", "Ii"); ("ʹyy", "ii"); // ok
  ("Ū", "Uu"); ("ū", "uu"); ("ʹUu", "Üü"); ("ʹuu", "üü"); // ok

  ("-", "")
  ("=", "")
  ]

let orthography_v3cc = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "Ŋ"); ("h", "ŋ");
  ("X", "H"); ("x", "h");
  ("Y", "J"); ("y", "j");
  ("W", "V"); ("w", "v");

  ("E", "Æ"); ("e", "æ"); ("ʹÆ", "Ë"); ("ʹæ", "ë"); // ok
  ("I", "Ï"); ("i", "ï"); ("ʹÏ", "I"); ("ʹï", "i"); // ok
  ("Ə", "E"); ("ə", "e"); ("ʹE", "Æ̈"); ("ʹe", "æ̈"); // ok
              ("ʹ°", "j");             ("°", "");               
  ("O", "O"); ("o", "o"); ("ʹO", "Ö"); ("ʹo", "ö"); // ok
  ("A", "A"); ("a", "a"); ("ʹA", "Ä"); ("ʹa", "ä"); // ok
  ("U", "U"); ("u", "u"); ("ʹU", "Ü"); ("ʹu", "ü"); // ok
  ("Ǣ", "Ee"); ("ǣ", "ee");                         // ok
  ("Ī", "Ïï"); ("ī", "ïï"); ("ʹÏï", "Ii"); ("ʹïï", "ii"); // ok
  ("Ū", "Uu"); ("ū", "uu"); ("ʹUu", "Üü"); ("ʹuu", "üü"); // ok

  ("-", "")
  ("=", "")
  ]

let orthography_v3d = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "Ŋ"); ("h", "ŋ");
  ("X", "H"); ("x", "h");
  ("Y", "J"); ("y", "j");
  ("W", "V"); ("w", "v");

  ("A", "A"); ("a", "a"); ("ʹA", "Ä"); ("ʹa", "ä"); // ok
  ("E", "E"); ("e", "e"); ("ʹE", "Ë"); ("ʹe", "ë"); // ok
  ("I", "Ï"); ("i", "ï"); ("ʹÏ", "I"); ("ʹï", "i"); // ok
  ("Ə", "Å"); ("ə", "å"); ("ʹÅ", "Ȁ"); ("ʹå", "ȁ"); // ok
              ("ʹ°", "'"); ("°", "");              
  ("O", "O"); ("o", "o"); ("ʹO", "Ö"); ("ʹo", "ö"); // ok
  ("U", "U"); ("u", "u"); ("ʹU", "Ü"); ("ʹu", "ü"); // ok
  ("Ǣ", "Ee"); ("ǣ", "ee");                         // ok
  ("Ī", "Ïï"); ("ī", "ïï"); ("ʹÏï", "Ii"); ("ʹïï", "ii"); // ok
  ("Ū", "Uu"); ("ū", "uu"); ("ʹUu", "Üü"); ("ʹuu", "üü"); // ok

  ("-", "")
  ("=", "-")
  ]

let orthography_rus = 
  [
  //абвгдеëжзийклмнопрстуфхцчшщъыьэюя
  //АБВГДЕËЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ
  
  ( "B", "Б")
  ( "W", "В")
  ( "G", "Г")
  ( "D", "Д")
  ( "Z", "З")
  ( "Y", "Й")
  ( "K", "К")
  ( "L", "Л")
  ( "M", "М")
  ( "N", "Н")
  ( "P", "П")
  ( "R", "Р")
  ( "S", "С")
  ( "Y", "Т")
  ( "F", "Ф")
  ( "X", "Х")
  ( "C", "Ц")
  ( "Q", "Ҡ")
  ( "Ŋ", "ҥ");
  ( "b", "б")
  ( "w", "в")
  ( "g", "г")
  ( "d", "д")
  ( "z", "з")
  ( "y", "й")
  ( "k", "к")
  ( "l", "л")
  ( "m", "м")
  ( "n", "н")
  ( "p", "п")
  ( "r", "р")
  ( "s", "с")
  ( "t", "т")
  ( "f", "ф")
  ( "x", "х")
  ( "c", "ц")
  ( "H", "Ҥ");
  ( "h", "ҥ");
  ( "ŋ", "ҥ");
  ( "q", "ҡ")
  

  ("A", "А"); ("a", "а"); ("ʹА", "Я"); ("ʹа", "я"); // ok
  ("E", "Э"); ("e", "э"); ("ʹЭ", "Е"); ("ʹэ", "е"); // ok
  ("I", "Ы"); ("i", "ы"); ("ʹЫ", "И"); ("ʹы", "и"); // ok
  ("Ə", "Ъ"); ("ə", "ъ"); ("ʹЪ", "Ь"); ("ʹъ", "ь"); // ok
              ("ʹ°", "ь"); ("°", "ъ");              
  ("O", "О"); ("o", "о"); ("ʹО", "Ë"); ("ʹо", "ë"); // ok
  ("U", "У"); ("u", "у"); ("ʹУ", "Ю"); ("ʹу", "ю"); // ok
  ("Ǣ", "Ээ"); ("ǣ", "ээ");                         // ok
  ("Ī", "Ыы"); ("ī", "ыы"); ("ʹЫы", "Ии"); ("ʹыы", "ии"); // ok
  ("Ū", "Уу"); ("ū", "уу"); ("ʹУу", "Юю"); ("ʹуу", "юю"); // ok

  ("-", "")
  ("=", "")
  ]


let orthography_v4a = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "Ŋ"); ("h", "ŋ");
  ("X", "H"); ("x", "h");
  ("Y", "J"); ("y", "j");
  ("W", "V"); ("w", "v");

  ("ʹ", "́");
  ("A", "A"); ("a", "a"); 
  ("E", "Æ"); ("e", "æ"); 
  ("I", "I"); ("i", "i"); 
  ("O", "O"); ("o", "o"); 
  ("U", "U"); ("u", "u"); 
  ("Ə", "E"); ("ə", "e"); 
              ("°", "e");  
  ("Ǣ", "Ǽ"); ("ǣ", "ǽ");                      
  ("Ī", "Ii"); ("ī", "ii");
  ("Ū", "Uu"); ("ū", "uu");

  ("-", "")
  ("=", "")
  ]

let removePunctuation =
  [
    ("\"", " ")
    (".", " ")
    (",", " ")
    ("!", " ")
    ("?", " ")
    (":", " ")
    ("”", " ")
    ("“", " ")
    ("\010", " ")
    ("\013", " ")
    ("   ", " ")
    ("  ", " ")
    ("  ", " ")
    ("  ", " ")
    ("  ", " ")
    ("  ", " ")
    ("  ", " ")
    ("  ", " ")
    ("  ", " ")
    ("  ", " ")
    ("  ", " ")
    ("  ", " ")
    ("  ", " ")
  ]

text
|> apply orthography_internal
|> printfn "\n%s\n"

text
|> apply orthography_v1a
|> printfn "\n%s\n"

text
|> apply orthography_v1b
|> printfn "\n%s\n"

text
|> apply orthography_v1c
|> printfn "\n%s\n"

text
|> apply orthography_v2a
|> printfn "\n%s\n"

text
|> apply orthography_v2b
|> printfn "\n%s\n"

text
|> apply orthography_v2c
|> printfn "\n%s\n"


text
|> apply orthography_v3a
|> printfn "\n%s\n"

text
|> apply orthography_v3b
|> printfn "\n%s\n"

text
|> apply orthography_v3c
|> printfn "\n%s\n"

text
|> apply orthography_v3cc
|> printfn "\n%s\n"


text
|> apply orthography_v3d
|> printfn "\n%s\n"


text
|> apply orthography_v4a
|> printfn "\n%s\n"


text
|> apply orthography_rus
|> printfn "\n%s\n"


text
|> apply orthography_salminen
|> printfn "\n%s\n"





// Statistics

text.ToLower()
|> apply orthography_internal
|> apply removePunctuation
|> Seq.countBy id
|> Seq.sortBy snd
|> Seq.toArray
|> Array.iter (fun (a,b) -> printfn "%c;%A" a b)
|> printfn "%A\n"

// most common 2-gramms
text.ToLower()
|> apply orthography_internal
|> apply removePunctuation
|> apply [(" ", "#")]
|> Seq.windowed 2
|> Seq.countBy id
|> Seq.sortBy snd
|> Seq.toArray
|> Array.iter (fun ([|x;y|],b) -> printfn "%c;%c;%A" x y b)

// most common 3-gramms
let _ =
  use streamWriter = new System.IO.StreamWriter(@".\\nenets.3gram.txt")

  text.ToLower()
  |> apply orthography_internal
  |> apply removePunctuation
  |> apply [(" ", "#")]
  |> Seq.windowed 3
  |> Seq.countBy id
  |> Seq.sortBy snd
  |> Seq.toArray
  |> Array.map (fun ([|x;y;z|],b) -> fprintfn streamWriter "%c;%c;%c;%A" x y z b)

  streamWriter.Close()


// most common 4-gramms
let _ =
  use streamWriter = new System.IO.StreamWriter(@".\\nenets.4gram.txt")

  text.ToLower()
  |> apply orthography_internal2
  |> apply removePunctuation
  |> apply [(" ", "#")]
  |> Seq.windowed 4
  |> Seq.countBy id
  |> Seq.sortBy snd
  |> Seq.toArray
  |> Array.map (fun ([|x;y;z;w|],b) -> fprintfn streamWriter "%c;%c;%c;%c;%A" x y z w b)

  streamWriter.Close()



let x = """
"""
x |> Seq.toList
