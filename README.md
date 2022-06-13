# MSUnitLabb1
Labb1

Koden finns i BankClass, och test i LoginTest.

## Test 1 Change Password
Testar om man kan byta lösenord, måste ha minst 8 karaktärer med både bokstäver och siffror. Väldigt simpel och funkar som den ska.
Den har inte en funktion som ser till att man inte ska byta lösen till den man hade tidigare. Ingen try-catch.

## Test 2 Create Savings Account
Testar om man kan skapa ett konto med samma namn eller utan namn, vilket går.
Det ska finnas en if-sats som gör att den inte kan skapa ett konto med samma namn eller utan namn.
Den har inte ens en try-catch.

## Test 3 Withdraw Money from Account
Testar om man kan dra ut mer pengar än det som finns på kontot. Det finns ingen if-sats som förhindrar detta.
Det finns bara en try-catch som gör att man inte kan skriva bokstäver eller annat.
