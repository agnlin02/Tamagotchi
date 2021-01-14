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

            while(minTimagotchi.isAlive == true)
            {
            minTimagotchi.Tick();
            System.Console.WriteLine("Vad vill du göra?");
            System.Console.WriteLine("1. Lära min Tamaguchi ett ord"); //Funkar förutom att man kan trycka "enter" https://stackoverflow.com/questions/5891538/listen-for-key-press-in-net-console-app
            System.Console.WriteLine("2. Mata min Tamagutchi"); // Funkar
            System.Console.WriteLine("3. Prata med min Tamaguchi"); //Funkar 
            System.Console.WriteLine("4. Stats för Gutchi"); //Funkar
            System.Console.WriteLine("5. SHOP!"); //Funkar
            System.Console.WriteLine("6. inventory"); //Funkar
            svar = Console.ReadLine();
            
            bool lyckad = int.TryParse(svar, out usernumber);
           

                if (usernumber > 0 && usernumber < 7)
             {
            
            
                if ( svar == "1")
            {                
                minTimagotchi.Teach();
            }
             else if ( svar == "2")
            {
                minTimagotchi.Feed();
            }
            else if(svar == "3")
            {
                minTimagotchi.Hi();
            }
            else if(svar == "4")
            {   
                minTimagotchi.PrintStats();
            }
               else if(svar == "5")
            {   
                System.Console.WriteLine("Shop!");
                shop.printStuff();
                shop.choice(minTimagotchi);
            }
            else if (svar == "6")
            {
               minTimagotchi.Inventory();
            }

            }
             else{
                System.Console.WriteLine("Du måste skriva ett av nummrerna ovan [1,2,3,4,5 eller 6");
                Console.ReadLine();
            }
           
            } 
            minTimagotchi.Dead();
                
        }
    }
}
