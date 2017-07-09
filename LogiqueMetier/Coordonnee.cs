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
        private List<Node> listNodes = new List<Node>();
        //private List<IElement> coordoonees = new List<IElement>();

        // ------------------------ //
        // -- START Accesseur -- //
        public List<Node> ListNodes
        {
            get
            {
                return listNodes;
            }

            set
            {
                listNodes = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        // -- END Accesseur -- //
        // ---------------------- //



        public Coordonnee(int width, int height)
        {
            this.width = width;
            this.height = height;
 
             
            List<Node> theNode = new List<Node>();
            
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    // Au debut toutes les cases sont vides --> Ce sont des objets qui sont ajoutés ici (Rover / Obstacle / null)
                    Node node = new Node();
                    node.x = x;
                    node.y = y;
                    node.element = null;
                    theNode.Add(node);
                }
            }
            this.listNodes = theNode;
            //Console.WriteLine("Nombre de coordonnées : " + listNodes.Count);
        }

        public Node getCoordonnee(int x, int y)
        {

            //Il List faut que je return le bon index de la list en fonction de X et de Y
            //index = nbLigne * Ligne + Colone --> height * y + x
            int indexList = (this.height) * y + x;

            if (this.listNodes[indexList].element == null)
            {
                Console.Write("-");
            }

            try
            {
                return this.listNodes[(this.height) * y + x];
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                System.Console.WriteLine(e.Message);
                throw new System.ArgumentOutOfRangeException("Recherche coordonnées (getCoordonnee): Les coordonnées recherchées sont en dehors de la carte.", e);
            }
        }

        public List<Node> getNeightborhood(int x, int y)
        {
            List<int[]> neitghtborhoorIndex = new List<int[]>();
            List<IElement> neitghtborhoorCoordonnee = new List<IElement>();
            int limiteTableauX = this.width - 1,
                limiteTableauY = this.Height - 1;

            List<Node> informationsVoisinage = new List<Node>();

            try
            {
                //Top
                if (y - 1 < 0)
                {
                    int xVoisin = x, yVoisin = limiteTableauY;
                    int ponderation = 1;

                    Node informationVoisin = new Node();
                    informationVoisin.ponderation = ponderation;
                    informationVoisin.x = xVoisin;
                    informationVoisin.y = yVoisin;
                    informationVoisin.element = getCoordonnee(xVoisin, yVoisin).element;
                    informationsVoisinage.Add(informationVoisin);
                }
                else
                {
                    int xVoisin = x, yVoisin = y - 1;
                    int ponderation = 2;

                    Node informationVoisin = new Node();
                    informationVoisin.ponderation = ponderation;
                    informationVoisin.x = xVoisin;
                    informationVoisin.y = yVoisin;
                    informationVoisin.element = getCoordonnee(xVoisin, yVoisin).element;
                    informationsVoisinage.Add(informationVoisin);
                }



                //Bottom
                if (y + 1 > limiteTableauY)
                {
                    int xVoisin = x, yVoisin = 0;
                    int ponderation = 1;

                    Node informationVoisin = new Node();
                    informationVoisin.ponderation = ponderation;
                    informationVoisin.x = xVoisin;
                    informationVoisin.y = yVoisin;
                    informationVoisin.element = getCoordonnee(xVoisin, yVoisin).element;
                    informationsVoisinage.Add(informationVoisin);
                }
                else
                {
                    int xVoisin = x, yVoisin = y + 1;
                    int ponderation = 2;

                    Node informationVoisin = new Node();
                    informationVoisin.ponderation = ponderation;
                    informationVoisin.x = xVoisin;
                    informationVoisin.y = yVoisin;
                    informationVoisin.element = getCoordonnee(xVoisin, yVoisin).element;
                    informationsVoisinage.Add(informationVoisin);
                }


                //Left
                if (x - 1 < 0)
                {
                    int xVoisin = limiteTableauX, yVoisin = y;
                    int ponderation = 1;

                    Node informationVoisin = new Node();
                    informationVoisin.ponderation = ponderation;
                    informationVoisin.x = xVoisin;
                    informationVoisin.y = yVoisin;
                    informationVoisin.element = getCoordonnee(xVoisin, yVoisin).element;
                    informationsVoisinage.Add(informationVoisin);
                }
                else
                {
                    int xVoisin = x - 1, yVoisin = y;
                    int ponderation = 2;

                    Node informationVoisin = new Node();
                    informationVoisin.ponderation = ponderation;
                    informationVoisin.x = xVoisin;
                    informationVoisin.y = yVoisin;
                    informationVoisin.element = getCoordonnee(xVoisin, yVoisin).element;
                    informationsVoisinage.Add(informationVoisin);
                }



                //Right
                if (x + 1 > limiteTableauX)
                {
                    int xVoisin = 0, yVoisin = y;
                    int ponderation = 1;

                    Node informationVoisin = new Node();
                    informationVoisin.ponderation = ponderation;
                    informationVoisin.x = xVoisin;
                    informationVoisin.y = yVoisin;
                    informationVoisin.element = getCoordonnee(xVoisin, yVoisin).element;
                    informationsVoisinage.Add(informationVoisin);
                }
                else
                {
                    int xVoisin = x + 1, yVoisin = y;
                    int ponderation = 2;

                    Node informationVoisin = new Node();
                    informationVoisin.ponderation = ponderation;
                    informationVoisin.x = xVoisin;
                    informationVoisin.y = yVoisin;
                    informationVoisin.element = getCoordonnee(xVoisin, yVoisin).element;
                    informationsVoisinage.Add(informationVoisin);
                }
                return informationsVoisinage;
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                System.Console.WriteLine(e.Message);
                throw new System.ArgumentOutOfRangeException("Recherche voisinage (getNeightborhood): Les coordonnées du point n'existe pas sur le carte", e);
            }

            
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
