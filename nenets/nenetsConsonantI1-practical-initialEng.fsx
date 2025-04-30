#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsConsonantI1-practical-initialEng.txt"

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
    ("ī", "yy");  ("Ī", "Yy");
    ("ʹyy", "ī"); ("ʹYy", "Ī"); 
    ("jyy", "jī"); ("Jyy", "Jī")

    ("i", "y");  ("I", "Y");
    ("ʹy", "i"); ("ʹY", "I"); 
    ("jy", "ji"); ("Jy", "Ji")


    ("ʹ", "i")


    ("e", "ä");  ("E", "Ä");
    ("ə", "e");  ("Ə", "E"); 
    ("°", "e");

    ("a", "a");  ("A", "A"); 
    ("o", "o");  ("O", "O"); 
    ("u", "u");  ("U", "U"); 

    let combiningCaron = "\u030C"


    //Vowels - Short

    //Vowels - Long
    ("ī", "ii"); ("Ī", "Ii");
    ("ū", "uu"); ("Ū", "Uu"); 
    ("ǣ", "aa"); ("Ǣ", "Aa"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ("qe#","t'e#")]

  let combiningTilde = "\u0303"
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
    ("qe","t'e")
    ("q","t")
    ]

  let weakEReplacement =
    [ ("°", "e") ]

  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  //@ NgCapsInitialRemoval
  //@ NgLowInitialRemoval
  //@ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement

inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName


