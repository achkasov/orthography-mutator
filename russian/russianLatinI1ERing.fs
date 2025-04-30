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
    let combiningDiaeresis = "\u0308"
    let combiningRingAbove = "\u030A"
    let yo = "e" + combiningRingAbove

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

    let positionalReplacements0 =
        let preEnvironments = consonants
        let postEnvironments = makeLetterList "ауыэ"
        let environment = List.allPairs preEnvironments postEnvironments
        let replaceFrom = makeLetterList "и"
        let replaceTo = makeLetterList "ï"
        List.zip replaceFrom replaceTo
        |> List.allPairs environment
        |> List.map (fun ((preEnv, postEnv), (a, b)) -> ((preEnv + a + postEnv), (preEnv + b + postEnv)))

    let positionalReplacements1 =
        let preEnvironments = ["#"] @ vowels
        let postEnvironments = [""]
        let environment = List.allPairs preEnvironments postEnvironments
        let replaceFrom = makeLetterList "еёюя"
        let replaceTo = [ "je"; "j"+yo; "ju"; "ja";
                          "Je"; "J"+yo; "Ju"; "Ja"; ]
        List.zip replaceFrom replaceTo
        |> List.allPairs environment
        |> List.map (fun ((preEnv, postEnv), (a, b)) -> ((preEnv + a + postEnv), (preEnv + b + postEnv)))


    let positionalReplacements2 =
        let preEnvironments = reduced
        let postEnvironments = [""]
        let environment = List.allPairs preEnvironments postEnvironments
        let replaceFrom = makeLetterList "еёюя"
        let replaceTo = [ "je"; "j"+yo; "ju"; "ja";
                          "Je"; "J"+yo; "Ju"; "Ja"; ]
        List.zip replaceFrom replaceTo
        |> List.allPairs environment
        |> List.map (fun ((preEnv, postEnv), (a, b)) -> ((preEnv + a + postEnv), (b + postEnv)))

    let newConsonants =
        List.zip
            (makeLetterList "бвгджзйклмнпрстфцчш")
            (makeLetterList "bvgdžzjklmnprstfcčš")
        |> List.append
            [ ("х", "ch"); ("Х", "Ch");
                ("щ", "šč"); ("Щ", "ŠČ"); ]

    let newVowels =
        List.zip
            (makeLetterList "аиоуыэ")
            (makeLetterList "aiouye")
        |> List.append
            [ ("е", "e"); ("Е", "E");
              ("ё", yo); ("Ё", "J"+yo);
              ("ю", "iu"); ("Ю", "Ju");
              ("я", "ia"); ("Я", "Ja"); ]            

    let newReduced =
        List.zip
            (makeLetterList "ъь")
            (makeLetterList "jj")

    List.concat
        [
            shj
            positionalReplacements0
            positionalReplacements1
            positionalReplacements2
            newConsonants
            newVowels
            newReduced
        ]


// Execution
let inputFileName = "./russian/text/Russian.txt"
let outputFileName = "./russian/text/RussianLatinI1ERing.txt"
inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName
()
