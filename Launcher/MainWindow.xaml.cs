using LogiqueMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Launcher
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            int width = 10, height = 10, pourcentage = 25;
            List<String> sequenceMouvement = new List<String>();

            Carte carte = new Carte(width, height, pourcentage);
            ICoordonnee coordonnees = carte.Coordonnees;
            Rover rover = new Rover(carte);
            carte.addRover(0, 0, rover);

            sequenceMouvement.Add("t");
            sequenceMouvement.Add("t");
            rover.moveSequence(sequenceMouvement);

            // AJouter les obstacle 
            //carte.addElement(1, 1, rover);

            for (int y = 0; y < height; y++)
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
            foreach (IElement item in neightborhood)
            {
                Console.WriteLine("Voisin : " + item);
            }

            InitializeComponent();
            lst.ItemsSource = coordonnees.Coordoonees;
        }
    }
}
