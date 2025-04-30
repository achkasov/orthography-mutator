#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsVowelA5.txt"

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
    ("ʹa", "ää"); ("ʹA", "Ää"); ("a", "aa"); ("A", "Aa"); 
    ("ʹe", "ë"); ("ʹE", "Ë"); ("e", "e"); ("E", "E"); 
    ("ʹo", "ö"); ("ʹO", "Ö"); ("o", "o"); ("O", "O"); 
    ("ʹu", "ü"); ("ʹU", "Ü"); ("u", "u"); ("U", "U"); 



    //Vowels - Short
    let combiningCaron = "\u030C"
    let combiningAcute = "\u0301"
    ("ʹ°", "ä");              ("°", "°");             
    ("ʹə", "ä"); ("ʹƏ", "Ä"); ("ə", "a"); ("Ə", "A"); 

    //Vowels - Long
    ("ʹī", "ïï"); ("ʹĪ", "Ïï"); ("ī", "ii"); ("Ī", "Ii");
    ("ʹū", "üü"); ("ʹŪ", "Üü"); ("ū", "uu"); ("Ū", "Uu"); 
                                ("ǣ", "æ"); ("Ǣ", "Æ"); 
    ]

  let qFinalReplacement =
    [ ("q#", "t#"); ("q°#","t'°#")]

  let engFinalReplacement =
    [ ("ŋ#", "n#"); ]

  let qMedialdReplacement =
    [
    ("q°","t'°")
    ("q","t")
    ]

  let weakEReplacement =
    [ ("°", "e") ]

  basicsLettersReplacement
  @ qFinalReplacement
  @ engFinalReplacement
  @ qMedialdReplacement
  @ weakEReplacement

// let main _ =
inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName
    // ()
