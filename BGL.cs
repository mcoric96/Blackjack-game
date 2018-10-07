using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Blackjack;

namespace OTTER
{
    /// <summary>
    /// -
    /// </summary>
    public partial class BGL : Form
    {
        /* ------------------- */
        #region Environment Variables

        List<Func<int>> GreenFlagScripts = new List<Func<int>>();

        /// <summary>
        /// Uvjet izvršavanja igre. Ako je <c>START == true</c> igra će se izvršavati.
        /// </summary>
        /// <example><c>START</c> se često koristi za beskonačnu petlju. Primjer metode/skripte:
        /// <code>
        /// private int MojaMetoda()
        /// {
        ///     while(START)
        ///     {
        ///       //ovdje ide kod
        ///     }
        ///     return 0;
        /// }</code>
        /// </example>
        public static bool START = true;

        //sprites
        /// <summary>
        /// Broj likova.
        /// </summary>
        public static int spriteCount = 0, soundCount = 0;

        /// <summary>
        /// Lista svih likova.
        /// </summary>
        //public static List<Sprite> allSprites = new List<Sprite>();
        public static SpriteList<Sprite> allSprites = new SpriteList<Sprite>(); //LISTA SVIH LIKOVA U IGRI

        //sensing
        int mouseX, mouseY;
        Sensing sensing = new Sensing();

        //background
        List<string> backgroundImages = new List<string>();
        int backgroundImageIndex = 0;
        string ISPIS = "";

        SoundPlayer[] sounds = new SoundPlayer[1000];
        TextReader[] readFiles = new StreamReader[1000];
        TextWriter[] writeFiles = new StreamWriter[1000];
        bool showSync = false;
        int loopcount;
        DateTime dt = new DateTime();
        String time;
        double lastTime, thisTime, diff;

        #endregion
        /* ------------------- */
        #region Events

        private void Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            try
            {
                foreach (Sprite sprite in allSprites)
                {
                    if (sprite != null)
                        if (sprite.Show == true)
                        {
                            g.DrawImage(sprite.CurrentCostume, new Rectangle(sprite.X, sprite.Y, sprite.Width, sprite.Heigth));
                        }
                    if (allSprites.Change)
                        break;
                }
                if (allSprites.Change)
                    allSprites.Change = false;
            }
            catch
            {
                //ako se doda sprite dok crta onda se mijenja allSprites
                MessageBox.Show("Greška!");
            }
        }

        private void startTimer(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            Init();
            OnemoguciKontrole();//onemogucimo kontrole od korisnika
            LoadSettings();//postavimo sve pocetne vrijednosti
            BetChange += new BetChangeEvent(AddBet);//dogadjaju promjene oklade dodamo instancu delegata

            //dogadjaj za brisanje oklade
            ClearBet += new ClearBetEvent(ClearBet_Clicked);


            //pokusamo pozadinu dodati kao sprite
            pictureBoxStol.Visible = false;//ne vidimo vise picture box
            Sprite slika = new Sprite("Resources\\blackjack-table.png", pictureBoxStol.Location.X, pictureBoxStol.Location.Y, pictureBoxStol.Width, pictureBoxStol.Height, "pozadina");
            Game.AddSprite(slika);
        }

        private void updateFrameRate(object sender, EventArgs e)
        {
            updateSyncRate();
        }

        /// <summary>
        /// Crta tekst po pozornici.
        /// </summary>
        /// <param name="sender">-</param>
        /// <param name="e">-</param>
        public void DrawTextOnScreen(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            var brush = new SolidBrush(Color.WhiteSmoke);
            string text = ISPIS;

            SizeF stringSize = new SizeF();
            Font stringFont = new Font("Arial", 14);
            stringSize = e.Graphics.MeasureString(text, stringFont);

            using (Font font1 = stringFont)
            {
                RectangleF rectF1 = new RectangleF(0, 0, stringSize.Width, stringSize.Height);
                e.Graphics.FillRectangle(brush, Rectangle.Round(rectF1));
                e.Graphics.DrawString(text, font1, Brushes.Black, rectF1);
            }
        }

        private void mouseClicked(object sender, MouseEventArgs e)
        {
            //sensing.MouseDown = true;
            sensing.MouseDown = true;
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            //sensing.MouseDown = true;
            sensing.MouseDown = true;
        }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            //sensing.MouseDown = false;
            sensing.MouseDown = false;
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            //mouseX = e.X;
            //mouseY = e.Y;

