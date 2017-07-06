using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class Obstacle : Element
    {
        private int positionX, positionY;

        public Obstacle(int x , int y)
        {
            this.positionX = x;
            this.positionY = y;
        }
        

        public override ICoordonnee getPosition()
        {
            throw new NotImplementedException();
        }

    }
}
