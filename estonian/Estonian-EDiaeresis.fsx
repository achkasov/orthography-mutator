#load "../lib/mutator.fs"
#load "../lib/utilities.fs"
let inputFileName = "./estonian/text/Estonian.txt"
let outputFileName = "./estonian/text/Estonian-EDiaeresis.txt"

let orthography = 
  [
    ("õ","ë")
    ("Õ","Ë")
  ]

inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName

