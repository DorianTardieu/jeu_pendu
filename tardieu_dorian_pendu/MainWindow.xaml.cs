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
        string word ;
        string motcache;
        string Result;
        int vie = 7;
        int minute = 0;
        DispatcherTimer time;
        //Liste de mots du pendu
        string[] listMots = new string[] { "moto", "lycee", "lettre", "pendu", "ordinateur", "internet", "programme", "pirate",
         "Diplomate","Pieds","Conceptuel","Lunettes","Jeune","Peur","Reflechir","Oncle","Embouchure","ecrire","Tournevis","Perdant",
         "Cou","Poivre","Haut","Adulte","Agrafe","Plastique","Funiculaire","Acier","ecorce","Chemisier","Phare","Saucisse",
          "Plein","Entreprise","Soins","electrique","Labyrinthe","Caricature","Fertile","Titre","Rival","Orbite","Cactus","Pratique"};
        Random rdm = new Random();
        public MainWindow()
        {


          //DispatcherTimer dt = new DispatcherTimer();
            InitializeComponent();
            word = listMots[rdm.Next(listMots.Length)]; //Choisi aléatoirement un mot de la liste pour le jeu
            word = word.ToUpper();
            motcache = new string('*', word.Length);
            TB_Display.Text = motcache;
            
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            time = new DispatcherTimer();

            time.Interval = TimeSpan.FromSeconds(1);
            time.Tick += dtTicker;
            time.Interval = new TimeSpan(0, 0, 1);
            time.Start();
        }

        int increment =0;

        public void dtTicker(object sender, EventArgs e)
        {
            increment++;
            TimerLabel.Content = increment.ToString();
            if (increment == 60)
            {
                minute++;
                increment = 0;
            }
            TimerLabel.Content=(minute+":"+increment);
        
        }




        private void BTN_Click(object sender, RoutedEventArgs e) //Methode de tout les boutons Click
        {


       


            Button _btn = sender as Button;
            string lettre = _btn.Content.ToString();
            _btn.IsEnabled = false;        
            int n = 0;
            char l = Convert.ToChar(lettre);
            time.Start();

    



            if (word.Contains(lettre))
            {
                foreach (var t in word)
                {

                    if (t == l)
                    {
                        motcache = motcache.Remove(n, 1).Insert(n, lettre);
                        TB_Display.Text = motcache;
                    }
                    n++;

                }
                if (!motcache.Contains("*"))
                {
                    Result = "gagné";
                    LBL_vie.Content = Result;
                    time.Stop();




                    // Les lettres ne sont plus clicable si les conditions sont reunies

                    BTN_A.IsEnabled = false;
                    BTN_B.IsEnabled = false;
                    BTN_C.IsEnabled = false;
                    BTN_D.IsEnabled = false;
                    BTN_E.IsEnabled = false;
                    BTN_F.IsEnabled = false;
                    BTN_G.IsEnabled = false;
                    BTN_H.IsEnabled = false;
                    BTN_I.IsEnabled = false;
                    BTN_J.IsEnabled = false;
                    BTN_K.IsEnabled = false;
                    BTN_L.IsEnabled = false;
                    BTN_M.IsEnabled = false;
                    BTN_N.IsEnabled = false;
                    BTN_O.IsEnabled = false;
                    BTN_P.IsEnabled = false;
                    BTN_Q.IsEnabled = false;
                    BTN_R.IsEnabled = false;
                    BTN_S.IsEnabled = false;
                    BTN_T.IsEnabled = false;
                    BTN_U.IsEnabled = false;
                    BTN_V.IsEnabled = false;
                    BTN_W.IsEnabled = false;
                    BTN_X.IsEnabled = false;
                    BTN_Y.IsEnabled = false;
                    BTN_Z.IsEnabled = false;
                }
            }
            else
            {           
                vie = vie - 1;           
                LBL_vie.Content = ("Vie:" + vie);
                //Affichage des images du pendu
                Uri uri = new Uri("Ressource/" + vie + ".png", UriKind.Relative);
                Uri Image_Uri = uri;
                Image_vie.Source = new BitmapImage(Image_Uri);


                if (vie == 0)
                {
                    Result = "Perdu";
                    LBL_vie.Content = Result;
                    TB_Display.Text = word;
                    time.Stop();

                    // Les lettres ne sont plus clicable si les conditions sont reunies


                    BTN_A.IsEnabled = false;
                    BTN_B.IsEnabled = false;
                    BTN_C.IsEnabled = false;
                    BTN_D.IsEnabled = false;
                    BTN_E.IsEnabled = false;
                    BTN_F.IsEnabled = false;
                    BTN_G.IsEnabled = false;
                    BTN_H.IsEnabled = false;
                    BTN_I.IsEnabled = false;
                    BTN_J.IsEnabled = false;
                    BTN_K.IsEnabled = false;
                    BTN_L.IsEnabled = false;
                    BTN_M.IsEnabled = false;
                    BTN_N.IsEnabled = false;
                    BTN_O.IsEnabled = false;
                    BTN_P.IsEnabled = false;
                    BTN_Q.IsEnabled = false;
                    BTN_R.IsEnabled = false;
                    BTN_S.IsEnabled = false;
                    BTN_T.IsEnabled = false;
                    BTN_U.IsEnabled = false;
                    BTN_V.IsEnabled = false;
                    BTN_W.IsEnabled = false;
                    BTN_X.IsEnabled = false;
                    BTN_Y.IsEnabled = false;
                    BTN_Z.IsEnabled = false;
                    
                  
                }
            }
        }
    }
}