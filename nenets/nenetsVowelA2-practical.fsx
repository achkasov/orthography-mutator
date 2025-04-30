#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsVowelA2-practical.txt"

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
    ("ʹa", "ä"); ("ʹA", "Ä"); ("a", "a"); ("A", "A"); 
    ("ʹe", "é"); ("ʹE", "É"); ("e", "è"); ("E", "È"); 
    ("ʹo", "ö"); ("ʹO", "Ö"); ("o", "o"); ("O", "O"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 
    ("i", "y"); ("I", "Y"); ("ʹy", "i"); ("ʹY", "I");



    //Vowels - Short
    let combiningCaron = "\u030C"
    let combiningAcute = "\u0301"
    ("ʹ°", "ë");              ("°", "°");             
    ("ʹə", "ë"); ("ʹƏ", "Ë"); ("ə", "e"); ("Ə", "E"); 

    //Vowels - Long
    ("ī", "yy"); ("Ī", "Yy"); ("ʹyy", "ii"); ("ʹYy", "Ii"); 
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "aa"); ("Ǣ", "Aa"); 

    ("jyy","jii"); ("Jyy","Jii")
    ("jy","ji"); ("Jy","Ji")
    ("jè","jé"); ("Jè","Jé"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ("q°#","t'°#")]

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
    ("ŋ", "nn")
    ]

  let qMedialdReplacement =
    [
    ("q°","t'°")
    ("q","t")
    ]

  let weakEReplacement =
    [ ("°", "e") ]

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
