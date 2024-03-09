# language: pl

Właściwość: Tworzenie nowej kategorii edycja oraz usunięcie przez administratora
  Jako administrator systemu
  Chcę móc tworzyć nowe kategorie
  Aby móc organizować kategorii w sklepie
  Założenia: 
    Zakładając, że otwieram stronę logowania do panelu administracyjnego
    Kiedy wybieram opcję Zaloguj
    I wpisuję email administratora
    I wpisuję hasło administratora
    I zatwierdzam formularz logowania
    Wtedy jestem zalogowany do systemu jako administrator

@smoke
Scenariusz: Pomyślne dodanie nowej kategorii przez administratora
    Zakładając, że jestem zalogowany jako administrator
    Kiedy wybieram zakładkę Kategoria
    I wybieram opcję Utwórz nową kategorię
    I wypełniam formularz danymi
    I wybieram opcję Utwórz
    Wtedy nowa kategoria zostaje dodana 


@smoke
Scenariusz: Pomyślne edytowanie istniejącej kategorii przez administratora
    Zakładając, że jestem zalogowany jako administrator
    Kiedy wybieram zakładkę Kategoria
    I wybieram istniejącą kategorię do edycji
    I modyfikuję dane w formularzu
    I wybieram opcję Edytuj
    Wtedy zmodyfikowana kategoria zostaje zaktualizowana 
    
@smoke
Scenariusz: Pomyślne usunięcie istniejącej kategorii przez administratora
    Zakładając, że jestem zalogowany jako administrator
    Kiedy wybieram zakładkę Kategoria
    I wybieram istniejącą kategorię do usunięcia
    I klikam przycisk Usuń

    Wtedy wybrana kategoria zostaje usunięta 


