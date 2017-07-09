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
            ICoordonnee casesPresenteSurLaCarte = carte.Coordonnees;

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
                    // Ajoute les obstacles de manière aléatoire
                    carte.generateRandomObstacle(x, y);

                    // Affiche la grille avec les éléments présent dans celle-ci
                    Console.Write(casesPresenteSurLaCarte.getCoordonnee(x, y).element + " ");
                }
                Console.WriteLine();
            }
            
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
