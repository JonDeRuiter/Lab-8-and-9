using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_Student_Class_Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> studenNames = new List<string> { "Andrew", "Chuck", "Jeremy", "Jon", "Joseph", "Justin", "Katie", "Kelsey", "Sean", "Tommy" };
            List<string> homeTown = new List<string> { "Grand Haven", "Ripon", "Milwaukee", "Alger", "Grand Rapids", "Wyoming", "Grand Rapids", "Grand Rapids", "Grand Rapids",  "Raleigh"};
            List<string> favFood = new List<string> { "Chicken Wings", "Almonds", "Peanut Butter", "Tres Leches", "Burritos", "Burgers", "Indian Cuisine", "Grits", "BBQ", "Buttered Chicken"};
            List<int> favNum = new List<int> {911, 209, 10, 100, 5, 2, 12, 616, 32, 0};
            do
            {
                int numOfStudents = studenNames.Count;
                int index;
                string choiceOne;
                Console.WriteLine($"Welcome to our C# class.");
                bool goOn = false;
                bool tryAgain = false;
                Console.WriteLine("Would you like to add a new student or learn about one of our students? (new or learn)");
                choiceOne = AddLearn(Console.ReadLine());

                if (choiceOne == "learn")
                {
                    do
                    {
                        Console.WriteLine($"Which student would you like to learn about? (1-{studenNames.Count})");
                        string studentNum = Console.ReadLine();
                        tryAgain = IsNumber(studentNum, numOfStudents);
                        index = int.Parse(studentNum);
                        goOn = InRange(index, numOfStudents);

                    } while (!goOn || !tryAgain);


                    Console.Write($"Student number {index} is {studenNames[index - 1]}, would you like to learn more about {studenNames[index - 1]}? \n(Hometown, Favorite Food, Favorite Number): ");
                    string choice = ValidChoice(Console.ReadLine());

                    if (choice == "hometown")
                    {
                        Console.WriteLine($"{studenNames[index - 1]}'s Hometown is {homeTown[index - 1]}");
                    }
                    else if (choice == "favorite food")
                    {
                        Console.WriteLine($"{studenNames[index - 1]}'s Favorite Food is {favFood[index - 1]}");
                    }
                    else
                    {
                        Console.WriteLine($"{studenNames[index - 1]}'s Favorite Number is {favNum[index - 1]}");
                    }
                }
                
                else
                {
                    
                    Console.Write($"Please enter a name for student {numOfStudents + 1}: ");
                    string name = IsName(Console.ReadLine());
                    Console.Write($"Please enter a Hometown for {name}: ");
                    string home = IsName(Console.ReadLine());
                    Console.Write($"Please enter a Favorite Food for {name}: ");
                    string food = IsName(Console.ReadLine());
                    Console.Write($"Please enter a Favorite Number for {name}: ");
                    string newNum = Console.ReadLine();
                    IsNumber(newNum, int.MaxValue);
                    int niceNum = int.Parse(newNum);
                    studenNames.Add(name);
                    homeTown.Add(home);
                    favFood.Add(food);
                    favNum.Add(niceNum);
                }
               
                
            } while (Continue());
        }
        public static string AddLearn(string input)
        {
            input = input.ToLower();
            if (input == "new")
            {
                return input;
            }
            else if (input == "learn")
            {
                return input;
            }
            else
            {
                Console.WriteLine($"I could not understand {input}. Please type new to add a new student or learn to find out about our students.");
                input = AddLearn(Console.ReadLine());
            }
            return "invalid";

        }
        public static bool Continue()
        {
            bool run;
            Console.WriteLine("Would you like to do more? y/n");
            string answer = Console.ReadLine();
            answer = answer.ToLower();

            if (answer == "y")
            {
                run = true;
            }
            else if (answer == "n")
            {
                run = false;
            }
            else
            {
                Console.WriteLine("Sorry, I didn't understand that. Try again.");
                run = Continue();
            }
            return run;
        }
        public static string NotEmpy(string input)
        {
            input = input.Trim();
            try
            {
                if (input == null || input == "")
                {
                    throw new Exception("Input is empty, Please enter a number");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Please enter a number 1-10: ");
                input = NotEmpy(Console.ReadLine());           
            }
            return input;
        }
        public static bool IsNumber(string input, int x)
        {
            input = NotEmpy(input);
            char[] inputArray = input.ToCharArray();
            foreach (char i in inputArray)
            {
                try
                {
                    if (char.IsDigit(i) )
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception($"Your input, {input}, needs to be a number between 1 and {x}. ");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Please Try again: ");
                    input = Console.ReadLine();
                    IsNumber(input, x);
                }
            }
            return true; 
        }
        public static string ValidChoice(string input)
        {
            try
            {
                input = input.ToLower();
                if (input == "hometown" || input == "favorite food" || input == "favorite number")
                {
                    return input;
                }
                else 
                {
                    throw new Exception($"You entered: {input}. Only Hometown, Favorite Food, or Favorite Number available.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Please try again: ");
                input = ValidChoice(Console.ReadLine());
            }
            return input;
        }
        public static bool InRange(int index, int range)
        {
            try
            {
                if (index <= range && index > 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception($"We don't have {index} students. \nPlease enter a student number betweem 1-{range}: ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }
        public static string IsName(string input)
        {
            char[] letterArray = input.ToCharArray();

            try
            {
                if (!(Char.IsUpper(letterArray[0])))
                {
                    throw new Exception("This value must start with an Uppercase letter.");
                }
                foreach (char c in letterArray)
                {
                    if (!(char.IsLetter(c)))
                    {
                        throw new Exception("This value may only contain letters");
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Please try again: ");
                input = IsName(Console.ReadLine());

            }
            return input;
            
        }
    }
}
