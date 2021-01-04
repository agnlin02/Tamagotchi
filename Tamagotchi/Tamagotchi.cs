using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tamagotchi
{
    public class Tamagotchi
    {
        private int hunger = 10;
        private int boredom = 10;
        private List<string> words = new List<string>() {"Hello"};
        // public List<string> inventory = new List<string>() {};
        private bool isAlive;
        private Random generator = new Random();
        int randomWord;
        Shop shops = new Shop();

        
   
        public string name;

        public void Feed()
        {
            
            bool containChokolate = shops.inventory.Contains(shops.inventory[0]);
            bool containLakris = shops.inventory.Contains(shops.inventory[1]);
            
            if (containChokolate == true || containLakris == true)
            {
                if(containChokolate == true)
                {System.Console.WriteLine("Vill du använda din choklad? [Y/N]");
                string svar = Console.ReadLine();
                if (svar.ToUpper()=="Y")
                {
                    System.Console.WriteLine("Du använde choklad. Hunger gick upp 4");
                    hunger += 2;
                    Console.ReadLine();
                    shops.inventory.Remove(shops.inventory[0]);
                    
                }
                else if(svar.ToUpper()=="N")
                    {
                        System.Console.WriteLine("ok. hungern gick bara upp 2");
                    }
                    Console.ReadLine();
                }
                    else if( containLakris == true)
                    {
                        System.Console.WriteLine("....Lakris är inte gott..alls \nDin hunger gick ned 1-");
                        hunger -=1;
                        shops.inventory.Remove(shops.inventory[1]);
                    }

            //           if(shops.posessed == true)
            // {
            //     System.Console.WriteLine("Ditt sak var förbannad. Hungern gick ner 4-");
            //     hunger -=4;
            // }
                
            }
            else{
                hunger += 2;
            }
            
            
        }
        public void Hi()
        {
            
            randomWord = generator.Next(words.Count);
            Console.WriteLine(words[randomWord]);
            Console.ReadLine();

        }
        public void Teach(string word)
        {
            words.Add(word);
            ReduceBoredom();
        }
        public void Tick()
        {
            boredom = -2;
            hunger = -2;
        }
         public bool GetAlive()
        {
            if (boredom <= 0 || boredom <= 0)
            {
                isAlive = false;
            }
            if (boredom > 0 || boredom > 0)
            {
                isAlive = true;
            }
            return isAlive;
        }
        public void PrintStats()
        {
            System.Console.WriteLine("Ord din gutchi kan: ");
            foreach (string i in words)
            {
                System.Console.WriteLine(i);  //Du ska kunna foreach...det är kortare än en for loop, fast bara på listor (inte arrayer) :)
            }
            System.Console.WriteLine("Boredom " + boredom);
            System.Console.WriteLine("Hunger " + hunger);
            System.Console.WriteLine(isAlive);
            Console.ReadLine();

        }
       
        private void ReduceBoredom()
        {
            boredom += 2;
        }
        
        }

}
