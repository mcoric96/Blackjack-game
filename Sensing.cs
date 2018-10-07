using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OTTER
{
    /// <summary>
    /// Klasa <c>Sensing</c> služi za očitavanje događaja s tipkovnice i miša.
    /// </summary>
    public class Sensing
    {
        //mouse
        /// <summary>
        /// Koordinate miša.
        /// </summary>
        public Point Mouse;

        /// <summary>
        /// Miš pritisnut.
        /// </summary>
        public bool MouseDown;

        //key
        private string key;

        private bool keyPressedTest;

        /// <summary>
        /// Je li bilo koja tipka pritisnuta.
        /// </summary>
        public bool KeyPressedTest
        {
            get { return keyPressedTest; }
            set { keyPressedTest = value; }
        }

        /// <summary>
        /// Tipka koja je pritisnuta (string).
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Sensing()
        {
            MouseDown = false;
            keyPressedTest = false;
            Mouse = new Point(0, 0);
        }

        //method
        /// <summary>
        /// Provjerava je li tipka koja je poslana kao parametar pritisnuta.
        /// </summary>
        /// <param name="keyName">Naziv tipke.</param>
        /// <returns>true/false</returns>
        public bool KeyPressed(string keyName)
        {
            if (KeyPressedTest && Key == keyName)
            {
                Game.WaitMS(20);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Provjerava je li tipka koja je poslana kao parametar pritisnuta.
        /// </summary>
        /// <param name="key">Ugrađeni tip <c>Keys</c></param>
        /// <returns>true/false</returns>
        public bool KeyPressed(Keys key)
        {
            if (KeyPressedTest && Key == key.ToString())
            {
                Game.WaitMS(20);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Provjerava je li bilo koja tipka pritisnuta.
        /// </summary>
        /// <returns>true/false</returns>
        public bool KeyPressed()
        {
            return KeyPressedTest;
        }

        /// <summary>
        /// Tipka otpuštena.
        /// </summary>
        public void KeyUp()
        {
            keyPressedTest = false;
            key = "";
        }

    } 
    //sensing
}
