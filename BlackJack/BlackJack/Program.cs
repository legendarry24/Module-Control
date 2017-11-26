using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        public static bool ExitConfirmed()
        {
            while (true)
            {
                Console.WriteLine("Do you want to start new game? Yes / No");
                string decision = Console.ReadLine();
                switch (decision)
                {
                    case "Yes":
                        return false;
                    case "No":
                        return true;
                    default:
                        Console.WriteLine("Please enter a correct value!");
                        break;
                }
            }        
        }
        static void Main(string[] args)
        {
            int playerWinsCounter = 0, computerWinsCounter = 0;

            while (true)
            {
                // create and shuffle a deck
                Card[] deck = new Card[36];
                deck = Card.GenerateDeck(deck);
                Card.ShuffleDeck(deck);

                // two players receive two cards each
                Card[] playersHand = new Card[0];
                Card[] computersHand = new Card[0];           
                ConsoleKeyInfo answer;
                do
                {
                    Console.WriteLine("Who will receive first cards?\nPress on NumPad: 1 - player or 0 - computer");
                    answer = Console.ReadKey();
                    switch (answer.Key)
                    {
                        case ConsoleKey.NumPad1:
                            Card.AddToHand(ref playersHand, ref deck, 2);
                            Card.AddToHand(ref computersHand, ref deck, 2);
                            break;
                        case ConsoleKey.NumPad0:
                            Card.AddToHand(ref computersHand, ref deck, 2);
                            Card.AddToHand(ref playersHand, ref deck, 2);
                            break;
                        default:
                            Console.WriteLine("\rPlease enter a correct value!");
                            break;
                    }
                } while (answer.Key != ConsoleKey.NumPad1 && answer.Key != ConsoleKey.NumPad0);

                // check for instant win
                if (playersHand[0].Number == Number.Ace && playersHand[1].Number == Number.Ace ||
                    Card.ValueOfHand(playersHand) == 21)
                {
                    if (computersHand[0].Number == Number.Ace && computersHand[1].Number == Number.Ace ||
                        Card.ValueOfHand(computersHand) == 21)
                    {
                        Console.WriteLine("Draw");
                    }
                    else
                    {
                        Console.WriteLine("You won!");
                        playerWinsCounter++;
                    }
                }
                else if (computersHand[0].Number == Number.Ace && computersHand[1].Number == Number.Ace ||
                         Card.ValueOfHand(computersHand) == 21)
                {
                    Console.WriteLine("Computer won!");
                    computerWinsCounter++;
                }

                // Players turn
                do
                {
                    Console.WriteLine($"\r{new string('-', 40)}");
                    foreach (Card card in playersHand)
                    {
                        Console.WriteLine($"{card.Number} of {card.Suit}");
                    }
                    Console.WriteLine($"\rYou have {Card.ValueOfHand(playersHand)} points");

                    Console.WriteLine("Press on NumPad: 1 - to get one more card or 0 - to stop receiving cards");
                    answer = Console.ReadKey();

                    if (answer.Key == ConsoleKey.NumPad1)
                    {
                        Card.AddToHand(ref playersHand, ref deck);
                    }
                    else if (answer.Key != ConsoleKey.NumPad0)
                    {
                        Console.WriteLine("\rPlease enter a correct value!");
                    }

                } while (answer.Key != ConsoleKey.NumPad0 && Card.ValueOfHand(playersHand) < 21);
                Console.WriteLine($"\r{new string('-', 40)}");
                foreach (Card card in playersHand)
                {
                    Console.WriteLine($"{card.Number} of {card.Suit}");
                }
                Console.WriteLine($"\rYou have {Card.ValueOfHand(playersHand)} points");

                // Computers turn
                Random rand = new Random();
                do
                {
                    //Console.WriteLine(new string('-', 40));
                    //foreach (Card card in computersHand)
                    //{
                    //    Console.WriteLine($"{card.Number} of {card.Suit}");
                    //}
                    //Console.WriteLine($"\rComputer has {Card.ValueOfHand(computersHand)} points");
                    int chance = rand.Next(0, 100);
                    if (Card.ValueOfHand(computersHand) < 11)
                    {
                        Card.AddToHand(ref computersHand, ref deck);
                    }
                    else if (Card.ValueOfHand(computersHand) >= 11 && Card.ValueOfHand(computersHand) < 14)
                    {
                        if (chance < 80) // 80 % to make this choice
                        {
                            Card.AddToHand(ref computersHand, ref deck);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (Card.ValueOfHand(computersHand) >= 14 && Card.ValueOfHand(computersHand) < 16)
                    {
                        if (chance < 60) // 60 % to make this choice
                        {
                            Card.AddToHand(ref computersHand, ref deck);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (Card.ValueOfHand(computersHand) >= 16 && Card.ValueOfHand(computersHand) < 18)
                    {
                        if (chance < 50) // 50 % to make this choice
                        {
                            Card.AddToHand(ref computersHand, ref deck);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else if (Card.ValueOfHand(computersHand) >= 18 && Card.ValueOfHand(computersHand) < 21)
                    {
                        if (chance < 10) // 10 % to make this choice
                        {
                            Card.AddToHand(ref computersHand, ref deck);
                        }
                        else
                        {
                            break;
                        }
                    }

                } while (Card.ValueOfHand(computersHand) < 21);

                Console.WriteLine(new string('-', 40));
                foreach (Card card in computersHand)
                {
                    Console.WriteLine($"{card.Number} of {card.Suit}");
                }
                Console.WriteLine($"\rComputer has {Card.ValueOfHand(computersHand)} points\n");

                // Result
                if (Card.ValueOfHand(playersHand) > Card.ValueOfHand(computersHand) &&
                    Card.ValueOfHand(playersHand) <= 21)
                {
                    Console.WriteLine("You won!");
                    playerWinsCounter++;
                }
                else if (Card.ValueOfHand(computersHand) > Card.ValueOfHand(playersHand) &&
                         Card.ValueOfHand(computersHand) <= 21)
                {
                    Console.WriteLine("Computer won!");
                    computerWinsCounter++;
                }
                else if (Card.ValueOfHand(computersHand) == Card.ValueOfHand(playersHand) &&
                         Card.ValueOfHand(computersHand) <= 21)
                {
                    Console.WriteLine("Draw");
                }
                else
                {
                    if (Card.ValueOfHand(playersHand) > Card.ValueOfHand(computersHand))
                    {
                        Console.WriteLine("Computer won!");
                        computerWinsCounter++;
                    }                    
                    else
                    {
                        Console.WriteLine("You won!");
                        playerWinsCounter++;
                    }
                }

                // Exit application or start new game
                if (ExitConfirmed())
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }
            // Games score
            Console.WriteLine($"\nYou {playerWinsCounter} : {computerWinsCounter} Computer");

            Console.ReadKey();
        }
    }
}
