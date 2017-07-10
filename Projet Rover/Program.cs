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
            int width = 10, height = 10, pourcentage = 15;
            List<String> sequenceMouvement = new List<String>();

            Carte carte = new Carte(width, height, pourcentage);
            ICoordonnee casesPresenteSurLaCarte = carte.Coordonnees;

            Graph graph = new Graph(carte);
            Rover rover = new Rover(carte, graph);
            carte.addRover(5, 5, rover);

            // ---- START Déplacement manuel du robot ----
            /*
            sequenceMouvement.Add("t");
            sequenceMouvement.Add("t");
            rover.moveSequence(sequenceMouvement);
            */
            // ---- END Déplacement manuel du robot ----
            for (int y =0; y < height; y++ )
            {
                for (int x = 0; x < width; x++)
                {
                    carte.generateRandomObstacle(x, y);

                    // Affiche la grille avec les éléments présent dans celle-ci
                    Console.Write(casesPresenteSurLaCarte.getCoordonnee(x, y).element + " ");
                }
                Console.WriteLine();
            }

            
            try
            {
                // La ligne suivante permet de faire bouger de robot d'un point à un autre. (Dijsktra)
                rover.moveTo(9, 9);
            }
            catch (CaseIsNotEmptyException e)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine(e.Message);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("\n\n");
                Console.WriteLine("Exception : La position de destination du robot est en dehors des limites de la carte. Veuillez spécifier des valeurs valides.");
            }            

            Console.ReadLine();
            
        }
    }
}
