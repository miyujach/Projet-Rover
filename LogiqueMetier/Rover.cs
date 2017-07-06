using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class Rover : Element, IRover
    {
        private int positionX, positionY;
        private ICarte carte;
        public Rover(ICarte carte)
        {
            this.carte = carte;
        }
        public Rover(int x, int y)
        {
            this.positionX = x;
            this.positionY = y;
        }

        public override ICoordonnee getPosition()
        {
            throw new NotImplementedException();
        }

        public void moveSequence(List<string> sequence)
        {
            foreach (string mouvement in sequence)
            {
                carte.get
            }
        }

        public void moveTo(int x, int y)
        {
            //Dijkstrat a faire ici
            throw new NotImplementedException();
        }
    }
}
