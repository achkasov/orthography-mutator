#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsConsonant-voro.txt"

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

    //Vowels - I, Y
    ("ī", "yy");  ("Ī", "Yy");
    ("ʹyy", "ī"); ("ʹYy", "Ī"); 
    ("jyy", "jī"); ("Jyy", "Jī")

    ("i", "y");  ("I", "Y");
    ("ʹy", "i"); ("ʹY", "I"); 
    ("jy", "ji"); ("Jy", "Ji")

    ("ī", "ii"); ("Ī", "Ii");

    //Consonants - palatalized
    ("bʹ", "b'"); ("Bʹ", "B'"); 
    ("dʹ", "d'"); ("Dʹ", "D'"); 
    ("fʹ", "f'"); ("Fʹ", "F'"); 
    ("hʹ", "h'"); ("Hʹ", "H'"); 
    ("jʹ", "j"); ("Jʹ", "J"); 
    ("kʹ", "k'"); ("Kʹ", "K'"); 
    ("lʹ", "l'"); ("Lʹ", "L'"); 
    ("tʹ", "t'"); ("Tʹ", "T'"); 
    ("cʹ", "c"+combiningAcute); ("Cʹ", "C"+combiningAcute); 
    ("gʹ", "g"+combiningAcute); ("Gʹ", "G"+combiningAcute); 
    ("mʹ", "m"+combiningAcute); ("Mʹ", "M"+combiningAcute); 
    ("nʹ", "n"+combiningAcute); ("Nʹ", "N"+combiningAcute); 
    ("ŋʹ", "ŋ"+combiningAcute); ("Ŋʹ", "Ŋ"+combiningAcute); 
    ("pʹ", "p"+combiningAcute); ("Pʹ", "P"+combiningAcute); 
    ("qʹ", "q"+combiningAcute); ("Qʹ", "Q"+combiningAcute); 
    ("rʹ", "r"+combiningAcute); ("Rʹ", "R"+combiningAcute); 
    ("sʹ", "s"+combiningAcute); ("Sʹ", "S"+combiningAcute); 
    ("vʹ", "v"+combiningAcute); ("Vʹ", "V"+combiningAcute); 
    ("wʹ", "w"+combiningAcute); ("Wʹ", "W"+combiningAcute); 
    ("xʹ", "x"+combiningAcute); ("Xʹ", "X"+combiningAcute); 
    ("zʹ", "z"+combiningAcute); ("Zʹ", "Z"+combiningAcute); 
    
    ("ʹ", "**") //should have no effect


    ("e", "e");  ("E", "E");
    ("ə", "õ");  ("Ə", "Õ"); 
    ("°", "õ");

    ("a", "a");  ("A", "A"); 
    ("o", "o");  ("O", "O"); 
    ("u", "u");  ("U", "U"); 

    let combiningCaron = "\u030C"


    //Vowels - Short

    //Vowels - Long
    ("ū", "uu"); ("Ū", "Uu"); 
    ("ǣ", "aa"); ("Ǣ", "Aa"); 
    ]

  let qFinalReplacement =
    [ ("q#", "q#"); ("qõ#","qõ#")]

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
    ("ŋk", "ŋk")
    ("ŋ", "ŋ")
    ]

  let qMedialdReplacement =
    [
    ("qõ","qõ")
    ("q","q")
    ]

  let weakEReplacement =
    [ ("°", "õ") ]

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


