using System.ComponentModel.Design;
using System;
using System.Runtime.ConstrainedExecution;
using System.Net.Security;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.ComponentModel;


namespace Tamagotchi
{
    public class Shop
    {
        int likable;
        int prize;
        int money;
        private List<string> stuff = new List<string>(){"hatt", "mat", "arg Lakris"};
        private Random generator = new Random();




        public void printStuff(){
                for (int u = 0; u < stuff.Count; u++)
                {
                     System.Console.WriteLine(u + 1  + " " + stuff[u]);  //Du ska kunna foreach...det är kortare än en for loop, fast bara på listor (inte arrayer) :)
                }
        }

        public void printstats(){
            System.Console.WriteLine("Likable: " + likable);
            System.Console.WriteLine("Prize: " + prize);
            System.Console.WriteLine("money: " + money);
        }


        public void choicde(){
            string svar = Console.ReadLine();
            if(svar == "1"){
                
            }
        }


    }
}
