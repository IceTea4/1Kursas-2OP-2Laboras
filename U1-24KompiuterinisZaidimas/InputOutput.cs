using System.Text; //Library used for text encoding

namespace U1_24KompiuterinisZaidimas
{
    /// <summary>
    /// A class that performs scans and prints
    /// </summary>
    public class InputOutput
    {
        /// <summary>
        /// A method that reads heroes and their data from the
        /// “Herojus.csv” file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static HeroRegister ReadHeroes(string fileName)
        {
            HeroRegister heroes = new HeroRegister();

            //Reads all lines from a file in UTF-8 encoding
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);

            string race = Lines[0];
            string city = Lines[1];

            //Parses each line
            for (int i = 2; i < Lines.Length; i++)
            {
                string[] values = Lines[i].Split(";");
                string name = values[0];
                int number = int.Parse(values[1]);
                int health = int.Parse(values[2]);
                int mana = int.Parse(values[3]);
                int damage = int.Parse(values[4]);
                int defend = int.Parse(values[5]);
                int strength = int.Parse(values[6]);
                int speed = int.Parse(values[7]);
                int intellect = int.Parse(values[8]);
                string power = values[9];

                //Creates new hero object
                Hero hero = new Hero(race, city, name, number, health, mana,
                    damage, defend, strength, speed, intellect, power);

                //Adds the created Hero object to the list of heroes
                heroes.Add(hero);
            }

            return heroes;
        }

        /// <summary>
        /// A method that prints all heroes and their data to the console
        /// </summary>
        /// <param name="heroes"></param>
        public static void PrintAllHeroes(HeroRegister heroes)
        {
            List<string> races = heroes.GetRaces();

            foreach (string race in races)
            {
                string city = heroes.GetCityByRace(race);

                //A table is created to store the data
                Console.WriteLine("Rasė: {0}; Miestas: {1}", race, city);
                Console.WriteLine(new string('-', 128));
                Console.WriteLine("| {0,-12} | {1,-5} | {2,-14} | " +
                    "{3,-4} | {4,-12} | {5,-14} | {6,-4} | {7,-8} | " +
                    "{8,-10} | {9,-14} |", "Vardas", "Klasė",
                    "Gyvybės taškai", "Mana", "Žalos taškai",
                    "Gynybos taškai", "Jėga", "Vikrumas", "Intelektas",
                    "Ypatinga galia");
                Console.WriteLine(new string('-', 128));

                for (int i = 0; i < heroes.HeroCount(); i++)
                {
                    Hero hero = heroes.WhichHero(i);

                    //Selects a hero with exact race
                    if (hero.race != race)
                    {
                        continue;
                    }
                    Console.WriteLine(hero.ToString());
                }

                Console.WriteLine(new string('-', 128));

                Console.WriteLine();
            }
        }

        /// <summary>
        /// A method that prints all heroes and their data to a txt file
        /// The data is stored in a table
        /// </summary>
        /// <param name="fileNameTxt"></param>
        /// <param name="heroes"></param>
        public static void PrintAllHeroesToTxt(string fileNameTxt,
            HeroRegister heroes)
        {
            List<string> races = heroes.GetRaces();

            List<string> lines = new List<string>();

            lines.Add("Registro informacija:");

            foreach (string race in races)
            {
                string city = heroes.GetCityByRace(race);
                
                lines.Add(String.Format("Rasė: {0}; Miestas: {1}", race, city));
                lines.Add(new string('-', 128));
                lines.Add(String.Format("| {0,-12} | {1,-5} | {2,-14} | " +
                    "{3,-4} | {4,-12} | {5,-14} | {6,-4} | {7,-8} | " +
                    "{8,-10} | {9,-14} |", "Vardas", "Klasė",
                    "Gyvybės taškai", "Mana", "Žalos taškai", "Gynybos taškai",
                    "Jėga", "Vikrumas", "Intelektas", "Ypatinga galia"));
                lines.Add(new string('-', 128));

                for (int i = 0; i < heroes.HeroCount(); i++)
                {
                    Hero hero = heroes.WhichHero(i);
                    if (hero.race != race)
                    {
                        continue;
                    }
                    lines.Add(hero.ToString());
                }

                lines.Add(new string('-', 128));

                lines.Add("");
            }

            //Prints on each line of the file
            File.WriteAllLines(fileNameTxt, lines, Encoding.UTF8);
        }

        /// <summary>
        /// The method prints hero classes (without duplicates) to
        /// "Klases.csv" file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="numbers"></param>
        public static void PrintNumbers(string fileName, List<int> numbers)
        {
            List<string> lines = new List<string>();

            lines.Add("Herojų klasės:");

            for (int i = 0; i < numbers.Count; i++)
            {
                lines.Add(String.Format("{0}", numbers[i]));
            }

            //Prints to all lines of the file
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }

        /// <summary>
        /// The method prints heroes missing classes to csv file
        /// <param name="fileName"></param>
        /// <param name="numbers"></param>
        public static void PrintMissingNumbers(string fileName,
            List<int> numbers)
        {
            List<int> trols = new List<int>();
            List<int> elfs = new List<int>();
            List<string> lines = new List<string>();

            lines.Add("Trūkstamos klasės:");

            int x = numbers.IndexOf(-1)!;

            for (int i = 0; i < numbers.Count(); i++)
            {
                if (i > x)
                {
                    trols.Add(numbers[i]);
                }
                else if (i < x)
                {
                    elfs.Add(numbers[i]);
                }
            }

            lines.Add("Troliai:");
            if (trols.Count == 0)
            {
                lines.Add("VISI");
            }
            else
            {
                for (int i = 0; i < trols.Count(); i++)
                {
                    lines.Add(String.Format("{0}", trols[i]));
                }
            }

            lines.Add("Elfai:");
            if (elfs.Count == 0)
            {
                lines.Add("VISI");
            }
            else
            {
                for (int i = 0; i < elfs.Count(); i++)
                {
                    lines.Add(String.Format("{0}", elfs[i]));
                }
            }

            ///Prints to all lines of the file
            File.WriteAllLines(fileName, lines, Encoding.UTF8);

        }
    }
}

