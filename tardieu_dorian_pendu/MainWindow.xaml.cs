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
using System.Windows.Threading;

namespace tardieu_dorian_pendu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly string motChoisi;
        string motCache;

        int nombreVie = 7;
        int minutes = 0;
        int secondes = 0;
        readonly Random nombreAleatoire = new Random();
        DispatcherTimer chrono;

        //Liste de mots du pendu
        readonly string[] listeMots = new string[] { "moto", "lycee", "lettre", "pendu", "ordinateur", "internet", "programme", "pirate",
         "Diplomate","Pieds","Conceptuel","Lunettes","Jeune","Peur","Reflechir","Oncle","Embouchure","ecrire","Tournevis","Perdant",
         "Cou","Poivre","Haut","Adulte","Agrafe","Plastique","Funiculaire","Acier","ecorce","Chemisier","Phare","Saucisse",
         "Plein","Entreprise","Soins","electrique","Labyrinthe","Caricature","Fertile","Titre","Rival","Orbite","Cactus","Pratique"};

        public MainWindow()
        {
            
            InitializeComponent();
            motChoisi = listeMots[nombreAleatoire.Next(listeMots.Length)]; //Choisi aléatoirement un mot de la liste pour le jeu
            motChoisi = motChoisi.ToUpper();
            motCache = new string('*', motChoisi.Length);
            tbDisplay.Text = motCache;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            chrono = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            chrono.Tick += Timer;
            chrono.Interval = new TimeSpan(0, 0, 1);
            chrono.Start();
        }

        private void BoutonFalse()
        {
            foreach (var button in new[]
            {
                btnA, btnB, btnC, btnD, btnE, btnF, btnG, btnH,
                btnI, btnJ, btnK, btnL, btnM, btnN, btnO, btnP,
                btnQ, btnR, btnS, btnT, btnU, btnV, btnW, btnX,
                btnY, btnZ
            })
            {
                button.IsEnabled = false;
            }
        }

        public void Timer(object sender, EventArgs e)
        {
            secondes++;
            TimerLabel.Content = secondes.ToString();
            if (secondes == 60)
            {
                minutes++;
                secondes = 0;
            }
            TimerLabel.Content = (minutes + ":" + secondes);
        }

        private void BoutonClick(object sender, RoutedEventArgs e) //Methode de tout les boutons Click
        {
            int numSupprime = 0;
            Button boutonChoisi = sender as Button;
            string motEntier = boutonChoisi.Content.ToString();
            char lettre = Convert.ToChar(motEntier);

            boutonChoisi.IsEnabled = false;
            //Lance le chronomètre
            chrono.Start();

            if (motChoisi.Contains(motEntier))
            {
                foreach (var position in motChoisi)
                {
                    if (position == lettre)
                    {

                        motCache = motCache.Remove(numSupprime, 1).Insert(numSupprime, motEntier);
                        tbDisplay.Text = motCache;
                    }
                    numSupprime++;
                }

                if (!motCache.Contains("*"))
                {
                    lblVie.Content = "Gagné";
                    //Arrete le chronomètre
                    chrono.Stop();

                    // Les lettres ne sont plus clicable si les conditions sont reunies
                    BoutonFalse();
                }
            }

            else
            {   //Supprime une vie et l'affiche a chaque fois 
                nombreVie--;
                lblVie.Content = ("Vie: " + nombreVie);

                //Affichage des images du pendu
                Uri imageUri = new Uri("Ressource/" + nombreVie + ".png", UriKind.Relative);
                imgVie.Source = new BitmapImage(imageUri);

                if (nombreVie == 0)
                {

                    lblVie.Content = "Perdu";
                    //Affiche le mot en entier
                    tbDisplay.Text = motChoisi;
                    //Arrete le chronomètre
                    chrono.Stop();

                    // Les lettres ne sont plus clicable si les conditions sont reunies
                    BoutonFalse();
                }
            }
        }
    }
}