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
        
        public int XPositionRover
        {
            get
            {
                return xPositionRover;
            }

            set
            {
                xPositionRover = value;
            }
        }

        public int YPositionRover
        {
            get
            {
                return yPositionRover;
            }

            set
            {
                yPositionRover = value;
            }
        }

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
            this.YPositionRover = y;
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

                // Déplacement avec des directions (NORD - SUD - EST - OUEST)
                // Il faut que je fasse le déplacement du Robot en tenant compte de sa direction (CF voir fonction que j'ai déjà codé pour l'autre projet en commentaire ci-dessous)
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
                    listeDesNodes[carte.Coordonnees.Height * this.YPositionRover + this.xPositionRover].element = null;
                    listeDesNodes[carte.Coordonnees.Height * validIndex[1] + validIndex[0]].element = this;

                    // Ajout des nouvelles coordonnées du robot
                    this.xPositionRover = validIndex[0];
                    this.yPositionRover = validIndex[1];
                }
                else
                {
                    Console.WriteLine("Le rover ne peut pas aller sur la case suivante car celle-ci n'est pas vide. | Case suivante =  [{0}, {1}] = {2}.", validIndex[0], validIndex[1], listeDesNodes[carte.Coordonnees.Height * this.YPositionRover + this.XPositionRover].element);
                }
            }
        }
        /*

        private void deplacerRobot(int[] nextPositionRobot)
        {
            // Si il n'y a pas d'obstacle, alors on execute l'action de deplacement
            if (!isObstacle(this.currentPosition, nextPositionRobot))
            {
                this.previousPosition = this.currentPosition;
                this.currentPosition = nextPosition;

                // Faire le déplacement ici ...

            }
            else
            {
                Console.WriteLine("Impossible d'éffectuer le déplamecement car un obstacle est présent !");
            }
        }

        private int[] getDirectionRobot(Node currentPosition, Node previousPosition)
        {
            int[] direction = new int[2];
            int x = 0, y = 0;

            // Si x =  1; --> Le devant du robot vise la DROITE     // Si y =  1; --> Le devant du robot vise la HAUT
            // Si x = -1; --> Le devant du robot vise la GAUCHE     // Si y = -1; --> Le devant du robot vise la BAS
            if (currentPosition[0] > previousPosition[0])
            {
                x = 1;
                Console.WriteLine("Va vers DROITE");
            }
            else
            {
                x = -1;
                Console.WriteLine("Va vers GAUCHE");
            }

            if (currentPosition[1] > previousPosition[1])
            {
                y = 1;
                Console.WriteLine("Va vers le HAUT");
            }
            else
            {
                y = -1;
                Console.WriteLine("Va vers le BAS");
            }

            direction.SetValue(x, 0);
            direction.SetValue(y, 1);

            return direction;
        }

        private int[] nextPositionAvancer(int[] currentPosition, int[] previousPosition)
        {
            int[] nextPosition = new int[2];
            int[] dir = getDirectionRobot(currentPosition, previousPosition);
            int nextX = 0, nextY = 0;

            if (dir[0] == 0 && dir[1] == 0)
            {
                nextY = currentPosition[1] + 1;
                nextPosition.SetValue(nextY, 1);
            }
            else
            {
                if (dir[0] > 0) // Vers la droite
                {
                    nextX = currentPosition[0] + 1;
                    nextPosition.SetValue(nextX, 0);
                }
                else
                {
                    nextX = currentPosition[0] - 1;
                    nextPosition.SetValue(nextX, 0);
                }

                if (dir[1] > 0) // Vers le haut
                {
                    nextY = currentPosition[1] + 1;
                    nextPosition.SetValue(nextY, 1);
                }
                else
                {
                    nextY = currentPosition[1] - 1;
                    nextPosition.SetValue(nextY, 1);
                }
            }



            return nextPosition;
        }

        private int[] nextPositionReculer(int[] currentPosition, int[] previousPosition)
        {
            int[] nextPosition = new int[2];
            int[] dir = getDirectionRobot(currentPosition, previousPosition);
            int nextX = 0, nextY = 0;

            if (dir[0] == 0 && dir[1] == 0)
            {
                nextY = currentPosition[1] - 1;
                nextPosition.SetValue(nextY, 1);
            }
            else
            {
                if (dir[0] > 0) // Vers la droite
                {
                    nextX = currentPosition[0] - 1;
                    nextPosition.SetValue(nextX, 0);
                }
                else
                {
                    nextX = currentPosition[0] + 1;
                    nextPosition.SetValue(nextX, 0);
                }

                if (dir[1] > 0) // Vers le haut
                {
                    nextY = currentPosition[1] - 1;
                    nextPosition.SetValue(nextY, 1);
                }
                else
                {
                    nextY = currentPosition[1] + 1;
                    nextPosition.SetValue(nextY, 1);
                }
            }




            return nextPosition;
        }

        private int[] nextPositionDroite(int[] currentPosition, int[] previousPosition)
        {
            int[] nextPosition = new int[2];
            int[] dir = getDirectionRobot(currentPosition, previousPosition);
            int nextX = 0, nextY = 0;

            if (dir[0] == 0 && dir[1] == 0)
            {
                nextX = currentPosition[0] + 1;
                nextPosition.SetValue(nextX, 0);
            }
            else
            {
                if (dir[0] > 0) // Vers la droite
                {
                    nextY = currentPosition[0] - 1;
                    nextPosition.SetValue(nextY, 1);
                }
                else
                {
                    nextY = currentPosition[0] + 1;
                    nextPosition.SetValue(nextX, 1);
                }

                if (dir[1] > 0) // Vers le haut
                {
                    nextX = currentPosition[1] + 1;
                    nextPosition.SetValue(nextX, 0);
                }
                else
                {
                    nextX = currentPosition[1] - 1;
                    nextPosition.SetValue(nextX, 0);
                }
            }



            return nextPosition;
        }

        private int[] nextPositionGauche(int[] currentPosition, int[] previousPosition)
        {
            int[] nextPosition = new int[2];
            int[] dir = getDirectionRobot(currentPosition, previousPosition);
            int nextX = 0, nextY = 0;

            if (dir[0] == 0 && dir[1] == 0)
            {
                nextX = currentPosition[0] - 1;
                nextPosition.SetValue(nextX, 0);
            }
            else
            {
                if (dir[0] > 0) // Vers la droite
                {
                    nextY = currentPosition[0] + 1;
                    nextPosition.SetValue(nextY, 1);
                }
                else
                {
                    nextY = currentPosition[0] - 1;
                    nextPosition.SetValue(nextX, 1);
                }

                if (dir[1] > 0) // Vers le haut
                {
                    nextX = currentPosition[1] - 1;
                    nextPosition.SetValue(nextX, 0);
                }
                else
                {
                    nextX = currentPosition[1] + 1;
                    nextPosition.SetValue(nextX, 0);
                }
            }


            return nextPosition;
        }
        */

        public void moveTo(int xDestination, int yDestination)
        {
            if ((xDestination < carte.Width-1) || (yDestination < carte.Height -1))
            {
                throw new ArgumentOutOfRangeException();
            }else
            {
                if (carte.isEmpty(xDestination, yDestination))
                {
                    Node positionRoverDepart = this.carte.getRover();
                    Node positionRoverArrivee = this.carte.Coordonnees.getCoordonnee(xDestination, yDestination);
                    Dictionary<Node, List<Node>> listVertex = this.graph.generateGraph();

                    Dijkstra shortestPath = new Dijkstra();
                    Chemin chem = shortestPath.Chemin_Le_Plus_Cours(positionRoverDepart, positionRoverArrivee, listVertex);

                    foreach (Node c in chem.listeCoor)
                    {
                        Console.WriteLine("Path : [{0}, {1}]", c.x, c.y);
                    }
                }
                else
                {
                    Console.WriteLine("\n\n");
                    throw new CaseIsNotEmptyException();
                }
            }
        }
    }
}
