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
        private int xPositionRover;
        private int yPositionRover;
        private Graph graph;
        private ICarte carte;
        private Node nodeQuiContientRover;


        // ---------------------- //
        // -- START Accesseur  -- //

        public int XPositionRover { get => xPositionRover; set => xPositionRover = value; }
        public int YPositionRover { get => yPositionRover; set => yPositionRover = value; }

        // -- END Accesseur  -- //
        // -------------------- //


        public Rover(ICarte carte, Graph graph)
        {
            this.carte = carte;
            this.graph = graph;
        }


        public void setPosition(int x, int y)
        {
            this.xPositionRover = x;
            this.yPositionRover = y;
            this.nodeQuiContientRover = this.carte.getRover();
            Console.WriteLine("Position du robot : x = " + this.xPositionRover + " , y = " + this.yPositionRover);
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
                        validIndex = carte.Coordonnees.validCoordonnee(XPositionRover, YPositionRover - 1);
                        break;
                    case "b":
                        validIndex = carte.Coordonnees.validCoordonnee(XPositionRover, YPositionRover + 1);
                        break;
                    case "r":
                        validIndex = carte.Coordonnees.validCoordonnee(XPositionRover - 1, YPositionRover);
                        break;
                    case "l":
                        validIndex = carte.Coordonnees.validCoordonnee(XPositionRover + 1, YPositionRover);
                        break;
                    default:
                        Console.WriteLine("La direction fourni n'existe pas. Seul les directions suivantes peuvent être utilisées : t = top / b = bottom / r = right / l = left");
                        break;
                }
                Console.WriteLine("Valid index :" + validIndex[0] + " " + validIndex[1]);

                List<Node> listeDesNodes = carte.Coordonnees.ListNodes;

                if (carte.isEmpty(validIndex[0], validIndex[1]))
                {
                    listeDesNodes[carte.Coordonnees.Height * this.YPositionRover + this.XPositionRover].element = null;
                    listeDesNodes[carte.Coordonnees.Height * validIndex[1] + validIndex[0]].element = this;

                    // Ajout des nouvelles coordonnées du robot
                    this.XPositionRover = validIndex[0];
                    this.YPositionRover = validIndex[1];
                }
                else
                {
                    Console.WriteLine("Le rover ne peut pas aller sur la case suivante car celle-ci n'est pas vide. | Case suivante =  [{0}, {1}] = {2}.", validIndex[0], validIndex[1], listeDesNodes[carte.Coordonnees.Height * this.YPositionRover + this.XPositionRover].element);
                }
            }
        }

       

        public void moveTo(int xDestination, int yDestination)
        {
            try
            {
                Node positionRoverDepart = this.carte.getRover();
                Node positionRoverArrivee = this.carte.Coordonnees.getCoordonnee(xDestination, yDestination);
                Dictionary<Node, Dictionary<Node, int>> listVertex = this.graph.generateGraph();
                
                Dijkstra shortestPath = new Dijkstra(positionRoverDepart, positionRoverArrivee, listVertex);

                Console.WriteLine("Path :" + shortestPath.shortest_path());
                //shortestPath.shortest_path().ForEach(x => Console.WriteLine(x));
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
