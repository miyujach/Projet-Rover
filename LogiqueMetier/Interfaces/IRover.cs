using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public interface IRover
    {
        void moveSequence(List<string> sequence);
        void moveTo(int x, int y);
    }
}
