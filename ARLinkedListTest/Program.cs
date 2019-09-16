using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARLinkedList;

namespace ARLinkedListTest
{
    class Program
    {

        static void Main(string[] args)
        {
            //create different types of list
            LList<int> numbers = new LList<int>();
            LList<float> floatingNums = new LList<float>();
            LList<char> Alphabet = new LList<char>();
            LList<string> names = new LList<string>();

            string input;

            #region int list
            //each time there is a blank WriteLine method, I am explictly making a blank line for readability purposes
            Console.WriteLine(); 

            //prompt for input
            Console.WriteLine("Enter 5 numbers: ");
            Console.WriteLine();

            //get input
            for (int i = 0; i < 5; i++)
            {
                input = Console.ReadLine();

                int num;
                int.TryParse(input, out num);

                numbers.AddBack(num);
            }

            Console.WriteLine();

            //comments and instructions before showing what was entered
            Console.WriteLine("You added " + numbers.Count + " to the linked list numbers");
            Console.WriteLine("You entered:");
            Console.WriteLine();

            //show what was entered
            foreach (var item in numbers)
            {
                Console.Write(item.ToString() + " ");
            }

            //get the min and max of the list
            Console.WriteLine("\nThe minimum number in the list is: " + numbers.Min());
            Console.WriteLine("The maximum number in the list is: " + numbers.Max());
            #endregion

            #region float list
            Console.WriteLine();

            //prompt for input
            Console.WriteLine("Let's create a list of floating numbers");
            Console.WriteLine("Enter in 5 floating numbers");

            //get input
            for (int i = 0; i < 5; i++)
            {
                input = Console.ReadLine();

                float num;
                float.TryParse(input, out num);

                floatingNums.AddFirst(num);
            }
            Console.WriteLine();
            //comments and instructions before showing what was entered
            Console.WriteLine("The previous numbers you entered we added to the back of the list.");
            Console.WriteLine("This time we added the floating numbers to the front of the list.");
            Console.WriteLine("Let's see what that looks like");

            foreach (var item in floatingNums)
            {
                Console.Write(item.ToString() + " ");
            }

            //get the min and max of the list
            Console.WriteLine("\nThe minimum number in the list is: " + floatingNums.Min());
            Console.WriteLine("The maximum number in the list is: " + floatingNums.Max());
            Console.WriteLine();
            #endregion

            #region char list
            Console.WriteLine();

            //prompt for input
            Console.WriteLine("Next let's do a list of char characters");
            Console.WriteLine("Enter in 5 chars, each on a different line");

            //get input
            for (int i = 0; i < 5; i++)
            {
                input = Console.ReadLine();

                char charLetter;
                char.TryParse(input, out charLetter);

                Alphabet.AddFirst(charLetter);
            }

            Console.WriteLine();

            //comments and instructions before showing what was entered
            Console.WriteLine("The Char list is: ");
            foreach (var item in Alphabet)
            {
                Console.Write(item.ToString() + " ");
            }

            //get the min and max of the list
            Console.WriteLine("\nThe minimum number in the list is: " + Alphabet.Min());
            Console.WriteLine("The maximum number in the list is: " + Alphabet.Max());
            Console.WriteLine();
            #endregion

            #region string list
            Console.WriteLine();

            //prompt for input
            Console.WriteLine("Finally let's do a list of strings");
            Console.WriteLine("Enter in 5 strings, each on a different line");

            //get input
            for (int i = 0; i < 5; i++)
            {
                input = Console.ReadLine();

                names.AddBack(input);
            }

            Console.WriteLine();

            //comments and instructions before showing what was entered
            Console.WriteLine("The string list is: ");
            foreach (var item in names)
            {
                Console.Write(item.ToString() + " ");
            }

            //get the min and max of the list
            Console.WriteLine("\nThe minimum number in the list is: " + names.Min());
            Console.WriteLine("The maximum number in the list is: " + names.Max());
            Console.WriteLine();
            #endregion

            #region find and delete
            //prompt for number to find
            Console.WriteLine("Remember the first 5 numbers you entered?  Let's try and find one.");
            Console.WriteLine("Enter and number that you think was in the list and I will search the list to find it");
            input = Console.ReadLine();

            int findNum;
            int.TryParse(input, out findNum);

            int foundNumber = numbers.Find(findNum).Item;

            Console.WriteLine();

            //found result
            Console.WriteLine("You asked me to search for: " + findNum);
            Console.WriteLine("I found this: " + foundNumber);

            //try and delete
            numbers.Delete(findNum);

            //delete result
            Console.WriteLine("I have attempted to delete that number you searched for");
            Console.WriteLine("Let's see what that list looks like now");
            foreach (var item in numbers)
            {
                Console.Write(item.ToString() + " ");
            }
            #endregion
            Console.ReadLine();
        }
    }
}
