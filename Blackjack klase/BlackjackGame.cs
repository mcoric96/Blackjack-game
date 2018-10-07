/// <summary>
/// Popis igraca u igri
/// </summary>
public enum TrenutniIgrac
{
    Nobody=0, Player1=1, Player2=3, UserPlayer=2, Dealer=4
}

namespace Blackjack
{
    /// <summary>
    /// Klasa sa metodama i svojstvima koje oponasaju pravila igre.
    /// </summary>
    public static class BlackjackGame
    {
        //varijable da znamo koliko je slika karte visoka i siroka
        public static int Sirina=65;
        public static int Visina=100;

        /// <summary>
        /// Zelimo znati tko je trenutni igrac koji igra
        /// </summary>
        public static TrenutniIgrac TrenutniIgrac;
        public static int PocetniNovac;//za igraca korisnika
        /// <summary>
        /// Da znamo s koliko spilova pocinjemo igru
        /// </summary>
        public static int BrojSpilova;

        /// <summary>
        /// Da znamo je li korisniku dostupna opcija double(ako ima tocno 2 karte).
        /// </summary>
        public static bool DoubleActive;

        /// <summary>
        /// Da znamo je li igra aktivna u trenutku
        /// </summary>
        public static bool ActiveGame;
    }
}
