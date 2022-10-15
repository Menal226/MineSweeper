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

namespace MineSweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool flagMode = false;
        bool isPlaying = true;
        //Vytvoří hrací plochu
        int[,] GameBoard = {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, };
        int[,] GameBoardDuring = {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, };

        public MainWindow()
        {
            int kolikMinJeVeHre = 50;
            //Vygeneruje souřadnice min
            var souřadniceMinČíslo = RNG(kolikMinJeVeHre);
            //Zaplní hrací plochu minama
            foreach (var item in souřadniceMinČíslo)
            {
                GameBoard[item / 9, item % 9] = 9;
            }
            //THIS CODE IS DOGSHIT!!!
            //Měl bych to dělat z pohledu bomby a ne jednotlivých políček, ale nechce se mi nad tím přemýslet, takže FUCK IT LMAO
            //Projde každé políčko a zapíše kolik bomb kolem sebe má
            for (int i = 0; i < 180; i++)
            {
                if (!souřadniceMinČíslo.Contains(i))
                {
                    int řada = i / 9;
                    int sloupec = i % 9;
                    int bombAmount = 0;
                    //Pokud je bomba v levo nahoře přidej 1 do počtu
                    try
                    {
                        if (GameBoard[řada - 1, sloupec - 1] == 9) bombAmount++;
                    }
                    catch
                    {

                    }
                    //Pokud je bomba uprostřed nahoře přidej 1 do počtu
                    try
                    {
                        if (GameBoard[řada - 1, sloupec] == 9) bombAmount++;
                    }
                    catch
                    {

                    }
                    //Pokud je bomba v pravo nahoře přidej 1 do počtu
                    try
                    {
                        if (GameBoard[řada - 1, sloupec + 1] == 9) bombAmount++;
                    }
                    catch
                    {

                    }
                    //Pokud je bomba v levo přidej 1 do počtu
                    try
                    {
                        if (GameBoard[řada, sloupec - 1] == 9) bombAmount++;
                    }
                    catch
                    {

                    }
                    //Pokud je bomba v pravo přidej 1 do počtu
                    try
                    {
                        if (GameBoard[řada, sloupec + 1] == 9) bombAmount++;
                    }
                    catch
                    {

                    }
                    //Pokud je bomba v levo dole přidej 1 do počtu
                    try
                    {
                        if (GameBoard[řada + 1, sloupec - 1] == 9) bombAmount++;
                    }
                    catch
                    {

                    }
                    //Pokud je bomba v uprostřed dole přidej 1 do počtu
                    try
                    {
                        if (GameBoard[řada + 1, sloupec] == 9) bombAmount++;
                    }
                    catch
                    {

                    }
                    //Pokud je bomba v pravo dole přidej 1 do počtu
                    try
                    {
                        if (GameBoard[řada + 1, sloupec + 1] == 9) bombAmount++;
                    }
                    catch
                    {

                    }
                    GameBoard[řada, sloupec] = bombAmount;
                }

            }
        }
        /// <summary>
        /// Vygeneruje učitý počet náhodných čísel
        /// </summary>
        /// <param name="kolikČíselVygenerovat">Počet náhodných čísel k vygenerovaní</param>
        /// <returns>List s náhodnýmy čísly</returns>
        public List<int> RNG(int kolikČíselVygenerovat)
        {
            //Vytvoří RNG
            var rand = new Random();
            //List do, kterého se budou ukládat náhodná čísla
            List<int> listNumbers = new List<int>();
            int number;
            for (int x = 0; x < kolikČíselVygenerovat; x++)
            {
                do
                {
                    //Náhodné číslo od 1 do 180
                    number = rand.Next(1, 180);
                    //Jestli ještě neexistuje, tak ho uloží
                } while (listNumbers.Contains(number));
                //Přidá ho na list
                listNumbers.Add(number);
            }
            //Vrátí list
            return listNumbers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                var zmáčknutéTlačíko = (Button)sender;
                //Zjistí souřadnice tlačítka pomocí jeho názvu
                int sloupec = Convert.ToInt32(Convert.ToString(zmáčknutéTlačíko.Name[8]));
                int řádek = Convert.ToInt32(Convert.ToString(zmáčknutéTlačíko.Name[10]) + Convert.ToString(zmáčknutéTlačíko.Name[11]));
                //Pokud je zapnutý flagmode dá na zmáčknuté místo vlajku
                if (flagMode)
                {
                    GameBoardDuring[řádek, sloupec] = 10;
                    zmáčknutéTlačíko.Content = "🚩";
                }
                else
                {
                    if (GameBoard[řádek, sloupec] == 9)
                    {
                        zmáčknutéTlačíko.Content = "💣";
                    }
                    else
                    {
                        zmáčknutéTlačíko.Content = Convert.ToString(GameBoard[řádek, sloupec]);
                    }
                }
            }
            else
            {

            }
        }

        private void ModeSwitchButton_Click(object sender, RoutedEventArgs e)
        {
            //Pokud je flagMode zapnutý
            if (flagMode)
            {
                //Zmeň obsah buttonu
                ModeSwitchButton.Content = "⚒️";
                //Vypni flagMode 
                flagMode = false;
            }
            //Pokud je flagMode vypnutý
            else
            {
                //Zmeň obsah buttonu
                ModeSwitchButton.Content = "🚩";
                //Zapni flagMode 
                flagMode = true;
            }
        }
    }
}