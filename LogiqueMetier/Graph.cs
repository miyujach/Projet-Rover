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


        public List<Dictionary<int[], Dictionary<int[], int>>> generateGraph()
        {
            //List<List<NeightborhoodInfos>> graph = new List<List<NeightborhoodInfos>>();
            List<Dictionary<int[], Dictionary<int[], int>>> graph = new List<Dictionary<int[], Dictionary<int[], int>>>();
            Dictionary<int[], Dictionary<int[], int>> vertices = new Dictionary<int[], Dictionary<int[], int>>();

            for (int y = 0; y < carte.Height; y++)
            {
                for (int x = 0; x < carte.Width; x++)
                {
                    List<NeightborhoodInfos> voisinageCaseEnCour = carte.Coordonnees.getNeightborhood(x, y);


                    //voisinsDuPointEnCour =  { [x, y], ponderation };
                    Dictionary<int[], int> voisinsDuPointEnCour = new Dictionary<int[], int>();
                    foreach (NeightborhoodInfos voisin in voisinageCaseEnCour)
                    {
                        if (voisin.indexElement == null || voisin.indexElement is IRover)
                        {
                            Console.WriteLine("CaseEnCour : [" + x + "," + y + "] | Case analysée : [" + voisin.xIndexCase + "," + voisin.yIndexCase + "] - Ponderation case = " + voisin.ponderation);
                            voisinsDuPointEnCour.Add(new int[] { voisin.xIndexCase, voisin.yIndexCase }, voisin.ponderation);
                        }
                    }
                    Console.WriteLine("----");


                    //vertices = ([x,y], { { [x, y], ponderation }, { [x, y], ponderation } });
                    vertices.Add(new int[] { x, y }, voisinsDuPointEnCour);

                    //Liste de l'ensemble des vertex de la carte
                    //Représente toutes les routes entre les points (vides) avec les ponderations
                    graph.Add(vertices);
                }
            }
            return graph;
        }


    }
}
