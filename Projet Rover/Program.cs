using LogiqueMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Rover
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            int width = 5, height = 5, pourcentage = 20;
            List<String> sequenceMouvement = new List<String>();

            Carte carte = new Carte(width, height, pourcentage);
            ICoordonnee coordonnees = carte.Coordonnees;

            Graph graph = new Graph(carte);
            Rover rover = new Rover(carte, graph);
            carte.addRover(0, 0, rover);

            sequenceMouvement.Add("t");
            sequenceMouvement.Add("t");
            rover.moveSequence(sequenceMouvement);

            // AJouter les obstacle 
            //carte.addElement(1, 1, rover);

            for (int y =0; y < height; y++ )
            {
                for (int x = 0; x < width; x++)
                {
                    // Il faut ajouter un obstacle ici
                    //Console.WriteLine(height * y + x);
                    carte.generateRandomObstacle(x, y);
                    Console.Write(coordonnees.getCoordonnee(x, y) + " ");
                }
                Console.WriteLine();
            }

            //coordonnees.generateGraph();
            graph.generateGraph();
            rover.moveTo(4, 4);


            /*
            List<IElement> neightborhood = coordonnees.getNeightborhood(0, 0);
            foreach(IElement item in neightborhood)
            {
                Console.WriteLine("Voisin : " + item);
            }
            */
            

            Console.ReadLine();
            
        }
    }
}
