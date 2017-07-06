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
        // -- START Constructeur -- //
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
        // -- END Constructeur -- //
        // ---------------------- //

                

        public Coordonnee(int width, int height)
        {
            this.width = width;
            this.height = height;
 
             
            List<IElement> coordonnee = new List<IElement>();
            
            for (int y = 0; y < this.height; y++)
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
            return this.coordoonees[this.height*y + x];
        }

        public List<IElement> getNeightborhood(int x, int y)
        {
            List<IElement> neitghtborhoorCoordonnee = new List<IElement>();
            int limiteTableauX = this.width - 1,
                limiteTableauY = this.height - 1;
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

        
    }
}
