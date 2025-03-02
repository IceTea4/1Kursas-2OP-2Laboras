namespace U1_24KompiuterinisZaidimas
{
    /// <summary>
    /// Class which controls the list of heroes and logic around them
    /// </summary>
    public class HeroRegister
    {
        /// <summary>
        /// List of heroes
        /// </summary>
        private List<Hero> AllHeroes;

        /// <summary>
        /// Creating an empty register
        /// </summary>
        public HeroRegister()
        {
            AllHeroes = new List<Hero>();
        }

        /// <summary>
        /// Creating a register with list of heroes
        /// </summary>
        /// <param name="heroes"></param>
        public HeroRegister(List<Hero> heroes)
        {
            AllHeroes = new List<Hero>();

            foreach (Hero hero in heroes)
            {
                this.AllHeroes.Add(hero);
            }
        }

        /// <summary>
        /// Adds hero to the register
        /// </summary>
        /// <param name="hero"></param>
        public void Add(Hero hero)
        {
            AllHeroes.Add(hero);
        }

        /// <summary>
        /// Counts how many heroes there are in register
        /// </summary>
        /// <returns></returns>
        public int HeroCount()
        {
            return this.AllHeroes.Count();
        }

        /// <summary>
        /// Returns an exact hero from the register
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public Hero WhichHero(int number)
        {
            return AllHeroes[number];
        }

        /// <summary>
        /// Combines two hero registers into one
        /// </summary>
        /// <param name="heroes"></param>
        /// <returns></returns>
        public HeroRegister CombineRegisters(HeroRegister heroes)
        {
            HeroRegister newRegister = new HeroRegister(this.AllHeroes);

            for (int i = 0; i < heroes.HeroCount(); i++)
            {
                newRegister.Add(heroes.WhichHero(i));
            }

            return newRegister;
        }

        /// <summary>
        /// Returns different hero races
        /// </summary>
        /// <returns></returns>
        public List<string> GetRaces()
        {
            List<string> races = new List<string>();

            foreach (Hero hero in this.AllHeroes)
            {
                if (!races.Contains(hero.race))
                {
                    races.Add(hero.race);
                }
            }

            return races;
        }

        /// <summary>
        /// Assigns city to its race
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        public string GetCityByRace(string race)
        {
            foreach (Hero hero in this.AllHeroes)
            {
                if (race == hero.race)
                {
                    return hero.city;
                }
            }

            return null;
        }

        /// <summary>
        /// Method which finds all the different classes of the heroes
        /// and places them in one list
        /// </summary>
        /// <returns></returns>
        public List<int> FindClasses()
        {
            //New list is created for the new list of the classes
            List<int> numbers = new List<int>();

            foreach (Hero hero in this.AllHeroes)
            {
                int nr = hero.number;

                if (!numbers.Contains(nr))
                {
                    //Classes which met the conditions are added to
                    //the new list
                    numbers.Add(nr);
                }
            }

            numbers.Sort();
            return numbers;
        }

        /// <summary>
        /// Method which finds all missing classes and puts them in one list
        /// </summary>
        /// <returns></returns>
        public List<int> MissingClasses()
        {
            List<string> races = this.GetRaces();
            List<int> classes = new List<int>();
            List<int> other = new List<int>();

            for (int i = 0; i < 2; i++)
            {
                string race = races[i];
                for (int j = 0; j < this.HeroCount(); j++)
                {
                    Hero hero = WhichHero(j);
                    if (i == 0 && !classes.Contains(hero.number) && hero.race
                        == race)
                    {
                        classes.Add(hero.number);
                    }
                    else if (i == 1 && !other.Contains(hero.number) && hero.race == race)
                    {
                        other.Add(hero.number);
                    }
                }
            }

            var missesClasses = classes.Except(other).ToList();
            var missesOther = other.Except(classes).ToList();

            missesClasses.Add(-1);
            List<int> misses = missesClasses.Concat(missesOther).ToList();

            return misses;
        }

        /// <summary>
        /// Method which finds the biggest strength of the heroes
        /// </summary>
        /// <returns></returns>
        public double FindStrength()
        {
            double strength = AllHeroes[0].health + AllHeroes[0].defend
                - AllHeroes[0].damage;

            foreach (Hero hero in this.AllHeroes)
            {
                if (strength < hero)
                {
                    strength = hero.GetStrength();
                }
            }

            return strength;
        }

        /// <summary>
        /// Method which finds all the strongest heroes from the list
        /// </summary>
        /// <returns></returns>
        public HeroRegister FindAllStrongest()
        {
            HeroRegister strength = new HeroRegister();
            double powerfull = FindStrength();

            foreach (Hero hero in this.AllHeroes)
            {
                if (powerfull == hero.GetStrength())
                {
                    strength.Add(hero);
                }
            }

            return strength;
        }
    }
}
