using System;

class Program
{
    static void Main(string[] args)
    {
       //random generator
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        //while loop
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Guess Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Guess Lower");
            }
            else
            {
                Console.WriteLine("You won! You guessed it!");
            }

        }                    
    }
}