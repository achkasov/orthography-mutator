#load "mutator.fs"
open Mutator

// Albanian

"""Neni 1.
Të gjithë njerëzit lindin të lirë dhe të barabartë në dinjitet dhe në të drejta.
Ata kanë arsye dhe ndërgjegje dhe duhet të sillen ndaj njëri tjetrit me frymë 
vëllazërimi.

Neni 2.
Secili gëzon të gjitha të drejtat dhe liritë e parashtruara në këtë Deklaratë pa
kurrfarë kufizimesh përsa i përket racës, ngjyrës, gjinisë, gjuhës, besimit 
fetar, mendimit politik ose tjetër, origjinës kombëtare a shoqërore, pasurisë, 
lindjes ose tjetër.

Asnjë dallim nuk do të bëhet në bazë të statusit politik, juridik ose 
ndërkombëtar të shtetit ose vendit të cilit i përket çdo njeri, qoftë kur shteti
ose vendi është i pavarur, qoftë nën kujdestari, qoftë jo vetëqeverisës ose që 
gjindet në çfarëdo kushtesh të tjera të kufizimit të sovranitetit."""
|> replace
  [
  ("xh", "dž"); ("Xh", "Dž"); ("XH", "DŽ");
  ("sh", "š"); ("Sh", "Š"); ("SH", "Š");
  ("zh", "ž"); ("Zh", "Ž"); ("ZH", "Ž");
  ("nj", "ň"); ("NJ", "Ň"); ("Nj", "Ň");
  ("e", "ě"); ("E", "Ě");
  ("ë", "e"); ("Ë", "E"); 
  ("ç", "č"); ("Ç", "Č");
  ("x", "dz"); ("X", "Dz");
  ("q", "kj"); ("Q", "Kj");
  ("dh", "ð"); ("Dh", "Ð"); ("DH", "Ð");
  ("th", "þ"); ("Th", "Þ"); ("TH", "Þ");
  ]
|> printfn "\n%s\n"

