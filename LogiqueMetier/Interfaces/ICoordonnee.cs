using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public interface ICoordonnee
    {
        Node getCoordonnee(int x, int y);
        List<NeightborhoodNode> getNeightborhood(int x, int y);
        int[] validCoordonnee(int x, int y);
        int Height { get; }
        int Width { get; }
        List<Node> ListNodes { get; set; }

    }
}
