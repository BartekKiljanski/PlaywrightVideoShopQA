# language: pl

Właściwość: Założenie konta przez użytkownika
  Jako administrator systemu
  Chcę móc tworzyć nowe kategorie
  Aby móc organizować kategorii w sklepie

   

@smoke

Scenariusz: Pomyślne dodanie zarejestrowanie użytkownika
    Zakładając, że przechodzę na stronę aplikacji 
    Kiedy wybieram zakładkę Zarejestruj
    I Uzupełniam formularz danymi 
    I Wybieram opcję Rejestruj
    Wtedy jesteśmy zalogowani 
    
     

Scenariusz: Pomyślne zamówienie filmu przez użytkownika
    Zakładając, że otwieram stronę logowania do panelu administracyjnego
     Kiedy wybieram opcję Zaloguj
    I wpisuję email użytkownika
    I wpisuję hasło użytkownika
    I zatwierdzam formularz logowania
    Wtedy jestem zalogowany do systemu 
    I wybieram szczegóły wybranego filmu
    I wybieram ilość produktów
    I dodaje do koszyka
    Wtedy przechodzę do koszyka
    I wybieram podsumowanie
    I składam zamówienie
    I podaje danę do karty
    I wybieram opcję Zapłać
    Wtedy Zamówienie zostanie pomyślnie złożone
   

