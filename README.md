# Banka

# Korisne poveznice
1. Git - https://www.youtube.com/watch?v=RGOj5yH7evk

# Zadaci 15.10.2023.
Na glavnoj grani (master branch) gdje se nalazi aplikacija sa spremnikom podataka u JSON datotekama osmislite i implementirajte glavni program u kojem će te isprobati rad cjelokupnog sustava. Prilikom pokretanja programa korisniku se prikazuje tekstualni izbornik sa sljedećim opcijama: 
  a) Kreiraj novu fizičku osobu
  b) Uredi fizičku osobu
  c) Ispiši podatke
  d) Rad s računima
  e) Izlaz
Ako korisnik odabere opciju a) program od korisnika traži unos svih potrebnih podataka o fizičkoj osobi kao i informaciju o tome koje račune je potrebno kreirati za tu fizičku osobu. Ako kreacija fizičke osobe prođe bez grešaka, program ispisuje poruku o uspjehu. Ako se pak dogodila pogreška prilikom kreiranja nove fizičke osobe, program ispisuje prikladnu poruku i korisnika vrača u glavni izbornik.
Ako korisnik odabere opciju b) program od korisnika traži unos OIBa osobe čije podatke želi urediti. Ako nije moguće pronaći fizičku osobu s unesenim OIBom program ispisuje prikladnu poruku i korisnika vraća u glavni izbornik. Ako pak postoji osoba s unesenim OIBom program nudi opciju kreiranja ili brisanja tekućeg ili žiro računa, ovisno postoji li taj račun trenutno ili ne. Također se nudi i opcija promjene imena i prezimena. Svaku pogrešku u operacijama prikladno obradite i vratite korisnika u glavni izbornik.
Ako korisnik odabere opciju c) program od korisnika traži unos OIBa osobe čije je podatke potrebno ispisati. Ako nije moguće pronaći osobu s unesenim OIBom, program ispisuje prikladnu poruku i vraća korisnika u glavni izbornik. Ako pak postoji osoba s unesenim OIBom, program ispisuje osnove podatke o korisniku (ime, prezime i OIB).
Ako korisnik odabere opciju d) program od korisnika traži unos OIBa osobe čijim računima želimo pristupiti. Ako nije moguće pronaći osobu s unesenim OIBom, program ispisuje prikladnu poruku i vraća korisnika u glavni izbornik. Ako pak postoji osoba s unesenim OIBom program traži odabir računa nad kojim korisnik želi obaviti određenu operaciju. Kada korisnik odabere račun, program mu nudi opcije uplate, isplate i pregleda stanja računa. Navedene operacije prikladno implementirajte i obradite moguće pogreške.
Opcija e) gasi program te je pritom potrebno sve promjene pospremiti u lokalnu bazu podataka koja se nalazi u JSON datotekama.

# Zadaci 09.10.2023.
1. U sustav je potrebno dodati entitet Nenamjenskog kredita. Određena fizička osoba može imati više nenamjenskih kredita. Odredite skup atributa koji je potreban kako bi se opisao ovaj entitet, kao i skup metoda na njezinom vanjskom sučelju. Enkapsulirajte stvaranje entiteta Nenamjenskog kredita. Prilikom kreiranja kredita potrebno je prvo provjeriti kreditnu sposobnost fizičke osobe. Kreditna sposobnost maksimalni je ukupni mjesečni iznos zaduženja neke fizičke osobe i računa se kao x% mjesečnih primanja gdje banka određuje broj x. Ako novo zaduženje uzrokuje prelazak kreditne sposobnosti fizičkoj osobi se ne može odobriti kredit. Proširite entitet Fizičke osobe tako da posjeduje znanje o tome koje trenutno aktivne kredite osoba ima, kao i funkciju izračunavanja kreditne sposobnosti.

2. Refaktorirajte klasu FizickaOsobaFactory tako da se ovisnost o klasi TekuciRacunFactory i ZiroRacunFactory razriješuje uporabom Dependency Injection patterna.

3. Izdvojite funkcionalnost provjere OIB-a kao i kreacije IBAN-a u zasebnu Utility klasu. Novonastale ovisnosti razriješite uporabom Dependency Injection patterna.

# Zadaci 08.10.2023
1. Uvedite u sustav entitet Žiro računa. Identificirajte skup atributa potreban za opis ovog entiteta kao i za implementaciju operacija uplate i isplate novca na isti. Vanjsko sučelje klase modelirajte u zasebnoj klasi sučelja. Implemetirajte enkapsulirano kreiranje objekata klase žiro račun. Proširite entitet Fizička osoba tako da određena fizička osoba smije imati samo jedan žiro račun. Proširite kreaciju nove fizičke osobe tako da je potrebno specificirati koji od računa je potrebno kreirati zajedno s novom fizičkom osobom.

2. Implementirajte ograničenje u kojem fizička osoba mora imati ili žiro ili tekući račun kako bi mogla postojati u sustavu. Ako se prilikom kreiranja fizičke osobe ne traži kreiranje niti žiro niti tekućeg računa, funckija baca pripadnu iznimku. Identificirajte dio koda u kojem je prikladno uhvatiti i razriješiti navedenu iznimku te taj dio koda prikladno preuredite pomoću try-catch bloka.

