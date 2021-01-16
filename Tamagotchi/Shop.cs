using System.Runtime.ConstrainedExecution;
using System.Net.Security;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.ComponentModel;
using System.Linq;



namespace Tamagotchi
{
    public class Shop //En klass som fungerar som en affär. Användaren sak kunna köpa olika objekt med olika egenskaper. Detta är en sperat
    //klass eftersom den ska kunna nås genom hela spelet, även om fler tamagutchis skapas ska affären fortfarande vara samma affär. Det är 
    //Dessutom public då den behövs nås i både "game" klassen och "tamagutchi" klassen.
    {

        private int money = 15; //Variabel för pengar som användaren kan köpa för. Den är prvat då den bara behövs användas i lokala uträkningar.
        public int svarShop; // En int som är ett svar som bara används i affären. Dock är den publik eftersom den även används i tamagutchi
        //klassen när den ska använda samma objekt som finns i affären. Eftersom de befinner sig på samma plats används SvarShop variabeln
        //för att bestämma rätt plats.  
        public List<string> shopShelf = new List<string>() { "Choklad", "arg Lakris" }; //En lista som innehåller alla objekt som finns i
        //shoppen. Den är public eftersom den även används i klassen tamagutchi i komandor "contain" som kollar om användarens inventory har 
        //samma objekt som finns i shopen (föklaras mer utförligt vid det kodblocket). 
        private List<int> prizes = new List<int>() { 10, 1 }; //Det här är en lista som räknar upp priset för det som finns i afären. Den är 
        //private eftersom den bara används lokalt. 
        private List<int> likables = new List<int>() { 5, -1 }; //Det här är en lista som räknar upp älskvärdheten för det som finns i afären.
        // Den är private eftersom den bara används lokalt. 




        private void PrintShelf() //Detta är en mycket enkel metod som enbart räknar upp de string som finns i shopShelf listan. Dens syfte är 
        //Att låta användaren veta vad hen kan köpa. Detta gör den genom en for loop. En foorloop går ut på att räkna upp kodblocket under 
        //Ett speciellet antal gånger. Denna forloop körs så många gånger som det finns objet i listan. Den använder en foorloop och inte en 
        //forechloop eftersom den både är tänkt att räkna upp platsen som objektet befinner sig på och själva objektet. Ifall bara objektet 
        //skulle räknas upp hade en foreachLoop fungerat bättre eftersom den är kortare. 
        {
            System.Console.WriteLine("Dina Pengar: " + money);
            for (int u = 0; u < shopShelf.Count; u++)
            {
                System.Console.WriteLine(u + ". " + shopShelf[u]); 
            }
        }


        public void Choice(Tamagotchi tam) //Denna metod har som syfte att räkna upp och ge de val och dess egenslkaper såsom kostnad och  
        //hur mycket tamagutchin gillar objektet. Metoden använder sig av en parameter instansen "Tam". Detta är för att kunna skicka in den i
        //Metoden "Buy" där användningen för parametern föklaras mer utförligt. Metoden är public eftersom den behöver nås i klassen "Game"
        //Där själva spelet körs. Desutom är det en void eftersom ingenting behövs retuneras. Först anroppar den metoden PrintShelf vilket är
        //En klass som har som uppgift att skriva ut de objekt som finns i afärrshyllan (beskrivs mer utföligt ovan). Därefter får användaren
        //Valet att välja mellan de olika objekten genom en string. Stringen omvandlas till en int genom en trypars. Detta är användbart för
        //att kunna använda svaret spelaren skrev in till att ta fram det objekt som finns i de olika listorna över objekten och dess egenskaper.
        //Därefter skrivs alla egenskaper över objektet upp såsom pris och vad hur mycket den gillas av användaresn gutchi. Tillsisst anroppas
        //Metoden Buy som låter användaren bekräfta köpet. Här används även parametern som skickas in i metoden. 
        {
            PrintShelf();
                System.Console.WriteLine("Vilken vill du titta närmare på?");
            string svarString = Console.ReadLine();

            svarString = InvalidAnswer(svarString, "0", "1");
            bool lyckad = int.TryParse(svarString, out svarShop);


            if (svarShop == 0)
            {
                System.Console.WriteLine("Sak: " + shopShelf[0] + "\nÄlskvärd nivå: " + likables[svarShop] + "\npris: " + prizes[svarShop]); //Lägg till om den är posessed ... + "\nÄr den förbannad? " + isPosessedString
            }
            else if (svarShop == 1)
            {
                System.Console.WriteLine("Sak: " + shopShelf[1] + "\nÄlskvärd nivå: " + likables[svarShop] + "\npris: " + prizes[svarShop]); // + "\nÄr den förbannad? " + isPosessedString
            }
            Console.ReadLine();
            Buy(tam);
        }


        private void Buy(Tamagotchi tam) //Den här metoden har som uppgift att ge valet till användaren om den vill köpa objektet eller 
        //inte. Om spelaren väljer att köpa det läggs det in i spelarens inventory som sedan kan användas. Metoden är igentligen en del av 
        //choises metoden, men jag gjord eden separat eftersom den focuserade på ett eget område. Genom att dela upp det i två var det mindre kod
        //per metod vilket dessutom gjorde det lättare att få en god överblick över koden. Metoden tar även in en paramter.
        //Eftersom inventory finns i tamagutchii klassen behöver vi skapa en instans för att komma åt inventory. Eftersom en ny tamagutchi
        //inte ska skapas behövs en redan befintliga tamagutchin refereras till. Anars skulle objektet som användaren köppte läggas in i ett
        //Separat inventory i en annan tamagutchi, och man skulle därför inte kunna använda objektert. Metoden är en void eftersom ingenting
        //behövs retuneras. Metoden har som uppgift att bekräfta valet av köpet och lägga in obejtet i inventoryt. Desutom är den Privet då
        //metoden bara används inom klassen "Shop" och inte behövs nå utanför. 
        {

            System.Console.WriteLine("Vill du köpa? [Y/N]");
            string svarString = Console.ReadLine();
            svarString = InvalidAnswer(svarString, "Y", "N"); //Den anropar metoden invalid answer för att säkerställa att spelaren inte skriver 
            //In ett ogilltigt svar. Den skickar in tre parametrar. Svarstring = svaret som sanvändaren skriver in, och de två giltiga svaren
            //Y och N

            if (svarString.ToUpper() == "Y")
            {
                money = money - prizes[svarShop];
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
