#load "../lib/mutator.fs"
#load "../lib/utilities.fs"

let orthography = 
    let basicsLettersReplacement =
        [
            // ("bʹ", "bʹ"); //Consonant Palatalised Small
            // ("cʹ", "cʹ"); //Consonant Palatalised Small
            // ("dʹ", "dʹ"); //Consonant Palatalised Small
            // ("fʹ", "fʹ"); //Consonant Palatalised Small
            // ("gʹ", "gʹ"); //Consonant Palatalised Small
            // ("hʹ", "hʹ"); //Consonant Palatalised Small
            // ("jʹ", "jʹ"); //Consonant Palatalised Small
            // ("kʹ", "kʹ"); //Consonant Palatalised Small
            // ("lʹ", "lʹ"); //Consonant Palatalised Small
            // ("mʹ", "mʹ"); //Consonant Palatalised Small
            // ("nʹ", "nʹ"); //Consonant Palatalised Small
            // ("pʹ", "pʹ"); //Consonant Palatalised Small
            // ("qʹ", "qʹ"); //Consonant Palatalised Small
            // ("rʹ", "rʹ"); //Consonant Palatalised Small
            // ("sʹ", "sʹ"); //Consonant Palatalised Small
            // ("tʹ", "tʹ"); //Consonant Palatalised Small
            // ("vʹ", "vʹ"); //Consonant Palatalised Small
            // ("wʹ", "wʹ"); //Consonant Palatalised Small
            // ("xʹ", "xʹ"); //Consonant Palatalised Small
            // ("yʹ", "yʹ"); //Consonant Palatalised Small 
            // ("zʹ", "zʹ"); //Consonant Palatalised Small
            // ("ŋʹ", "ŋʹ"); //Consonant Palatalised Small
            // ("Bʹ", "Bʹ"); //Consonant Palatalised Capital
            // ("Cʹ", "Cʹ"); //Consonant Palatalised Capital
            // ("Dʹ", "Dʹ"); //Consonant Palatalised Capital
            // ("Fʹ", "Fʹ"); //Consonant Palatalised Capital
            // ("Gʹ", "Gʹ"); //Consonant Palatalised Capital
            // ("Hʹ", "Hʹ"); //Consonant Palatalised Capital
            // ("Jʹ", "Jʹ"); //Consonant Palatalised Capital
            // ("Kʹ", "Kʹ"); //Consonant Palatalised Capital
            // ("Lʹ", "Lʹ"); //Consonant Palatalised Capital
            // ("Mʹ", "Mʹ"); //Consonant Palatalised Capital
            // ("Nʹ", "Nʹ"); //Consonant Palatalised Capital
            // ("Pʹ", "Pʹ"); //Consonant Palatalised Capital
            // ("Qʹ", "Qʹ"); //Consonant Palatalised Capital
            // ("Rʹ", "Rʹ"); //Consonant Palatalised Capital
            // ("Sʹ", "Sʹ"); //Consonant Palatalised Capital
            // ("Tʹ", "Tʹ"); //Consonant Palatalised Capital
            // ("Vʹ", "Vʹ"); //Consonant Palatalised Capital
            // ("Wʹ", "Wʹ"); //Consonant Palatalised Capital
            // ("Xʹ", "Xʹ"); //Consonant Palatalised Capital
            // ("Yʹ", "Yʹ"); //Consonant Palatalised Capital
            // ("Zʹ", "Zʹ"); //Consonant Palatalised Capital
            // ("Ŋʹ", "Ŋʹ"); //Consonant Palatalised Capital         

            ("b", "б"); //Consonant Velarised Small
            ("c", "ц"); //Consonant Velarised Small
            ("d", "д"); //Consonant Velarised Small
            ("f", "ф"); //Consonant Velarised Small
            ("g", "г"); //Consonant Velarised Small
            ("h", "ң"); //Consonant Velarised Small
            ("j", "й"); //Consonant Velarised Small
            ("k", "к"); //Consonant Velarised Small
            ("l", "л"); //Consonant Velarised Small
            ("m", "м"); //Consonant Velarised Small
            ("n", "н"); //Consonant Velarised Small
            ("p", "п"); //Consonant Velarised Small
            ("q", "ҭ"); //Consonant Velarised Small
            ("r", "р"); //Consonant Velarised Small
            ("s", "с"); //Consonant Velarised Small
            ("t", "т"); //Consonant Velarised Small
            ("v", "в"); //Consonant Velarised Small
            ("w", "в"); //Consonant Velarised Small
            ("x", "х"); //Consonant Velarised Small
            ("z", "з"); //Consonant Velarised Small
            ("y", "й"); //Consonant Velarised Small
            ("ŋ", "ң"); //Consonant Velarised Small
            ("B", "Б"); //Consonant Velarised Capital
            ("C", "Ц"); //Consonant Velarised Capital
            ("D", "Д"); //Consonant Velarised Capital
            ("F", "Ф"); //Consonant Velarised Capital
            ("G", "Г"); //Consonant Velarised Capital
            ("H", "Ң"); //Consonant Velarised Capital
            ("J", "Й"); //Consonant Velarised Capital
            ("K", "К"); //Consonant Velarised Capital
            ("L", "Л"); //Consonant Velarised Capital
            ("M", "М"); //Consonant Velarised Capital
            ("N", "Н"); //Consonant Velarised Capital
            ("P", "П"); //Consonant Velarised Capital
            ("Q", "Ҭ"); //Consonant Velarised Capital
            ("R", "Р"); //Consonant Velarised Capital
            ("S", "С"); //Consonant Velarised Capital
            ("T", "Т"); //Consonant Velarised Capital
            ("V", "В"); //Consonant Velarised Capital
            ("W", "В"); //Consonant Velarised Capital
            ("X", "Х"); //Consonant Velarised Capital
            ("Y", "Й"); //Consonant Velarised Capital
            ("Z", "З"); //Consonant Velarised Capital
            ("Ŋ", "Ң"); //Consonant Velarised Capital

            ("ʹa", "я"); //Vowel Palatalised Small
            ("ʹe", "е"); //Vowel Palatalised Small
            ("ʹi", "и"); //Vowel Palatalised Small
            ("ʹo", "ё"); //Vowel Palatalised Small
            ("ʹu", "ю"); //Vowel Palatalised Small
            ("ʹǣ", "**ʹǣ**"); //Vowel Palatalised Small - Does not exist
            ("ʹī", "ӣ"); //Vowel Palatalised Small
            ("ʹū", "ю̄"); //Vowel Palatalised Small
            ("ʹə", "ь"); //Vowel Palatalised Small
            ("ʹ°", "ь"); //Vowel Palatalised Small
            ("ʹA", "Я"); //Vowel Palatalised Capital
            ("ʹE", "Е"); //Vowel Palatalised Capital
            ("ʹI", "И"); //Vowel Palatalised Capital
            ("ʹO", "О"); //Vowel Palatalised Capital
            ("ʹU", "Ю"); //Vowel Palatalised Capital
            ("ʹǢ", "Э̄"); //Vowel Palatalised Capital
            ("ʹĪ", "Ӣ"); //Vowel Palatalised Capital
            ("ʹŪ", "Ю̄"); //Vowel Palatalised Capital
            ("ʹƏ", "Ь"); //Vowel Palatalised Capital 

            ("a", "а"); //Vowel Velarised Small
            ("e", "э"); //Vowel Velarised Small
            ("i", "ы"); //Vowel Velarised Small
            ("o", "о"); //Vowel Velarised Small
            ("u", "у"); //Vowel Velarised Small
            ("ǣ", "э̄"); //Vowel Velarised Small
            ("ī", "ы̄"); //Vowel Velarised Small
            ("ū", "ӯ"); //Vowel Velarised Small
            ("ə", "ъ"); //Vowel Velarised Small
            ("°", "ъ"); //Vowel Velarised Small
            ("A", "А"); //Vowel Velarised Capital
            ("E", "Э"); //Vowel Velarised Capital
            ("I", "И"); //Vowel Velarised Capital
            ("O", "О"); //Vowel Velarised Capital
            ("U", "У"); //Vowel Velarised Capital
            ("Ǣ", "Э̄"); //Vowel Velarised Capital
            ("Ī", "Ы̄"); //Vowel Velarised Capital
            ("Ū", "Ӯ"); //Vowel Velarised Capital
            ("Ə", "Ъ"); //Vowel Velarised Capital

            // ("#йа","я")
            // ("#йэ","e")
            // ("#йы","и")
            // ("#йо","ё")
            // ("#йу","ю")
            // ("#йъ","ь")
            // ("#йэ̄","*")
            // ("#йы̄","ӣ")
            // ("#йӯ","ю̄")

            // ("#Йа","Я")
            // ("#Йэ","Е")
            // ("#Йы","И")
            // ("#Йо","Ё")
            // ("#Йу","Ю")
            // ("#Йъ","Ь")
            // ("#Йэ̄","*")
            // ("#Йы̄","Ӣ")
            // ("#Йӯ","Ю̄")

        ]

    let morphemeMarks =
        [    //Morpheme markers
            ("-", "")
            ("=", "-")
        ]
    morphemeMarks
    @ basicsLettersReplacement


let inputFileName = "./nenets/text/TundraNenets.txt"
let outputFileName = "./nenets/text/TundraNenetsCyrillicMorphological1.txt"
inputFileName
|> Utilities.readTextFile 
|> Mutator.applyPerWord orthography
|> Utilities.writeTextFile outputFileName

