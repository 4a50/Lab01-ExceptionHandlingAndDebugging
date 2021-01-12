using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception e)
            {
                Console.WriteLine("Hmm.  Something went wrong when starting the game: " + e.Message);
            }
        }

        static void StartSequence()
        {
            Console.WriteLine("Welcome to my game!  Let's do some math!");
            Console.WriteLine("Please enter a number greater that zero");            
            string userInput = Console.ReadLine();
            try
            {
                int userInt = Convert.ToInt32(userInput);
                int[] calcArray = new int[userInt];
                calcArray = Populate(calcArray);
                int sumArray = GetSum(calcArray);
                int product = GetProduct(calcArray, sumArray);
                decimal quotient = GetQuotient(product);

                Console.WriteLine($"Your Array size is: {calcArray.Length}");
                Console.Write($"The numbers in the array are ");
                
                //iterated through the array
                for (int i = 0; i < calcArray.Length; i++)
                {
                    if (i != calcArray.Length - 1)
                    {
                        Console.Write($"{calcArray[i]}, ");
                    }
                     else
                    {
                        Console.WriteLine($"{calcArray[i]}");
                    }
                }
                Console.WriteLine($"The sum of the array is {sumArray}");
                
                // since the multiplyers aren't passed out of the method, had to solve for x to get the other multiplyer
                int multiplyer = product / sumArray;
                Console.WriteLine($"{sumArray} * {multiplyer} = {product}");
                // divided was not passed out of the method, so solved for x to display the value.
                int dividend = product / Convert.ToInt32(quotient);
                
                Console.WriteLine($"{product} / {dividend} = {quotient}");



            }
            catch (FormatException e)
            {
                Console.WriteLine("Require a number to be entered: " + e.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine("Number is to Large to be entered: " + oe.Message);
            }
            
        }
        
        static int[] Populate (int[] intArr)
        {
            int counter = 0;

            while (counter < intArr.Length)
            {
                Console.WriteLine($"Enter a number {counter + 1}/{intArr.Length}");
                string userInput = Console.ReadLine();
                int userInt = int.Parse(userInput);
                intArr[counter] = userInt;
                counter++;
            }               
            return intArr;
        }

        static int GetSum(int[] intArr)
        {
            int sum = 0;
            foreach (int s in intArr)
            {
                sum += s;
            }
            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }
            
            return sum;
        }

        static int GetProduct (int[] intArr, int sum)
        {
            try
            {
                Console.WriteLine($"Please select a random number between 1 and {intArr.Length}");
                string userString = Console.ReadLine();
                int userIdx = Convert.ToInt32(userString) - 1;
                int product = sum * intArr[userIdx];
                return product;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("No a valid number: " + e.Message);
                throw new Exception();
            }


        }
        static decimal GetQuotient(int product)
        {
            try
            {
                Console.WriteLine($"Please enter a number to divide your product by {product} by");
                string userInput = Console.ReadLine();
                int divisor = Convert.ToInt32(userInput);
                decimal quotient = decimal.Divide(product, divisor);
                return quotient;
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return 0;
            }
        }
    }
}

    

