using OTTER;
namespace Blackjack
{
    public class Dealer:Person
    {
        //konstrutori
        public Dealer():base() //djelitelj koristi kontruktor bazne klase
        {
            _bust = false;
        }

        private bool _bust;
        /// <summary>
        /// Da znamo je li djelitelj presao zbroj 21,tada je true,inace je false
        /// </summary>
        public bool Bust
        {
            get
            {
                if (HandValue <= 21) return true;//ako djelitelj ima 21 ili manje nije Bust,inace je
                else return false;
            }
            set
            { _bust = value; }
        }
    }
}
