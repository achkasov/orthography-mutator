#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsSalminen.txt"

let orthographySalminen = 
  [
  ("Ŋ", "Ŋ"); ("ŋ", "ŋ");
  ("H", "H"); ("h", "h");
  ("X", "X"); ("x", "x");
  ("Y", "Ÿ"); ("y", "ÿ");

  ("ʹA", "Ya"); ("ʹa", "ya"); ("A", "A"); ("a", "a");
  ("ʹE", "Ye"); ("ʹe", "ye"); ("E", "E"); ("e", "e");
  ("ʹO", "Yo"); ("ʹo", "yo"); ("O", "O"); ("o", "o");
  ("ʹI", "Yi"); ("ʹi", "yi"); ("I", "I"); ("i", "i"); 
  ("ʹU", "Yu"); ("ʹu", "yu"); ("U", "U"); ("u", "u"); 
  ("ʹƏ", "Yə"); ("ʹə", "yə"); ("Ə", "Ə"); ("ə", "ə");
  ("ʹ°", "y°"); ("°", "°");
  ("Ǣ", "Æ"); ("ǣ", "æ");
  ("ʹĪ", "Yí"); ("ʹī", "yí"); ("Ī", "Í"); ("ī", "í"); 
  ("ʹŪ", "Yú"); ("ʹū", "yú"); ("Ū", "Ú"); ("ū", "ú"); 

  ("-", "")
  ("=", "")
  ]

inputFileName
|> Utilities.readTextFile 
|> Mutator.apply orthographySalminen
|> Utilities.writeTextFile outputFileName
