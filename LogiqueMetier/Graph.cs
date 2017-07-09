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

        // Vertices
        Dictionary<Node, Dictionary<Node, int>> vertices = new Dictionary<Node, Dictionary<Node, int>>();

        // Vertex
        //Dictionary<Node, Dictionary<NeightborhoodNode, int>> vertex = new Dictionary<Node, Dictionary<NeightborhoodNode, int>>();


        public Graph(ICarte carte)
        {
            this.carte = carte;
        }


        public void add_vertex(Node name, Dictionary<Node, int> edges)
        {
            vertices[name] = edges;
        }

        public void list_vertex()
        {
            foreach (var vertex in this.vertices)
            {
                Console.WriteLine("----");
                Console.WriteLine("CaseEnCour : [" + vertex.Key.x + "," + vertex.Key.y + "]");

                foreach (var neightborhoor in vertex.Value)
                {
                    Console.Write("{ [" + neightborhoor.Key.x + "," + neightborhoor.Key.y + "], " + neightborhoor.Key.ponderation + " }, ");
                }
                Console.WriteLine("\n");
            }
        }

        // Dictionary<pointInitial, Dictionary<pointFinal, ponderation>>> generateGraph
        public Dictionary<Node, Dictionary<Node, int>> generateGraph()
        {
            List<Node> listeNode = carte.Coordonnees.ListNodes;

            for (int y = 0; y < carte.Height; y++)
            {
                for (int x = 0; x < carte.Width; x++)
                {
                    Node currentNode = listeNode[carte.Height * y + x];
                    List<Node> voisinageCaseEnCour = carte.Coordonnees.getNeightborhood(x, y);
                    Node nodeEnCour = carte.Coordonnees.getCoordonnee(x, y);

                    
                    Dictionary <Node, int> voisinsDuPointEnCour = new Dictionary<Node, int>();
                    foreach (Node voisin in voisinageCaseEnCour)
                    {
                        // Ajoute seulement les voisins qui sont vide ou qui contiennent le Rover
                        if (voisin.element == null || voisin.element is IRover)
                        {
                            voisinsDuPointEnCour.Add( voisin, voisin.ponderation);
                        }
                    }
                    add_vertex(nodeEnCour, voisinsDuPointEnCour);
                }
            }

            // Liste toutes les vertex
            list_vertex();

            return vertices;
        }


    }
}
