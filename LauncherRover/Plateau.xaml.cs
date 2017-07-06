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

namespace LauncherRover
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            int width = 10, height = 10, pourcentage = 20;
            Carte carte = new Carte(width, height, pourcentage);
            carte.addRover(1, 1);

            // AJouter les obstacle 

            //carte.addElement(1, 1, rover);

            Coordonnee coordonnees = carte.Coordonnees;
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

            InitializeComponent();




        }
    }
}
