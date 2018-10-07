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
using System.Drawing.Drawing2D;
using Blackjack;

namespace OTTER
{
    #region SpriteCostume
    public class SpriteCostume
    {
        private Bitmap rotated;

        public Bitmap RotatedCostume
        {
            get { return rotated; }
            set { rotated = value; }
        }
        private int angle;

        public int CostumeAngle
        {
            get { return angle; }
            set { angle = value; }
        }

        public SpriteCostume(Bitmap bitmap, int degrees)
        {
            RotatedCostume = bitmap;
            CostumeAngle = degrees;
        }
    }
    #endregion

    /// <summary>
    /// Klasa Sprite predstavlja lika.
    /// </summary>
    public class Sprite
    {
        // Klasa Sprite nam sluzi za iscrtavanje likova u igri
        // Za pocetak su vam dijelovi koda sakriveni u regije
        #region rotation
        /// <summary>
        /// Način rotacije slike lika.
        /// </summary>
        public enum RotationStylesType 
        { 
            /// <summary>
            /// Lijevo - desno
            /// </summary>
            LeftRight, 
            /// <summary>
            /// Nemoj rotirati
            /// </summary>
            DontRotate, 
            /// <summary>
            /// Rotiraj
            /// </summary>
            AllAround };
        /// <summary>
        /// Smjer
        /// </summary>
        public enum DirectionsType { up = 0, right = 90, left = 270, down = 180 };
        #endregion

        #region properties

        //private
        private int width, heigth; //svojstvo
        private int Direction; //privatno

        //public
        /// <summary>
        /// X koordinata.
        /// </summary>
        /// <remarks><c>set</c> osigurava da lik ne izlazi van ruba <see cref="GameOptions"/></remarks>
        public int X
        {
            get { return x; }
            set
            {
                this.x = value;
            }
        }
        /// <summary>
        /// Y koordinata.
        /// </summary>
        /// <remarks><c>set</c> osigurava da lik ne izlazi van ruba <see cref="GameOptions"/></remarks>
        public int Y
        {
            get { return y; }
            set
            {
                //if (value < GameOptions.UpEdge)
                //    throw new ArgumentException();
                //else if (value + this.Heigth > GameOptions.DownEdge)
                //    throw new ArgumentException();
                //else
                    this.y = value;
            }
        }

