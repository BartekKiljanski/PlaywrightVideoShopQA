# language: pl

Właściwość: Tworzenie nowego produktu edycja oraz usunięcie przez administratora
  Jako administrator systemu
  Chcę móc tworzyć nowe kategorie
  Aby móc organizować produkty w sklepie
  Założenia: 
    Zakładając, że otwieram stronę logowania do panelu administracyjnego
    Kiedy wybieram opcję Zaloguj
    I wpisuję email administratora
    I wpisuję hasło administratora
    I zatwierdzam formularz logowania
    Wtedy jestem zalogowany do systemu jako administrator

@smoke
Scenariusz: Pomyślne dodanie nowego produktu przez administratora
    Zakładając, że jestem zalogowany jako administrator
    Kiedy wybieram zakładkę Produkty
    I wybieram opcję Utwórz nowy produkt
    I wypełniam formularz danymi produktu
    I wybieram opcję Utwórz produkt
    Wtedy widzę nowy produkt na liście produktów
    


@smoke
Scenariusz: Pomyślne edytowanie istniejącego produktu przez administratora
    Zakładając, że jestem zalogowany jako administrator
    Kiedy wybieram zakładkę Produkty
    I wybieram istniejący produkt do edycji
    I modyfikuję dane w formularzu produktu
    I wybieram opcję Zapisz zmiany
    Wtedy zmodyfikowany produkt zostaje zaktualizowany na liście produktów

    
@smoke
Scenariusz: Pomyślne usunięcie istniejącego produktu przez administratora
    Zakładając, że jestem zalogowany jako administrator
    Kiedy wybieram zakładkę Produkty
    I wybieram istniejący produkt do usunięcia

    I potwierdzam chęć usunięcia produktu
    Wtedy wybrany produkt zostaje usunięty 


