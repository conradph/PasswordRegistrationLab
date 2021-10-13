using System;
using System.Collections.Generic;

namespace PasswordRegistrationLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> usernames = new List<string>();
            List<string> passwords = new List<string>();
            List<string> restrictedNames = new List<string>() {"fuck", "shit", "damn", "hell", "bitch"};
            bool keepGoing = true;
            while (keepGoing)
            {
                bool validPassword = false;
                bool validUsername = false;
                string password = "";
                string username = "";
                while (!validPassword)
                {

                    password = GetInput("Please enter a password: ");
                    validPassword = ValidatePassword(password);
                }
                while (!validUsername)
                {


                    username = GetInput("Please enter a username: ");
                    validUsername = ValidateUsername(username, restrictedNames);
                }
                if (!usernames.Contains(username))
                {
                    usernames.Add(username);
                    passwords.Add(password);
                }
                else
                {
                    Console.WriteLine("Username already exists.");
                }
                keepGoing = ContinueYesNo();
            }
            Console.WriteLine("Goodbye");
            Console.WriteLine("Showing Username and password list:");
            for (int i = 0; i < usernames.Count; i++)
            {
                Console.WriteLine($"Username: {usernames[i]} \tPassword: {passwords[i]}");
            }

        }
        public static string GetInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        public static bool ValidatePassword(string password)
        {
            bool valid = true;
            if (password.ToLower() == password)
            {
                Console.WriteLine("Error, no uppercase letters in password");
                valid = false;
            }
            if (password.ToUpper() == password)
            {
                Console.WriteLine("Error, no lowercase letters in password");
                valid = false;
            }
            if (password.IndexOfAny(new char[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'}) == -1)
            {
                Console.WriteLine("Error, no numbers in password");
                valid = false;
            }
            if (password.Length < 7 || password.Length > 12)
            {
                Console.WriteLine("Error, password must be between 7-12 characters long");
                valid = false;
            }
            if (password.IndexOfAny(new char[] { '!', '@', '#', '$', '%', '^', '&', '*' }) == -1)
            {
                Console.WriteLine("Error, password must contain special character: ! @ # $ % ^ & * ");
                valid = false;
            }
            return valid;

        }
        public static bool ValidateUsername(string username, List<string> restrictedWords)
        {
            bool valid = true;
            int letterCount = 0;
            bool containsLetter = false;
            foreach (char s in username)
            {
                if (char.IsLetter(s))
                {
                    letterCount += 1;
                    containsLetter = true;
                }
            }
            if (!containsLetter)
            {
                Console.WriteLine("Error, no letters in username");
                valid = false;
            }
            if (username.IndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }) == -1)
            {
                Console.WriteLine("Error, no numbers in username");
                valid = false;
            }
            if (username.Length < 7 || username.Length > 12)
            {
                Console.WriteLine("Error, password must be between 7-12 characters long");
                valid = false;
            }
            if (stringContains(username, restrictedWords)) 
            {
                Console.WriteLine("Error, username contains restricted word");
                valid = false;
            }    
            return valid;
        }
        public static bool ContinueYesNo ()
        {
            Console.WriteLine("Would you like to continue (y/n)?");
            string response = Console.ReadLine().ToLower();
            if (response == "y")
            {
                return true;
            }
            else if (response == "n")
            { 
                return false;
            }
            else
            {
                Console.WriteLine("Invalid Response");
                return ContinueYesNo();
            }
        }
        public static bool stringContains(string checkString, List<string> checkList)
        {
            foreach(string word in checkList)
            {
                if(checkString.ToLower().Contains(word))
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}
