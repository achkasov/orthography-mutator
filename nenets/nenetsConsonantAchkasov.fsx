#load "../lib/mutator.fs"
#load "../lib/utilities.fs"

let orthography = 
    [
    ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
    ("H", "Q̃"); ("h", "q̃");
    ("X", "H"); ("x", "h");
    ("Y", "J"); ("y", "j");
    

    let combiningCedilla = "\u0327"
    let combiningDotBelow = "\u0323"
    ("ʹ", combiningDotBelow); 

    ("A", "A"); ("a", "a");
    ("E", "E"); ("e", "e");
    ("O", "O"); ("o", "o");
    ("I", "I"); ("i", "i"); 
    ("U", "U"); ("u", "u"); 
    ("Ə", "Ə"); ("ə", "ə");
    ("°", "ə̆");
    ("Ǣ", "Á"); ("ǣ", "á");
    ("Ī", "Í"); ("ī", "í"); 
    ("Ū", "Ú"); ("ū", "ú"); 

    ("-", "")
    ("=", "")
    ]

let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsConsonantAchkasov.txt"

inputFileName
|> Utilities.readTextFile 
|> Mutator.apply orthography
|> Utilities.writeTextFile outputFileName
