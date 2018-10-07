using System;
using System.Collections.Generic;

namespace Blackjack
{
    /// <summary>
    /// Klasa spila za igru,tj kolekcije karta kojom se igra
    /// </summary>
    public class Deck
    {
        private Random r;

        private List<Card> cards;
        /// <summary>
        /// Kolekcija svih karata u jednom objektu spila.
        /// </summary>
        public List<Card> Cards
        {
            get { return cards; }set { cards = value; }
        }

        public int CardsNumber//broj karata koji se koristi u spilu
        {
            get { return Cards.Count; }
        }

        /// <summary>
        /// Metoda koja promijesa spil karata
        /// </summary>
        public void Shuffle()
        {
            Random r = new Random();//pomocni random objekt uz pomocu kojeg mjesamo karte
            for (int i = 1; i <= 100; i++)//radimo 1000 mjesanja spila
            {
                for (int index = 0; index < CardsNumber; index++)//idemo od prve do zadnje karte u spilu
                {
                    int k = r.Next(0,CardsNumber-1);//index slucajne karte u spilu
                    Card pomocna = cards[index];//nasa trenutna karta
                    cards[index] = cards[k];
                    cards[k] = pomocna;
                }
            }
        }

        /// <summary>
        /// Metoda koja zadnju kartu u spilu doda u igru i makne ju iz spila
        /// </summary>
        /// <returns></returns>
        public Card ReturnCard()
        {
            int index = r.Next(0, CardsNumber - 1);
            Card karta = new Card(Cards[index].ID);//karta koju vracamo
            cards.RemoveAt(index);
            return karta;
        }

        public Deck()//1.konstruktor
        {
            Cards = new List<Card>();r = new Random();
        }
        public Deck(int broj)//2. konstruktor,brj oznacava koliko spilova koristimo
        {
            r = new Random();
            cards = new List<Card>();
            for (int i = 1; i <= broj; i++)// n puta dodamo 1 spil karata(52 karte)  u jedan veliki
            {
                AddDeck();//dodamo jednom 1 spil(52 karte)
            }
            //Shuffle();//promjesamo spil
        }

        /// <summary>
        /// Metoda koja nam samo treba u konstruktoru,da n puta dodamo jedan spil karata u jedan veliki.
        /// </summary>
        private void AddDeck()
        {
            for (int i = 1; i <= 4; i++)//za svaku boju
            {
                for (int l = 2; l <= 10; l++)//brojcane karte
                {
                    Card karta = new Card(l.ToString());
                    Cards.Add(karta);
                }
                //karte znakovi
                Card a = new Card("A");Card k = new Card("K");Card q = new Card("Q");Card j = new Card("J");
                Cards.Add(a);Cards.Add(k);Cards.Add(q);Cards.Add(j);
            }
        }
}
}
