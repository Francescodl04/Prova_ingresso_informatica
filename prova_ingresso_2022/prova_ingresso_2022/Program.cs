using System;

namespace prova_ingresso_2022
{
    class Program
    {
        private static string logo = "  ___ _             _    _         _     _             \n" +
                                     " | _ (_)___ __ __ _| |__| |__ _ __| |_ _(_)___ ___ _ _ \n" +
                                     " |   / (_-</ _/ _` | / _` / _` / _` \\ V / (_-</ _ \\ '_|\n" +
                                     " |_|_\\_/__/\\__\\__,_|_\\__,_\\__,_\\__,_|\\_/|_/__/\\___/_|\n\n";
        private static string welcome = "Benvenuto in Riscaldadvisor, scegli un opzione dal menu...\n";
        private static string[] menu = new string[] { "Scopri il miglior sistema di riscaldamento per la tua casa", "Conosci il rendimento di un sistema di riscaldamento" };
        static void Main(string[] args)
        {
            ShowHeading();
            ShowMenu();
            Exit();
        }

        static private void ShowHeading()
        {
            Console.WriteLine(logo + welcome);
        }

        static private void ShowMenu()
        {
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {menu[i]}");
            }
            int choice;
            while (int.TryParse(Console.ReadLine(), out choice) == false)
            {
                Console.WriteLine($"Devi inserire un numero compreso tra 1 e {menu.Length}:");
            }
        }

        static private void Exit()
        {
            Console.WriteLine("Per uscire dal programma premere un tasto qualsiasi...");
            Console.ReadKey();
        }
    }

    class HeatingSystem
    {
        private string name;
        public HeatingSystem()
        {

        }

        public void InstallationCost()
        {

        }

        public void MonthlyCost()
        {

        }

        public void YearlyCost()
        {

        }
    }
}
