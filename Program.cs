using System;
using System.Collections.Generic;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Crupier crupier = new Crupier();
            crupier.StartGame();
        }
    }

    class Crupier
    {
        Deck deck = new Deck();

        public void StartGame()
        {
            bool isWork = true;
            deck.AddCart();

            while (isWork)
            {
                Console.WriteLine("1 - вытянуть карты\n2 - выйти из програмы");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        deck.TakeCards();
                        break;
                    case "2":
                        isWork = false;
                        break;
                }
            }
        }
    }

    class Player
    {
        public int PlayerCardCount { get; private set; }

        public Player(int playerCardCount)
        {
            PlayerCardCount = playerCardCount;
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();

        public void AddCart()
        {
            int maxCardCount = 14;

            for (int i = 0; i < maxCardCount; i++)
            {
                Card card = new Card((CardValue)i);
                _cards.Add(card);
            }
        }

        public void TakeCards()
        {
            Console.WriteLine("Какое количество карт вытянуть?");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int number))
            {
                Player cartCount = new Player(number);

                if (cartCount.PlayerCardCount <= _cards.Count)
                    ShowCards(cartCount.PlayerCardCount);
                else
                    Console.WriteLine($"В колоде недостаточно карт. Осталось {_cards.Count} карт.");
            }
        }

        public void ShowCards(int cardsCount)
        {
            for (int i = 0; i < cardsCount; i++)
            {
                Console.WriteLine(_cards[0]._cartValue);

                DeleteCard();
            }
        }

        public void DeleteCard()
        {
            _cards.Remove(_cards[0]);
        }
    }

    class Card
    {
        public CardValue _cartValue { get; private set; }

        public Card(CardValue cartValue)
        {
            _cartValue = cartValue;
        }
    }

    enum CardValue
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
}
