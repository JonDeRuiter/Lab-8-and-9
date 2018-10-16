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
            do
            {
                Console.Write("Welcome to our C# class. Which student would you like to learn more about? \nEnter Student # 1-10: ");
                string studentNum = IsNumber(Console.ReadLine());
                int index = int.Parse(studentNum);

                Console.WriteLine($"Student {index} is {studenNames[index -1]}, would you like to learn more about {studenNames[index - 1]}? \n(Hometown, Favorite Food, Favorite Number): ");
                string choice = "o";


            } while (Continue());
        }
        public static bool Continue()
        {
            bool run;
            Console.WriteLine("Continue? y/n");
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
        public static string IsNumber(string input)
        {
            input = NotEmpy(input);
            char[] inputArray = input.ToCharArray();
            foreach (char i in inputArray)
            {
                try
                {
                    if (char.IsDigit(i) )
                    {
                        return input;
                    }
                    else
                    {
                        throw new Exception($"Your input, {input}, needs to be a number between 1 and 10. ");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Please Try again: ");
                    input = IsNumber(Console.ReadLine());
                }
            }
            return input; 
        }
        public static bool IsInRange()
        {
            return true;
        }
    }
}
