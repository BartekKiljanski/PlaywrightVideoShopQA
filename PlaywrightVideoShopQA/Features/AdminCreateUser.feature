# language: pl

Właściwość: Tworzenie nowego konta przez administratora
  Jako administrator systemu
  Chcę móc tworzyć nowe firmy
  Aby móc zarządzać nimi w systemie
  
    

@smoke
Scenariusz: Pomyślne dodanie nowego konta przez administratora
Zakładając, że otwieram stronę logowania do panelu administracyjnego
    Kiedy wybieram opcję Zaloguj
    I wpisuję email administratora
    I wpisuję hasło administratora
    I zatwierdzam formularz logowania
    
    Zakładając, że jestem zalogowany jako administrator
    Kiedy wybieram zakładkę Utwórz użytkownika
    I wypełniam formularz danymi nowego konta
    I wybieram opcję Rejestruj
    Wtedy nowe konto zostaje dodane 
    


@smoke
Scenariusz: Pomyślne logowanie na nowo utworzone konto przez administratora
    Zakładając, że otwieram stronę logowania do aplikacji
  
    Kiedy wybieram opcję Zaloguj
    I wpisuję email utworzonego konta
    I wpisuję hasło utworzonego konta
    I zatwierdzam formularz logowania
    Wtedy jestem zalogowany do systemu jako nowy użytkownik

    
