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

    let ultraShort = "e"
    let ultraShortCap = "E"

    //Vowels - Ultra-Short Palatalized
    ("ʹ°", "j");

    //Palatalisation marker
    ("ʹ", "y")

    //Vowels - Short
    ("i", "i"); ("I", "I");
    ("a", "a"); ("A", "A"); 
    ("e", "ä"); ("E", "Ä"); 
    ("o", "o"); ("O", "O"); 
    ("u", "u"); ("U", "U"); 
    ("ə", ultraShort); ("Ə", ultraShortCap); 

    //Vowels - Ultra-Short Velarized
    ("°", ultraShort);

    //Vowels - Long
    ("ī", "í"); ("Ī", "Í");
    ("ū", "ú"); ("Ū", "Ú"); 
    ("ǣ", "á"); ("Ǣ", "Á"); 
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
    ("q"+ultraShort,"t'")
    ("q","t")
    ]

  let weakEReplacement =
    [ ("°", ultraShort) ]

  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ NgCapsInitialRemoval
  @ NgLowInitialRemoval
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement


let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsMorphologicDigraphical-Y.txt"

inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName
