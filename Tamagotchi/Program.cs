using System.Runtime.ConstrainedExecution;
using System.Net.Security;
using System;
using System.Collections.Generic;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args)
        {   string svar = "";
            int usernumber = 0;
            bool succes = int.TryParse(svar, out usernumber);
            Tamagotchi minTimagotchi = new Tamagotchi();
            Shop shop = new Shop();

            while(true)
            {
            minTimagotchi.Tick();
            System.Console.WriteLine("Vad vill du göra?");
            System.Console.WriteLine("1. Lära min Tamaguchi ett ord"); //Funkar
            System.Console.WriteLine("2. Mata min Tamagutchi"); //Kan inte få items att funka
            System.Console.WriteLine("3. Prata med min Tamaguchi"); //Funkar
            System.Console.WriteLine("4. Stats för Gutchi"); //Funkar - isAlive bool
            System.Console.WriteLine("5. SHOP!"); //Funkar
            System.Console.WriteLine("6. inventory"); //Funkar
            svar = Console.ReadLine();

            if ( svar == "1")
            {
                 System.Console.WriteLine("Vilket ord vill du lära din Tamaguchi?");
                svar = Console.ReadLine();
                minTimagotchi.Teach(svar);
                System.Console.WriteLine("Guchi lärde " + svar);

            }
             else if ( svar == "2")
            {
                minTimagotchi.Feed();
                System.Console.WriteLine("Hungern och tråkighet minskade");
            }
            else if(svar == "3")
            {
                minTimagotchi.Hi();
                System.Console.WriteLine("Tråkighet minskade");
            }
            else if(svar == "4")
            {   
                System.Console.WriteLine("Det här är dina stats: ");
                minTimagotchi.PrintStats();
            }
               else if(svar == "5")
            {   
                System.Console.WriteLine("Shop!");
                shop.printStuff();
                shop.choice();
            }
            else if (svar == "6")
            {
                System.Console.WriteLine("ditt inventory: ");
                shop.Inventory();
            }

            }     
        }
    }
}
