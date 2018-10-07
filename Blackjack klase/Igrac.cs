using OTTER;
namespace Blackjack
{
    public class Player:Person
    {
        //konstruktori
        /// <summary>
        /// Osnovni kontruktor.
        /// </summary>
        /// <param name="_money"></param>
        public Player(int _money):base() //igrac koristi kontruktor bazne klase
        {
            //postavimo pocetne vrijednosti
            money = _money;
            score = 0;
            bet = 0;
        }
        /// <summary>
        /// Defaultni kontruktor.
        /// </summary>
        public Player():base() { score = 0;money = 10000; }
        private double money;
        /// <summary>
        /// Kolicina novca igraca
        /// </summary>
        public double Money
        {
            get { return money;}
            set { money = value; }
        }

        private int cards_number;
        public int CardsNumber//svojstvo koje nam govori koliko igrac ima karat u ruci,ako ima 7,igrac zavrsava svoju igru
        {
            get { return Hand.Count; }
        }

        private int score;
        /// <summary>
        /// 0 izjednaceno, -1 poraz  1 pobjeda
        /// </summary>
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        private int bet;
        /// <summary>
        /// Trenutna oklada igraca.
        /// </summary>
        public int Bet
        {
            get { return bet; }
            set { bet = value; if (bet < 0) { bet = 0; } }
        }
        /// <summary>
        /// Svojstvo koje nam dohvati ID zadnje karte igraca,zbog lakseg dodavanja karata na ekran
        /// </summary>
        public string LastCard
        {
            get { return Hand[CardsNumber - 1].ID; }
        }
        /// <summary>
        /// Svojstvo koje nam vraca vrijednost zadnje karte igraca
        /// </summary>
        public int LastCardValue
        {
            get { return Hand[CardsNumber - 1].Value; }
        }
    }
}
