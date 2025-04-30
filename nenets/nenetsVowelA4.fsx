#load "../lib/mutator.fs"
#load "../lib/utilities.fs"

let orthography = 
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
    ("ʹi", "ï"); ("ʹI", "ï"); ("i", "i"); ("I", "I");
    ("ʹa", "ä"); ("ʹA", "Ä"); ("a", "å"); ("A", "Å"); 
    ("ʹe", "ë"); ("ʹE", "Ë"); ("e", "e"); ("E", "E"); 
    ("ʹo", "ö"); ("ʹO", "Ö"); ("o", "o"); ("O", "O"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 



    //Vowels - Short
    let combiningCaron = "\u030C"
    let combiningAcute = "\u0301"
    ("ʹ°", "j");              ("°", "°");             
    ("ʹə", "æ"); ("ʹƏ", "Æ"); ("ə", "a"); ("Ə", "a"); 

    //Vowels - Long
    ("ʹī", "ïï"); ("ʹĪ", "Ïï"); ("ī", "ii"); ("Ī", "Ii");
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "á"); ("Ǣ", "Á"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ("q°#","t°#")]

  let ngFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aáåäæbcdeëèéȅfghıiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aáåäæbcdeëèéȅfghıiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c))

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ŋ")
    ]

  let qMedialdReplacement =
    [
    ("q°","t'")
    ("q","t")
    ]

  let weakEReplacement =
    [ ("°", "a") ]

  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement

let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsVowelA4.txt"
inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName
