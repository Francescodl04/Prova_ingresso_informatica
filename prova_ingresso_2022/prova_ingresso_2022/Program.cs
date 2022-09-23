using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace prova_ingresso_2022
{
    class Program
    {
        private static readonly string logo = "                      ___ _             _    _         _     _             \n" +
                                     "                     | _ (_)___ __ __ _| |__| |__ _ __| |_ _(_)___ ___ _ _ \n" +
                                     "                     |   / (_-</ _/ _` | / _` / _` / _` \\ V / (_-</ _ \\ '_|\n" +
                                     "                     |_|_\\_/__/\\__\\__,_|_\\__,_\\__,_\\__,_|\\_/|_/__/\\___/_|\n";
        private static readonly string benvenuto = "\nBenvenuto, scegli un opzione dal menu inserendo il numero corrispondente e premendo invio...\n";
        private static readonly string[] opzioniMenu = new string[] { "Inserisci un nuovo sistema di riscaldamento", "Inserisci nuovi valori della bolletta", "Visualizza i sistemi di riscaldamento inseriti", "Scopri il miglior sistema di riscaldamento per la tua casa", "Riporta il programma alle impostazioni iniziali", "Esci dal programma" };
        private static readonly string[] intestazioniFunzioni = new string[] { "Ad ogni richiesta inserisci un valore o una parola e premi invio...", "Ecco i sistemi di riscaldamento inseriti:", "Attraverso questa funzione eliminerai OGNI sistema di riscaldamento da te inserito." };
        private static readonly string[] descrizioneDatiSistemiRiscaldamento = new string[] { "il nome", "il tipo", "il rendimento", "il costo della macchina", "il costo di installazione", "la fonte di riscaldamento" };
        private static readonly string[] descrizioneDatiBolletta = new string[] { "il tipo della materia", "la spesa per la materia", "la spesa per il trasporto e la gestione del contatore", "gli oneri di sistema", "il QVD" };
        private static readonly string[] percorsiIO = new string[] { "files", "files/sistemi_riscaldamento.json", "files/bollette.json", "files/fonti_energia.json" };
        private static List<SistemaRiscaldamento> SistemiRiscaldamento = new List<SistemaRiscaldamento>();
        private static List<Bolletta> Bollette = new List<Bolletta>();

        static void Main()
        {
            MostraIntestazione(true);
            OperazioniIniziali();
            switch (MostraMenu())
            {
                case 1:
                    SchermataNuovoSistemaRiscaldamento();
                    break;
                case 2:
                    SchermataNuovaBolletta();
                    break;
                case 3:
                    SchermataMostraSistemiRiscaldamento();
                    break;
                case 4:
                    MiglioreSistemaRiscaldamento();
                    break;
                case 5:
                    SchermataReset();
                    break;
                case 6:
                    Esci();
                    break;
            }
            RitornoMenu();
        }

        static private void OperazioniIniziali()
        {
            OperazioniFile operazioniFile = new OperazioniFile();
            for (int i = 0; i < percorsiIO.Length; i++)
            {
                if (File.Exists(percorsiIO[i]) == true)
                {
                    switch (i)
                    {
                        case 0:
                            if (Directory.Exists(percorsiIO[i]) == false)
                            {
                                operazioniFile.CreaCartella(percorsiIO[i]);
                            }
                            break;
                        case 1:
                            SistemiRiscaldamento = JsonConvert.DeserializeObject<List<SistemaRiscaldamento>>(operazioniFile.LeggiFile(percorsiIO[i]));
                            break;
                        case 2:
                            FontiEnergia = JsonConvert.DeserializeObject<List<FonteEnergia>>(operazioniFile.LeggiFile(percorsiIO[i]));
                            break;
                        case 3:
                            Bollette = JsonConvert.DeserializeObject<List<Bolletta>>(operazioniFile.LeggiFile(percorsiIO[i]));
                            break;
                    }
                }
            }
        }

        static private void MostraIntestazione(bool avvioSoftware)
        {
            Console.Clear();
            if (avvioSoftware == true)
            {
                Console.WriteLine(logo + benvenuto);
            }
            else
            {
                Console.WriteLine(logo);
            }
        }

        static private int MostraMenu()
        {
            for (int i = 0; i < opzioniMenu.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {opzioniMenu[i]}");
            }
            int scelta;
            while (int.TryParse(Console.ReadLine(), out scelta) == false || scelta < 1 || scelta > opzioniMenu.Length)
            {
                Console.WriteLine($"Devi inserire un numero compreso tra 1 e {opzioniMenu.Length}:");
            }
            Console.Clear();
            MostraIntestazione(false);
            return scelta;
        }

        static private void SchermataNuovoSistemaRiscaldamento()
        {
            Console.WriteLine(intestazioniFunzioni[0]);
            string[] datiRaccolti= InserimentoDati(descrizioneDatiSistemiRiscaldamento);
            SistemaRiscaldamento sistemaRiscaldamento = new SistemaRiscaldamento(datiRaccolti[0], datiRaccolti[1], datiRaccolti[2], double.Parse(datiRaccolti[3]), double.Parse(datiRaccolti[4]), datiRaccolti[5]);
            SistemiRiscaldamento = sistemaRiscaldamento.NuovoSistemaRiscaldamento(SistemiRiscaldamento);
            MostraIntestazione(false);
            Console.WriteLine("Salvataggio delle informazioni in corso...");
            OperazioniFile operazioniFile = new OperazioniFile();
            Console.WriteLine(operazioniFile.ScriviFile(percorsiIO[1], JsonConvert.SerializeObject(SistemiRiscaldamento)));
        }

        static private void SchermataNuovaBolletta()
        {
            Console.WriteLine(intestazioniFunzioni[0]);
            string[] datiRaccolti = InserimentoDati(descrizioneDatiBolletta);
            Bolletta bolletta = new Bolletta(datiRaccolti[0], double.Parse(datiRaccolti[1]), double.Parse(datiRaccolti[2]), double.Parse(datiRaccolti[3]), double.Parse(datiRaccolti[4]));
            Bollette = bolletta.NuovaBolletta(Bollette);
            MostraIntestazione(false);
            Console.WriteLine("Salvataggio delle informazioni in corso...");
            OperazioniFile operazioniFile = new OperazioniFile();
            Console.WriteLine(operazioniFile.ScriviFile(percorsiIO[1], JsonConvert.SerializeObject(Bollette)));
        }

        static private void SchermataMostraSistemiRiscaldamento()
        {
            Console.WriteLine(intestazioniFunzioni[1]);
            for (int i = 0; i < SistemiRiscaldamento.Count; i++)
            {
                SistemaRiscaldamento sistemaRiscaldamento = new SistemaRiscaldamento(SistemiRiscaldamento[i].GetNome(), SistemiRiscaldamento[i].GetTipo(), SistemiRiscaldamento[i].GetRendimento(), SistemiRiscaldamento[i].GetCostoMacchina(), SistemiRiscaldamento[i].GetCostoInstallazione(), SistemiRiscaldamento[i].GetFonteRiscaldamento());
                Console.WriteLine($"{i + 1}) {sistemaRiscaldamento.ToString()}");
            }
        }

        static private void MiglioreSistemaRiscaldamento()
        {
            Console.WriteLine(intestazioniFunzioni[0]);
        }

        static private void SchermataReset()
        {
            Console.WriteLine(intestazioniFunzioni[2]);
            Console.WriteLine("Sei sicuro di voler compiere questa operazione? (inserisci S se sì, oppure N se NON vuoi farlo):");
            bool erroreInserimento;
            do
            {
                string scelta = Console.ReadLine().ToUpper();
                switch (scelta)
                {
                    case "S":
                        Console.WriteLine("Eliminazione in corso...\n");
                        MostraIntestazione(false);
                        Console.WriteLine("Eliminazione completata!");
                        erroreInserimento = false;
                        break;
                    case "N":
                        erroreInserimento = false;
                        break;
                    default:
                        Console.WriteLine("Non hai inserito una risposta accettabile. Ripeti l'inserimento:");
                        erroreInserimento = true;
                        break;
                }
            }
            while (erroreInserimento == true);
        }

        static private string[] InserimentoDati(string[] descrizioniDati)
        {
            string[] datiInseriti = new string[descrizioniDati.Length];
            for (int i = 0; i < descrizioniDati.Length; i++)
            {
                Console.WriteLine($"Inserisci {descrizioniDati[i]}:");
                datiInseriti[i] = Console.ReadLine();
            }
            return datiInseriti;
        }

        static private void RitornoMenu()
        {
            Console.WriteLine("\nPremi un tasto qualsiasi per per tornare al menu principale...");
            Console.ReadKey();
            Main();
        }

        static private void Esci()
        {
            Console.WriteLine("Per uscire dal programma premere un tasto qualsiasi...");
            Console.ReadKey();
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
