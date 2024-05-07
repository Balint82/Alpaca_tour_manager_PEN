using Alapaca_tour_Winform_dotNet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alapaca_tour_Winform_dotNet
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Graph graph = new Graph();

            string str = "greetings!";
            Console.WriteLine(char.ToUpper(str[0]) + str.Substring(1));
            // Adatok betöltése az adatbázisból a Graph objektumba
            Db_helper db_helper = new Db_helper(graph);
            db_helper.CreateDistanceTable();
            db_helper.ImportDataFromCsv("./stationList.csv");
            db_helper.FetchDataFromDatabase();

            graph.AddNodeForNodeCounterAndCalc();

            Alapaca_tour_Winform_dotNet.Models.Matrix matrix = new Alapaca_tour_Winform_dotNet.Models.Matrix(graph);
            matrix.MakeMatrix(graph);
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Splash());
        }
    }
}
