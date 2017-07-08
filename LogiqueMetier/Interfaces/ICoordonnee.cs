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
        List<NeightborhoodInfos> getNeightborhood(int x, int y);
        int[] validCoordonnee(int x, int y);
        int Height { get; }
        int Width { get; }
        List<IElement> Coordoonees { get; set; }
        List<Dictionary<int[], Dictionary<int[], int>>> generateGraph();

    }
}
