#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./hungarian/text/Hungarian.txt"
let outputFileName = "./hungarian/text/Hungarian-slovak.txt"

let orthography = 
  [
    ("s","š");      ("S","Š"); 
    ("dzš","dž");   ("Dzš","Dž");
    ("šz","s");     ("Šz","S");
    ("cš","č");     ("Cš","Č");
    ("zš","ž");     ("Zš","Ž");

    ("ny","ň");     ("Ny","Ň");
    ("ty","ť");     ("Ty","Ť");
    ("gy","ď");     ("Gy","Ď");
    ("ly","ľ");     ("Ly","Ľ");
  ]

inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName

