#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./albanian/text/Albanian.txt"
let outputFileName = "./albanian/text/Albanian-Caron.txt"

let orthography = 
  [
    ("xh", "dž"); ("Xh", "Dž"); ("XH", "DŽ");
    ("sh", "š"); ("Sh", "Š"); ("SH", "Š");
    ("zh", "ž"); ("Zh", "Ž"); ("ZH", "Ž");
    ("e", "ě"); ("E", "Ě");
    ("ë", "e"); ("Ë", "E"); 
    ("ç", "č"); ("Ç", "Č");
    ("x", "dz"); ("X", "Dz");
    ("q", "ć"); ("Q", "Ć");

    
    ("ll", "ł"); ("Ll", "Ł"); ("LL", "Ł"); 
    ("l", "lj"); ("L", "Lj");
    ("ł","l"); ("Ł","L");

  ]

inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName
