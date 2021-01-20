using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tamagotchi
{
    public class Tamagotchi //Denna klass har i uppgift att innehålla alla metoder som är driekt kopplade till tamagutchin. Det är en separat
    //klass av flera anledningar. För det första delar det upp koden på ett bra sätt. Desutom ger det möjlighet att enkelt kunna skapa fler 
    //tamagutchis som spelaren skulle kunna köra med. Det är en publik klass eftersom den används i både game klassen och Shop klassen.
    {
        string svar = "";
        private int hunger = 10;
        private int boredom = 10;
        private List<string> words = new List<string>() { "Hello" }; //Detta är en lista eftersom fler ord ska kunna läggas in. Listor
        //är dynamiska och kan därför ändras efter ord som läggs in. 
        public List<string> inventory = new List<string>() { };//Detta är en lista eftersom fler föremål ska kunna läggas in. Listor
        //är dynamiska och kan därför ändras efter föremål som läggs in. 
        public bool isAlive = true;
        private Random generator = new Random();
        int randomWord;
        Shop shops = new Shop();

        public void Feed() //En metod som låter spelaren mata sin tamagutchi. Den börjar med att skapa två bools som har i uppgift att se 
        //ifall listan inventory innehåller ett av samma objekt som finns i listan shopshelf. Programet kollar Ifall den innehåller samma
        //sak som i listan (altså att boolen är true) genom en if sats. Finns föremålet kan spelaren använda det föremålet. Detta görs 
        //genom att köra kodblocket under. Spelaren får då valet om hen vill använda föremålet. svaret sparas i den tomma stingen "svar".
        //För att säkerställa att användaren inte skriver in fel anropas meroden "InvalidAnswer" som finns i Shop.cs klassen. Denna metod 
        //föklaras mer utförligt vid själva metoden. Metoden är publik eftersom den refereras bortom denna metod, i game klassen. Desstuom 
        //behövs ingenting retuneras och metoden är därför en void. Metoden har två syften. Till att börja med skapat det mer spelmöjligheter
        //för användaren. Desutom gör det möjligt för användaren att hålla sin tamagucthi vid liv. Om denna metod inte skulle finnas 
        //finns inget anant sätt att mata tamagutchin. Gucthin skulle då dö av hunger.
        {

            bool containChokolate = inventory.Contains(shops.shopShelf[0]);
            bool containLakris = inventory.Contains(shops.shopShelf[1]);

            if (containChokolate == true || containLakris == true)
            {
                if (containChokolate == true)
                {
                    hunger = UseChokolate(); //Om spelaren har choklad i sitt inventory Anropar UseChokolate som låter användaren att använda 
                    //chokladen.
                }

                if (containLakris == true) //Om spelaren har choklad i sitt inventory Anropar UseChokolate som låter användaren att använda 
                                           //chokladen.
                {
                    hunger = UseLakris();
                }
            }

            hunger += 2;//Eftersom spelaren valde att mata sin tamagutchi kommer spelaren ge sin tamagutchi mat, även om de inte har några 
                        //föremål. Därför adderas 2 till hunger variabeln.


            System.Console.WriteLine("Hungern minskade");
            Console.ReadLine();
        }


        private int UseChokolate() //Denna metod går ut på att låta användaren använda chokladen (ifall det finns i spelarens inventory). 
        //Syftet med metoden är att låta spelaren känna att den får anvädning för de objekt hen köper. Desutom är det ett sätt att behålla 
        //tamagutchin levande under en längre tid. Metoden är en int då den behöver retunera inten hunger till resten av spelet.
        {
            System.Console.WriteLine("Vill du använda din choklad? [Y/N]");
            string svar = Console.ReadLine();

            svar = shops.InvalidAnswer(svar, "Y", "N"); //Metoden skickar in tre stycken parametrar. Svar är det svaret som 
                                                        //användaren skriver in. Y och N är de giltiga svaren som användaren måste skriva in.
                                                        //anledningen till varför denna metod anropas är för att unvika att spelaren skriver fel svar.

            if (svar.ToUpper() == "Y") //Om användaren vill använda chokladen skriver programet ut vad som händer (att hungenr går upp
                // 4) och så går hungenr upp 4, samt att föremålet i inventoryt tas bort så att spelaren inte kan återanvända föremålet.
            {
                System.Console.WriteLine("Du använde choklad. Hunger gick upp 4");
                hunger += 2; //variabeln "hunger" adderas med 2. Eftersom hungern adderas en extra gång med 2 i slutet av metoden
                //Behövs bara 2 adderas i detta kodblock för att hungern ska gå upp med 4 (2+2 = 4). Hunger variabeln ökar dubbelt eftersom
                //tamagutchis älskar choklad, och blir då därför mättare.
                Console.ReadLine();
                inventory.Remove(inventory[0]); //tar bort föremålet som ligger på plats 0 (chokladen). 

            }
            else if (svar.ToUpper() == "N") //Om användaren inte vill använda föremålet matar användaren sin gutchi med pellets och
                                            //hunern går bara upp 2. VAriabeln hunger adderas då med 2. 
            {
                System.Console.WriteLine("ok. Du matar din gutchi med vanliga pellets. Hungern gick bara upp 2");

            }
            Console.ReadLine();
            return hunger;
        }


        private int UseLakris() //Denna metod går ut på att låta användaren använda Lakrisen (ifall det finns i spelarens inventory). 
        //Syftet med metoden är att låta spelaren känna att den får anvädning för de objekt hen köper. Desutom är det ett sätt att skaffa lite
        //strategi i spelet (eftersom lakrisen är skadlig och försämrar changserna för gutchin att överleva). Detta skapar även mer gameplay. 
        //Följande kod är nästan densamma som i Usechokolate. De största skillnaderna är texten samt att varabeln hunger ökar mindre.
        {
            System.Console.WriteLine("Vill du använda din Lakris? [Y/N]");
            string svar = Console.ReadLine();
            if (svar.ToUpper() == "Y")
            {
                System.Console.WriteLine("Du använde Lakris.");
                System.Console.WriteLine("....Lakris är inte gott..alls \nDin hunger gick upp bara 1");
                hunger -= 1; //eftersom programet adderar 2 till hungern, behövs -1 dras av från hunger variabeln för att den totala 
                             //hungern ska ha gått upp 1 (2-1=1). Detta är eftersom tamaguthi inte gillar lakris (med goda anledningar), och därav
                             //blir tamaguthin inte lika mätt. 
                inventory.Remove(inventory[1]);

            }
            else if (svar.ToUpper() == "N")
            {
                System.Console.WriteLine("ok. Hungern gick upp 2");
            }
            Console.ReadLine();
            return hunger;
        }

        public void Hi() //denna metod har i uppgift att skriva ut ett slumpmässigt ord till användaren. Till att börja med deffineras den 
        //slupgnerator som skapades tidigare. Denna slupgenerator slupar en siffra mellan antalet ord i listan "words" som består av alla ord
        //Gutchin kan. Count i words.count räknar upp alla platser i words. Därefter skrivs ordet ut som befinner sig på den platsen 
        //slumpegenratorn slumpade ordet. Därefter antroppar metoden metoden "ReduceBoredome" som minskar tamagutchins trågighet genom att 
        //addera 2 till variabeln boredom. Programet skriver ut vad som hände (trågigheten minskade. Denna metod är nödvändig eftersom den
        //låter användaren komunucera med sin tamagutchi. Detta skapar mer gameplay, mer interaktivitet samt ett sätt att minska tamaguthcins
        //trågighet.
        {

            randomWord = generator.Next(words.Count);
            Console.WriteLine(words[randomWord]);
            Console.ReadLine();
            ReduceBoredom();
            System.Console.WriteLine("Tråkighet minskade");
            Console.ReadLine();

        }
        public void Teach() //Denna metod låter användaren lära tamagutchin ett ord. Det är relevant för att listan "word" ska kunna växa, få
        //metoden Hi() att slumpa mellan fler ord, skapa mer gameplay samt ett till sätt att minska tråkigheten hos tamagutchin. Först skrivs 
        //en ledande fråga till spelaren så att spelaren vet vad hen ska göra. Svaret sparas då i den tomma stringen "svar". Därefter läggs
        //det svar som användaren skrev in i listan word. Eftersom användarens svar har sparats i variabeln svar, läggs användaresn svar in i
        //listan när variabeln svars lägs in. Därefter anropas metoden "reduceBoredome" som minskar gutchinns tråkighet. Detta är eftersom
        //Gutchin tcyker att det är kul att lära sig något nytt. 
        {
            System.Console.WriteLine("Vilket ord vill du lära din Tamaguchi?");
            svar = Console.ReadLine();

            words.Add(svar);
            ReduceBoredom();

            System.Console.WriteLine("Guchi lärde " + svar);
        }
        public void Tick()//Tick har som uppgift att minska hungern och tråkigheten efter varje runda av spelet. Det gör det möjligt för
        //Spelaren att förlora då hungern och tråkigheten har risken att gå under 0, och därefter dör tamagutchin. 
        {
            boredom -= 2;
            hunger -= 2;
        }

        public bool GetAlive() //Get alive är en bool som har i uppgift att retunera om variabeln isAlive är sann eller fals. Altså ifall 
        //tamagutchin lever eller inte. Detta gör det även möjligt för spelarns tamagutchi att dö och därmed avsluta, och förlora spelet.
        {
            if (boredom < 1 || hunger < 1) //Kollar om tamagutchin inte har slut på hunger, eller slut på tråkighet. Om tamagutchins hunger
            //eller tråkighet (variabeln boredome och hunger) har gått under 1 förändras boolen isAlive till falsk, altså att tamagutchin dör.
            //Denna variabel retuneras senare för att kunna användas i både klass Game (spelet körs medan isAlive = true, altså gutchin lever
            //och avslutas när isAlive = false, altså att gutchin dör) och i lokala beräkningar (PrintStats).  
            {
                return isAlive = false;
            }
            else if (boredom > 0 || hunger > 0) //Om tamagutchin å andra sidan inte har variabeln hunger eller boredome under 1, altså
            //högre än 0 är boolen isAlive true, altså att tamagutchin lever. Denna variabel retuneras senare för att kunna användas i 
            //både klass Game (spelet körs medan isAlive = true, altså gutchin lever) och i lokala beräkningar (PrintStats). 
            {
                return isAlive = true;
            }
            else { return isAlive; } //Även om detta kodblock alltid körs måste det finnas en möjlighet att retunera isAlive, även om 
            //Det aldrig kommer spela detta kodblock. Detta är eftersom programmet C# inte vet ifall detta kodblock har möjlighet att 
            //köras eller inte.
        }
        public void PrintStats() //Denna metod gör det möjligt för användaren att se statestik över sin tamagutchi. Här räknas all information
        //som är nödvändig för användaren att veta om sin tamagutchi. 
        {
            System.Console.WriteLine("Det här är dina stats: ");
            GetAlive(); //Måste anroppa GetAlive metoden för att veta om isAlive är sant eller falsk. Om den inte skulle anroppa denna metod 
            //Skulle isAlive inte uppdateras och därav skulle gutchin inte kunna dö.
            System.Console.WriteLine("Ord din gutchi kan: "); //Skriver ut alla ord som gutchin kan. Detta görs genom en forEachloop. Den 
            //fungerar på så sätt att för varje sak i listan word körs loopen, där Loopen skriver sedan ut stringsen i listan. Detta skulle 
            //också kunnat gjorts med en foor loop, men eftersom en forech lopp är kortare i detta samanhang var den loopen bättre anpassad till
            //syftet.
            foreach (string i in words)
            {
                System.Console.WriteLine(i);
            }
            System.Console.WriteLine("Boredom " + boredom); //Metoden skriver ut hungern och hur utråkad gutchin är.
            System.Console.WriteLine("Hunger " + hunger);
            if (isAlive == false) //med hjälp av en ifsast skriver metoden ut om tamaguchin lever eller är död. Om boolen Isalive är sann
            //skriver programet ut att gutchin levert. Om istället boolen isalive är falsk skriver programet ut att gutchin är död. Här är
            //det vikigt att tidigare i metoden refererat till Getalive() metoden. körs inte den metoden och boolen isalive uppdateras inte.
            { System.Console.WriteLine("Din gutchi är död.."); }
            else if (isAlive == true)
            { System.Console.WriteLine("Din gutchi lever än!"); }
            Console.ReadLine();

        }

        private void ReduceBoredom() //En metod som minskar gutchins tråkighet genom att adera variabeln boredome. Detta är nödvändigt 
        //för att användas i andra metoder.
        {
            boredom += 2;
        }

        public void Dead() //Denna void spelas i slutet av spelet när tamagutchin har dött. Den skriver också ut anledningen till döden.
        //Detta gör det möjligt för spelaren att både veta ved hen gjorde fel och desutom få reda på att guthcin dog.
        {
            System.Console.WriteLine("Ledsen...din gutchi dog ://");
            Console.ReadLine();
            if (hunger < 1) //Om hungern är under 1 dog gutchin av hunger. Detta komenterar programmet på. 
            {
                System.Console.WriteLine("Gutchi dog av hunger. Glömde du mata?");
                Console.ReadLine();
            }
            else if (boredom < 1) //Om trågigheten är under 1 dog gutchin av utråkighet. Detta komenterar programmet på. 
            {
                System.Console.WriteLine("Din gutchi dog av att vara för utråkad");
                Console.ReadLine();
            }
        }

        public void Inventory() //Denna metod har som uppgift att skriva ut alla saker i spelarens inventory. Precis som i Printstats() används
        //en foreachloop. Den fungerar på så sätt att för varje sak i listan inventory körs loopen, där Loopen skriver sedan ut stringsen i 
        //listan. Detta skulle också kunnat gjorts med en foor loop, men eftersom en forech lopp är kortare i detta samanhang var den loopen
        // bättre anpassad till syftet.
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
