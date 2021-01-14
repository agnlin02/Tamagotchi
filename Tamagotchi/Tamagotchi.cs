using System.Runtime.CompilerServices;
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
        string svar = "";
        private int hunger = 10;
        private int boredom = 10;
        private List<string> words = new List<string>() { "Hello" };
        // public List<string> inventory = new List<string>() {};
        public List<string> inventory = new List<string>() { };
        public bool isAlive = true;
        private Random generator = new Random();
        int randomWord;
        Shop shops = new Shop();



        public string name;

        public void Feed()
        {

            bool containChokolate = inventory.Contains(shops.stuff[0]);
            bool containLakris = inventory.Contains(shops.stuff[1]);

            if (containChokolate == true || containLakris == true)
            {
                if (containChokolate == true)
                {
                    System.Console.WriteLine("Vill du använda din choklad? [Y/N]");
                    string svar = Console.ReadLine();
                    if (svar.ToUpper() == "Y")
                    {
                        System.Console.WriteLine("Du använde choklad. Hunger gick upp 4");
                        hunger += 2;
                        Console.ReadLine();
                        inventory.Remove(inventory[0]);

                    }
                    else if (svar.ToUpper() == "N")
                    {
                        System.Console.WriteLine("ok. hungern gick bara upp 2");
                    }
                    Console.ReadLine();
                }
                else if (containLakris == true)
                {
                    System.Console.WriteLine("....Lakris är inte gott..alls \nDin hunger gick ned 1-");
                    hunger -= 1;
                    inventory.Remove(inventory[1]);
                }

                //           if(shops.posessed == true)
                // {
                //     System.Console.WriteLine("Ditt sak var förbannad. Hungern gick ner 4-");
                //     hunger -=4;
                // }

            }
            else
            {
                hunger += 2;

            }

            System.Console.WriteLine("Hungern minskade");
            Console.ReadLine();


        }
        public void Hi()
        {

            randomWord = generator.Next(words.Count);
            Console.WriteLine(words[randomWord]);
            Console.ReadLine();
            System.Console.WriteLine("Tråkighet minskade");
            Console.ReadLine();

        }
        public void Teach()
        {
            System.Console.WriteLine("Vilket ord vill du lära din Tamaguchi?");
            svar = Console.ReadLine();

            words.Add(svar);
            ReduceBoredom();

            System.Console.WriteLine("Guchi lärde " + svar);
        }
        public void Tick()
        {
            boredom -= 2;
            hunger -= 2;
        }

        public bool GetAlive()
        {
            if (boredom < 1 || hunger < 1)
            {
                return isAlive = false;
            }
            else if (boredom > 0 || hunger > 0)
            {
                return isAlive = true;
            }
            else { return isAlive; }
        }
        public void PrintStats()
        {
            System.Console.WriteLine("Det här är dina stats: ");
            GetAlive();
            System.Console.WriteLine("Ord din gutchi kan: ");
            foreach (string i in words)
            {
                System.Console.WriteLine(i);  //Du ska kunna foreach...det är kortare än en for loop, fast bara på listor (inte arrayer) :)
            }
            System.Console.WriteLine("Boredom " + boredom);
            System.Console.WriteLine("Hunger " + hunger);
            if (isAlive == false)
            { System.Console.WriteLine("Din gutchi är död.."); }
            else if (isAlive == true)
            { System.Console.WriteLine("Din gutchi lever än!"); }
            Console.ReadLine();

        }

        private void ReduceBoredom()
        {
            boredom += 2;
        }

        public void Dead()
        {
            System.Console.WriteLine("Ledsen...din gutchi dog ://");
            Console.ReadLine();
            if (hunger < 1)
            {
                System.Console.WriteLine("Gutchi dog av hunger. Glömde du mata?");
                Console.ReadLine();
            }
            else if (boredom < 1)
            {
                System.Console.WriteLine("Din gutchi dog av att vara för utråkad");
                Console.ReadLine();
            }
        }

        public void Inventory()
        {
            System.Console.WriteLine("ditt inventory: ");
            foreach (string i in inventory)
            {
                System.Console.WriteLine(i);
            }
            Console.ReadLine();
        }

    }


}
