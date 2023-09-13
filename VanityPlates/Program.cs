using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace VanityPlates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What are the limitations of the license plate:");
            Console.WriteLine("  - Minimum length is two characters and maximum length is six characters.");
            Console.WriteLine("  - The plate cannot contain anything besides letters and numbers.");
            Console.WriteLine("  - The first two characters of the plate have to be letters.");
            Console.WriteLine("  - Bez cifrichki po sredata.");

            while (true)
            {
                bool isValid = true;
                string plate = Console.ReadLine();
                List<char> plateList = new List<char>();
                List<char> invalidChars = new List<char>() { ' ', '.', '!', '?', ':', ';', '@', '#', ',' }; // etc.
                List<string> numbers = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                List<string> plate1s0s = new List<string>();
                List<string> plateNumbers = new List<string>();
                foreach (char c in plate)
                {
                    plateList.Add(c);
                }
                for (int i = 0; i < plate.Length; i++)
                {
                    if (numbers.Contains(plate.ElementAt(i).ToString()))
                    {
                        plate1s0s.Add("0");
                        plateNumbers.Add(plate.ElementAt(i).ToString());
                    }
                    else
                    {
                        plate1s0s.Add("1");
                    }
                }
                
                if (plate.Length < 2 || plate.Length > 6) //min length of 2 and max length of 6
                {
                    isValid = false;
                }
                
                else if (plate.StartsWith("0"))
                {
                    isValid = false;
                }

                else if (numbers.Contains(plateList[0].ToString()) || numbers.Contains(plateList[1].ToString())) //first two characters must be letters
                {
                    isValid = false;
                }

                foreach (char c in invalidChars) //cant contain periods, spaces, punctuation marks etc.
                {
                    if (plateList.Contains(c))
                    {
                        isValid = false;
                    }
                }

                if (plateNumbers.Count > 0 && plateNumbers[0] == "0")
                {
                   isValid = false;
                }

                foreach (string s in numbers)
                {
                    if (!numbers.Contains(plateList[plateList.Count - 1].ToString()) && plate.Contains(s))
                    {
                        isValid = false;
                    }
                }

                string plate1s0sSTR = string.Concat(plate1s0s);
                if (plate1s0sSTR.Contains("101"))
                {
                    isValid = false;
                }

                IsValid(isValid, plate);
            }
        }
         public static void IsValid(bool isValid, string plate)
        {
            if (isValid == true)
            {
                Console.WriteLine(plate + " is valid.");
            }
            else
            {
                Console.WriteLine(plate + " is invalid.");
            }
        }   
    }
}