using System.Net.Http.Headers;
using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace Tamagotchi
{
    public class Tamagotchi
    {
        private int hunger = 10;
        private int boredom = 10;
        private List<string> words = new List<string>();
        private bool isAlive;
        private Random generator = new Random();
        public string name;

        public void Feed()
        {
            hunger += 2;
        }
        public void Hi()
        {
            int randomWord = generator.Next(words.Count);
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
            boredom -= 2;
        }
    }

}