            //sensing.MouseX = e.X;
            //sensing.MouseY = e.Y;
            //Sensing.Mouse.x = e.X;
            //Sensing.Mouse.y = e.Y;
            //sensing.Mouse.X = e.X;
            //sensing.Mouse.Y = e.Y;

            //na formi pokazemo koordinate misa
            //lblMisKoordinate.Text = sensing.Mouse.X + ";" + sensing.Mouse.Y;
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            sensing.Key = e.KeyCode.ToString();
            sensing.KeyPressedTest = true;
        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            sensing.Key = "";
            sensing.KeyPressedTest = false;
        }

        private void Update(object sender, EventArgs e)
        {
            if (sensing.KeyPressed(Keys.Escape))
            {
                START = false;
            }

            if (START)
            {
                this.Refresh();
            }
        }

        #endregion
        /* ------------------- */
        #region Start of Game Methods

        //my
        #region my

        //private void StartScriptAndWait(Func<int> scriptName)
        //{
        //    Task t = Task.Factory.StartNew(scriptName);
        //    t.Wait();
        //}

        //private void StartScript(Func<int> scriptName)
        //{
        //    Task t;
        //    t = Task.Factory.StartNew(scriptName);
        //}

        private int AnimateBackground(int intervalMS)
        {
            while (START)
            {
                setBackgroundPicture(backgroundImages[backgroundImageIndex]);
                OTTER.Game.WaitMS(intervalMS);
                backgroundImageIndex++;
                if (backgroundImageIndex == 3)
                    backgroundImageIndex = 0;
            }
            return 0;
        }

        private void KlikNaZastavicu()
        {
            foreach (Func<int> f in GreenFlagScripts)
            {
                Task.Factory.StartNew(f);
            }
        }

        #endregion

        /// <summary>
        /// BGL
        /// </summary>
        public BGL()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pričekaj (pauza) u sekundama.
        /// </summary>
        /// <example>Pričekaj pola sekunde: <code>Wait(0.5);</code></example>
        /// <param name="sekunde">Realan broj.</param>
        public static void Wait(double sekunde)
        {
            int ms = (int)(sekunde * 1000);
            Thread.Sleep(ms);
        }

        //private int SlucajanBroj(int min, int max)
        //{
        //    Random r = new Random();
        //    int br = r.Next(min, max + 1);
        //    return br;
        //}

        /// <summary>
        /// -
        /// </summary>
        public void Init()
        {
            if (dt == null) time = dt.TimeOfDay.ToString();
            loopcount++;
            //Load resources and level here
            this.Paint += new PaintEventHandler(DrawTextOnScreen);
            SetupGame();
        }

        /// <summary>
        /// -
        /// </summary>
        /// <param name="val">-</param>
        public void showSyncRate(bool val)
        {
            showSync = val;
            if (val == true) syncRate.Show();
            if (val == false) syncRate.Hide();
        }

        /// <summary>
        /// -
        /// </summary>
        public void updateSyncRate()
        {
            if (showSync == true)
            {
                thisTime = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
                diff = thisTime - lastTime;
                lastTime = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;

                double fr = (1000 / diff) / 1000;

                int fr2 = Convert.ToInt32(fr);

                syncRate.Text = fr2.ToString();
            }

        }

        //stage
        #region Stage

        /// <summary>
        /// Postavi naslov pozornice.
        /// </summary>
        /// <param name="title">tekst koji će se ispisati na vrhu (naslovnoj traci).</param>
        public void SetStageTitle(string title)
        {
            this.Text = title;
        }

        /// <summary>
        /// Postavi boju pozadine.
        /// </summary>
        /// <param name="r">r</param>
        /// <param name="g">g</param>
        /// <param name="b">b</param>
        public void setBackgroundColor(int r, int g, int b)
        {
            this.BackColor = Color.FromArgb(r, g, b);
        }

        /// <summary>
        /// Postavi boju pozornice. <c>Color</c> je ugrađeni tip.
        /// </summary>
        /// <param name="color"></param>
        public void setBackgroundColor(Color color)
        {
            this.BackColor = color;
        }

        /// <summary>
        /// Postavi sliku pozornice.
        /// </summary>
        /// <param name="backgroundImage">Naziv (putanja) slike.</param>
        public void setBackgroundPicture(string backgroundImage)
        {
            this.BackgroundImage = new Bitmap(backgroundImage);
        }

        /// <summary>
        /// Izgled slike.
        /// </summary>
        /// <param name="layout">none, tile, stretch, center, zoom</param>
        public void setPictureLayout(string layout)
        {
            if (layout.ToLower() == "none") this.BackgroundImageLayout = ImageLayout.None;
            if (layout.ToLower() == "tile") this.BackgroundImageLayout = ImageLayout.Tile;
            if (layout.ToLower() == "stretch") this.BackgroundImageLayout = ImageLayout.Stretch;
            if (layout.ToLower() == "center") this.BackgroundImageLayout = ImageLayout.Center;
            if (layout.ToLower() == "zoom") this.BackgroundImageLayout = ImageLayout.Zoom;
        }

        #endregion

        //sound
        #region sound methods

        /// <summary>
        /// Učitaj zvuk.
        /// </summary>
        /// <param name="soundNum">-</param>
        /// <param name="file">-</param>
        public void loadSound(int soundNum, string file)
        {
            soundCount++;
            sounds[soundNum] = new SoundPlayer(file);
        }

        /// <summary>
        /// Sviraj zvuk.
        /// </summary>
        /// <param name="soundNum">-</param>
        public void playSound(int soundNum)
        {
            sounds[soundNum].Play();
        }

        /// <summary>
        /// loopSound
        /// </summary>
        /// <param name="soundNum">-</param>
        public void loopSound(int soundNum)
        {
            sounds[soundNum].PlayLooping();
        }

        /// <summary>
        /// Zaustavi zvuk.
        /// </summary>
        /// <param name="soundNum">broj</param>
        public void stopSound(int soundNum)
        {
            sounds[soundNum].Stop();
        }

        #endregion

        //file
        #region file methods

        /// <summary>
        /// Otvori datoteku za čitanje.
        /// </summary>
        /// <param name="fileName">naziv datoteke</param>
        /// <param name="fileNum">broj</param>
        public void openFileToRead(string fileName, int fileNum)
        {
            readFiles[fileNum] = new StreamReader(fileName);
        }

        /// <summary>
        /// Zatvori datoteku.
        /// </summary>
        /// <param name="fileNum">broj</param>
        public void closeFileToRead(int fileNum)
        {
            readFiles[fileNum].Close();
        }

        /// <summary>
        /// Otvori datoteku za pisanje.
        /// </summary>
        /// <param name="fileName">naziv datoteke</param>
        /// <param name="fileNum">broj</param>
        public void openFileToWrite(string fileName, int fileNum)
        {
            writeFiles[fileNum] = new StreamWriter(fileName);
        }

        /// <summary>
        /// Zatvori datoteku.
        /// </summary>
        /// <param name="fileNum">broj</param>
        public void closeFileToWrite(int fileNum)
        {
            writeFiles[fileNum].Close();
        }

        /// <summary>
        /// Zapiši liniju u datoteku.
        /// </summary>
        /// <param name="fileNum">broj datoteke</param>
        /// <param name="line">linija</param>
        public void writeLine(int fileNum, string line)
        {
            writeFiles[fileNum].WriteLine(line);
        }

        /// <summary>
        /// Pročitaj liniju iz datoteke.
        /// </summary>
        /// <param name="fileNum">broj datoteke</param>
        /// <returns>vraća pročitanu liniju</returns>
        public string readLine(int fileNum)
        {
            return readFiles[fileNum].ReadLine();
        }

        /// <summary>
        /// Čita sadržaj datoteke.
        /// </summary>
        /// <param name="fileNum">broj datoteke</param>
        /// <returns>vraća sadržaj</returns>
        public string readFile(int fileNum)
        {
            return readFiles[fileNum].ReadToEnd();
        }

        #endregion

        //mouse & keys
        #region mouse methods

        /// <summary>
        /// Sakrij strelicu miša.
        /// </summary>
        public void hideMouse()
        {
            Cursor.Hide();
        }

        /// <summary>
        /// Pokaži strelicu miša.
        /// </summary>
        public void showMouse()
        {
            Cursor.Show();
        }

        /// <summary>
        /// Provjerava je li miš pritisnut.
        /// </summary>
        /// <returns>true/false</returns>
        public bool isMousePressed()
        {
            //return sensing.MouseDown;
            return sensing.MouseDown;
        }

        /// <summary>
        /// Provjerava je li tipka pritisnuta.
        /// </summary>
        /// <param name="key">naziv tipke</param>
        /// <returns></returns>
        public bool isKeyPressed(string key)
        {
            if (sensing.Key == key)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnBasicStrategy_Click(object sender, EventArgs e) //kad zelimo formu za basic strategy
        {
            FormStrategy form = new FormStrategy();
            form.Show();
        }

        /// <summary>
        /// Provjerava je li tipka pritisnuta.
        /// </summary>
        /// <param name="key">tipka</param>
        /// <returns>true/false</returns>
        public bool isKeyPressed(Keys key)
        {
            if (sensing.Key == key.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #endregion
        /* ------------------- */

        /* ------------ GAME CODE START ------------ */

        /* Deklariranje likova koji se koriste */
        public static Player user;
        public static Player player1;
        public static Player player2;
        public static Dealer dealer;
        public static Deck deck;

        /* varijable u igri */

        /// <summary>
        /// Delegat koji sluzi za dogadjaj promjene oklade igraca .
        /// </summary>
        /// <param name="oklada"></param>
        private delegate void BetChangeEvent(int oklada);

        /// <summary>
        /// Delegat koji sluzi za dogadjaj postavljanja oklade korisnika na 0
        /// </summary>
        private delegate void ClearBetEvent();

        /// <summary>
        /// Dogadjaj kad igrac promjeni okladu u igri.
        /// </summary>
        private event BetChangeEvent BetChange;

        /// <summary>
        /// Dogadjaj kad igrac postavi okladu na 0 tj. pobrise je.
        /// </summary>
        private event ClearBetEvent ClearBet;

        private void SetupGame()
        {
            //1. Postavi pozornicu
            SetStageTitle("Blackjack game");
            setBackgroundColor(Color.DarkGreen);          
            //none, tile, stretch, center, zoom
            setPictureLayout("stretch");
        }

        #region moje_metode
        /// <summary>
        /// Metoda kojom postavimo pocetne vrijednosti igre.
        /// </summary>
        private void SetGame()
        {
            BlackjackGame.ActiveGame = true;
            user.Active = false;
            BlackjackGame.PocetniNovac = 10000;
            lblPlayerMoney.Text = "Money: 10000";
            BlackjackGame.BrojSpilova = 8;
            BlackjackGame.DoubleActive = false;
            BlackjackGame.TrenutniIgrac = TrenutniIgrac.Player1;
            MessageBox.Show("Game starts.","Game",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //GameTimer.Enabled = true;
            //GameTimer.Start();
            btnNovaIgra.Enabled = true;
            lblUserScore.Visible = true;
            lblPlayerMoney.Visible = true;lblPlayerMoney.Text = "0";

            // PRILAGODITI NAKNADNO postavimo svim osobama koordinate pocetne pozicije njihove prve karte
            user.SetNewCard(520, 373);
            player1.SetNewCard(815, 340); player2.SetNewCard(215, 242); dealer.SetNewCard(512, 42);//POSEBNO SVIMA PRILAGODITI
        }

        #region game_methods
        /// <summary>
        /// Metoda kojom pripremimo sljedecu rundu za igru.
        /// </summary>
        private void SetNextRound()
        {
            btnDeal.Enabled = false;//moramo onemoguciti pokretanje nove runde jer je jedna vec pokrenuta
            user.Active = false;//korisnik jos ne igra na pocetku runde
            player2.Active = false; dealer.Active = false;//na pocetku runde igra player1,ostali nisu aktivni
            OnemoguciKontrole();//korisniku onemogucimo kontrole
            //postavimo svim osobama koordinate pocetne pozicije njihove prve karte
            user.SetNewCard(520, 373);
            player1.SetNewCard(815, 330); player2.SetNewCard(215, 242); dealer.SetNewCard(512, 42);

            //uvjet za ponovno mjesanje spila karata.
            if (deck.CardsNumber / (52 * BlackjackGame.BrojSpilova) < 0.3)
            {
                deck = new Deck(BlackjackGame.BrojSpilova);//postavimo novi spil za igru,koji se promjesa
            }

            //postavimo pocetne ruke,po redu kako sjede u igri
            //za prvog igraca
            player1.AddNewCard(new Card(deck.ReturnCard().ID));
            player1.AddNewCard(new Card(deck.ReturnCard().ID));

            //za igraca korisnika
            user.AddNewCard(new Card(deck.ReturnCard().ID));
            user.AddNewCard(new Card(deck.ReturnCard().ID));

            //za drugog igraca
            player2.AddNewCard(new Card(deck.ReturnCard().ID));
            player2.AddNewCard(new Card(deck.ReturnCard().ID));

            //za djelitelja,dodamo samo jednu kartu po pravilima
            dealer.AddNewCard(new Card(deck.ReturnCard().ID));
            Sprite poledjina = new Sprite("sprites\\blue_back.png", dealer.LastCard_X, dealer.LastCard_Y, 65, 100, "card");
            Game.AddSprite(poledjina);

            lblDealerScore.Visible = true;lblUserScore.Visible = true;
            lblDealerScore.Text = dealer.HandValue.ToString();
            lblUserScore.Text = user.HandValue.ToString();

            //postavimo da je trenutni igrac player1
            //BlackjackGame.TrenutniIgrac = TrenutniIgrac.Player1; VRATITI PO POTREBI
            player1.Active = true;
            lblActivePlayer.Text = "Active player: player 1";
        }
        
        /// <summary>
        /// Metoda kojom igra igrac.
        /// </summary>
        private void Play(Player player, int dealer_card)
        {
            if (player1.Active) { lblActivePlayer.Text = "Active player: player 1"; }
            else lblActivePlayer.Text = "Active player: player 2";

            if (player.CardsNumber == 7)//ako ima 7 karata,runda je za igraca zavrsena
            {
                //namjestimo tko je sljedeci igrac/djelitelj
                if (player1.Active)
                { player1.Active = false; user.Active = true; OmoguciKontrole(); EnableBets(false); lblActivePlayer.Text = "Active player: user"; }
                else if (player2.Active)
                {
                    player2.Active = false; dealer.Active = true; lblActivePlayer.Text = "Active player: dealer";
                    MessageBox.Show("Dealer play.");
                    while (dealer.Active) { Play(); }
                }
            }
            else //inace ako nema 7 karata igrac jos moze igrati
            {
                if (player.CardsNumber == 2)//ima opciju double
                {
                    if (player.HandValue == 10 && !player.SoftHand && dealer_card <= 9)//jedini slucaj kad igrac uzima double
                    {
                        Card nova_karta = deck.ReturnCard();//nova karta za igraca
                        player.AddNewCard(nova_karta);//dodamo kartu igracu
                        //igrac je zavrsio sa svojom igrom,namjestimo sljedecem igracu
                        if (player1.Active)
                        { player1.Active = false; user.Active = true; OmoguciKontrole(); EnableBets(false); lblActivePlayer.Text = "Active player: user"; }
                        else if (player2.Active)
                        {
                            player2.Active = false; dealer.Active = true; lblActivePlayer.Text = "Active player: dealer";
                            MessageBox.Show("Dealer play.");
                            while (dealer.Active) { Play(); }
                        }
                    }
                    else //ne uzima double,uzima jednu kartu normalno
                    {
                        if (player.HandValue < 17 || (player.HandValue >= 17 && player.HandValue<=19 && player.SoftHand))//uzima opciju hit
                        {
                            Card nova_karta = deck.ReturnCard();//nova karta za igraca
                            player.AddNewCard(nova_karta);//dodamo kartu igracu
                        }
                        else//igrac uzima stand
                        {
                            if (player1.Active)
                            { player1.Active = false; user.Active = true; OmoguciKontrole(); EnableBets(false); lblActivePlayer.Text = "Active player: user"; }
                            else if (player2.Active)
                            {
                                player2.Active = false; dealer.Active = true; lblActivePlayer.Text = "Active player: dealer";
                                MessageBox.Show("Dealer play.");
                                while (dealer.Active) { Play(); }
                            }
                        }
                    }
                }
                else//inace ako ima 3 ili vise karata,ima samo opcije hit i stand
                {
                    //ako je sigurno stand opcija
                    if (player.HandValue >= 17 && !player.SoftHand)
                    {
                        if (player1.Active)
                        { player1.Active = false; user.Active = true;OmoguciKontrole(); EnableBets(false); lblActivePlayer.Text = "Active player: user"; }
                        else if (player2.Active)
                        {
                            player2.Active = false; dealer.Active = true; lblActivePlayer.Text = "Active player: dealer";
                            MessageBox.Show("Dealer play.");
                            while (dealer.Active) { Play(); }
                        }
                    }
                    else //inace,ako jos uvijek ima smisla igrati
                    {
                        Card nova_karta = deck.ReturnCard();//nova karta za igraca
                        player.AddNewCard(nova_karta);//dodamo kartu igracu
                    }
                }
            }
        }

        /// <summary>
        /// Metoda koja oponasa igru djelitelja.Djelitelj igra po fiksnim pravilima.
        /// </summary>
        private void Play()
        {
            lblActivePlayer.Text = "Active player: dealer";
            dealer.Active = true;
            lblDealerScore.Visible = true;lblDealerScore.Text = "0";
            //sve dok zbroj djelitelja nije barem 17,djelitelj igra po fiksnim pravilima
            while (dealer.HandValue < 17)
            {
                Card karta = deck.ReturnCard();//nova karta za djelitelja
                dealer.AddNewCard(karta);//dodamo jos kartu djelitelju
                lblDealerScore.Text = dealer.HandValue.ToString();
                Wait(0.05);
            }
            dealer.Active = false; player1.Active = false;player2.Active = false;user.Active = false;
            lblActivePlayer.Text = "Active player: nobody";
            //kad djelitelj odigra,isplatimo igraca ako je pobjedio
            if ((user.HandValue <= 21 && user.HandValue > dealer.HandValue) || (user.HandValue <= 21 && dealer.HandValue > 21))
            {
                user.Money += 2 * user.Bet;
                MessageBox.Show("You won!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (user.HandValue > 21 || (dealer.HandValue <= 21 && dealer.HandValue > user.HandValue))//inace ako je igrac presao 21,ili ako
            {   //djelitelj ima veci zbroj karata,igrac gubi okladu,oklada je vec oduzeta od novca igraca prilikom dodavanja oklade
                MessageBox.Show("You lost!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //ko igrac vise nema novca
                if (user.Money <= 0)
                {
                    MessageBox.Show("You don't have any money for play!");
                    user.Active = false; player1.Active = false; player2.Active = false; dealer.Active = false;
                    OnemoguciKontrole();
                }
            }
            else { MessageBox.Show("Draw !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); user.Money += user.Bet; }
            user.Bet = 0;
            lblNovac.Text = "0";
            lblPlayerMoney.Text = "Money: " + user.Money;

            btnDeal.Enabled = true;//omogucimo da igrac pokrene novu rundu za igru
            lblDealerScore.Visible = false;lblUserScore.Visible = false;
            pictureBoxChip100.Enabled = true;pictureBoxChip25.Enabled = true;pictureBoxChip5.Enabled = true;pictureBoxChip50.Enabled = true;
            ClearStage();
        }
        #endregion

        private void CardVisible(bool visible)
        {
            foreach (Sprite card in allSprites)
            {
                if (card.Name.ToLower().Trim() == "card" || card.Name.ToLower().Trim( )== "karta")
                {
                    card.SetVisible(visible);
                }
            }
        }

        private void EnableBets(bool enabled)
        {
            pictureBoxChip100.Enabled = enabled;
            pictureBoxChip25.Enabled = enabled;
            pictureBoxChip5.Enabled = enabled;
            pictureBoxChip50.Enabled = enabled;
        }

        /// <summary>
        /// Metoda kojom na kraju runde ocistimo ekran od svih karata.
        /// </summary>
        private void ClearStage()
        {
            CardVisible(false);//postavimo karte na nevidljivo
            try
            {
                //onda izbrisemo sve likove iz igre
                for (int i = 0; i < allSprites.Count; i++) //izbrisemo sve spriteove koji nisu pozadina,tj sve karte
                {
                    if (allSprites[i].Show == false || allSprites[i].Name.ToLower() == "card") { allSprites.RemoveAt(i); }
                }
            }
            catch { throw new Exception(); }

            try
            {
                //maknemo igracima  i djelitelju sve karte koje je imao
                user.Hand.Clear(); player1.Hand.Clear(); player2.Hand.Clear(); dealer.Hand.Clear();
            }
            catch { throw new Exception(); }

            spriteCount = allSprites.Count;//samo pozadina
            lblUserScore.Visible = false;
            lblDealerScore.Visible = false;
            lblPlayerMoney.Text = "Money: "+user.Money.ToString();lblPlayerMoney.Visible = true;
            lblNovac.Text = "0";lblNovac.Visible = true;
            user.Bet = 0;
        }
        /// <summary>
        /// Postavimo pocetne vrijednosti pri ucitavanju igre.
        /// </summary>
        private void LoadSettings()
        {
            BlackjackGame.ActiveGame = false;
            BlackjackGame.DoubleActive = false;
            BlackjackGame.BrojSpilova = 8;
            BlackjackGame.PocetniNovac = 10000;lblNovac.Text = "0";lblPlayerMoney.Text = "Money: 0";
            BlackjackGame.TrenutniIgrac = TrenutniIgrac.Nobody;//moramo postaviti da trenutno nitko ne igra

            //postavimo nase varijable
            user = new Player(10000);
            player1 = new Player();player2 = new Player();dealer = new Dealer();
            deck = new Deck(8);

            lblUserScore.Visible = false;
            lblDealerScore.Visible = false;
            btnDeal.Enabled = false;
        }

        #region micanje_misa
        private void pictureBoxStol_MouseMove(object sender, MouseEventArgs e)
        {
            lblMisKoordinate.Text = e.X + ";" + e.Y;
        }
        #endregion

        private void OnemoguciKontrole()
        {
            btnHit.Enabled = false;btnStand.Enabled = false;btnDouble.Enabled = false;
            pictureBoxChip100.Enabled = false;pictureBoxChip25.Enabled = false;pictureBoxChip5.Enabled = false;pictureBoxChip50.Enabled = false;
        }

        private void OmoguciKontrole()
        {
            btnHit.Enabled = true; btnStand.Enabled = true; btnDouble.Enabled = true; 
            pictureBoxChip100.Enabled = true; pictureBoxChip25.Enabled = true; pictureBoxChip5.Enabled = true; pictureBoxChip50.Enabled = true;
            lblUserScore.Visible = true; lblDealerScore.Visible = true;
        }

        private void BetsAllowed(bool allowed)
        {
            pictureBoxChip100.Enabled = allowed;pictureBoxChip25.Enabled = allowed;pictureBoxChip5.Enabled = allowed;pictureBoxChip50.Enabled = allowed;
        }

        #region akcije_korisnika_dogadjaji

        #region kontrole_dogadjaji

        /// <summary>
        /// Kliknuta kontrola Clear bet,metoda koja oponasa taj dogadjaj.
        /// </summary>
        private void ClearBet_Clicked()
        {
            if (user.Bet > 0)
            {
                user.Money += user.Bet;//igracu vratimo njegovu okladu
                user.Bet = 0;//igracu korisniku postavimo okladu na 0
                lblNovac.Text = "0";
                lblPlayerMoney.Text = "Money: " + user.Money.ToString();
                btnClearOklada.Enabled = false;
            }
        }
        #endregion

        #region oklada_dogadjaji
        /// <summary>
        /// Metoda za dogadjaj kad korisnik doda novu okladu u igru.
        /// </summary>
        private void AddBet(int bet)
        {
            if (bet > 0)
            {
                if (user.Money - bet < 0)//ako oklada nije dopustena
                {
                    MessageBox.Show("Bet is not allowed.", "Mistake", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // ako je oklada dopustena
                {
                    user.Bet += bet;//postavimo okladu igraca
                    lblNovac.Text = user.Bet.ToString();
                    user.Money -= bet;
                    lblPlayerMoney.Text = "Money: "+ user.Money.ToString();
                    btnClearOklada.Enabled = true;
                }
            }
        }

        private void pictureBoxChip5_Click(object sender, EventArgs e)//dogadjaj kad se odabere oklada 5
        {
            BetChange.Invoke(5);//pokrenemo dogadjaj
        }

        private void pictureBoxChip25_Click(object sender, EventArgs e)//dogadjaj kad se odabere oklada 25
        {
            BetChange.Invoke(25);//pokrenemo dogadjaj
        }

        private void pictureBoxChip50_Click(object sender, EventArgs e)//dogadjaj kad se odabere oklada 50
        {
            BetChange.Invoke(50);//pokrenemo dogadjaj
        }

        private void ClearBet_Clicked(object sender, EventArgs e)//dogadjaj kad obrisemo okladu,tj postavimo je na 0
        {
            ClearBet.Invoke();
        }

        private void HitClick(object sender, EventArgs e)//dogadjaj kad uzimamo jos jednu kartu
        {
            Card card = new Card(deck.ReturnCard().ID);//nova karta za igraca korisnika
            user.AddNewCard(card); //dodamo kartu korisniku
            lblUserScore.Text = user.HandValue.ToString();
            btnDouble.Enabled = false;//ako igrac uzme kartu opcijom HIT,onda ne moze vise koristiti opciju DOUBLE
            
            //ako je igrac presao 21 ,nema vise pravo na igru
            if (user.HandValue >= 21) //ako igrac ima 21 odmah staje jer nema smisla dalje igrati jer ima najbolji moguci zbroj
            {
                StandClick(null, null);
            }
        }

        private void StandClick(object sender, EventArgs e)//dogadjaj kad zaustavimo igru korisnika u jednoj rundi
        {
            user.Active = false;//igrac vise nije aktivan
            OnemoguciKontrole();
            btnDouble.Enabled = false;
            player2.Active = true;
            lblActivePlayer.Text = "Active player: player 2";
            while (player2.Active)
            {
                Play(player2, dealer.HandValue);//igrac 2 igra
            }
        }

        private void btnDouble_Click(object sender, EventArgs e)//dogadjaj kad korisnik odigra opciju double
        {
            //koristimo prije definirane dogadjaje,tj metode koje reagiraju na njih
            if (user.Money - user.Bet < 0)
            {
                MessageBox.Show("You don't have enough money for option DOUBLE!");
                return;
            }
            user.Money -= user.Bet;
            user.Bet = 2 * user.Bet;
            lblNovac.Text = user.Bet.ToString();

            Card card = new Card(deck.ReturnCard().ID);//nova karta za igraca korisnika
            user.AddNewCard(card); //dodamo kartu korisniku
            lblUserScore.Text = user.HandValue.ToString();
            StandClick(null, null);
        }

        //button koji testiramo program
        private void btnTestButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sprite count: "+allSprites.Count);
        }

        private void Deal_Click(object sender, EventArgs e)//dogadjaj kad zelimo dijeliti novu rundu
        {
            if (user.Bet <= 0)
            {
                MessageBox.Show("Add bet.");
                return;
            }
            
            btnDeal.Enabled = false;
            btnClearOklada.Enabled = false;
            OnemoguciKontrole();
            MessageBox.Show("GAME STARTS");
            SetNextRound();
            EnableBets(false);
            while (player1.Active) { Play(player1,dealer.HandValue); }
        }

        private void btnTest2_Click(object sender, EventArgs e)//novi test dogadjaj
        {
            foreach (Sprite sprite in allSprites)
            {
                sprite.Show = true;
            }
        }

        private void pictureBoxChip100_Click(object sender, EventArgs e)//dogadjaj kad se odabere oklada 100
        {
            BetChange.Invoke(100);//pokrenemo dogadjaj
        }
        #endregion

        /// <summary>
        /// Metoda kojom kotroliramo timer igre,tj dogadjaje u igri ako je aktivna,pola sekunde razmaka.
        /// </summary>
        private void UpdateGameTimer(object sender, EventArgs e)
        {
            if (BlackjackGame.ActiveGame)
            {
                lblMisKoordinate.Text = "Sprite count: "+allSprites.Count;
                if (!user.Active)//ako korisnik ne igra trenutno
                {
                    //OnemoguciKontrole();//zakljucamo korisnicke kontrole
                }
                else
                {
                    //OmoguciKontrole();//inace ako korisnik igra omoguci kontrole
                    ////gledamo za opciju double je li smije biti aktivna
                    //if (user.CardsNumber==2) btnDouble.Enabled = true;
                    //else btnDouble.Enabled = false;

                    //gledamo je li igrac ima uopce novaca jos za igru
                    if (user.Money <= 0)
                    {
                        BlackjackGame.ActiveGame = false;
                        ClearStage();
                        lblPlayerMoney.Text = "Money: 0";lblNovac.Text = "0";
                        OnemoguciKontrole();
                        MessageBox.Show("Game is finished,you don't have any money!.", "GAME END");
                    }
                    lblUserScore.Visible = true;
                }
            }
            else { GameTimer.Enabled = false;OnemoguciKontrole(); btnNovaIgra.Enabled = true; }
        }
        #endregion
        #endregion

        private void btnWikipedia_Click(object sender, EventArgs e)//zelimo otvoriti blackjack stranicu na wikipediji
        {
            try
            {
                Process.Start("https://en.wikipedia.org/wiki/Blackjack");
            }
            catch
            {
                MessageBox.Show("Trouble with internet connection.","Mistake",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnNovaIgra_Click(object sender, EventArgs e)//dogadjaj kad se odabere nova igra
        {
            lblPlayerMoney.Text = "10000";lblPlayerMoney.Visible = true;
            lblNovac.Text = "0";lblNovac.Visible = true;
            btnDeal.Enabled = true;
            OnemoguciKontrole();
            BetsAllowed(true);
            btnClearOklada.Enabled = true;

            btnNovaIgra.Enabled = false;
        }

        /* ------------ GAME CODE END ------------ */
    }
}
