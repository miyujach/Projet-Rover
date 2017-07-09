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
            var previous = new Dictionary<Node, Node>();
            var distances = new Dictionary<Node, int>();
            var nodes = new List<Node>();
            Node start = this.depart;
            Node finish = this.arrivee;


            List<Node> path = null;

            foreach (var vertex in vertices)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                }

                nodes.Add(vertex.Key);
            }
            
            while (nodes.Count != 0)
            {
                Console.WriteLine(nodes.ToList());
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                
                nodes.Remove(smallest);

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

                

                foreach (var neighbor in vertices[smallest])
                {
                    try
                    {
                        int alt = distances[smallest] + neighbor.Value;
                        Console.WriteLine("smallest : " + smallest);
                        Console.WriteLine("distances[smallest] : " + distances[smallest]);
                        Console.WriteLine("neighbor.Value : " + neighbor.Value);
                        Console.WriteLine("neighbor : " + neighbor);
                        Console.WriteLine("alt : " + alt);
                        Console.WriteLine("distances : " + distances);
                        Console.WriteLine("neighbor.Key : " + neighbor.Key);
                        Console.WriteLine(" distances[neighbor.Key] : " + distances[neighbor.Key]);

                        if (alt < distances[neighbor.Key])
                        {
                            distances[neighbor.Key] = alt;
                            previous[neighbor.Key] = smallest;
                        }
                    }
                    catch(KeyNotFoundException ex)
                    {
                        //Console.WriteLine("Exception :" + ex);
                    }
                }
            }
            

            return path;
        }

    }
}
