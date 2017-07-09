using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class Dijkstra
    {
        private Node depart, arrivee;
        private List<Dictionary<Node, Dictionary<NeightborhoodNode, int>>> listVertex;

        public Dijkstra(Node depart, Node arrivee, List<Dictionary<Node, Dictionary<NeightborhoodNode, int>>> listVertex)
        {
            this.depart = depart;
            this.arrivee = arrivee;
            this.listVertex = listVertex;
        }

        private void exploreGraph()
        {
            // 1. Ajoute dans une liste tous les voisins du point de depart
            // 2. Pour chaque voisin, 
        }
    }
}
