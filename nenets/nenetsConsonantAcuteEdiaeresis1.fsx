#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsConsonantAcuteEdiaeresis1.txt"

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

    let combiningAcute = "\u0301"

    //Vowels - Basics
    ("ʹ", combiningAcute)

    ("i", "i");  ("I", "I");
    ("a", "a");  ("A", "A"); 
    ("e", "e");  ("E", "E"); 
    ("o", "o");  ("O", "O"); 
    ("u", "u");  ("U", "U"); 
    ("ə", "ë");  ("Ə", "Ë"); 
    ("°", "ë");

    let combiningCaron = "\u030C"


    //Vowels - Short

    //Vowels - Long
    ("ī", "ii"); ("Ī", "Ii");
    ("ū", "uu"); ("Ū", "Uu"); 
    ("ǣ", "aa"); ("Ǣ", "Aa"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ("q°#","t°#")]

  let ngFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéȅfghıiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéȅfghıiïjklmnŋoöpqrstuüvwxyÿz°'"
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
    ("q°","'°")
    ("q","t")
    ]

  let weakEReplacement =
    [ ("°", "ë") ]

  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement


inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName
