#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsConsonantY1.txt"

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
    ("ʹ", "y")

    ("i", "i");  ("I", "I");
    ("a", "a");  ("A", "A"); 
    ("e", "ä");  ("E", "Ä"); 
    ("o", "o");  ("O", "O"); 
    ("u", "u");  ("U", "U"); 
    ("ə", "e");  ("Ə", "E"); 
    ("°", "e");

    let combiningCaron = "\u030C"


    //Vowels - Short

    //Vowels - Long
    ("ī", "ii"); ("Ī", "Ii");
    ("ū", "uu"); ("Ū", "Uu"); 
    ("ǣ", "aa"); ("Ǣ", "Aa"); 
    ]

  let qFinalReplacement =
    [ ("q#", "q#"); ("q°#","q°#")]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ŋ")
    ]

  let qMedialdReplacement =
    [
    ("q°","q°")
    ("q","q")
    ]

  let weakEReplacement =
    [ ("°", "e") ]

  basicsLettersReplacement
  @ qFinalReplacement
  // @ ngFinalReplacement
  // @ NgCapsInitialReplacement
  // @ NgLowInitialReplacement
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement

inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName

