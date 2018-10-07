namespace Blackjack
{
    /// <summary>
    /// Klasa koja predstavlja nacrt objekta karte koja se koristi za igru blackjacka
    /// </summary>
    public class Card
    {
        private string id;
        /// <summary>
        /// Svojstvo koje odredjuje kartu
        /// </summary>
        public string ID
        {
            get { return id; }set { id = value; }
        }
        
        private int card_value;
        /// <summary>
        /// Svojstvo koje nam kaze kolika je blackjack vrijednost karte
        /// </summary>
        public int Value
        {
            get
            {
                return card_value;
            }
            set { card_value = value; }
        }
        /// <summary>
        /// Svojstvo koje govori je li karta broj ili znak sluzi za dodavanje karata na ekran
        /// </summary>
        public bool IDNumber
        {
            get
            {
                if (ID == "J" || ID == "Q" || ID == "K" || ID == "A") return true;
                else return false;
            }
        }

        //konstruktori
        public Card()
        { id = "";card_value = 0; }
        public Card(string id_karte)//prima string id,dakle oznaku karte,brojeve standardno te "J","Q","K","A"
        {
            id = id_karte;
            //ako se moze pretvoriti u broj
            try
            {
                card_value = int.Parse(id_karte);//karte 2,3,4,5,6,7,8,9,10
            }
            catch //ako se ne moze pretvoriti u broj
            {
                if (id_karte == "J" || id_karte == "Q" || id_karte == "K")//ako je karta J,Q ili K,vrijednost je 10
                {
                    card_value = 10;
                }
                else card_value = 11;//ako je karta as,defaultno se stavi na pocetak 11,kasnije se mjenja tijekom igre po potrebi
            }
        } 
    }
}
