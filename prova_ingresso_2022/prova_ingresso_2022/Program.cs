/**
 * @name Francesco Di Lena, classe 5F
 * @date 24/09/2022
 * @file Program.cs
**/ 

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
        private static readonly string[] opzioniMenu = new string[] { "Inserisci un nuovo sistema di riscaldamento", "Inserisci una nuova bolletta", "Visualizza i sistemi di riscaldamento inseriti", "Visualizza le bollette inserite", "Scopri il miglior sistema di riscaldamento per la tua casa", "Riporta il programma alle impostazioni iniziali", "Esci dal programma" };
        private static readonly string[] intestazioniFunzioni = new string[] { "Ad ogni richiesta inserisci un valore o una parola e premi invio...", "Ecco i sistemi di riscaldamento inseriti:", "Ecco le bollette inserite:", "Attraverso questa funzione eliminerai OGNI sistema di riscaldamento da te inserito." };
        private static readonly string[] descrizioneDatiSistemiRiscaldamento = new string[] { "il nome", "il tipo", "il rendimento (nel formato x.x o x,x)", "il costo della macchina (in euro)", "il costo di installazione (in euro)", "la fonte di riscaldamento" };
        private static readonly string[] descrizioneDatiBolletta = new string[] { "il tipo della materia", "la spesa annuale per la materia ( solo il numero in euro/unità misura materia)", "la spesa annuale per il trasporto e la gestione del contatore (in euro)", "gli oneri di sistema annuali (in euro)", "la Quota Vendita al Dettaglio annuale (QVD, in euro)" };
        private static readonly string[] percorsiCartelle = new string[] { "files" };
        private static readonly string[] percorsiFile = new string[] { "files/sistemi_riscaldamento.json", "files/bollette.json" };
        private static List<SistemaRiscaldamento> SistemiRiscaldamento;
        private static List<Bolletta> Bollette;

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
                    SchermataMostraBollette();
                    break;
                case 5:
                    MiglioreSistemaRiscaldamento();
                    break;
                case 6:
                    SchermataEliminaDati();
                    break;
                case 7:
                    Esci();
                    break;
            }
            RitornoMenu();
        }

        static private void OperazioniIniziali()
        {
            OperazioniFile operazioniFile = new OperazioniFile();
            for (int i = 0; i < percorsiCartelle.Length; i++)
            {
                if (Directory.Exists(percorsiCartelle[i]) == false)
                {
                    operazioniFile.CreaCartella(percorsiCartelle[i]);
                }
            }
            for (int i = 0; i < percorsiFile.Length; i++)
            {
                if (File.Exists(percorsiFile[i]) == true)
                {
                    switch (i)
                    {
                        case 0:
                            SistemiRiscaldamento = JsonConvert.DeserializeObject<List<SistemaRiscaldamento>>(operazioniFile.LeggiFile(percorsiFile[i]));
                            break;
                        case 1:
                            Bollette = JsonConvert.DeserializeObject<List<Bolletta>>(operazioniFile.LeggiFile(percorsiFile[i]));
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
            int scelta = ControlloMenu(opzioniMenu.Length);
            Console.Clear();
            MostraIntestazione(false);
            return scelta;
        }

        static private void SchermataNuovoSistemaRiscaldamento()
        {
            Console.WriteLine(intestazioniFunzioni[0]);
            string[] datiRaccolti = InserimentoDati(descrizioneDatiSistemiRiscaldamento);
            SistemaRiscaldamento sistemaRiscaldamento = new SistemaRiscaldamento(datiRaccolti[0], datiRaccolti[1], double.Parse(datiRaccolti[2]), double.Parse(datiRaccolti[3]), double.Parse(datiRaccolti[4]), datiRaccolti[5]);
            SistemiRiscaldamento = sistemaRiscaldamento.NuovoSistemaRiscaldamento(SistemiRiscaldamento);
            MostraIntestazione(false);
            Console.WriteLine("Salvataggio delle informazioni in corso...");
            OperazioniFile operazioniFile = new OperazioniFile();
            Console.WriteLine(operazioniFile.ScriviFile(percorsiFile[0], JsonConvert.SerializeObject(SistemiRiscaldamento)));
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
            Console.WriteLine(operazioniFile.ScriviFile(percorsiFile[1], JsonConvert.SerializeObject(Bollette)));
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

        static private void SchermataMostraBollette()
        {
            Console.WriteLine(intestazioniFunzioni[2]);
            for (int i = 0; i < Bollette.Count; i++)
            {
                Bolletta bolletta = new Bolletta(Bollette[i].GetTipoMateria(), Bollette[i].GetSpesaMateria(), Bollette[i].GetSpesaTrasportoGestioneContatore(), Bollette[i].GetOneriSistema(), Bollette[i].GetQVD());
                Console.WriteLine($"{i + 1}) {bolletta.ToString()}");
            }
        }

        static private void MiglioreSistemaRiscaldamento()
        {
            Console.WriteLine(intestazioniFunzioni[0]);
            Console.WriteLine("\nScegli il tuo attuale sistema di riscaldamento:");
            for (int i = 0; i < SistemiRiscaldamento.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {SistemiRiscaldamento[i].GetNome()}, del tipo {SistemiRiscaldamento[i].GetTipo()} ");
            }
            int indiceFonteRiscaldamento = 0;
            switch (SistemiRiscaldamento[ControlloMenu(SistemiRiscaldamento.Count)].GetFonteRiscaldamento())
            {
                case "Energia elettrica":
                    Console.WriteLine("Inserisci il tuo consumo annuo di energia elettrica:");
                    indiceFonteRiscaldamento = 0;
                    break;
                case "Gas naturale":
                    Console.WriteLine("Inserisci il tuo consumo annuo di gas naturale:");
                    indiceFonteRiscaldamento = 1;
                    break;
            }
            double consumoReale = double.Parse(Console.ReadLine());
            MostraIntestazione(false);
            Console.WriteLine("NOTA: nella bolletta dei sistemi con una fonte di riscaldamento diversa da quella che già possiedi\nla spesa per la materia verrà calcolata attraverso un valore di consumo di una famiglia media,\nmentre gli altri con i valori reali da te inseriti.\n");
            double costoBollettaPrimoAnnoMinore=0, costoBollettaSecondoAnnoMinore=0;
            string sistemaRiscaldamentoPrimoAnnoMigliore = "", sistemaRiscaldamentoSecondoAnnoMigliore = "";
            for (int i = 0; i < SistemiRiscaldamento.Count; i++)
            {
                double[] consumoMedio = new double[] { 2700, 1300 };
                double consumo, costoBollettaPrimoAnno, costoBollettaSecondoAnno;
                if (SistemiRiscaldamento[i].GetFonteRiscaldamento() != Bollette[indiceFonteRiscaldamento].GetTipoMateria())
                {
                    consumo = consumoMedio[indiceFonteRiscaldamento];
                }
                else
                {
                    consumo = consumoReale;
                }
                SistemaRiscaldamento sistemaRiscaldamento = new SistemaRiscaldamento(SistemiRiscaldamento[0].GetNome(), SistemiRiscaldamento[0].GetTipo(), SistemiRiscaldamento[0].GetRendimento(), SistemiRiscaldamento[0].GetCostoMacchina(), SistemiRiscaldamento[0].GetCostoInstallazione(), SistemiRiscaldamento[0].GetFonteRiscaldamento());
                Bolletta bolletta = new Bolletta(Bollette[indiceFonteRiscaldamento].GetTipoMateria(), Bollette[indiceFonteRiscaldamento].GetSpesaMateria(), Bollette[indiceFonteRiscaldamento].GetSpesaTrasportoGestioneContatore(), Bollette[indiceFonteRiscaldamento].GetOneriSistema(), Bollette[indiceFonteRiscaldamento].GetQVD());
                Console.WriteLine($"{i + 1}) {SistemiRiscaldamento[i].GetNome()}, del tipo {SistemiRiscaldamento[i].GetTipo()} \n" +
                                  $"   --> Bolletta primo anno: {costoBollettaPrimoAnno = bolletta.CalcoloCostoBolletta(consumo, SistemiRiscaldamento[i].GetRendimento()) + SistemiRiscaldamento[i].GetCostoMacchina() + SistemiRiscaldamento[i].GetCostoInstallazione()} euro\n" +
                                  $"   --> Bolletta a partire dal secondo anno: {costoBollettaSecondoAnno = bolletta.CalcoloCostoBolletta(consumo, SistemiRiscaldamento[i].GetRendimento())} euro");
                if (i == 0 || costoBollettaPrimoAnnoMinore > costoBollettaPrimoAnno)
                {
                    costoBollettaPrimoAnnoMinore = costoBollettaPrimoAnno;
                    sistemaRiscaldamentoPrimoAnnoMigliore = SistemiRiscaldamento[i].GetNome();
                }
                if (i == 0 || costoBollettaSecondoAnnoMinore > costoBollettaSecondoAnno)
                {
                    costoBollettaSecondoAnnoMinore = costoBollettaSecondoAnno;
                    sistemaRiscaldamentoSecondoAnnoMigliore = SistemiRiscaldamento[i].GetNome();
                }
            }
            Console.WriteLine($"\nIl sistema di riscaldamento con il quale spenderesti meno nel primo anno meno è: {sistemaRiscaldamentoPrimoAnnoMigliore}" +
                              $"\nIl sistema di riscaldamento con il quale spenderesti meno a partire dal secondo anno è: {sistemaRiscaldamentoSecondoAnnoMigliore}");
        }

        static private void SchermataEliminaDati()
        {
            Console.WriteLine(intestazioniFunzioni[3]);
            Console.WriteLine("Sei sicuro di voler compiere questa operazione? (inserisci S se sì, oppure N se NON vuoi farlo):");
            bool erroreInserimento;
            do
            {
                string scelta = Console.ReadLine().ToUpper();
                switch (scelta)
                {
                    case "S":
                        Console.WriteLine("Eliminazione in corso...\n");
                        OperazioniFile operazioniFile = new OperazioniFile();
                        for (int i = 1; i < percorsiFile.Length; i++)
                        {
                            operazioniFile.EliminaFile(percorsiFile[i]);
                        }
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

        static private int ControlloMenu(int n_opzioni)
        {
            int scelta;
            while (int.TryParse(Console.ReadLine(), out scelta) == false || scelta < 1 || scelta > n_opzioni)
            {
                Console.WriteLine($"Devi inserire un numero compreso tra 1 e {n_opzioni}:");
            }
            return scelta;
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
