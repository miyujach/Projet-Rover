using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class Node
    {
        public int ponderation;
        public int x;
        public int y;
        public IElement element { get; set; }
    }
}
