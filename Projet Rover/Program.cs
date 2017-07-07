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
            
            int width = 10, height = 10, pourcentage = 25;
            List<String> sequenceMouvement = new List<String>();

            Carte carte = new Carte(width, height, pourcentage);
            ICoordonnee coordonnees = carte.Coordonnees;

            Graph graph = new Graph();
            Rover rover = new Rover(carte, graph);
            carte.addRover(0, 0, rover);


            sequenceMouvement.Add("t");
            sequenceMouvement.Add("t");
            rover.moveSequence(sequenceMouvement);
            rover.moveTo(10, 10);

            // AJouter les obstacle 
            //carte.addElement(1, 1, rover);

            for (int y =0; y < height; y++ )
            {
                for (int x = 0; x < width; x++)
                {
                    // Il faut ajouter un obstacle ici
                    Console.WriteLine(height * y + x);
                    //carte.generateRandomObstacle(x, y);
                    //Console.Write(coordonnees.getCoordonnee(x, y) + " ");
                }
                Console.WriteLine();
            }


            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Il faut ajouter un obstacle ici
                    List<IElement> voisinageCaseEnCour = carte.Coordonnees.getNeightborhood(x, y);
                    Dictionary<IElement, int> dico = new Dictionary<IElement, int>();
                    foreach (IElement voisin in voisinageCaseEnCour)
                    {
                        dico.Add(voisin, 1);
                    }

                    //graph.add_vertex(carte.Coordonnees.getCoordonnee(x, y), dico);
                }
                Console.WriteLine();
            }


            List<IElement> neightborhood = coordonnees.getNeightborhood(0, 0);
            foreach(IElement item in neightborhood)
            {
                Console.WriteLine("Voisin : " + item);
            }

            

            Console.ReadLine();
            
        }
    }
}
