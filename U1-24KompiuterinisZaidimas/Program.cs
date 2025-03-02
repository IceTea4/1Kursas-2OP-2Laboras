namespace U1_24KompiuterinisZaidimas
{
    /*U2-24. Kompiuterinis žaidimas. Sugrupavote herojus pagal dvi rases, 
     * ir surašėte jų duomenis į skirtingus failus. Duomenų formatas dabar 
     * toks: pirmoje eilutėje – rasės pavadinimas. Antroje – pradinis miestas. 
     * Toliau pateikta informacija tokiu pačiu formatu kaip L1 užduotyje, 
     * tik nebėra rasės stulpelio.
        • Sudarykite visų herojų klasių sąrašą, klasių pavadinimus įrašykite
        į failą „Klasės.csv“ .
        • Raskite, kokių klasių herojų „trūksta“ kiekvienai rasei. Į failą
        „Trūkstami.csv“ įrašykite kiekvienos rasės pavadinimą, ir trūkstamų
        klasių sąrašą. Jei rasė turi bent po vieną kiekvienos klasės atstovą,
        parašykite žodį „VISI“.
        • Raskite, kurioje rasėje yra stipriausias herojus: herojus stiprumą
        rodo gyvybės ir gynybos taškų suma sumažinta žalos taškais. Ekrane
        atspausdinkite visus herojaus duomenis ir jo rasę.
    */

    class Program
    {
        static void Main(string[] args)
        {
            //Heroes and their data are read from the “Troliai.csv” and
            //"Elfai.csv" files and then are placed into the register
            HeroRegister registerT =
                InputOutput.ReadHeroes(@"../../../../Troliai.csv");
            HeroRegister registerE =
                InputOutput.ReadHeroes(@"../../../../Elfai.csv");

            HeroRegister register = registerT.CombineRegisters(registerE);

            //All heroes and their data are printed to the console
            //in a table
            Console.WriteLine("Registro informacija:");
            InputOutput.PrintAllHeroes(register);

            //All heroes and their data in the table are printed to
            //txt file
            InputOutput.PrintAllHeroesToTxt("Duomenys.txt", register);

            //First task result (all different heroes classes) is
            //printed to the "Klases.csv" file
            InputOutput.PrintNumbers("Klases.csv", register.FindClasses());

            //Second task result (all missing each race classes) is printed
            //to the "Trukstami.csv" file
            List<int> missingClasses = register.MissingClasses();
            InputOutput.PrintMissingNumbers("Trukstami.csv", missingClasses);

            //Third task rezult: Searches in which race there is the
            //strongest hero and prints it, but if there is more than
            //one code prints others too
            Console.WriteLine("Stipriausi herojai:");

            HeroRegister strongT = registerT.FindAllStrongest();
            HeroRegister strongE = registerE.FindAllStrongest();

            HeroRegister strong = strongT.CombineRegisters(strongE);

            if (strongT.WhichHero(0).GetStrength()
                == strongE.WhichHero(0).GetStrength())
            {
                InputOutput.PrintAllHeroes(strong);
            }
            else if (strongT.WhichHero(0).GetStrength()
                > strongE.WhichHero(0).GetStrength())
            {
                InputOutput.PrintAllHeroes(strong);
            }
            else
            {
                InputOutput.PrintAllHeroes(strong);
            }
        }
    }

}
