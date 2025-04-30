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
    ("ʹa", "ä"); ("ʹA", "Ä"); ("a", "a"); ("A", "A"); 
    ("ʹe", "ȅ"); ("ʹE", "Ȅ"); ("e", "è"); ("E", "È"); 
    ("ʹo", "ö"); ("ʹO", "Ö"); ("o", "o"); ("O", "O"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 



    //Vowels - Short
    let combiningCaron = "\u030C"
    let combiningAcute = "\u0301"
    ("ʹ°", "j");              ("°", "°");             
    ("ʹə", "ë"); ("ʹƏ", "Ë"); ("ə", "e"); ("Ə", "E"); 

    //Vowels - Long
    ("ʹī", "ïï"); ("ʹĪ", "Ïï"); ("ī", "ii"); ("Ī", "Ii");
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "æ"); ("Ǣ", "Æ"); 
    ]

  let qFinalReplacement =
    [ ("q#", "q#"); ("q°#","q°#")]

  let ngFinalReplacement =
    [ ("ŋ#", "q#"); ]

  let ngMedialdReplacement =
    [
    ("ŋk", "nk")
    ("ŋ", "ŋ")
    ]

  let qMedialdReplacement =
    [
    ("q°","q")
    ("q","q")
    ]

  let weakEReplacement =
    [ ("°", "") ]

  basicsLettersReplacement
  @ qFinalReplacement
  @ ngFinalReplacement
  @ ngMedialdReplacement
  @ qMedialdReplacement
  @ weakEReplacement



let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsVowelA2Phonetic.txt"

inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName
