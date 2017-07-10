using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class CaseIsNotEmptyException : Exception
    {
        public CaseIsNotEmptyException()
            : base("Exception : La position finale du robot ne peut pas être placé car la case de destination n'est pas vide (Contient un Obstacle).")
        {
        }
    }
}
