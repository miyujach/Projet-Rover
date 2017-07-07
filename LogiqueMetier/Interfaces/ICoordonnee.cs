using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public interface ICoordonnee
    {
        IElement getCoordonnee(int x, int y);
        List<IElement> getNeightborhood(int x, int y);
        int[] validCoordonnee(int x, int y);
        int Height { get; }
        List<IElement> Coordoonees { get; set; }
    }
}
