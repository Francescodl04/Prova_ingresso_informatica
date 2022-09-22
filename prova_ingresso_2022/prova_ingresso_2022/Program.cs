using System;

namespace prova_ingresso_2022
{
    class Program
    {
        private static readonly string logo = "                      ___ _             _    _         _     _             \n" +
                                     "                     | _ (_)___ __ __ _| |__| |__ _ __| |_ _(_)___ ___ _ _ \n" +
                                     "                     |   / (_-</ _/ _` | / _` / _` / _` \\ V / (_-</ _ \\ '_|\n" +
                                     "                     |_|_\\_/__/\\__\\__,_|_\\__,_\\__,_\\__,_|\\_/|_/__/\\___/_|\n";
        private static readonly string welcome = "\nBenvenuto, scegli un opzione dal menu inserendo il numero corrispondente e premendo invio...\n";
        private static readonly string[] menuOptions = new string[] { "Inserisci un nuovo sistema di riscaldamento", "Visualizza i sistemi di riscaldamento inseriti", "Scopri il miglior sistema di riscaldamento per la tua casa", "Riporta il programma alle impostazioni iniziali", "Esci dal programma" };
        private static readonly string[] functionsHeadings = new string[] { "Ad ogni richiesta inserisci un valore o una parola e premi invio...", "Ecco i sistemi di riscaldamento inseriti:", "Attraverso questa funzione eliminerai OGNI sistema di riscaldamento da te inserito." };
        private static readonly string[,] dataDescriptions = new string[,] { {"il nome", "il rendimento", } };
        
        static void Main()
        {
            ShowHeading(true);
            switch (ShowMenu())
            {
                case 1:
                    NewHeatingSystemScreen();
                    break;
                case 2:
                    ShowHeatingSystemsScreen();
                    break;
                case 3:
                    BestHeatingSystemScreen();
                    break;
                case 4:
                    ResetScreen();
                    break;
                case 5:
                    Exit();
                    break;
            }
            ReturnOnMenu();
        }

        static private void ShowHeading(bool softwareBoot)
        {
            Console.Clear();
            if (softwareBoot == true)
            {
                Console.WriteLine(logo + welcome);
            }
            else
            {
                Console.WriteLine(logo);
            }
        }

        static private int ShowMenu()
        {
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {menuOptions[i]}");
            }
            int choice;
            while (int.TryParse(Console.ReadLine(), out choice) == false || choice < 1 || choice > menuOptions.Length)
            {
                Console.WriteLine($"Devi inserire un numero compreso tra 1 e {menuOptions.Length}:");
            }
            Console.Clear();
            ShowHeading(false);
            return choice;
        }

        static private void NewHeatingSystemScreen()
        {
            Console.WriteLine(functionsHeadings[0]);
        }

        static private void ShowHeatingSystemsScreen()
        {
            Console.WriteLine(functionsHeadings[1]);
        }

        static private void BestHeatingSystemScreen()
        {
            Console.WriteLine(functionsHeadings[0]);
        }

        static private void ResetScreen()
        {
            Console.WriteLine(functionsHeadings[2]);
            Console.WriteLine("Sei sicuro di voler compiere questa operazione? (inserisci S se sì, oppure N se NON vuoi farlo):");
            bool error = false;
            do
            {
                string choice = Console.ReadLine().ToUpper();
                switch (choice)
                {
                    case "S":
                        Console.WriteLine("Eliminazione in corso...\n");
                        ShowHeading(false);
                        Console.WriteLine("Eliminazione completata!");
                        error = false;
                        break;
                    case "N":
                        error = false;
                        break;
                    default:
                        Console.WriteLine("Non hai inserito una risposta accettabile. Ripeti l'inserimento:");
                        error = true;
                        break;
                }
            }
            while (error == true);
        }

        static private string[] DataInsert(int type, string[,] dataDescriptions)
        {
            string[] dataInserted = new string[dataDescriptions.Length];
            for (int i = 0; i < dataDescriptions.Length; i++)
            {
                Console.WriteLine($"Inserisci {dataDescriptions[type,i]}:");
                dataInserted[i] = Console.ReadLine();
            }
            return dataInserted;
        }

        static private void ReturnOnMenu()
        {
            Console.WriteLine("\nPremi un tasto qualsiasi per per tornare al menu principale...");
            Console.ReadKey();
            Main();
        }

        static private void Exit()
        {
            Console.WriteLine("Per uscire dal programma premere un tasto qualsiasi...");
            Console.ReadKey();
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
