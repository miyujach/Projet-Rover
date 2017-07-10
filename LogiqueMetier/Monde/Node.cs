using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class Node
    {
        public int ponderation { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public IElement element { get; set; }
    }
}
