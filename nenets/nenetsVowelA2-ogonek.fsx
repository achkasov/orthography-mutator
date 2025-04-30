#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsVowelA2-ogonek.txt"

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
    ("ʹa", "ä"); ("ʹA", "Ä"); ("a", "a"); ("A", "A"); 
    ("ʹe", "ȅ"); ("ʹE", "Ȅ"); ("e", "è"); ("E", "È"); 
    ("ʹo", "ö"); ("ʹO", "Ö"); ("o", "o"); ("O", "O"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 



    //Vowels - Short
    let combiningCaron = "\u030C"
    let combiningAcute = "\u0301"
    ("ʹ°", "ë");              ("°", "°");             
    ("ʹə", "ë"); ("ʹƏ", "Ë"); ("ə", "e"); ("Ə", "E"); 

    //Vowels - Long
    ("ʹī", "ïï"); ("ʹĪ", "Ïï"); ("ī", "ii"); ("Ī", "Ii");
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "aa"); ("Ǣ", "Aa"); 
    ]

  let combiningOgonek = "\u0328"
  let combiningBreve = "\u0306"

  let ngFinalReplacement =
    [ ("ŋ#", combiningOgonek+"#"); ]

  let NgCapsInitialReplacement =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéȅfghıiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()+combiningOgonek))

  let NgLowInitialReplacement =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéȅfghıiïjklmnŋoöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+lowerNg+c, "#"+c+combiningOgonek))

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", combiningOgonek)
    ]

  let weakEReplacement =
    [ ("°", "e") ]

  basicsLettersReplacement
  @ ngFinalReplacement
  @ NgCapsInitialReplacement
  @ NgLowInitialReplacement
  @ ngMedialdReplacement
  @ weakEReplacement


inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName
