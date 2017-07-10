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
        private Dictionary<Node, List<Node>> vertices = new Dictionary<Node, List<Node>>();

        // Vertex
        //Dictionary<Node, Dictionary<NeightborhoodNode, int>> vertex = new Dictionary<Node, Dictionary<NeightborhoodNode, int>>();


        public Graph(ICarte carte)
        {
            this.carte = carte;
        }


        public void add_vertex(Node name, List<Node> edges)
        {
            vertices[name] = edges;
        }

        public void list_vertex()
        {
            foreach (var vertex in this.vertices)
            {
                Console.WriteLine("----");
                Console.WriteLine("Le point X=" + vertex.Key.x + ", Y=" + vertex.Key.y);

                foreach (var neightborhoor in vertex.Value)
                {
                    Console.WriteLine("Est relié au point X=" + neightborhoor.x + ", Y=" + neightborhoor.y + " avec une pondération de " + neightborhoor.ponderation);
                }
                Console.WriteLine("\n");
            }
        }

        // Dictionary<pointInitial, Dictionary<pointFinal, ponderation>>> generateGraph
        public Dictionary<Node, List<Node>> generateGraph()
        {
            List<Node> listeNode = carte.Coordonnees.ListNodes;

            for (int y = 0; y < carte.Height; y++)
            {
                for (int x = 0; x < carte.Width; x++)
                {
                    Node currentNode = listeNode[carte.Height * y + x];
                    List<Node> voisinageCaseEnCour = carte.Coordonnees.getNeightborhood(x, y);
                    Node nodeEnCour = carte.Coordonnees.getCoordonnee(x, y);

                    
                    List<Node> voisinsDuPointEnCour = new List<Node>();
                    foreach (Node voisin in voisinageCaseEnCour)
                    {
                        // Ajoute seulement les voisins qui sont vide ou qui contiennent le Rover
                        if (voisin.element == null || voisin.element is IRover)
                        {
                            voisinsDuPointEnCour.Add(voisin);
                        }
                    }
                    add_vertex(currentNode, voisinsDuPointEnCour);
                }
            }

            list_vertex();
            return vertices;
        }


    }
}
