using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class Coordonnee : ICoordonnee
    {
        private int width, height;
        // Comment je peux ajouter plusieurs type d'objet dans un array ? int, string, Voiture, Moto, ...
        // Je dois ajouter dans la carte 
        //public Element[,] coordonnee;
        //private IEnumerable<Coordonnee> enumerationCoordoonee;
        private List<IElement> coordoonees = new List<IElement>();


        // ------------------------ //
        // -- START Accesseur -- //
        public List<IElement> Coordoonees
        {
            get
            {
                return coordoonees;
            }

            set
            {
                coordoonees = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        // -- END Accesseur -- //
        // ---------------------- //



        public Coordonnee(int width, int height)
        {
            this.width = width;
            this.height = height;
 
             
            List<IElement> coordonnee = new List<IElement>();
            
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    // Au debut toutes les cases sont vides --> Ce sont des objets qui sont ajoutés ici (Rover / Obstacle / null)
                    coordonnee.Add(null);
                }
                
            }
            this.coordoonees = coordonnee;
        }

        public IElement getCoordonnee(int x, int y)
        {
            //Il List faut que je return le bon index de la list en fonction de X et de Y
            //index = nbLigne * Ligne + Colone --> height * y + x
            Console.Write("-");
            int indexCollection = (this.Height -1) * y + x;
            return this.coordoonees[(this.Height - 1) * y + x];
        }

        public List<IElement> getNeightborhood(int x, int y)
        {
            List<IElement> neitghtborhoorCoordonnee = new List<IElement>();
            int limiteTableauX = this.width - 1,
                limiteTableauY = this.Height - 1;
            //Top
            if (y - 1 < 0)
            {
                int yTopToBottom = limiteTableauY;
                neitghtborhoorCoordonnee.Add(getCoordonnee(x, yTopToBottom));
            }else
            {
                neitghtborhoorCoordonnee.Add(getCoordonnee(x, y - 1));
            }



            //Bottom
            if (y + 1 > limiteTableauY)
            {
                neitghtborhoorCoordonnee.Add(getCoordonnee(x, 0));
            }
            else
            {
                neitghtborhoorCoordonnee.Add(getCoordonnee(x, y + 1));
            }


            //Left
            
            if (x - 1 < 0)
            {
                int xLeftToRight = limiteTableauX;
                neitghtborhoorCoordonnee.Add(getCoordonnee(xLeftToRight, y));
            }
            else
            {
                neitghtborhoorCoordonnee.Add(getCoordonnee(x - 1, y));
            }



            //Right
            if (x + 1 > limiteTableauX)
            {
                neitghtborhoorCoordonnee.Add(getCoordonnee(0, y));
            }
            else
            {
                neitghtborhoorCoordonnee.Add(getCoordonnee(x + 1, y));
            }

            return neitghtborhoorCoordonnee;
        }

        public int[] validCoordonnee(int x, int y)
        {
            int limiteTableauX = this.width - 1,
                limiteTableauY = this.Height - 1;

            int[] indexValid = new int[2];

            if (x < 0)
            {
                x = limiteTableauX;
            }

            if (x > limiteTableauX)
            {
                x = 0;
            }

            if (y < 0)
            {
                y = limiteTableauY;
            }

            if (y > limiteTableauY)
            {
                y = 0;
            }

            indexValid[0] = x;
            indexValid[1] = y;
            Console.WriteLine("Values {0}, {1}", x, y);

            return indexValid;
        }

    }
}
