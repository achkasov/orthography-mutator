#load "../lib/mutator.fs"
#load "../lib/utilities.fs"



let orthography = 
    // Creates a list of small and capitalised letters
    let makeLetterList (input: string) = 
        input + input.ToUpper()
        |> Seq.toList
        |> List.map (string)


    let alphabet = makeLetterList "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя"
    let consonants = makeLetterList "бвгґджзйклмнпрстфхцчшщ"
    let vowels = makeLetterList "аеєиіїоуюя"
    let vowelsJotated = makeLetterList "єїюя"
    let reduced = makeLetterList "ь"
        
    let positionalReplacements =
        let preEnvironments = [""]
        let postEnvironments = [""]
        let environment = List.allPairs preEnvironments postEnvironments
        let replaceFrom = [ "є"; "ї"; "юя";]
        let replaceTo   = [ "je"; "jo"; "ju"; "ja";
                            "Je"; "Jo"; "Ju"; "Ja"; ]
        List.zip replaceFrom replaceTo
        |> List.allPairs environment
        |> List.map (fun ((preEnv, postEnv), (a, b)) -> ((preEnv + a + postEnv), (preEnv + b + postEnv)))


    let newConsonants =
        List.zip
            (makeLetterList "бвгґджзйклмнпрстфцчш")
            (makeLetterList "bvhgdžzjklmnprstfcčš")
        |> List.append
            [ ("х", "ch"); ("Х", "Ch");
              ("щ", "šč"); ("Щ", "ŠČ"); ]

    let newVowels =
        List.zip
            (makeLetterList "аеиіоу")
            (makeLetterList "aeyiou")
        |> List.append
            [ ("є",  "je"); ("Є",  "Je");
              ("ї",  "ji"); ("Ї",  "Ji");
              ("ю",  "ju"); ("Ю",  "Ju");
              ("я",  "ja"); ("Я",  "Ja"); 
              ("ьо", "jo"); ("Ьо", "Jo");]         

    let newReduced = [ ("ь", "j"); ("Ь", "J"); ]

    let newApostrophe = [ ("'", "j") ]


    List.concat
        [
            newConsonants
            newVowels
            newReduced
            newApostrophe
        ]


// Execution
let inputFileName = "./ukrainian/text/ukrainian.txt"
let outputFileName = "./ukrainian/text/ukrainianLatinA2.txt"
inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName
()
