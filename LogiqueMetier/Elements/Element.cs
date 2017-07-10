using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public abstract class Element : IElement
    {
        public abstract ICoordonnee getPosition();
    }
}
