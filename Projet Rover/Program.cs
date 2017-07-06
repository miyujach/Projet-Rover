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
            Coordonnee coordonnees = carte.Coordonnees;
            Rover rover = new Rover(carte);
            carte.addRover(9, 0, rover);
                        
            sequenceMouvement.Add("t");
            sequenceMouvement.Add("t");
            sequenceMouvement.Add("l");
            sequenceMouvement.Add("l");
            rover.moveSequence(sequenceMouvement);

            // AJouter les obstacle 

            //carte.addElement(1, 1, rover);

            for (int y =0; y < height; y++ )
            {
                for (int x = 0; x < height; x++)
                {
                    // Il faut ajouter un obstacle ici
                    carte.generateRandomObstacle(x, y);
                    Console.Write(coordonnees.getCoordonnee(x, y) + " ");
                }
                Console.WriteLine();
            }


            List<IElement> neightborhood = coordonnees.getNeightborhood(0, 0);
            foreach(IElement item in neightborhood)
            {
                Console.WriteLine("Voisin : " + item);
            }


            // On affiche la carte
            /*
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    // Il faut ajouter un obstacle ici
                    carte.generateRandomObstacle(x, y);
                }
            }
            */

            Console.ReadLine();
        }
    }
}
