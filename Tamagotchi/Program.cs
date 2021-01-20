using System.Runtime.ConstrainedExecution;
using System.Net.Security;
using System;
using System.Collections.Generic;

namespace Tamagotchi
{
    class Program
    {
        static void Main(string[] args) //Main. Här ifrån körs spelet. Själva spelkoden har lagts in i Game klassen. Därför anroppar main 
        //den metod som körs i game.
        {

            Game game = new Game(); //Eftersom Choises metoden ligger i shop klassen behövs en instans skapas för klassen.  
            game.TheGame();
          
        }
    }
}
