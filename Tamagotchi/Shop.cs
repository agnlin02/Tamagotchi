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

        public int money = 15;
        public int svarShop;
        public List<string> shopShelf = new List<string>() { "Choklad", "arg Lakris" };
        private List<int> prizes = new List<int>() { 10, 3, 1 };
        public List<int> likables = new List<int>() { 5, 2, -1 };

        private Random generator = new Random();




        public void PrintStuff()
        {
            System.Console.WriteLine("Dina Pengar: " + money);
            for (int u = 0; u < shopShelf.Count; u++)
            {
                System.Console.WriteLine(u + ". " + shopShelf[u]);  //Du ska kunna foreach...det är kortare än en for loop, fast bara på listor (inte arrayer) :)
            }
        }


        public void Choice(Tamagotchi tam)
        {

            string svarString = Console.ReadLine();

            svarString = InvalidAnswer(svarString, "0", "1");
            bool lyckad = int.TryParse(svarString, out svarShop);


            if (svarShop == 0)
            {
                System.Console.WriteLine("Sak: " + shopShelf[0] + "\nLikable: " + likables[svarShop] + "\npris: " + prizes[svarShop]); //Lägg till om den är posessed ... + "\nÄr den förbannad? " + isPosessedString
            }
            else if (svarShop == 1)
            {
                System.Console.WriteLine("Sak: " + shopShelf[1] + "\nLikable: " + likables[svarShop] + "\npris: " + prizes[svarShop]); // + "\nÄr den förbannad? " + isPosessedString
            }
            Console.ReadLine();
            Buy(svarShop, tam);
        }


        public void Buy(int svar, Tamagotchi tam) 
        {

            System.Console.WriteLine("Vill du köpa? [Y/N]");
            string svarString = Console.ReadLine();
            svarString = InvalidAnswer(svarString, "Y", "N");

            if (svarString.ToUpper() == "Y")
            {
                money = money - prizes[svar];
                System.Console.WriteLine("Pengar kvar: " + money);
                tam.inventory.Add(shopShelf[svarShop]);
                System.Console.WriteLine("Antal saker i ditt inventory: " + tam.inventory.Count);

            }
            else if (svarString.ToUpper() == "N")
            {
                System.Console.WriteLine("Oki");
            }
        }


        public string InvalidAnswer(string svarWrong, string svarRight, string svarRigt2) //En metod som körs varje gång användaren skriver 
        //fel svar. Metoden kör då en while loop som körs tills användaren skriver in rätt svar. För att se om användaren skriver in rätt svar
        //Används en if sats. För att metoden ska vara generell och kunna appliceras för alla olika typer av svar tar metoden in tre parametrar.
        //Den första parametetn "svarWrong" tar in det felaktiga svaret som spelaren har skrivit. Spelaren behöver skriva in olika svar
        //I olika delar av spelet. Därför är det en parameter. Parameterarna svarRight och svarRight2 är två parametrar som används för att 
        //Programet ska veta vilket som är de giltiga svaren. Dessa parametrar gör även metoden generell då användaren kan skriva vilket svar
        //som helst, men programet kan också skicka in vilka giltiga svar som helst.
        //Metoden är public för att den ska kunna användas vartsomhelst. Metoden är desutom en string metod. Detta är i syfte att man programet
        //ska kunna retunera det svar som spelaren svarade till den bit kod som efterfrågade efter ett giltigt svar. Om det skulle varit en
        //Void hade inget svar retunerats till resten av koden. En int metod hade fungerat, men enbart för svar som krävs i siffror. 

        {
            while (svarWrong.ToUpper() != svarRight || svarWrong.ToUpper() != svarRigt2)
            {
                System.Console.WriteLine("Bekräfta [" + svarRight + "/" + svarRigt2 + "]");
                svarWrong = Console.ReadLine();
                if (svarWrong.ToUpper() == svarRight || svarWrong.ToUpper() == svarRigt2)
                {
                    break;
                }
            }
            return svarWrong;
        }


    }
}
