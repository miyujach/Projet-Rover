using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogiqueMetier
{
    public class Rover : Element, IRover
    {
        private int x;
        private int y;
        private Graph graph;
        private ICarte carte;
        private IRover rover;
        
        public Rover(ICarte carte, Graph graph)
        {
            this.carte = carte;
            this.rover = carte.getRover();
        }


        public void setPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override ICoordonnee getPosition()
        {
            throw new NotImplementedException();
        }

        public void moveSequence(List<string> sequence)
        {
            foreach (string mouvement in sequence)
            {
                int[] validIndex = new int[2];
                Thread.Sleep(100);
                // t, b, r, l

                switch (mouvement)
                {
                    case "t":
                        validIndex = carte.Coordonnees.validCoordonnee(x, y - 1);
                        break;
                    case "b":
                        validIndex = carte.Coordonnees.validCoordonnee(x, y + 1);
                        break;
                    case "r":
                        validIndex = carte.Coordonnees.validCoordonnee(x - 1, y);
                        break;
                    case "l":
                        validIndex = carte.Coordonnees.validCoordonnee(x + 1, y);
                        break;
                    default:
                        Console.WriteLine("La direction fourni n'existe pas. Seul les directions suivantes peuvent être utilisées : t = top / b = bottom / r = right / l = left");
                        break;
                }
                Console.WriteLine("Valid index :" + validIndex[0] + " " + validIndex[1]);

                List<Node> listeDesNodes = carte.Coordonnees.ListNodes;

                if (carte.isEmpty(validIndex[0], validIndex[1]))
                {
                    listeDesNodes[carte.Coordonnees.Height * this.y + this.x].element = null;
                    listeDesNodes[carte.Coordonnees.Height * validIndex[1] + validIndex[0]].element = this;

                    // Ajout des nouvelles coordonnées du robot
                    this.x = validIndex[0];
                    this.y = validIndex[1];
                }
            }
        }

       


        public void moveTo(int xDestination, int yDestination)
        {
            try
            {
                //Dijkstrat a faire ici
                Node depart = carte.Coordonnees.getCoordonnee(this.x, this.y);
                Node arrivee = carte.Coordonnees.getCoordonnee(xDestination, yDestination);
                List<Dictionary<Node, Dictionary<NeightborhoodNode, int>>> listVertex = graph.generateGraph();
                Dijkstra shortestPath = new Dijkstra(depart, arrivee, listVertex);
                //this.graph.shortest_path(depart, arrivee).ForEach(v => Console.WriteLine(v));
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                System.Console.WriteLine(e.Message);
                // Set IndexOutOfRangeException to the new exception's InnerException.
                throw new System.ArgumentOutOfRangeException("Déplacement Robot (moveTo) : Le robot ne peut pas être placé en dehors des coordonnées de la carte, veuillez placer le robot entre 0 et " + carte.Coordonnees.Width + " sur l'axe des X et entre 0 et " + carte.Coordonnees.Height + " sur l'axe des Y", e);
            }
        }
    }
}
