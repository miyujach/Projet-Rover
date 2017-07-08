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
        private ICoordonnee coordonnees;
        private Rover rover;

        // ------------------------ //
        // -- START Accesseur  -- //
        public ICoordonnee Coordonnees
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
            Thread.Sleep(10);
            if (new Random().Next(100) < this.pourcentageObstacle)
            {                
                for (int yCoordonnnees = 0; yCoordonnnees < Height; yCoordonnnees++)
                {
                    for (int xCoordonnnees = 0; xCoordonnnees < Width; xCoordonnnees++)
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
                Coordonnees.Coordoonees[this.Height * y + x] = obstacle;
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
                rover.setPosition(x, y);
                Coordonnees.Coordoonees[this.Height * y + x] = rover;
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
            return Coordonnees.Coordoonees[this.Height * y + x];
        }

        public bool isEmpty(int x, int y)
        {
            List<IElement> coordonneesDeLaCarte = Coordonnees.Coordoonees;
            if (coordonneesDeLaCarte[this.Height * y + x] == null)
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
