using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("===============OPERAZIONI==============");
            Console.WriteLine("Scegli l'operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");
            Console.WriteLine("========================================");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Logout();
                    break;
                case "3":
                    VerificaLogin();
                    break;
                case "4":
                    ListaAccessi();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida, riprova.");
                    break;
            }
        }
    }

    static void Login()
    {
        Console.Write("Inserisci username: ");
        string username = Console.ReadLine();

        Console.Write("Inserisci password: ");
        string password = Console.ReadLine();

        Console.Write("Conferma password: ");
        string confirmPassword = Console.ReadLine();

        if (string.IsNullOrEmpty(username) || password != confirmPassword)
        {
            Console.WriteLine("Errore: username non inserita o le password non coincidono.");
            return;
        }

        Utente.Login(username, password);
    }

    static void Logout()
    {
        if (!Utente.IsAuthenticated)
        {
            Console.WriteLine("Errore: nessun utente loggato.");
        }
        else
        {
            Utente.Logout();
            Console.WriteLine("Logout effettuato con successo.");
        }
    }

    static void VerificaLogin()
    {
        if (!Utente.IsAuthenticated)
        {
            Console.WriteLine("Errore: nessun utente loggato.");
        }
        else
        {
            Console.WriteLine($"Ultimo login effettuato il: {Utente.LastLogin}");
        }
    }

    static void ListaAccessi()
    {
        if (Utente.Accessi.Count == 0)
        {
            Console.WriteLine("Nessun accesso registrato.");
        }
        else
        {
            Console.WriteLine("Lista degli accessi:");
            foreach (var accesso in Utente.Accessi)
            {
                Console.WriteLine(accesso);
            }
        }
    }
}

public static class Utente
{
    public static string Username { get; private set; }
    private static string Password { get; set; }
    public static DateTime LastLogin { get; private set; }
    public static bool IsAuthenticated { get; private set; }
    public static List<DateTime> Accessi { get; private set; } = new List<DateTime>();

    public static void Login(string username, string password)
    {
        Username = username;
        Password = password;
        LastLogin = DateTime.Now;
        IsAuthenticated = true;
        Accessi.Add(LastLogin);
        Console.WriteLine("Login effettuato con successo.");
    }

    public static void Logout()
    {
        Username = null;
        Password = null;
        IsAuthenticated = false;
    }
}
