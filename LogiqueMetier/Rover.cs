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

                List<IElement> coordonnees = carte.Coordonnees.Coordoonees;

                if (carte.isEmpty(validIndex[0], validIndex[1]))
                {
                    coordonnees[carte.Coordonnees.Height * this.y + this.x] = null;
                    coordonnees[carte.Coordonnees.Height * validIndex[1] + validIndex[0]] = this;

                    // Ajout des nouvelles coordonnées du robot
                    this.x = validIndex[0];
                    this.y = validIndex[1];
                }
            }
        }

       


        public void moveTo(int x, int y)
        {
            //Dijkstrat a faire ici
            IElement depart = carte.Coordonnees.getCoordonnee(this.x, this.y);
            IElement arrivee = carte.Coordonnees.getCoordonnee(x, y);
            this.graph.shortest_path(depart, arrivee).ForEach(v => Console.WriteLine(v));
        }
    }
}
