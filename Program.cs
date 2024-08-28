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
        private const string TakeCardsOption = "1";
        private const string ExitOption = "2";

        private Deck _deck = new Deck();
        private Player _player = new Player();

        public void StartGame()
        {
            bool isWork = true;
            _deck.AddCards();

            while (isWork)
            {
                Console.WriteLine($"{TakeCardsOption} - вытянуть карты\n{ExitOption} - выйти из программы");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case TakeCardsOption:
                        TakeCardsFromDeck();
                        break;
                    case ExitOption:
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        private void TakeCardsFromDeck()
        {
            Console.WriteLine("Какое количество карт вытянуть?");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int number))
            {
                if (number > _deck.RemainingCards())
                {
                    Console.WriteLine($"В колоде осталось только {_deck.RemainingCards()} карт. Выберите меньшее количество.");
                    return; 
                }

                List<Card> cards = _deck.TakeCards(number);
                _player.AddCards(cards);
                _player.ShowCards();
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Введите число.");
            }
        }
    }

    class Player
    {
        private List<Card> _cards = new List<Card>();

        public void AddCards(List<Card> cards)
        {
            _cards.AddRange(cards);
        }

        public void ShowCards()
        {
            Console.WriteLine("Карты игрока:");

            foreach (var card in _cards)
            {
                Console.WriteLine(card.CartValue);
            }
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();

        public int RemainingCards()
        {
            return _cards.Count;
        }

        public void AddCards()
        {
            int maxCardCount = 14;

            for (int i = 0; i < maxCardCount; i++)
            {
                Card card = new Card((CardValue)i);
                _cards.Add(card);
            }
        }

        public List<Card> TakeCards(int amount)
        {
            List<Card> takenCards = new List<Card>();

            for (int i = 0; i < amount; i++)
            {
                takenCards.Add(_cards[0]);
                DeleteCard();
            }

            return takenCards;
        }

        private void DeleteCard()
        {
            _cards.RemoveAt(0);
        }
    }

    class Card
    {
        public CardValue CartValue { get; private set; }

        public Card(CardValue cartValue)
        {
            CartValue = cartValue;
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
