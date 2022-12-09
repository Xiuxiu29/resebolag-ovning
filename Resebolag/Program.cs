using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using reseprogram;

List<Resebolag> verksamheter = new List<Resebolag>();

void Meny()
{
    Console.ReadKey();
    Console.Clear();
    Console.WriteLine("[1] Registrera en verksamhet \n[2] Ta bort en verksamhet\n[3] Söka på verksamheter \n[0] End program.");         //Menys innehåll

    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.D1:                         //ConsoleKey.D() gör att man inte behöver trycka på enter.

            while (true)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;               //Ändrar färg till grön. 
                Console.WriteLine("[Registrere en verksamhet.]");
                Console.ForegroundColor = ConsoleColor.Gray;                //Ändrar färg till grå sen.


                Console.WriteLine("Vilken verksamhet vill du registrera?");
                Console.WriteLine("Tre verksamheter kan du registretra: hotell, bb och vandrarhem. ");
                string verksamhet;
                verksamhet = Console.ReadLine();                //Läser in vad man ska registrera

                switch (verksamhet)                 //Switcha till olika aktivteter
                {
                    case "hotell":
                        Console.WriteLine("Hotell");
                        Hotell();
                        break;

                    case "bb":
                        Console.WriteLine("bb");
                        bb();
                        break;
                    case "vandrarhem":
                        Console.WriteLine("vandarhem");
                        vandrarhem();
                        break;
                }

                void Hotell()
                {

                    Console.WriteLine("Vad är namnet till Hotellet? ");
                    String namn = Console.ReadLine();

                    if (!Regex.IsMatch(namn, @"^[a-ö A-Ö]+$") || namn.Length < 2 || namn.Length > 20)       //Namnet ska vara mellan a-ö eller A-ö, det ska vara mindre än 20 och störe än 2 bostaver. 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Felaktigt namn, försök igen. ");                                 //Om inte fyller ovan krav
                        Console.ForegroundColor = ConsoleColor.Gray;

                    }
                    else                            //Sedan går vidare.
                    {
                        string nyverksamhet = "";        
                        Console.WriteLine("Ange orten");
                        String ort = Console.ReadLine();

                        Console.WriteLine("Vilken rumtyp är den?");
                        String rumtyp = Console.ReadLine();

                        Console.WriteLine("Hur många rum finns det?");
                        int rum = int.Parse(Console.ReadLine());

                        //while()
                        //{
                        //try
                        //{}
                        //OverflowException
                        //{}
                        //}

                        if (rum > 120) { rum = 120; }            //Om rum är större än 120 så = 120
                        if (rum < 0) { rum = 0; }

                        Console.WriteLine("Vilket betyg ska du sätta mellan 1-5 ?");
                        int betyg = int.Parse(Console.ReadLine());

                        verksamheter.Add(new Hotell(namn, ort, betyg, rum, rumtyp));

                
                        Console.WriteLine("Här är din hotell");
                        Console.Clear();

                    }
                    Meny();                 //Sedan går till meny igen. 
                }
                break;

            }
            break;


            void bb()
            {

                //List<Resebolag> verksamheter = new List<Resebolag>();

                string nyverksamhet = "";
            
                    Console.WriteLine("Vad är namnet till B&B? ");
                    string Namn = Console.ReadLine();

                    Console.WriteLine("Ange orten");
                    String ort = Console.ReadLine();

                    Console.WriteLine("Vilket betyg ska du sätta mellan 1-5 ?");
                    int betyg = int.Parse(Console.ReadLine());

                    Console.WriteLine("Hur mycket kostar B&B?");
                    int pris = int.Parse(Console.ReadLine());

                    verksamheter.Add(new BB(Namn, ort, betyg, pris));

                Console.WriteLine("Här är din B&B");
                Console.Clear();

                Meny();
            }

            void vandrarhem()
            {

                //List<Resebolag> verksamheter = new List<Resebolag>();

                    string nyverksamhet = "";
            
                    Console.WriteLine("Vad är namnet till Vandrarhem? ");
                    string Namn = Console.ReadLine();

                    Console.WriteLine("Ange orten");
                    String ort = Console.ReadLine();

                    Console.WriteLine("Vilket betyg ska du sätta mellan 1-5 ?");
                    int betyg = int.Parse(Console.ReadLine());

                    Console.WriteLine("Hur många rum finns det?");
                    int rum = int.Parse(Console.ReadLine());

                    if (betyg > 120) { betyg = 120; }            //Om rum är större än 120 så = 120
                    if (betyg < 0) { betyg = 0; }

                verksamheter.Add(new Vandrarhem(Namn, ort, rum, betyg));
             
                //Console.WriteLine("Här är din Vandrahem");
                Console.Clear();

                Meny();
            }



        case ConsoleKey.D2:
            Console.Clear();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Har du registerat en verksamhet? Om NEJ tryck på N! Om JA tryck på J!");
                Console.ForegroundColor = ConsoleColor.Gray;
                String answer = Console.ReadLine();
                if (answer == "N")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Man måste har registerat en verksamhet innan man söker.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                    goto case ConsoleKey.D1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;               //Ändrar färg till grön. 
                    Console.WriteLine("[Tar bort verksamhet.]");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine(" Vad heter den verksamhet du vill ta bort? hotell, bb eller vandrarhem? ");
                    string verksamhet;
                    verksamhet = Console.ReadLine();
                    Console.WriteLine("Vad är namnet?");
                    verksamhet = Console.ReadLine();

                     for (int i = 0; i < verksamheter.Count; i++)        //For loop som sätt value på verksamheten som man ska ta bort. 
                    {
                        if (verksamheter[i].getNamn() == verksamhet)       //getNamn hittar den namnet man skriver in som man vill ta bort.
                        {
                            verksamheter.RemoveAt(i);                   //När man har hittat namnet tas bort den och blir den value = 0
                        }
                        Console.WriteLine("Verksamhet har tagit bort!");
                        //Console.WriteLine(i);
                    }
                    Console.ReadKey();
                    break;

          
                }
            }
            break;


        case ConsoleKey.D3:
            Console.Clear();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Har du registerat en verksamhet? Om NEJ tryck på N! Om JA tryck på J!");
                Console.ForegroundColor = ConsoleColor.Gray;
                String answer = Console.ReadLine();
                if (answer == "N")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Man måste har registerat en verksamhet innan man söker.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadKey();
                    goto case ConsoleKey.D1;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;               //Ändrar färg till grön. 
                    Console.WriteLine("[Söker på verksamhet.]");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine("Vilken verksamhet ska du söka?");           // Användaren behöver skriva in vad den skall söka efter
                    string answer1 = Console.ReadLine();
                    Console.WriteLine("Skriv namnet på det du vill söka efter");

                    if (answer1 == "Hotell")
                    {
                        if(verksamheter.Count == 0)
                        {
                            Console.WriteLine("Verksamheten hittades inte");
                        }
                        string input = Console.ReadLine();                        // Skriv in vad man ska jämföra med. 
                        foreach (Resebolag verksamhet in verksamheter)
                        {
                            if (verksamhet.CompareName(input) == true)             //Här jämföra man med vad man har skrivit in. 
                            {
                                Console.WriteLine(verksamhet.getInfo());
                                
                            }
                        }

                    }
                    if (answer1 == "bb")
                    {
                        if (verksamheter.Count == 0)
                        {
                            Console.WriteLine("Verksamheten hittades inte");
                        }
                        string input = Console.ReadLine();                        // Skriv in vad man ska jämföra med. 
                        foreach (Resebolag verksamhet in verksamheter)
                        {
                            if (verksamhet.CompareName(input) == true)             //Här jämföra man med vad man har skrivit in. 
                            {
                                Console.WriteLine(verksamhet.getInfo());           //När man hittar den hämtar den hit. 
                            }
                        }

                    }
                    if (answer1 == "Vandrarhem")
                    {
                        if (verksamheter.Count == 0)
                        {
                            Console.WriteLine("Verksamheten hittades inte");
                        }
                        string input = Console.ReadLine();                        // Skriv in vad man ska jämföra med. 
                        foreach (Resebolag verksamhet in verksamheter)
                        {
                            if (verksamhet.CompareName(input) == true)             //Här jämföra man med vad man har skrivit in. 
                            {
                                Console.WriteLine(verksamhet.getInfo());           //När man hittar den hämtar den hit. 
                            }
                        }

                    }
                   
                }
                break;
            }
            break;
        case ConsoleKey.D0:
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[Avsluta programet.]");
                Console.ForegroundColor = ConsoleColor.Gray;

                Environment.Exit(0);                    //Avsluta programmet
            }
            break;
    }
    Meny();
}
Meny();