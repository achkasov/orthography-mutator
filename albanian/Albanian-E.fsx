#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./albanian/text/Albanian.txt"
let outputFileName = "./albanian/text/Albanian-E.txt"

let orthography = 
  [
    ("e", "è"); ("E", "È");
    ("ë", "e"); ("Ë", "E"); 
  ]

inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName
