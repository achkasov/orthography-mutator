#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./hungarian/text/Hungarian.txt"
let outputFileName = "./hungarian/text/Hungarian-saamic.txt"

let orthography = 
  [
    ("s","š");      ("S","Š"); 
    ("dz", "ʒ");    ("dz", "Ʒ");
    ("dzš","ǯ");    ("Dzš","Ǯ");
    ("šz","s");     ("Šz","S");
    ("cš","č");     ("Cš","Č");
    ("zš","ž");     ("Zš","Ž");

    ("ny","ñ");     ("Ny","Ñ");
    ("ty","ŧ");     ("Ty","Ŧ");
    ("gy","đ");     ("Gy","Đ");
    ("ly","ł");     ("Ly","Ł");

    ("á","aa");     ("Á","Aa");
    ("é","ee");     ("É","Ee");
    ("í","ii");     ("Í","Ii");
    ("ó","oo");     ("Ó","Oo");
    ("ő","öö");     ("Ő","Öö");
    ("ú","uu");     ("Ú","Uu");
    ("ű","yy");     ("Ű","Yy");
    ("ü","y");      ("Ü","Y");
  ]

inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName

