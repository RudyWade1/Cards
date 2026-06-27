using System;
using System.Collections.Generic;

namespace Переменные
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player player = new Player();
            Croupier croupier = new Croupier(deck, player);

            Console.Write("Сколько карт выдать игроку? ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int card))
            {
                croupier.DealCards(card);
            }

            Console.WriteLine("\nКарты у игрока на руках:");
            player.ShowHand();
        }
    }

    class Card
    {
        public string Suit { get; private set; }
        public string Value { get; private set; }

        public Card(string suit, string value)
        {
            Suit = suit;
            Value = value;
        }
    }

    class Player
    {
        private List<Card> _hand = new List<Card>();

        public void TakeCard(Card card)
        {
            _hand.Add(card);
        }

        public void ShowHand()
        {
            foreach (Card card in _hand)
            {
                Console.WriteLine($"Масть: {card.Suit}, Номинал: {card.Value}");
            }
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();

        public Deck()
        {
            string[] suits = { "Черви", "Буби", "Крести", "Пики" };
            string[] values = { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            foreach (string suit in suits)
            {
                foreach (var value in values)
                {
                    _cards.Add(new Card(suit, value));
                }
            }
        }

        public Card DrawCard()
        {
            int lastCard = _cards.Count - 1;
            Card chosenCard = _cards[lastCard];
            _cards.RemoveAt(lastCard);
            return chosenCard;
        }
    }

    class Croupier
    {
        private Deck _deck;
        private Player _player;

        public Croupier(Deck deck, Player player)
        {
            _deck = deck;
            _player = player;
        }

        public void DealCards(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Card card = _deck.DrawCard();
                _player.TakeCard(card);
            }
        }
    }
}

