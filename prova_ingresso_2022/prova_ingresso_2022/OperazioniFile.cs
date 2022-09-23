using System;
using System.IO;

namespace prova_ingresso_2022
{
    class OperazioniFile
    {
        string messaggioOutput = "Salvataggio delle modifiche completato con successo!";
        //Metodi

        //Metodo costruttore.
        public OperazioniFile()
        {

        }

        //Metodo che permette di eseguire la creazione di una cartella (directory).
        public string CreaCartella(string percorsoIO) //Il metodo accetta come argomento il percorso del file e restituisce un messaggio per indicare se ci sono state delle eccezioni o meno.
        {
            try //Prova a eseguire le istruzioni.
            {
                Directory.CreateDirectory(percorsoIO); //Metodo che esegue la creazione di una directory al percorso specificato.
            }
            catch (UnauthorizedAccessException) //Rileva l'eccezione che non autorizza l'accesso al file.
            {
                messaggioOutput = GestisciErrori(0);
            }
            catch (IOException) //Rileva l'eccezione che indica un errore di IO.
            {
                messaggioOutput = GestisciErrori(1);
            }
            return messaggioOutput;
        }

        //Metodo che permette di eseguire la lettura di un file.
        public string LeggiFile(string percorsoIO) //Il metodo accetta come argomento il percorso del file e restituisce il contenuto del file letto oppute messaggio per indicare se ci sono state delle eccezioni.
        {
            string contenutoInput;
            try //Prova a eseguire le istruzioni.
            {
                contenutoInput = File.ReadAllText(percorsoIO); //Metodo che esegue la lettura di tutto il testo di un file al percorso specificato e restituisce la stringa del testo letto.
            }
            catch (UnauthorizedAccessException) //Rileva l'eccezione che non autorizza l'accesso al file.
            {
                contenutoInput = GestisciErrori(0);
            }
            catch (IOException) //Rileva l'eccezione che indica un errore di IO.
            {
                contenutoInput = GestisciErrori(1);
            }
            return contenutoInput;
        }

        //Metodo che permette di eseguire la scrittura di un file.
        public string ScriviFile(string percorsoIO, string contenutoOutput) //Il metodo accetta come argomenti il percorso del file e il contenuto che dovrà essere scritto su file e restituisce un messaggio per indicare se ci sono state delle eccezioni o meno.
        {
            try //Prova a eseguire le istruzioni.
            {
                File.WriteAllText(percorsoIO, contenutoOutput); //Metodo che esegue la scrittura di un file al percorso specificato (se il percorso non esiste, allora crea il file) e inserisce l'intero contenuto di una stringa.
            }
            catch (UnauthorizedAccessException) //Rileva l'eccezione che non autorizza l'accesso al file.
            {
                messaggioOutput = GestisciErrori(0);
            }
            catch (IOException) //Rileva l'eccezione che indica un errore di IO.
            {
                messaggioOutput = GestisciErrori(1);
            }
            return messaggioOutput;
        }

        //Metodo che permette di eseguire la cancellazione di un file.
        public string EliminaFile(string percorsoIO) //Il metodo accetta come argomento il percorso del file e restituisce un messaggio per indicare se ci sono state delle eccezioni o meno.
        {
            try //Prova a eseguire le istruzioni.
            {
                File.Delete(percorsoIO); //Metodo che esegue l'eliminazione del file al percorso specificato.
            }
            catch (UnauthorizedAccessException) //Rileva l'eccezione che non autorizza l'accesso al file.
            {
                messaggioOutput = GestisciErrori(0);
            }
            catch (IOException) //Rileva l'eccezione che indica un errore di IO.
            {
                messaggioOutput = GestisciErrori(1);
            }
            return messaggioOutput;
        }

        //Metodo che permette di gestire le eccezioni derivanti dai metodi soprastanti.
        public string GestisciErrori(int codiceErrore) //Il metodo accetta come argomento il codice dell'errore che si è verificato nei metodi.
        {
            switch (codiceErrore) //In base al valore che assume la variabile, si possono presentare diversi casi.
            {
                case (0):
                    return "\nERRORE: Si è verificato un errore nell'accesso al file (accesso non autorizzato).\nSi prega di riavviare il programma e, eventualmente, se non si risolve il problema, contattare l'amministratore di sistema.";
                case (1):
                    return "\nERRORE: Si è verificato un errore nell'accesso al file (errore di IO).\nSi prega di riavviare il programma e, eventualmente, se non si risolve il problema, contattare l'amministratore di sistema.";
            }
            return "";
        }
    }
}
