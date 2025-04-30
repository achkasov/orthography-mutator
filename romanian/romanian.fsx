#load "../lib/mutator.fs"

// Example: Romanian

"""Articolul 1
Toate ființele umane se nasc libere și egale în demnitate și în drepturi. 
Ele sînt înzestrate cu rațiune și conștiință și trebuie să se comporte 
unele față de altele în spiritul fraternității.

Articolul 2
Fiecare om se poate prevala de toate drepturile și libertățile proclamate 
în prezenta Declarație fără nici un fel de deosebire ca, de pildă, deosebirea 
de rasă, culoare, sex, limbă, religie, opinie politică sau orice altă opinie, 
de origine națională sau socială, avere, naștere sau orice alte împrejurări.

În afară de aceasta, nu se va face nici o deosebire după statutul politic, 
juridic sau internațional al țării sau al teritoriului de care ține o 
persoană, fie că această țară sau teritoriu sînt independente, sub tutelă, 
neautonome sau supuse vreunei alte limitări a suveranității.

Articolul 3
Orice ființă umană are dreptul la viață, la libertate și la securitatea 
persoanei sale."""
|> Mutator.apply
  [
  ("ă", "æ"); ("Ă", "Æ");
  ("ț", "ç"); ("Ț", "Ç"); ("ţ", "ç"); ("Ţ", "Ç");
  ("â", "ā"); ("Â", "ā");
  ("î", "ī"); ("Î", "ī");
  ("ș", "x"); ("Ș", "X"); ("ş", "x"); ("Ş", "X");
  ]
|> printfn "\n%s\n"