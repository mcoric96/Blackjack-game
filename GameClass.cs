using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Blackjack;

namespace OTTER
{
    public class SpriteList<T> : List<T>
    {        
        public new void Add(T item)
        {
            base.Add(item);
            Change = true;
        }

        public new void Remove(T item)
        {
            base.Remove(item);
            Change = true;
        }

        public SpriteList()
        {
            Change = false;
        }

        private bool change;

        public bool Change
        {
            get { return change; }
            set { change = value; }
        }
    }

    /// <summary>
    /// Klasa za općenite aktivnosti vezane uz igru.
    /// </summary>
    public class Game
    {

        /// <summary>
        /// Pauzira izvršavanje trenutne metode
        /// </summary>
        /// <param name="ms"></param>
        public static void WaitMS(int ms)
        {
            Thread.Sleep(ms);
        }

        /// <summary>
        /// Instanciranje novog lika.
        /// </summary>
        /// <param name="file">Naziv i putanja datoteke koja sadrži sliku lika.</param>
        /// <param name="x">koordinata lika</param>
        /// <param name="y">koordinata lika</param>
        /// <returns>Vraća Sprite</returns>        
        public static void AddSprite(Sprite s)
        {            
            s.SpriteIndex = BGL.spriteCount;
            BGL.spriteCount++;
            BGL.allSprites.Add(s);
        }

        /// <summary>
        /// Metoda koja poziva izvršavanje metode <c>scriptName</c> te čeka završetak izvođenja.
        /// </summary>
        /// <remarks>Ponaša se isto kao i metoda <see cref="Game.StartScript"/> osim što čeka završetak izvođenja da bi se moglo prijeći na iduću naredbu.</remarks>
        /// <param name="scriptName"></param>
        public static void StartScriptAndWait(Func<int> scriptName)
        {
            Task t = Task.Factory.StartNew(scriptName);
            t.Wait();
        }

        /// <summary>
        /// Metoda koja poziva paralelno izvršavanje metode <c>scriptName</c>.
        /// </summary>
        /// <param name="scriptName"></param>
        /// <example>
        /// <para>Metoda (skripta ili procedura) koju pokreće <c>Game.StartScript</c> mora biti napisana na određen način inače se neće prihvatiti. 
        /// Metoda mora imati povratnu vrijednost tipa <c>int</c> koja se može koristiti za povratnu informaciju je li se dogodila pogreška (npr. 0 nije bilo pogreške). 
        /// Sve metode/skripte pozvane putem Game.StartScript() se izvršavaju istovremeno.
        /// </para>
        /// Primjer:
        /// <code>
        /// private int MetodaLika()
        /// {
        ///     //kod
        ///     return 0;
        /// }
        /// </code>
        /// <para>Obično se za aktivnosti lika koje traju dulje vrijeme (ili tijekom trajanja igre) koristi petlja while. 
        /// Pri tome se za uvjet petlje koristi vrijabla START (vidi: <see cref="BGL.START"/>).
        /// <code>
        /// while (START)
        /// {
        ///     //radi nešto
        /// }
        /// </code>
        /// </para>
        /// </example>
        public static void StartScript(Func<int> scriptName)
        {
            Task t;
            //t = Task.Factory.StartNew(scriptName, TaskCreationOptions.LongRunning);
            t = Task.Factory.StartNew(scriptName);
        }                        
       
    } //game
}
