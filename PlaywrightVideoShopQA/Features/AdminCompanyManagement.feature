# language: pl

Właściwość: Tworzenie nowej firmy oraz jej edycja oraz usunięcie przez administratora
  Jako administrator systemu
  Chcę móc tworzyć nowe firmy
  Aby móc zarządzać nimi w systemie
  Założenia: 
    Zakładając, że otwieram stronę logowania do panelu administracyjnego
    Kiedy wybieram opcję Zaloguj
    I wpisuję email administratora
    I wpisuję hasło administratora
    I zatwierdzam formularz logowania
    Wtedy jestem zalogowany do systemu jako administrator

@smoke
Scenariusz: Pomyślne dodanie nowej firmy przez administratora
    Zakładając, że jestem zalogowany jako administrator
    Kiedy wybieram zakładkę Firmy
    I wybieram opcję Utwórz nową firmę
    I wypełniam formularz danymi firmy
    I wybieram opcję Utwórz firmę
    Wtedy nowa firma zostaje dodana



@smoke
Scenariusz: Pomyślne edytowanie istniejącej firmy przez administratora
    Zakładając, że jestem zalogowany jako administrator
    Kiedy wybieram zakładkę Firmy
    I wybieram istniejącą firmę do edycji
    I modyfikuję dane w formularzu firmy
    I wybieram opcję Zapisz zmiany
    Wtedy zmodyfikowana firma zostaje zaktualizowana

    
@smoke
Scenariusz: Pomyślne usunięcie istniejącej firmy przez administratora
    Zakładając, że jestem zalogowany jako administrator
    Kiedy wybieram zakładkę Firmy
    I wybieram istniejącą firmę do usunięcia

    I potwierdzam chęć usunięcia firmy
    Wtedy wybrana firma zostaje usunięta 
