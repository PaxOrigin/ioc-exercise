# ioc-exercise
IOC exercise

## Consegna
> Creare un gestore di credenziali

L'utente dovrà:
- Poter creare un account inserendo utente e password
- Una volta creato l'account questo se non esiste gia' viene salvato su un db
- L'utente riceve un numero di matricola univoca
- Usando questo numero di matricola e la password l'utente puo' stampare su un file csv le proprie credenziali

**File CSV**   
NomeFile
Matricola-yyyy-mm-gg.csv
Contenuto
Matricola,Username,Password,Data

**Password**
Deve rispettare i seguenti parametri
- Almeno 7 caratteri
- Almeno una lettera maiuscola
- Almeno una cifra numerica
- Almeno un carattere speciale
