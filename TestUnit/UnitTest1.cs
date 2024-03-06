using System;
using Xunit;


namespace TestUnit
{
    public class UnitTest1
    {
        [Test]
        public void TestMotChoisiNotNullOrEmpty()
        {
            //Verifi que on a bien choisis un mot
            MainWindow mainWindow = new MainWindow();
            Assert.That(!string.IsNullOrEmpty(mainWindow.motChoisi));
        }

        [Test]
        public void TestMotCacheInitializedWithAsterisks()
        {
            // Verifi la longueur du mot
            MainWindow mainWindow = new MainWindow();
            string expected = new string('*', mainWindow.motChoisi.Length);
            Assert.AreEqual(expected, mainWindow.motCache);
        }

        [Test]
        public void TestNombreVieInitializedWithSeven()
        {
            //Verifi le nombre de vies 
            MainWindow mainWindow = new MainWindow();
            Assert.AreEqual(7, mainWindow.nombreVie);
        }

        [Test]
        public void TestTimerTicks()
        {
            //Verifi que le timer est plus grand que 0
            MainWindow mainWindow = new MainWindow();
            mainWindow.Timer(null, null);
            Assert.Greater(mainWindow.secondes, 0);
        }

        [Test]
        public void TestBoutonClickCorrectGuess()
        {
            //Verifi l'algo avec un bon mot
            MainWindow mainWindow = new MainWindow();
            mainWindow.motChoisi = "TEST";
            mainWindow.tbDisplay.Text = "****";
            mainWindow.BoutonClick(mainWindow.btnT, null);
            Assert.AreEqual("T***", mainWindow.tbDisplay.Text);
        }
    }
}
