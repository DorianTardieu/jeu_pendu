using System;
using Xunit;


namespace TestUnit
{
    public class UnitTest1
    {
        [TestMethod]
        public void Constructor_InitializesVariablesCorrectly()
        {
         
            MainWindow mainWindow = new MainWindow();

            // Assert
            Assert.IsNotNull(mainWindow.motChoisi); //Verifie que mot choisi n'est pas null
            Assert.AreEqual(7, mainWindow.nombreVie);//Verifie que le nombre de vie n'est pas null
            Assert.AreEqual(0, mainWindow.minutes);//Verifie que le temps en minute est égale a 0 (pour le depart)
            Assert.AreEqual(0, mainWindow.secondes);//Verifie que le temps en seconde est égale a 0 (pour le depart)
            Assert.IsNotNull(mainWindow.nombreAleatoire);//Verifie que le nombre aleatoire pour choir dans la listes n'est pas null
            Assert.IsNotNull(mainWindow.listeMots);//Verifie que la listesmots n'est pas null
            Assert.IsNotNull(mainWindow.chrono);//Verifie que le chrono est pas null
            Assert.IsNotNull(mainWindow.motCache);//Verifie que mot caché n'est pas null
            Assert.IsFalse(string.IsNullOrEmpty(mainWindow.motCache));//Verifie que mot cache n'est pas encore trouvé
        }

        [TestMethod]
        public void Timer_IncrementsSecondsCorrectly()
        {
            //verifie que le timer fonctionne
          
            MainWindow mainWindow = new MainWindow();

           
            mainWindow.Timer(null, EventArgs.Empty);

         
            Assert.AreEqual(1, mainWindow.secondes);
        }
        [Test]
        public void TestBoutonClickIncorrectGuess()
        {
             // verifie l'algorithme en testant quand le mot est faux
            MainWindow mainWindow = new MainWindow();
            mainWindow.motChoisi = "TEST";
            mainWindow.tbDisplay.Text = "****";

            
            mainWindow.BoutonClick(mainWindow.btnA, null);

            Assert.AreEqual("****", mainWindow.tbDisplay.Text);
            Assert.AreEqual(6, mainWindow.nombreVie);
        }



    }
}
