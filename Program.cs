using System;
using System.IO;

namespace JurnalPersonal
{
    class Program
    {
        const string Fisier = "notite.txt";

        static void Main()
        {
            Console.WriteLine("=== Jurnal-Personal ===");
            string? optiune;
            do
            {
                Console.WriteLine("\n1. Adauga notita");
                Console.WriteLine("2. Afiseaza notitele");
                Console.WriteLine("3. Sterge toate notitele");
                Console.WriteLine("0. Iesire");
                Console.Write("Optiunea: ");
                optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Console.Write("Notita: ");
                        string? text = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(text))
                        {
                            Console.WriteLine("Notita goala nu se salveaza.");
                            break;
                        }
                        File.AppendAllText(Fisier, $"[{DateTime.Now:dd.MM.yyyy HH:mm}] {text.Trim()}{Environment.NewLine}");
                        Console.WriteLine("Notita salvata.");
                        break;

                    case "2":
                        if (!File.Exists(Fisier) || new FileInfo(Fisier).Length == 0)
                        {
                            Console.WriteLine("Jurnalul este gol.");
                            break;
                        }
                        string[] notite = File.ReadAllLines(Fisier);
                        for (int i = 0; i < notite.Length; i++)
                            Console.WriteLine($"{i + 1}. {notite[i]}");
                        Console.WriteLine($"Total notite: {notite.Length}");
                        break;

                    case "3":
                        Console.Write("Sigur stergeti toate notitele? (da/nu): ");
                        if (Console.ReadLine()?.Trim().ToLower() == "da")
                        {
                            File.Delete(Fisier);
                            Console.WriteLine("Toate notitele au fost sterse.");
                        }
                        else
                            Console.WriteLine("Stergere anulata.");
                        break;

                    case "0":
                        Console.WriteLine("La revedere!");
                        break;

                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            } while (optiune != "0" && optiune != null);
        }
    }
}
