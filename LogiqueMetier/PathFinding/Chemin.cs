using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class Chemin
    {
        public List<Node> listeCoor { get; set; }
        public int totalPonderation { get; set; }

        public Chemin()
        {
            listeCoor = new List<Node>();
            totalPonderation = 0;
        }

        public void AddCoordonnee(Node coor, int ponderation)
        {

            listeCoor.Add(coor);
            totalPonderation += ponderation;
        }

        public bool isFinishIsReach(Node finish)
        {
            foreach (Node node in listeCoor)
            {
                if (node == finish)
                {
                    return true;
                }
               
            }
            return false;
        }

        public List<Chemin> exploreNewChemin(Dictionary<Node, List<Node>> graph)
        {
            int lastindex = listeCoor.Count - 1;

            Node temp = listeCoor[lastindex];
            List<Node> pointsAutour = graph[temp];

            List<Chemin> resChemin = new List<Chemin>();

            foreach (Node vec in pointsAutour)
            {
                if (!listeCoor.Contains(vec)) // Si cette coordonnée ne fait pas partie du chemin actuel
                {
                    Chemin chem = new Chemin();
                    foreach (Node coordo in listeCoor)
                    {
                       
                        chem.AddCoordonnee(new Node() { x = coordo.x, y = coordo.y, ponderation = coordo.ponderation }, 0);
                    }
                    chem.totalPonderation = this.totalPonderation;

                    chem.AddCoordonnee(vec, vec.ponderation);
                    resChemin.Add(chem);
                }
            }

            return resChemin;
        }

    }

}