        /// <summary>
        /// Širina lika.
        /// </summary>
        public int Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                    width = 100;
                else
                    width = value;
            }
        }

        /// <summary>
        /// Visina lika.
        /// </summary>
        public int Heigth
        {
            get { return heigth; }
            set
            {
                if (value <= 0)
                    heigth = 100;
                else
                    heigth = value;
            }
        }

        /// <summary>
        /// Stil rotacije.
        /// </summary>
        ///<remarks>Pogledajte: <see cref="Sprite.RotationStylesType"/></remarks>
        public string RotationStyle;
        public bool Show; //show
        public List<Bitmap> Costumes = new List<Bitmap>();
        /// <summary>
        /// Trenutna slika (kostim) lika.
        /// </summary>
        public Bitmap CurrentCostume;
        public int CostumeIndex;
        public string CostumeName;
        public int Size;
        public int SpriteIndex;

        //potrebno radi crtanja
        private Bitmap Kopija; 
        private int h2, w2;

        /// <summary>
        /// Ime spritea,oni spriteovi koji nisu pozadina za igru se mogu brisati
        /// </summary>
        public string Name;

        #endregion

        #region constructors

        private int originalWidth, originalHeigth;
        private List<SpriteCostume> Rotations;

        /// <summary>
        /// Konstruktor za Sprite.
        /// </summary>
        /// <param name="spriteImage">naziv/putanja slike</param>
        /// <param name="posX">x koordinata lika</param>
        /// <param name="posY">y koordinata lika</param>
        /// <remarks>Sprite se može instancirati i uz pomoć metode NewSprite koja se nalazi u klasi Game: <see cref="Game.NewSprite"/>.</remarks>
        public Sprite(string spriteImage, int posX, int posY) //predefinirani kontruktor
        {
            CurrentCostume = new Bitmap(spriteImage);
            Kopija = new Bitmap(spriteImage);

            h2 = Kopija.Height / 2;
            w2 = Kopija.Width / 2;

            CostumeName = spriteImage;
            X = posX;
            Y = posY;
            Width = CurrentCostume.Width;
            Heigth = CurrentCostume.Height;
            Show = true;
            SpriteIndex = -1;
            Costumes.Add(new Bitmap(spriteImage));
            CostumeIndex = 0;
            RotationStyle = RotationStylesType.DontRotate.ToString();
            Direction = 0;
            Size = 100;
            originalWidth = width;
            originalHeigth = heigth;
            
            //nova rotacija, predviđeno 36 sličica
            int numOfRotations = 36;

            if (numOfRotations > 360)
                numOfRotations %= 360;
            if (numOfRotations < 1)
                numOfRotations = 1;
            Rotations = new List<SpriteCostume>();

            Bitmap original = new Bitmap(spriteImage);

            int ang = 360 / numOfRotations;
            for (int i = 0; i < numOfRotations; i++)
            {
                PointF offset = new PointF(this.Width / 2, this.Heigth / 2);
                Bitmap b = RotateImage(original, offset, ang * i);
                SpriteCostume s = new SpriteCostume(b, i * ang);
                Rotations.Add(s);
            }

        }

        public Sprite(string spriteImage, int posX, int posY,int sirina,int visina,string name)//moj novi kontruktor,razlika je samo sta postavimo sami sirinu i visinu,te prima ime spritea
        {
            CurrentCostume = new Bitmap(spriteImage);
            Kopija = new Bitmap(spriteImage);

            h2 = Kopija.Height / 2;
            w2 = Kopija.Width / 2;

            CostumeName = spriteImage;
            X = posX;
            Y = posY;
            Width = sirina;//1.promjena
            Heigth = visina;//2.promjena
            Show = true;
            SpriteIndex = -1;
            Costumes.Add(new Bitmap(spriteImage));
            CostumeIndex = 0;
            RotationStyle = RotationStylesType.DontRotate.ToString();
            Direction = 0;
            Size = 100;
            originalWidth = width;
            originalHeigth = heigth;
            
            //3.promjena   IME MOZE BITI SAMO KARTA ILI POZADINA,SLUZI DA NE IZBRISEMO SPRITE KOJI JE POZADINA IZ IGRE
            if (name.ToLower().Trim() == "card" || name.ToLower().Trim() == "karta")
            {
                Name = "card";
            }
            else Name = "pozadina";

            //nova rotacija, predviđeno 36 sličica
            int numOfRotations = 36;

            if (numOfRotations > 360)
                numOfRotations %= 360;
            if (numOfRotations < 1)
                numOfRotations = 1;
            Rotations = new List<SpriteCostume>();

            Bitmap original = new Bitmap(spriteImage);

            int ang = 360 / numOfRotations;
            for (int i = 0; i < numOfRotations; i++)
            {
                PointF offset = new PointF(this.Width / 2, this.Heigth / 2);
                Bitmap b = RotateImage(original, offset, ang * i);
                SpriteCostume s = new SpriteCostume(b, i * ang);
                Rotations.Add(s);
            }
        }       

        #endregion

        #region methods

        /// <summary>
        /// Vraća trenutni smjer.
        /// </summary>
        /// <returns>smjer</returns>
        public int GetDirection()
        {
            return Direction;
        }

        /// <summary>
        /// Vraća trenutni smjer.
        /// </summary>
        /// <returns>smjer</returns>
        public int GetHeading()
        {
            return Direction;
        }

        /// <summary>
        /// Metoda koja radi isto kao SetHeading
        /// </summary>
        /// <param name="direction">kut</param>
        public void SetDirection(int direction)
        {
            SetHeading(direction);
        }

        /// <summary>
        /// Središte lika.
        /// </summary>
        /// <returns>x koordinata središta lika.</returns>
        public int CenterX()
        {
            return X + Width / 2;
        }

        /// <summary>
        /// Središte lika.
        /// </summary>
        /// <returns>y koordinata središta lika.</returns>
        public int CenterY()
        {
            return Y + Heigth / 2;
        }        

        /* Motion */
        /// <summary>
        /// Metoda koja postavlja lika na (posX, posY) koordinate.
        /// </summary>
        /// <param name="posX">x koordinata</param>
        /// <param name="posY">y koordinata</param>
        public void GotoXY(int posX, int posY)
        {
            this.X = posX;
            this.Y = posY;
        }

        /// <summary>
        /// Postavlja x koordinatu.
        /// </summary>
        /// <param name="posX">x koordinata.</param>
        public void SetX(int posX)
        {
            this.X = posX;
        }

        /// <summary>
        /// Postavlja y koordinatu.
        /// </summary>
        /// <param name="posY">y koordinata.</param>
        public void SetY(int posY)
        {
            this.Y = posY;
        }

        /// <summary>
        /// Idi do lika koji je poslan kao parametar. Postavlja se na istu poziciju (prema sredini).
        /// </summary>
        /// <param name="sprite">Lik do kojeg treba ići.</param>
        public void Goto_Sprite(Sprite sprite)
        {
            //poklopiti centar

            //razlika središta
            int rx, ry;
            rx = this.CenterX() - sprite.CenterX();
            ry = this.CenterY() - sprite.CenterY();

            this.X -= rx;
            this.Y -= ry;
        }

        /// <summary>
        /// Idi do strelice miša.
        /// </summary>
        /// <param name="mouse">Koorinate miša (točka).</param>
        public void Goto_MousePoint(Point mouse)
        {
            X = mouse.X - Width / 2;
            Y = mouse.Y - Heigth / 2;
        }

        /// <summary>
        /// Promijeni x koordinatu za n.
        /// </summary>
        /// <example>Promijeni x koordinatu za 5:
        /// <code>lik.ChangeX(5);</code>
        /// </example>
        /// <param name="n">cijeli broj za koji se mijenja x koordinata.</param>
        public void ChangeX(int n)
        {
            if (CheckEdgeX(X + n))
                X += n;
            
        }

        /// <summary>
        /// Promijeni y koordinatu za n.
        /// </summary>
        /// <param name="n">cijeli broj za koji se mijenja y koordinata.</param>
        public void ChangeY(int n)
        {
            if (CheckEdgeY(Y + n))
                Y += n;           
        }

        private bool CheckEdgeX(int posX)
        {
            if (posX + Width >= 700 || posX <= 0)
                return false;
            else
                return true;
        }

        private bool CheckEdgeY(int posY)
        {
            if (posY + Heigth >= 500 || posY <= 0)
                return false;
            else
                return true;
        }        
        

        /// <summary>
        /// Postavlja smjer.
        /// </summary>
        /// <param name="heading">Definirani tip.</param>
        public void SetHeading(DirectionsType heading)
        {
            int d = (int)heading;
            SetHeading(d);
        }

        /// <summary>
        /// Metoda koja pomiče lika u 4 osnovna smjera: lijevo, desno, gore i dolje.
        /// </summary>
        /// <param name="steps">broj koraka</param>
        public void MoveSimple(int steps)
        {
            if (this.Direction == (int)DirectionsType.right)
                this.X += steps;
            else if (this.Direction == (int)DirectionsType.left)
                this.X -= steps;
            else if (this.Direction == (int)DirectionsType.up)
                this.Y -= steps;
            else
                this.Y += steps;
        }

        /// <summary>
        /// Postavlja smjer lika.
        /// </summary>
        /// <param name="newDirectionAngle">Novi smjer u stupnjevima.</param>
        public void SetHeading(int newDirectionAngle)
        {
            if (Direction == newDirectionAngle)
                return;
            if (newDirectionAngle < 0)
            {
                while (newDirectionAngle < 0)
                    newDirectionAngle += 360;
            }

            newDirectionAngle %= 360;
            Direction = newDirectionAngle;
            if (CostumeIndex > 0)
                return;
            if (RotationStyle == RotationStylesType.LeftRight.ToString())
            {
                return;
            }
            else if (RotationStyle == RotationStylesType.DontRotate.ToString())
            {
                return;
            }
            //naći da li postoji rotacija za taj kut
            int min = 0;
            int max = 0;
            bool tocanKut = false;
            for (int i = 0; i < Rotations.Count; i++)
            {
                if (Rotations[i].CostumeAngle == newDirectionAngle)
                {
                    this.CurrentCostume = Rotations[i].RotatedCostume;
                    tocanKut = true;
                    break;
                }
                else if (Rotations[i].CostumeAngle < newDirectionAngle)
                    min = i;
                else
                {
                    max = i;
                    break;
                }
            }

            //vidi koji je bliži ako nije jednak
            if (!tocanKut)
            {
                int r1 = Math.Abs(newDirectionAngle - Rotations[min].CostumeAngle);
                int r2 = Math.Abs(newDirectionAngle - Rotations[max].CostumeAngle);
                if (r1 <= r2)
                {
                    this.CurrentCostume = Rotations[min].RotatedCostume;
                }
                else
                    this.CurrentCostume = Rotations[max].RotatedCostume;
            }
        } //Setdir             

        private static Bitmap RotateImage(Image image, PointF offset, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            //create a new empty bitmap to hold rotated image
            //Bitmap rotatedBmp = new Bitmap(image.Width, image.Height);

            Bitmap rotatedBmp;
            //lock (image)
            {
                rotatedBmp = new Bitmap(image.Width, image.Height);

                rotatedBmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            }

            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(rotatedBmp);

            //Put the rotation point in the center of the image
            g.TranslateTransform(offset.X, offset.Y);

            //rotate the image
            g.RotateTransform(angle);

            //move the image back
            g.TranslateTransform(-offset.X, -offset.Y);

            //draw passed in image onto graphics object
            g.DrawImage(image, new PointF(0, 0));

            return rotatedBmp;
        }

        /// <summary>
        /// Okreni lika prema strelici miša.
        /// </summary>
        /// <remarks>Tip <see cref="System.Drawing.Point"/> ima koordinate x i y.</remarks>
        /// <param name="mis">Koordinate strelica miša</param>
        public void PointToMouse(Point mis)
        {
            //naći kut
            int ax = this.CenterX();
            int ay = this.CenterY();

            int bx = mis.X;
            int by = mis.Y;

            double a, b, kutS, kutR;

            a = Math.Abs(bx - ax);
            b = Math.Abs(by - ay);

            kutR = Math.Atan(b / a);
            kutS = kutR * (180 / Math.PI);

            int kut = (int)kutS;

            if (ax < bx && ay > by) //I
                kut = 90 - kut;
            else if (ax > bx && ay < by) //III
                kut = 270 - kut;
            else if (ax > bx && ay > by) //II
                kut = 270 + kut;
            else if (ax < bx && ay < by) //IV
                kut = 90 + kut;
            else if (kut == 0 && ay == by)
            {
                if (ax <= bx)
                    kut = 90;
                else
                    kut = 270;
            }
            else if (kut == 90 && ax == bx)
            {
                if (ay < by)
                    kut = 180;
                else
                    kut = 0;
            }

            if (a == 0 && b == 0)
                kut = 0;
            //Direction = kut;

            SetHeading(kut);
        }

        /// <summary>
        /// Okreni se prema drugom liku. Okrenut će se prema sredini drugog lika.
        /// </summary>
        /// <param name="sprite">Lik prema kojem se treba okrenuti.</param>
        public void PointToSprite(Sprite sprite)
        {
            Point p = new Point(sprite.CenterX(), sprite.CenterY());
            PointToMouse(p);
        }

        /// <summary>
        /// Pomakni se u trenutnom smjeru za definirani broj koraka.
        /// </summary>
        /// <param name="steps">Broj koraka za pomicanje.</param>
        public void MoveSteps(int steps)
        {
            if (Direction == 0 || Direction == 90 || Direction == 180 || Direction == 270)
            {
                MoveSimple(steps);
                return;
            }

            double a, b, c, rad;
            c = Math.Abs(steps);

            int angle = Direction;

            rad = angle * (Math.PI / 180);

            a = c * Math.Sin(rad);
            b = c * Math.Cos(rad);

            a = Math.Abs(a);
            b = Math.Abs(b);

            if (steps < 0)
            {
                a = -a;
                b = -b;
            }

            if (angle > 0 && angle < 90)
            {
                x += (int)a;
                y -= (int)b;
            }
            else if (angle > 90 && angle < 180)
            {
                x += (int)a;
                y += (int)b;
            }
            else if (angle > 180 && angle < 270)
            {
                x -= (int)a;
                y += (int)b;
            }
            else
            {
                x -= (int)a;
                y -= (int)b;
            }


        }

        //Motion TODO
        //IfOnEdgeBounce()

        /* Looks */

        /// <summary>
        /// Postavlja prozirnu boju.
        /// </summary>
        /// <param name="r">-</param>
        /// <param name="g">-</param>
        /// <param name="b">-</param>
        public void SetTransparentColor(int r, int g, int b)
        {
            this.CurrentCostume.MakeTransparent(Color.FromArgb(r, g, b));
        }

        /// <summary>
        /// Postavlja prozirnu boju.
        /// </summary>
        /// <remarks>Tip <see cref="System.Drawing.Color"/> je postojeći tip u C#.</remarks>
        /// <param name="color">boja lika</param>
        public void SetTransparentColor(Color color)
        {            
            this.CurrentCostume.MakeTransparent(color);
        }

        /// <summary>
        /// Postavi veličinu lika. Ako se postavi 100, vraća se na početnu.
        /// Ako se postavi na manje od 100 lik će se smanjiti, 
        /// a ako se postavi na veće od 100, lik će se povećati.
        /// </summary>
        /// <param name="size">Veličina lika (postotak).</param>
        public void SetSize(int size)
        {
            Size = size;

            float sx = float.Parse(this.Width.ToString());
            float sy = float.Parse(this.Heigth.ToString());
            float nsx = ((sx / 100) * size);
            float nsy = ((sy / 100) * size);

            if (Size == 100)
            {
                nsx = originalWidth;
                nsy = originalHeigth;
            }

            this.Width = Convert.ToInt32(nsx);
            this.Heigth = Convert.ToInt32(nsy);
        }

        /// <summary>
        /// Postavlja vidljivost lika.
        /// </summary>
        /// <example>Ovo se može postići i postavljanjem vrijednosti Show na true ili false:
        /// <code>lik.Show = true;</code></example>
        /// <param name="value">true ili false</param>
        public void SetVisible(bool value)
        {
            this.Show = value;
        }

        //flip
        private void FlipSprite(string fliptype)
        {
            if (fliptype.ToLower() == "none")
            {
                foreach (Bitmap b in Costumes)
                    b.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                return;
            }

            if (fliptype.ToLower() == "horizontal")
            {
                foreach (Bitmap b in Costumes)
                {
                    //lock(b)
                    b.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }
                return;
            }

            if (fliptype.ToLower() == "horizontalvertical")
            {
                foreach (Bitmap b in Costumes)
                    b.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                return;
            }

            if (fliptype.ToLower() == "vertical")
            {
                foreach (Bitmap b in Costumes)
                    b.RotateFlip(RotateFlipType.RotateNoneFlipY);
                return;
            }
        }

        private void ChangeImage(string fileName)
        {
            CurrentCostume = new Bitmap(fileName);
            CostumeName = fileName;
            Width = CurrentCostume.Width;
            Heigth = CurrentCostume.Height;
        }

        private void ChangeImage(string fileName, int w, int h)
        {
            CurrentCostume = new Bitmap(fileName);
            CostumeName = fileName;
            Width = w;
            Heigth = h;
        }

        /// <summary>
        /// Dodaj kostime.
        /// </summary>
        /// <param name="files">popis naziva datoteka.</param>
        public virtual void AddCostumes(params string[] files)
        {
            foreach (string f in files)
            {
                Costumes.Add(new Bitmap(f));
            }
        }

        /// <summary>
        /// Uzima sljedeći kostim. Napomena: U ovoj se verziji može rotirati samo prvi kostim.
        /// </summary>
        public void NextCostume()
        {
            if (CostumeIndex + 1 == Costumes.Count)
            {
                CostumeIndex = 0;
                CurrentCostume = Costumes[0];
            }
            else
            {
                CostumeIndex++;
                CurrentCostume = Costumes[CostumeIndex];
            }
        }
        
        /// <summary>
        /// Sljedeći kostim.
        /// </summary>
        /*
        public void NextCostume()
        {
            if (CostumeIndex + 1 == Costumes.Count)
                CostumeIndex = -1;
            CostumeIndex++;

            bool greska;
            do
            {
                greska = false;
                try
                {
                    CurrentCostume = (Bitmap)Costumes[CostumeIndex].Clone();
                    Kopija = (Bitmap)Costumes[CostumeIndex].Clone();
                    w2 = Kopija.Width / 2;
                    h2 = Kopija.Height / 2;
                    PointF offset = new PointF(w2, h2);

                    if (this.RotationStyle == RotationStylesType.AllAround.ToString())
                    {
                        Bitmap temp = RotateImage(Kopija, offset, Direction);
                        CurrentCostume = temp;
                    }
                }
                catch
                {
                    greska = true;
                }
            } while (greska);
        }
        /*
        /* Sensing */
        
        private bool TouchingRightEdge()
        {
            if (this.X + this.Width >= 700)
                return true;
            else
                return false;
        }

        private bool TouchingLeftEdge()
        {
            if (this.X <= 0)
                return true;
            else
                return false;
        }

        private bool TouchingBottomEdge()
        {
            if (this.Y + this.Heigth >= 500)
                return true;
            else
                return false;
        }

        private bool TouchingTopEdge()
        {
            if (this.Y <= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Provjerava da li lik dira rub pozornice/prozora.
        /// </summary>
        /// <returns>vraća true ako dira, odnosno false ako ne dira.</returns>
        public bool TouchingEdge()
        {
            if (TouchingLeftEdge())
            {
                return true;
            }
            if (TouchingRightEdge())
            {
                return true;
            }
            if (TouchingBottomEdge())
            {
                return true;
            }
            if (TouchingTopEdge())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Provjerava da li lik dira rub pozornice/prozora.
        /// </summary>
        /// <param name="edge">Vraća koji rub dira: left, right, up, down.</param>
        /// <returns>-</returns>
        public bool TouchingEdge(out string edge)
        {
            if (TouchingLeftEdge())
            {
                edge = "left";
                return true;
            }
            if (TouchingRightEdge())
            {
                edge = "right";
                return true;
            }
            if (TouchingBottomEdge())
            {
                edge = "bottom";
                return true;
            }
            if (TouchingTopEdge())
            {
                edge = "top";
                return true;
            }

            edge = "";
            return false;
        }

        /// <summary>
        /// Provjerava da li lik dira nekog drugog lika.
        /// </summary>
        /// <param name="b">Lik kojeg možda dira.</param>
        /// <returns>Vraća true/false.</returns>
        public bool TouchingSprite(Sprite b)
        {
            Sprite a = this;

            Rectangle A = new Rectangle(a.X, a.Y, a.Width, a.Heigth);
            Rectangle B = new Rectangle(b.X, b.Y, b.Width, b.Heigth);

            if (A.IntersectsWith(B))
                return true;
            else
                return false;
        }

        private bool TouchingSprite_ne(Sprite b, int offset)
        {
            Sprite a = this;

            double x1 = a.CenterX();//a.x + a.width / 2;
            double y1 = a.CenterY();//a.y + a.heigth / 2;
            double x2 = b.CenterX();//b.x + b.width / 2;
            double y2 = b.CenterY();//b.y + b.heigth / 2;

            double d = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

            int ma = a.Width <= a.Heigth ? a.Width : a.Heigth;
            int mb = b.Width <= b.Heigth ? b.Width : b.Heigth;

            double ra = ma / 2;
            double rb = mb / 2;

            if (d + offset > ra + rb)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Provjerava da li lik dira strelicu miša.
        /// </summary>
        /// <param name="m">Pozicija miša.</param>
        /// <returns>Vraća true/false.</returns>
        public bool TouchingMousePoint(Point m)
        {
            Sprite a = this;
            int offset = 1;

            double x1 = a.X + a.Width / 2;
            double y1 = a.Y + a.Heigth / 2;
            double x2 = m.X;
            double y2 = m.Y;

            double d = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));

            int ma = a.Width < a.Heigth ? a.Width : a.Heigth;
            int mb = 0;

            double ra = ma / 2;
            double rb = mb / 2;

            if (d + offset > ra + rb)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Provjerava je li lik kliknut. Za provjeru je potrebno poslati koordinate strelice miša. 
        /// Koordinate (točka) miša se mogu dobiti iz "sensing".
        /// </summary>
        /// <param name="mousePoint">Koordinate strelice miša.</param>
        /// <returns></returns>
        public bool Clicked(Point mousePoint)
        {
            if (mousePoint.X > this.X && mousePoint.X < this.X + this.Width)
            {
                if (mousePoint.Y > this.Y && mousePoint.Y < this.Y + this.Heigth)
                    return true;
            }

            return false;
        }


        /* Control */
        private void Wait(double seconds)
        {
            int ms = (int)(seconds * 1000);
            Thread.Sleep(ms);
        }

        #endregion

        // VJEŽBA 01

        // Koordinate lika
        private int x;
        private int y;

        // Ovdje implementirajte svoje metode  
       
    }
}
