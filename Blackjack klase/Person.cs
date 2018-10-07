using System.Collections.Generic;
using OTTER;
using System;

namespace Blackjack
{
    /// <summary>
    /// Nadklasa od igraca i djelitelja,ima njihove "glavne" osobine.
    /// Ovu klasu nasljedjuju igrac i djelitelj,oboje su osoba,ali njihovo ponasanje u igri je drugacije.
    /// </summary>
    public abstract class Person
    {
        //kontruktor
        public Person()
        {
            hand = new List<Card>();
            last_card_x = 0;
            last_card_y = 0;
            active = false;
            soft_hand = false;
            r = new Random();
        }

        private List<Card> hand;

        /// <summary>
        /// Popis karata koje osoba ima u ruci
        /// </summary>
        public List<Card> Hand
        {
            get { return hand; }set { hand = value; }
        }

        private int last_card_x;
        private int last_card_y;
        private bool active;
        private bool soft_hand;
        private Random r;//pomocni random objekt

        /// <summary>
        /// Metoda koja postavlja koordinate sljedecoj karti za igraca ili djeltielja,koja ce se pojaviti na ekranu.
        /// </summary>
        public void SetNewCard(int x,int y)
        {
            LastCard_X = x;LastCard_Y = y;
        }

        /// <summary>
        /// Svojstvo koje svi igraci imaju,numericka vrijednost karata u ruci koje osoba ima.
        /// </summary>
        public int HandValue
        {
            get
            {
                int br_aseva = 0;//moramo brojiti aseve
                int vrijednost = 0;//ono sta vracamo 
                for (int i = 0; i < Hand.Count; i++)
                {
                    if (Hand[i].ID == "A")
                    {
                        br_aseva = br_aseva + 1;
                    }
                    else//karta koja nije as
                    {
                        vrijednost = vrijednost + Hand[i].Value;
                    }
                }
                SoftHand = false;//soft hand je po defaultu false
                //gledamo je li ijedan as mozemo gledati da ima vrijednost 11
                if (br_aseva > 0)//ako uopce ima aseva u ruci,najvise jedan moze imati vrijednost 11
                {
                    if ((vrijednost + 11 + br_aseva - 1) <= 21)
                    {
                        vrijednost = vrijednost + 11 + br_aseva - 1;//postavimo da jedan as ima vrijednost 11,ostali asevi vrijednost 1
                        SoftHand = true;//jedini slucaj kad je ruka SoftHand
                    }
                    else//ako niti jedan as ne smije imati vrijednost 11,jer bi premasili zbroj 21,svi asevi imaju vrijednost 1
                    {
                        vrijednost = vrijednost + br_aseva;
                    }
                }
                return vrijednost;
            }
        }

        /// <summary>
        /// Svojstvo karata koje osoba ima trenutno,ovisno o broju aseva,ako jedan as u ruci ima vrijednost 11,onda je SoftHand = true,inace je false.
        /// </summary>
        public bool SoftHand
        {
            get { return soft_hand; }set { soft_hand = value; }
        }

        //moramo znati gdje se nalazila zadnja karta igraca na ekranu,da bi znali pozicionirati sljedecu,ako je pozicija(0,0) znaci da nema karata
        public int LastCard_X
        {
            get
            {
                return last_card_x;
            }
            set
            {
                last_card_x = value;
            }
        }

        public int LastCard_Y
        {
            get
            {
                return last_card_y;
            }
            set
            {
                last_card_y = value;
            }
        }

        /// <summary>
        /// Svojstvo da znamo je li igrac trenutno aktivan ,u smislu da on igra trenutno.
        /// </summary>
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }

        /// <summary>
        /// Metoda kojom dodamo novu kartu za igraca.
        /// </summary>
        public void AddNewCard(Card nova_karta)
        {
            //putanja slike spritea(karte)
            string putanja = "sprites\\cards2\\"+nova_karta.ID.ToString()+"\\"+r.Next(1,5).ToString()+".png";
            Hand.Add(nova_karta);//dodamo novu kartu u popis karata koje osoba ima
            Sprite card = new Sprite(putanja, LastCard_X, LastCard_Y, BlackjackGame.Sirina, BlackjackGame.Visina,"card");//napravimo novi lik(karta)
            Game.AddSprite(card);//dodamo kartu u igru
            SetNewCard(LastCard_X + 15, LastCard_Y);//pripremimo za sljedecu kartu,njenu poziciju
        }
    }
}
