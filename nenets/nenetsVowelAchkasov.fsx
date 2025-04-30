#load "../lib/mutator.fs"
#load "../lib/utilities.fs"


let orthography = 
    [
    ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
    ("H", "Q̃"); ("h", "q̃");
    ("X", "H"); ("x", "h");
    ("Y", "J"); ("y", "j");

    ("ʹA", "Ä"); ("ʹa", "ä"); ("A", "A"); ("a", "a");
    ("ʹE", "Ë"); ("ʹe", "ë"); ("E", "E"); ("e", "e");
    ("ʹO", "Ö"); ("ʹo", "ö"); ("O", "O"); ("o", "o");
    ("ʹI", "Ï"); ("ʹi", "ï"); ("I", "I"); ("i", "i"); 
    ("ʹU", "Ü"); ("ʹu", "ü"); ("U", "U"); ("u", "u"); 
    ("ʹƏ", "Ə̈"); ("ʹə", "ə̈"); ("Ə", "Ə"); ("ə", "ə");
    ("ʹ°", "ə̈̆"); ("°", "ə̆");
    ("Ǣ", "Á"); ("ǣ", "á");
    ("ʹĪ", "I̋"); ("ʹī", "i̋"); ("Ī", "Í"); ("ī", "í"); 
    ("ʹŪ", "Ű"); ("ʹū", "ű"); ("Ū", "Ú"); ("ū", "ú"); 

    ("-", "")
    ("=", "")
    ]

let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsVowelAchkasov.txt"

inputFileName
|> Utilities.readTextFile 
|> Mutator.apply orthography
|> Utilities.writeTextFile outputFileName
