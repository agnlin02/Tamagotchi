using System.Runtime.ConstrainedExecution;
using System.Net.Security;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.ComponentModel;



namespace Tamagotchi
{
    public class Shop
    {
        bool posessed;
        public int money = 15;
        public List<string> stuff = new List<string>(){"hatt", "mat", "arg Lakris"};
        private List<int> prizes = new List<int>(){10, 3, 1};
        public List<int> likables = new List<int>(){5, 2, -1};
        public List<string> inventory = new List<string>() {};
        private Random generator = new Random();
        int isPosessed;
       // Tamagotchi tamagotchi = new Tamagotchi();




        public void printStuff(){
            System.Console.WriteLine("Dina Pengar: " + money);
                for (int u = 0; u < stuff.Count; u++)
                {
                     System.Console.WriteLine(u  + ". " + stuff[u]);  //Du ska kunna foreach...det är kortare än en for loop, fast bara på listor (inte arrayer) :)
                }
        }


        public void choice(){  
            string isPosessedString;
          

            posessed = IsPosessed();
            if(posessed == true)
            {
                isPosessedString = "Ja";
            }
            else
            {
                isPosessedString = "nej";
            }

            string svarString = Console.ReadLine();
            int svar;
            bool lyckad = int.TryParse(svarString, out svar);

            if(svar == 0){
                System.Console.WriteLine("Sak: " + stuff[0] + "\nLikable: " + likables[svar] +  "\npris: " + prizes[svar] + "\nÄr den förbannad? " + isPosessedString); //Lägg till om den är posessed 
            }
             if(svar == 1){
                System.Console.WriteLine("Sak: " + stuff[1] + "\nLikable: " + likables[svar] +  "\npris: " + prizes[svar]  + "\nÄr den förbannad? " + isPosessedString); 
            }
             if(svar == 2){
                System.Console.WriteLine("Sak: " + stuff[2] + "\nlikable: " + likables[svar] +  "\npris: " + prizes[svar]  + "\nÄr den förbannad? " + isPosessedString); 
            }
            Console.ReadLine();
            Buy(svar);
        }

        public void Buy(int svar){
            System.Console.WriteLine("Vill du köpa? [Y/N]");
            string svarString = Console.ReadLine();
            if (svarString.ToUpper() == "Y") 
            {
               money =  money - prizes[svar];            
               System.Console.WriteLine(money);
               inventory.Add("woop");
            }
            else if (svarString.ToUpper() == "N")
            {
               System.Console.WriteLine("Oki");
            }
        }

        public bool IsPosessed()
        {

            isPosessed = generator.Next(2);
        
            if (isPosessed == 1)
            {
                posessed = true;
                return posessed;
            }
            else if (isPosessed == 0)
            {
                posessed = false;
                return posessed;
            }
            else {
                return posessed;
            }
            
                
        }


    }
}
