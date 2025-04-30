#load "../lib/mutator.fs"
#load "../lib/utilities.fs"


let orthography = 
    // Creates a list of small and capitalised letters
    let makeLetterList (input: string) = 
        input + input.ToUpper()
        |> Seq.toList
        |> List.map (string)


    let alphabet = makeLetterList "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"
    let consonants = makeLetterList "бвгджзйклмнпрстфхцчшщ"
    let vowels = makeLetterList "аеёиоуыэюя"
    let vowelsJotated = makeLetterList "ёюя"
    let reduced = makeLetterList "ъь"
        
    // Final sibilant+yeri
    let shj =
        let preEnvironments = [""]
        let postEnvironments = ["#"]
        let environment = List.allPairs preEnvironments postEnvironments
        let replaceFrom = [ "шь"; "чь"; ]
        let replaceTo   = [ "š";  "č";  ]
        List.zip replaceFrom replaceTo
        |> List.allPairs environment
        |> List.map (fun ((preEnv, postEnv), (a, b)) -> ((preEnv + a + postEnv), (preEnv + b + postEnv)))  


    let positionalReplacements =
        let preEnvironments = ["#"] @ vowels
        let postEnvironments = [""]
        let environment = List.allPairs preEnvironments postEnvironments
        let replaceFrom = makeLetterList "еёюя"
        let replaceTo = [ "je"; "jo"; "ju"; "ja";
                            "Je"; "Jo"; "Ju"; "Ja"; ]
        List.zip replaceFrom replaceTo
        |> List.allPairs environment
        |> List.map (fun ((preEnv, postEnv), (a, b)) -> ((preEnv + a + postEnv), (preEnv + b + postEnv)))


    let newConsonants =
        List.zip
            (makeLetterList "бвгджзйклмнпрстфцчш")
            (makeLetterList "bvgdžzjklmnprstfcčš")
        |> List.append
            [ ("х", "ch"); ("Х", "Ch");
                ("щ", "šč"); ("Щ", "ŠČ"); ]

    let newVowels =
        List.zip
            (makeLetterList "аиоуыэьъ")
            (makeLetterList "aiouyej'")
        |> List.append
            [ ("е", "e"); ("Е", "E");
              ("ё", "jo"); ("Ё", "Jo");
              ("ю", "ju"); ("Ю", "Ju");
              ("я", "ja"); ("Я", "Ja"); ]            

    let jj = [ ("jj", "'j") ]

    let apostropheECorrection = [ ("'e", "'je") ]

    List.concat
        [
            shj
            positionalReplacements
            newConsonants
            newVowels
            jj
            apostropheECorrection
        ]


// Execution
let inputFileName = "./russian/text/Russian.txt"
let outputFileName = "./russian/text/RussianLatinJ2.txt"
inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName
()
