#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsConsonantI4-ogonek.txt"

let orthography = 
  let combiningOgonek = "\u0328"
  let combiningAcute = "\u0301"
  let combiningCaron = "\u030C"
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
    ("ī", "ïï");  ("Ī", "Ïï");
    ("ʹïï", "ī"); ("ʹÏï", "Ī"); 
    ("jïï", "jī"); ("Jïï", "Jī")

    ("i", "ï");  ("I", "Ï");
    ("ʹï", "i"); ("ʹÏ", "I"); 
    ("jï", "ji"); ("Jï", "Ji")


    ("ʹ", "i")


    ("e", "e");  ("E", "E");
    ("ə", "ë");  ("Ə", "Ë"); 
    ("°", "ë");

    ("a", "a");  ("A", "A"); 
    ("o", "o");  ("O", "O"); 
    ("u", "u");  ("U", "U"); 
    ("iu", "ü");  ("Iu", "Ü"); 



    //Vowels - Short

    //Vowels - Long
    ("ī", "ii"); ("Ī", "Ii");
    ("iū", "üü"); ("Iū", "Üü");
    ("ū", "uu"); ("Ū", "Uu");
    ("ǣ", "aa"); ("Ǣ", "Aa"); 
    ]

  let qFinalReplacement =
    [ ("q#", combiningOgonek+"#"); ("që#",combiningOgonek+"ë#")]

  let combiningTilde = "\u0303"
  let ngFinalReplacement =
    [ ("ŋ#", combiningOgonek+"#"); ]

  let NgCapsInitialRemoval =
    let capitalNg = "Ŋ"
    let letters = "aäæbcdeëèéȅfghıiïjklmnŋoõöpqrstuüvwxyÿz°'"
    letters
    |> Seq.toList
    |> List.map string
    |> List.map (fun c -> ("#"+ capitalNg+c, "#"+c.ToUpper()))

  let NgLowInitialRemoval =
    let lowerNg = "ŋ"
    let letters = "aäæbcdeëèéȅfghıiïjklmnŋoõöpqrstuüvwxyÿz°'"
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
    ("që",combiningOgonek+"ë")
    ("q",combiningOgonek)
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


