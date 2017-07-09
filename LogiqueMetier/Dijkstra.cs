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
        private Dictionary<Node, Dictionary<Node, int>> vertices = new Dictionary<Node, Dictionary<Node, int>>();

        public Dijkstra(Node depart, Node arrivee, Dictionary<Node, Dictionary<Node, int>> listVertex)
        {
            this.depart = depart;
            this.arrivee = arrivee;
            this.vertices = listVertex;
        }




        public List<Node> shortest_path()
        {
            Dictionary<Node, Node> previous = new Dictionary<Node, Node>();
            Dictionary<Node, int> distances = new Dictionary<Node, int>();
            List<Node> nodes = new List<Node>();
            Node start = this.depart;
            Node finish = this.arrivee;


            List<Node> path = null;
            

            //Je met dans distance la ponderation de CHAQUE vertex
            foreach (KeyValuePair<Node, Dictionary<Node, int>> vertex in vertices)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                }

                Console.WriteLine("J'ajoute la node dans le dictionary 'Dictionary<Node, int> distances' : [ {0}, {1} ] - {2}", vertex.Key.x, vertex.Key.y, vertex.Key.element);
                nodes.Add(vertex.Key);
            }


            
            while (nodes.Count != 0)
            {
                Console.WriteLine(nodes.ToList());
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                
                nodes.Remove(smallest);
                Console.WriteLine("Je supprime du dictonary la node suivante' : [ {0}, {1} ] - {2}", nodes[0].x, nodes[0].y, nodes[0].element);

                if (smallest == finish)
                {
                    path = new List<Node>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                var vertice = vertices[smallest];
                foreach (KeyValuePair<Node, int> neighbor in vertices[smallest])
                {
                    try
                    {
                        Console.WriteLine("La node que je demande : [{0},{1}]", neighbor.Key.x, neighbor.Key.y);
                        foreach (var cequiyadansdistance in distances)
                        {
                            Console.WriteLine("Node dans 'DISTANCE' - [{0}, {1}]", cequiyadansdistance.Key.x, cequiyadansdistance.Key.y);

                        }
                        Console.WriteLine("La node retournée {0}", distances[neighbor.Key]);
                        Node node = neighbor.Key;
                        int alt = distances[smallest] + neighbor.Value;
                        

                        if (alt < distances[neighbor.Key])
                        {
                            distances[neighbor.Key] = alt;
                            previous[neighbor.Key] = smallest;
                        }
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine(e.Message);

                        Console.WriteLine("La node n'existe pas dans le Dictionary 'Distance' : [ {0}, {1} ] - {2}", neighbor.Key.x, neighbor.Key.y, neighbor.Key.element);

                        throw new KeyNotFoundException(e.Message);
                    }
                }
            }
            

            return path;
        }

    }
}
