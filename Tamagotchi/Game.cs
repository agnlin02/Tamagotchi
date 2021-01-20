using System;

namespace Tamagotchi
{
    public class Game //En klass som innehåller själva spelet. Det är i denna klass som alla metoder från de övriga klasserna samlas
    //för att kunna köra spelet. Anledningen till att det här är en separat klass och inte en del av main i program.cs är för att 
    //uppnå så lite information i main som möjligt. Det gör det även lättare att få en överblick över själva spelet samt kunna korrigera
    //koden senare. Eftersom metoderna i klassen ska kunna anropas i program.cs behöver klassen vara pubic. 
    {
        string svar = ""; //Skapar en tom sting där användarens svar lagras.
        int usernumber; //Skapar en tom int där användarens svar lagras efter att den har typkonverterats från en string till en int.
        Tamagotchi minTimagotchi = new Tamagotchi(); //Skapar en instans till klassen "tamagutchi".
        Shop shop = new Shop(); //Skapar en instans till klassen shop.

        //Smatliga variablar är privata då de antinen används lokalt eller skickas mellan klasserna genom paramterar. De har därför inget
        //Behov att vara publika.





        void WriteChoises() //Denna metod skriver upp de olika alternativ för vad spelaren kan göra. Desutom får spelaren möjlighet att ge 
        //ett svar på vad hen vill göra. Metoden är inte public eftersom den endast används lokalt, i metoden chises. Metoden behövs inte 
        //anroppas mellan klasserna. Metoden har som syfte att informera spelaren över vad hen kan göra i spelet.
        {
            System.Console.WriteLine("Vad vill du göra?");
            System.Console.WriteLine("1. Lära min Tamaguchi ett ord"); 
            System.Console.WriteLine("2. Mata min Tamagutchi"); 
            System.Console.WriteLine("3. Prata med min Tamaguchi"); 
            System.Console.WriteLine("4. Stats för Gutchi"); 
            System.Console.WriteLine("5. SHOP!"); 
            System.Console.WriteLine("6. inventory"); 
            svar = Console.ReadLine(); //String variabeln "svar" har redan skapats tidigare i klassen. Denna bit kod lagrar det svar användaren
            //Skriver in i variabelnd "Svar". 
        }
        public void TheGame() //Denna metod har i uppgift att spela upp händelserna i spelet efter att användaren skrivit in sitt val. Det är
        //i denna metod som hela spelet utspelrar sig i. Den är därför vikit då metoden "pusslar" ihop alla metoder från de olika klasserna 
        //till ett spel.
        //Majoriteten av koden befinner sig inom en while loop. Detta gör det möjligt för spelaren att forsätta spelet ända tills 
        //tamaguthin dör. Loopen pågår tills boolen "isAlive" blir falsk, altså att tamagutchin dör. Därefter görs användarens svar om från
        //string till int. Detta är nödvändigt för att kunna se så att användaren skriver in ett svar med siffron och inte text, samt kunna
        //se om svaret är giltigt. Därefter kollar programet om användaren har skrivit in ett svar som matchar någon av alternativen (större
        //än 0 men mindre än 7). Om användaren skriver ett för högt, för lågt eller ett svar med text körs ingen av alternativen, utan 
        //Programet kommenterar på vilka svar som är giltiga. På så sätt får användaren reda på vilka svar som hen kan skriva in.
        //Därefter spelas loopen om och användaren får ett nytt försök att svara. Detta pågår
        //Tills användaren skriver in ett giltigt svar. Om användaren skriver in ett rätt svar körs kodblocker inom den ifsatsen som mathcar svaret. 
        //I denna ifsats kollar programet vilket av alternativen spelaren valde. Beroende på vilket val användaren vade anroppas olika metoder.
        //Om användaren valde att mata sin tamagutchi anroppas feed metoden som finns i Tamagutchi klassen. Om användaren valde att handla i 
        //affären anropas metoden ShopChoises som finns i affärklassen. Eftersom alla metoder finns i separata klasser måste man först referera 
        //till den instans man vill anropa metoden ifrån. Metoden TheGame (som heter TheGame eftersom metoden går ut på att inehålla hela spelet
        //) är publik eftersom den anroppas i program.sc. Det är desurtom en void då den inte behöver
        //retunera något värde. 
        {
            while (minTimagotchi.isAlive == true) //Loppen körs tills boolen isAlive i klassen Tamagutchi blir falsk, altså att 
            //gutchin dör. Eftersom boolen finns i en annan klass måste man först referera till den klass och till den tamagutchin
            // som man vill hämta variabeln irfån. Detta görs genom att referera till instansen som skapades tidigare i programet.
            {
                minTimagotchi.Tick();
                WriteChoises();

                bool lyckad = int.TryParse(svar, out usernumber);


                if (usernumber > 0 && usernumber < 7)
                {


                    if (svar == "1")
                    {
                        minTimagotchi.Teach();
                    }
                    else if (svar == "2")
                    {
                        minTimagotchi.Feed();
                    }
                    else if (svar == "3")
                    {
                        minTimagotchi.Hi();
                    }
                    else if (svar == "4")
                    {
                        minTimagotchi.PrintStats();
                    }
                    else if (svar == "5")
                    {
                        System.Console.WriteLine("Shop!");
                        shop.ShopChoice(minTimagotchi); //En parameter skickas in med instansen minTiamgocthi. (beskrivs mer utförligt vid
                        //den metoden varför metoden tar emot en parameter.)
                    }
                    else if (svar == "6")
                    {
                        minTimagotchi.Inventory();
                    }

                }
                else
                {
                    System.Console.WriteLine("Du måste skriva ett av nummrerna ovan [1,2,3,4,5 eller 6]");
                    Console.ReadLine();
                }

            }
            minTimagotchi.Dead();
        }


    }
}
