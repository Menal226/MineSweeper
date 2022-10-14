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
        public MainWindow()
        {
            int kolikMinJeVeHre = 10;
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
            //Vygeneruje souřadnice min
            var souřadniceMinČíslo = RNG(kolikMinJeVeHre);
            //Zaplní hrací plochu minama
            foreach (var item in souřadniceMinČíslo)
            {
                GameBoard[item / 9, item % 9] = 9;
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
    }
}
