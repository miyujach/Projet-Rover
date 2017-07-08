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

        // ---------------------- //
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
        // ------------------- //

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
                Coordonnees.ListNodes[this.Height * y + x].element = new Obstacle(x, y);
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
                Coordonnees.ListNodes[this.Height * y + x].element = rover;
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
            return Coordonnees.ListNodes[this.Height * y + x].element;
        }

        public bool isEmpty(int x, int y)
        {
            if (Coordonnees.ListNodes[this.Height * y + x].element == null)
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
