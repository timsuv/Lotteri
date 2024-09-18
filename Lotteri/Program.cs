using System.ComponentModel.Design;
using System.Xml;
using System.Linq;

namespace Lotteri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Money();
            
            CheckArrays(UserInput(), GetWinningNumber());
            Exit();

        }
        static int[] UserInput()
        {
            Console.WriteLine("Skriv 5 siffror");

            int[] userNumbers = new int[5];

            for (int i = 0; i < userNumbers.Length; i++)
            {
                int input;
                while ((!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 51) || userNumbers.Contains(input))
                {
                    Console.WriteLine("Ogiltigt, skriv endast 1 och 50 och du kan inte skriva samma siffra två gånger!");
                }
                userNumbers[i] = input;

            }
            Console.WriteLine("Your lottery numbers were: ");
            for (int i = 0; i < userNumbers.Length; i++)
            {
                Console.Write(userNumbers[i] + " ");
            }
            return userNumbers;

        }
        static int[] GetWinningNumber()
        {
            Random random = new Random();

            int[] winningNumber = new int[3];
            Console.WriteLine();
            Console.WriteLine("The winnings numbers were: ");
            for (int i = 0; i < winningNumber.Length; i++)
            {
                winningNumber[i] = random.Next(1, 50);

                Console.Write(winningNumber[i] + " ");
            }
            return winningNumber;
        }
        static void CheckArrays(int[] userNumbers, int[] winningNumber)
        {
            var matchingNumbers = 0;

            // Iterera över användarens nummer och kontrollera om något finns i de vinnande numren
            foreach (int userNumber in userNumbers)
            {
                if (winningNumber.Contains(userNumber))
                {
                    matchingNumbers++;
                }
            }
            Console.WriteLine();

            Console.WriteLine($"Du har {matchingNumbers} vinnande lottnummer.");
            if (matchingNumbers >= 3)
            {
                Console.WriteLine("JACKPOT! DU VANN!!! 1 MILLE");
            }
            else
            {
                Console.WriteLine("Du suger!");
            }
        }
        static void Exit()
        {

            while (true)
            {
                Console.WriteLine("Vill du fortsätta att spela? Skriv ja eller exit");
                string response = Console.ReadLine().ToLower();
                if (response == "exit")
                {
                    Console.WriteLine("Tack för att du spelade!");
                    break;
                }
                else if (response == "ja")
                {
                    Console.Clear();
                    Main(null);
                }
                else
                {
                    Console.WriteLine("Skriv ja eller exit");
                }
             }

        }
        static (int remainingMoney, int boughtTickets) Money()
        {
            int money = 100;
            int costTicket = 10;
            int boughtTickets;
          
            Console.WriteLine($"Välkommen till lotteriet! Du har {money} kronor, en biljet kostar {costTicket}");
            Console.WriteLine("Hur många biljetter vill du köpa?");
            int boughtInput = Convert.ToInt32( Console.ReadLine());

            boughtTickets = boughtInput;
            money = money - costTicket * boughtInput;
            Console.WriteLine($"Du har köpt {boughtTickets} biljetter och du har {money} kronor kvar");


            return (money, boughtTickets);
            
           
        }


        }
    }

