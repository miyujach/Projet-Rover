using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class Carte : ICarte
    {
        private int height,  width, pourcentageObstacle;
        private Coordonnee coordonnees;
        private Rover rover;

        // ------------------------ //
        // -- START Constructeur -- //
        public Coordonnee Coordonnees
        {
            get
            {
                return coordonnees;
            }

            set
            {
                coordonnees = value;
            }
        }
        // -- END Constructeur -- //
        // ---------------------- //

        public Carte(int width, int height, int pourcentage)
        {
            this.height = height;
            this.width = width;
            this.pourcentageObstacle = pourcentage;
            this.coordonnees = new Coordonnee(width, height);
        }    

        public Boolean generateRandomObstacle(int x, int y)
        {
            Boolean isObstacleSet = false;
            Thread.Sleep(100);
            if (new Random().Next(100) < this.pourcentageObstacle)
            {                
                for (int yCoordonnnees = 0; yCoordonnnees < height; yCoordonnnees++)
                {
                    for (int xCoordonnnees = 0; xCoordonnnees < width; xCoordonnnees++)
                    {
                        return isObstacleSet = addObstacle(x, y);
                    }
                }
                return isObstacleSet;
            }
            else
            {
                return false;
            }            
        }

        public bool addElement(int x, int y, IElement element)
        {
            throw new NotImplementedException();
        }

        public bool addObstacle(int x, int y)
        {            
            if (isEmpty(x, y))
            {
                Obstacle obstacle = new Obstacle(x, y);
                // On ajoute l'obstacle à l'emplacement spécifié
                Coordonnees.Coordoonees[this.height * y + x] = obstacle;
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool addRover(int x, int y, Rover rover)
        {
            if (isEmpty(x, y))
            {
                this.rover = rover;

                // On ajoute le rover à l'emplacement spécifié
                Coordonnees.Coordoonees[this.height * y + x] = rover;
                return true;
            }else
            {
                return false;
            }
        }

        public IRover getRover()
        {
            return rover;
        }

        public IElement getXY(int x, int y)
        {
            // On ajoute le rover à l'emplacement spécifié
            return Coordonnees.Coordoonees[this.height * y + x];
        }

        public bool isEmpty(int x, int y)
        {
            List<IElement> coordonneesDeLaCarte = Coordonnees.Coordoonees;
            if (coordonneesDeLaCarte[this.height * y + x] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
