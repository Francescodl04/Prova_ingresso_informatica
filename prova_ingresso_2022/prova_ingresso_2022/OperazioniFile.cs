/**
 * @name Francesco Di Lena, classe 5F
 * @date 24/09/2022
 * @file OperazioniFile.cs
**/

using System;
using System.IO;

namespace prova_ingresso_2022
{
    /**
     * @class OperazioniFile
     * @brief Classe che esegue le operazioni inerenti ai file.
    **/
    
    class OperazioniFile
    {
        //Attributi 
        string messaggioOutput = "Salvataggio delle modifiche completato con successo!";

        //Metodi

        /**
         * @fn public OperazioniFile()
         * @brief Metodo costruttore.
        **/
        public OperazioniFile()
        {

        }

        /**
         * @fn public string CreaCartella(string percorsoIO)
         * @param string percorsoIO : indica il percorso del file.
         * @brief Il metodo CreaCartella permette di eseguire la creazione di una cartella (directory), catturandone le eccezioni.
         * @returns string messaggioOutput : indica se ci sono state eccezioni nell'esecuzione delle operazioni o meno.
        **/

        public string CreaCartella(string percorsoIO)
        {
            try 
            {
                Directory.CreateDirectory(percorsoIO); 
            }
            catch (UnauthorizedAccessException)
            {
                messaggioOutput = MessaggiErrore(0);
            }
            catch (IOException)
            {
                messaggioOutput = MessaggiErrore(1);
            }
            return messaggioOutput;
        }

        /**
         * @fn public string LeggiFile(string percorsoIO)
         * @param string percorsoIO : indica il percorso del file.
         * @brief Il metodo LeggiFile permette di eseguire la lettura di un file, catturandone le eccezioni.
         * @returns string contenutoInput : contiene il contenuto letto del file, oppure può indicare se ci sono state eccezioni nell'esecuzione delle operazioni.
        **/

        public string LeggiFile(string percorsoIO)
        {
            string contenutoInput;
            try
            {
                contenutoInput = File.ReadAllText(percorsoIO);
            }
            catch (UnauthorizedAccessException)
            {
                contenutoInput = MessaggiErrore(0);
            }
            catch (IOException)
            {
                contenutoInput = MessaggiErrore(1);
            }
            return contenutoInput;
        }

        /**
         * @fn public string ScriviFile(string percorsoIO, string contenutoOutput)
         * @param string percorsoIO : indica il percorso del file.
         * @param string contenutoOutput : è il contenuto da scrivere sul file.
         * @brief Il metodo ScriviFile permette di eseguire la scrittura su file, catturandone le eccezioni.
         * @returns string messaggioOutput : indica se ci sono state eccezioni nell'esecuzione delle operazioni o meno.
        **/

        public string ScriviFile(string percorsoIO, string contenutoOutput) 
        {
            try 
            {
                File.WriteAllText(percorsoIO, contenutoOutput); 
            }
            catch (UnauthorizedAccessException)
            {
                messaggioOutput = MessaggiErrore(0);
            }
            catch (IOException)
            {
                messaggioOutput = MessaggiErrore(1);
            }
            return messaggioOutput;
        }

        /**
         * @fn public string EliminaFile(string percorsoIO)
         * @param string percorsoIO : indica il percorso del file.
         * @brief Il metodo EliminaFile permette di eseguire l'eliminazione di un file, catturandone le eccezioni.
         * @returns string messaggioOutput : indica se ci sono state eccezioni nell'esecuzione delle operazioni o meno.
        **/

        public string EliminaFile(string percorsoIO)
        {
            try
            {
                File.Delete(percorsoIO);
            }
            catch (UnauthorizedAccessException)
            {
                messaggioOutput = MessaggiErrore(0);
            }
            catch (IOException)
            {
                messaggioOutput = MessaggiErrore(1);
            }
            return messaggioOutput;
        }

        /**
         * @fn public string MessaggiErrore(int codiceErrore)
         * @param int codiceErrore : indica il codice assegnato all'eccezione dagli altri metodi.
         * @brief Il metodo MessaggiErrore ritorna i messaggi di errore in seguito al catturamento delle eccezioni.
         * @returns string : i messaggi di errore.
        **/
        public string MessaggiErrore(int codiceErrore) //Il metodo accetta come argomento il codice dell'errore che si è verificato nei metodi.
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
