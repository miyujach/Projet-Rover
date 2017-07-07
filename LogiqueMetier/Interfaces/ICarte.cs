using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public interface ICarte
    {
        IElement getXY(int x, int y);
        Boolean isEmpty(int x, int y);
        Boolean addElement(int x, int y, IElement element);
        Boolean addRover(int x, int y, Rover rover);
        Boolean addObstacle(int x, int y);
        IRover getRover();
        ICoordonnee Coordonnees { get; set; }

    }
}
