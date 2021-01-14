using System.Runtime.ConstrainedExecution;
using System.Net.Security;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.ComponentModel;
using System.Linq;



namespace Tamagotchi
{
    public class Shop
    {
       // public bool posessed;
         
        public int money = 15;
        public int svarShop;
        public List<string> stuff = new List<string>(){"Choklad", "arg Lakris"};
        private List<int> prizes = new List<int>(){10, 3, 1};
        public List<int> likables = new List<int>(){5, 2, -1};
       
        private Random generator = new Random();
      
        //int isPosessed;
       // Tamagotchi tamagotchi = new Tamagotchi();




        public void printStuff(){
            System.Console.WriteLine("Dina Pengar: " + money);
                for (int u = 0; u < stuff.Count; u++)
                {
                     System.Console.WriteLine(u  + ". " + stuff[u]);  //Du ska kunna foreach...det är kortare än en for loop, fast bara på listor (inte arrayer) :)
                }
        }


        public void choice(Tamagotchi tam){  
            //  string isPosessedString;
          

            // posessed = IsPosessed();
            // if(posessed == true)
            // {
            //     isPosessedString = "Ja";
            // }
            // else
            // {
            //     isPosessedString = "nej";
            // }

            string svarString = Console.ReadLine();
            
            bool lyckad = int.TryParse(svarString, out svarShop);

            if(svarShop == 0){
                System.Console.WriteLine("Sak: " + stuff[0] + "\nLikable: " + likables[svarShop] +  "\npris: " + prizes[svarShop]); //Lägg till om den är posessed ... + "\nÄr den förbannad? " + isPosessedString
            }
             else if(svarShop == 1){
                System.Console.WriteLine("Sak: " + stuff[1] + "\nLikable: " + likables[svarShop] +  "\npris: " + prizes[svarShop]); // + "\nÄr den förbannad? " + isPosessedString
            }
            Console.ReadLine();
            Buy(svarShop, tam);
        }

        public void Buy(int svar, Tamagotchi tam){
            
            System.Console.WriteLine("Vill du köpa? [Y/N]");
            string svarString = Console.ReadLine();
            if (svarString.ToUpper() == "Y") 
            {
               money =  money - prizes[svar];            
               System.Console.WriteLine("Pengar kvar: "+ money);
                tam.inventory.Add(stuff[svarShop]);
               System.Console.WriteLine(tam.inventory.Count);
               
            }
            else if (svarString.ToUpper() == "N")
            {
               System.Console.WriteLine("Oki");
            }
        }

          

        // public bool IsPosessed()
        // {

        //     isPosessed = generator.Next(2);
        
        //     if (isPosessed == 1)
        //     {
        //         posessed = true;
        //         return posessed;
        //     }
        //     else if (isPosessed == 0)
        //     {
        //         posessed = false;
        //         return posessed;
        //     }
        //     else {
        //         return posessed;
        //     }
            
                
        // }


    }
}
