using Alapaca_tour_Winform_dotNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alapaca_tour_Winform_dotNet
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();

            // Splash Screen középre helyezése
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar.Increment(2);
            if (progressBar.Value== 100 ) {
                timer1.Enabled= false;
                Graph graph = new Graph();

                // Adatok betöltése az adatbázisból a Graph objektumba
                Db_helper db_helper = new Db_helper(graph);
                db_helper.CreateDistanceTable();
                db_helper.ImportDataFromCsv("./stationList.csv");
                db_helper.FetchDataFromDatabase();

                graph.AddNodeForNodeCounterAndCalc();

                Alapaca_tour_Winform_dotNet.Models.Matrix matrix = new Alapaca_tour_Winform_dotNet.Models.Matrix(graph);
                matrix.MakeMatrix(graph);
                MainWindow mainWindow = new MainWindow(graph, db_helper, matrix);
                mainWindow.Show();
                this.Hide();
            }
        }
    }
}
