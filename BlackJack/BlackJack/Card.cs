using System;

namespace BlackJack
{
    enum Suit { Clubs, Diamonds, Hearts, Spades }
    enum Number
    {
        Six = 6,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack = 2,
        Lady,
        King,
        Ace = 11
    }

    struct Card
    {
        public Number Number;
        public Suit Suit;

        public Card(Number number, Suit suit)
        {
            Number = number;
            Suit = suit;
        }

        public static Card[] GenerateDeck(Card[] newDeck)
        {
            for (int i = 0; i < newDeck.Length;)
            {
                foreach (var suit in Enum.GetValues(typeof(Suit)))
                {
                    foreach (var number in Enum.GetValues(typeof(Number)))
                    {
                        newDeck[i] = new Card((Number) number, (Suit) suit);
                        i++;
                    }
                }
            }
            return newDeck;
        }

        public static void ShuffleDeck(Card[] deck)
        {
            Random rand = new Random();
            for (int i = 0; i < deck.Length; i++)
            {
                int randomIndex = rand.Next(deck.Length);
                int randomIndex2 = rand.Next(deck.Length);
                Card temp = deck[randomIndex];
                deck[randomIndex] = deck[randomIndex2];
                deck[randomIndex2] = temp;
            }
        }

        public static void AddToHand(ref Card[] hand, ref Card[] deck)
        {
            Card[] temp = new Card[hand.Length + 1];
            for (int i = 0; i < hand.Length; i++)
            {
                temp[i] = hand[i];
            }
            hand = temp;

            int lastIndex = hand.Length - 1;
            hand[lastIndex] = deck[0]; // add 1 card from deck to hand

            // remove this card from deck
            temp = new Card[deck.Length - 1];
            for (int i = 1; i < deck.Length; i++)
            {
                temp[i-1] = deck[i];
            }
            deck = temp;
        }

        public static void AddToHand(ref Card[] hand, ref Card[] deck, int n) 
        {
            Card[] temp = new Card[hand.Length + n];
            for (int i = 0; i < hand.Length; i++)
            {
                temp[i] = hand[i];
            }
            hand = temp;

            int lastIndex = hand.Length - n;
            // add various amount of cards from deck to hand
            for (int i = 0; i < n; i++) 
            {
                hand[lastIndex + i] = deck[i]; 
            }
            
            // remove these cards from deck
            temp = new Card[deck.Length - n];
            for (int i = n; i < deck.Length; i++)
            {
                temp[i - n] = deck[i];
            }
            deck = temp;
        }

        public static int ValueOfHand(Card[] hand)
        {
            int value = 0;
            for (int i = 0; i < hand.Length; i++)
            {
                value += (int)hand[i].Number;
            }
            return value;
        }
    }
}