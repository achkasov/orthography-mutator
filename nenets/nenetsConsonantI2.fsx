#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsConsonantI2.txt"

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

    ("a", "ä");  ("A", "Ä"); 
    ("ə", "a");  ("Ə", "A"); 
    ("°", "a");

    ("e", "e");  ("E", "E");
    ("o", "o");  ("O", "O"); 
    ("u", "u");  ("U", "U"); 

    let combiningCaron = "\u030C"


    //Vowels - Short

    //Vowels - Long
    ("ī", "ii"); ("Ī", "Ii");
    ("ū", "uu"); ("Ū", "Uu"); 
    ("ǣ", "ää"); ("Ǣ", "Ää"); 
    ]

  let qFinalReplacement =
    [ ("q#", "q#"); ("q°#","q°#")]

  let combiningTilde = "\u0303"

  let ngFinalReplacement =
    [ ("ŋ#", combiningTilde+"#"); ]

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
    [ ("°", "a") ]

  basicsLettersReplacement
  @ qFinalReplacement
  // @ ngFinalReplacement
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement


inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName


