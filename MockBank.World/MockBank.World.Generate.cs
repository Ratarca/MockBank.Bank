using MockBank.World.Entities;

namespace MockBank.World.Generate{

    public class app{
        public static void Main(){
            DataGenerate MyData = new DataGenerate();

            for (int i=0; i < 100; i++){
                Console.WriteLine(MyData.generate_person(i));
            };
        }
    }

    public class DataGenerate{
        //TODO:Medium:Use datetime born not int to set age
        private int generate_age(){
            Random random = new Random();
            double odds = Math.Round(random.NextDouble(),4);

            switch (odds){
                case double x when x < 0.3:
                    return random.Next(18,25);

                case double x when x > 0.3 && x < 0.75:
                    return random.Next(26,40);

                case double x when x > 0.75 && x < 0.90:
                    return random.Next(41,70);

                default:
                    return random.Next(18,90);
            };
        }

        private Gender generate_gender(){
            Random random    = new Random();
            int    sizeEnum  = Enum.GetValues(typeof(Gender)).Length;
            int    randomIdx = random.Next(sizeEnum);

            Gender randomGender = (Gender)randomIdx;
            return randomGender;
        }

        private string generate_name(Gender gender){
            Random random = new Random();
            
            // TODO:Low:Use json to build name
            var maleNames = new List<string> {"Ayrton", "Miguel", "Josias", 
                                            "Rafael", "Plato", "Isac","Joao",
                                            "Dwight", "Nikolai", "Graciliano","Linus"};
            
            var femaleNames = new List<string> {"Ana","Clara", "Rita", "Marieta", "Elisabeth",
                                            "Maria"};

            var lastNames = new List<string> {"Yamato", "Cesar", "Senna", "Rossi",
                                            "Silva","Santos","Cavalcante","Miller",
                                            "schrute","Murakami","Mishima","Fitzgerald",
                                            "Lovelace","Heisenberg","Torvalds","Cervantes",
                                            "Guimaraes Rosa"
                                            };

            int femaleArrayLenght = femaleNames.Count;
            int maleArrayLenght = maleNames.Count;
            int lastNameArrayLenght = lastNames.Count;

            switch (gender){
                case Gender.female:
                    string femaleName = femaleNames[random.Next(femaleArrayLenght)];
                    string femaleLastName = lastNames[random.Next(lastNameArrayLenght)];
                    return string.Concat(femaleName, " ", femaleLastName);

                case Gender.male:
                    string maleName = maleNames[random.Next(maleArrayLenght)];
                    string maleLastName = lastNames[random.Next(lastNameArrayLenght)];
                    return string.Concat(maleName, " ", maleLastName);

                default:
                    return "ERROR";
            };
        }

        private Countries generate_country(){
            Random random = new Random();
            int sizeEnum = Enum.GetValues(typeof(Countries)).Length;
            int randomIdx = random.Next(sizeEnum);
            Countries randomCountry = (Countries)randomIdx;

            return randomCountry;
        }

        private States generate_state(){
            Random random = new Random();
            int sizeEnum = Enum.GetValues(typeof(States)).Length;
            int randomIdx = random.Next(sizeEnum);
            States randomState = (States)randomIdx;

            return randomState;
        }

        private FlagParents generate_parents(){
            Random random = new Random();
            double odds = random.NextDouble();

            switch(odds){
                case double x when x < 0.9:
                    return FlagParents.hasParent;
                case double x when x > 0.91:
                    return FlagParents.notParent;
                default:
                    return FlagParents.hasParent;
            };
        }

        //TODO:Low:Add arguments impact(flagParents, States)
        private float generate_familyIncome(){
            return 2.500f;
        }

        //Todo:Medium:Add arguments impact on education level(familyIncome,state,parents)
        private EducationLevel generate_educationLevel(){
            Random random    = new Random();
            int    sizeEnum  = Enum.GetValues(typeof(EducationLevel)).Length;
            int    randomIdx = random.Next(sizeEnum);

            EducationLevel randomEducation = (EducationLevel)randomIdx;
            return randomEducation;
        }

        private Work generate_work(){
            Random random = new Random();
            double odds = Math.Round(random.NextDouble(),4);

            switch (odds){
                case double x when x < 0.95:
                    return Work.working;
                case double x when x > 0.96:
                    return Work.notWorking;
                default:
                    return Work.working;
            };
            
        }

        // TODO:Low:Improve income function
        private float generate_income(Work work, States state, EducationLevel education){
            // income = work * (avg_wage * educationLevel * (1+stateFactor)  )
            float income =  2f + (int)work * (2.500f * (int)education * (1 + 0.25f));
            return income;
        }

        public Person generate_person(int id){
            int            personAge          = generate_age();
            Gender         personGender       = generate_gender();
            string         personName         = generate_name(personGender);
            Countries      personLocalCountry = generate_country();
            States         personLocalState   = generate_state();
            FlagParents    personFlagParents  = generate_parents();
            float          personFamilyIncome = generate_familyIncome();
            Work           personWork         = generate_work();
            EducationLevel personEducation    = generate_educationLevel();
            float          personIncome       = generate_income(personWork,personLocalState,personEducation);

            Person         build_person       = new Person(id,personAge,personGender,
                                        personName, personLocalCountry,
                                        personLocalState,personFlagParents,
                                        personFamilyIncome,personEducation,
                                        personWork,personIncome);
            return build_person;
        }

        public void generate_world(){}
    }

}