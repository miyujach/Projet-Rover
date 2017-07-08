using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class Graph
    {
        private ICarte carte;

        public Graph(ICarte carte)
        {
            this.carte = carte;
        }

        // Dictionary<pointInitial, Dictionary<pointFinal, ponderation>>> generateGraph
        public List<Dictionary<Node, Dictionary<NeightborhoodNode, int>>> generateGraph()
        {
            List<Node> listeNode = carte.Coordonnees.ListNodes;

            // Graph qui contient la liste des vertex
            List<Dictionary<Node, Dictionary<NeightborhoodNode, int>>> graph = new List<Dictionary<Node, Dictionary<NeightborhoodNode, int>>>();

            // Vertex
            Dictionary<Node, Dictionary<NeightborhoodNode, int>> vertex = new Dictionary<Node, Dictionary<NeightborhoodNode, int>>();

            for (int y = 0; y < carte.Height; y++)
            {
                for (int x = 0; x < carte.Width; x++)
                {
                    Node currentNode = listeNode[carte.Height * y + x];
                    List<NeightborhoodNode> voisinageCaseEnCour = carte.Coordonnees.getNeightborhood(x, y);

                    
                    /*
                     * Création d'un nouveau Vertex 
                     * voisinsDuPointEnCour =  { pointFinal, ponderation };
                    */
                    Dictionary<NeightborhoodNode, int> voisinsDuPointEnCour = new Dictionary<NeightborhoodNode, int>();
                    foreach (NeightborhoodNode voisin in voisinageCaseEnCour)
                    {
                        if (voisin.indexElement == null || voisin.indexElement is IRover)
                        {
                            Console.WriteLine("CaseEnCour : [" + x + "," + y + "] | Case analysée : [" + voisin.xIndexCase + "," + voisin.yIndexCase + "] - Ponderation case = " + voisin.ponderation);
                            voisinsDuPointEnCour.Add( voisin, voisin.ponderation);
                        }
                    }
                    Console.WriteLine("----");


                    //Dictionnary vertex = (Node, { NeightborhoodNode, ponderation }) ;
                    vertex.Add(currentNode, voisinsDuPointEnCour);

                    //Liste de l'ensemble des vertex de la carte
                    //Représente toutes les routes entre les points (vides) avec les ponderations
                    graph.Add(vertex);
                }
            }
            return graph;
        }


    }
}
