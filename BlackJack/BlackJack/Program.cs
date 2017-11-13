using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            // create and shuffle a deck
            Card[] deck = new Card[36];
            deck = Card.GenerateDeck(deck);
            Card.ShuffleDeck(deck);
            foreach (Card card in deck)
            {
                Console.WriteLine($"{card.Number} of {card.Suit}");
            }

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
                        for (int i = 0; i < 2; i++)
                        {
                            if (i == 0)
                            {
                                Card.AddToHand(ref playersHand, ref deck);
                                Card.AddToHand(ref playersHand, ref deck);
                            }
                            else
                            {
                                Card.AddToHand(ref computersHand, ref deck);
                                Card.AddToHand(ref computersHand, ref deck);
                            }
                        }
                        break;
                    case ConsoleKey.NumPad0:
                        for (int i = 0; i < 2; i++)
                        {
                            if (i == 1)
                            {
                                Card.AddToHand(ref playersHand, ref deck);
                                Card.AddToHand(ref playersHand, ref deck);
                            }
                            else
                            {
                                Card.AddToHand(ref computersHand, ref deck);
                                Card.AddToHand(ref computersHand, ref deck);
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("\rPlease enter a correct value!");
                        break;
                }
            } while (answer.Key != ConsoleKey.NumPad1 && answer.Key != ConsoleKey.NumPad0);
            
            
            
            
            
            
            
            
            
            
            
                        
            Console.WriteLine(new string('-', 30));
            foreach (Card card in playersHand)
            {
                Console.WriteLine($"{card.Number} of {card.Suit}");
            }

            Console.WriteLine(new string('-', 30));
            foreach (Card card in computersHand)
            {
                Console.WriteLine($"{card.Number} of {card.Suit}");
            }

            Console.WriteLine(new string('-', 30));
            foreach (Card card in deck)
            {
                Console.WriteLine($"{card.Number} of {card.Suit}");
            }
            Console.ReadKey();
        }
    }
}
