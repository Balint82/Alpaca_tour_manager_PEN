using Alapaca_tour_Winform_dotNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;



namespace Alapaca_tour_Winform_dotNet
{
    public partial class MainWindow : Form
    {
        Graph graph;
        Db_helper db_helper;
        Alapaca_tour_Winform_dotNet.Models.Matrix matrix;
        Planner planner;
        UCS ucs;
        TimeCalc timeCalc;
        
        List<string> stationList = new List<string>();
        string tripType;

        public MainWindow(Graph graph, Db_helper db_helper, Alapaca_tour_Winform_dotNet.Models.Matrix matrix)
        {
            InitializeComponent();

            this.graph = graph; // graph inicializálása
            this.db_helper = db_helper; // db_helper inicializálása
            this.matrix = matrix; // matrix inicializálása

            ucs = new UCS(graph, matrix);
            planner = new Planner(ucs, graph);
            timeCalc = new TimeCalc(planner);

            // Feliratkozás az ErrorOccurred eseményre
            db_helper.ErrorOccurred += HandleError;

            //Ha túlfut valamelyik eredménymező szövege, akkor gördítősávval látja el ez a tulajdonság
            detailedResultField.ScrollBars = ScrollBars.Vertical;
            //sumResultField.ScrollBars = ScrollBars.Vertical;

            // Splash Screen középre helyezése
            this.StartPosition = FormStartPosition.CenterScreen;


            // DataGridView formázása
            //Header
            //sumGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            sumGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Szöveg középre igazítása
            sumGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12); // Betűméret és betűtípus beállítása
            //Cell
            sumGridView.DefaultCellStyle.BackColor = Color.LightBlue; // Üres cellák kitöltése
            sumGridView.CellBorderStyle = DataGridViewCellBorderStyle.None; // Cellakeret elrejtése
            sumGridView.DefaultCellStyle.Font = new Font("Arial", 10); // Betűméret és betűtípus beállítása
            sumGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Szöveg pozícionálása a cellákban
            sumGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Szöveg pozícionálása a fejlécekben
            sumGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.MintCream;

            OneDayRadioButton.Checked = true;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
           
        }

      

        private void oneDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            tripType = "Egy napos utazás";
           

        }

        private void moreDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            tripType = "Több napos utazás";
          
        }

        private void storeButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(StoreField.Text))
            {
                Tuple<int, string> storingStation;
                string cleanedText = StoreField.Text.Trim();
                storingStation = db_helper.RebuildNodedatas(StoreField.Text);
                if(storingStation != null && storingStation.Item1 != 0)
                {
                    int alpakaNr = storingStation.Item1;
                    string hotelPlace = storingStation.Item2;
                    if (!stationList.Contains(StoreField.Text)) //üres mező ellenőrzés
                    {
                        if (!stationList.Any(s => string.Equals(s.Trim(), cleanedText, StringComparison.OrdinalIgnoreCase)))// útvonallista - duplikáció ellenőrzés
                        {
                            stationList.Add(StoreField.Text);
                            UpdateListBox();
                            // Mezők ürítése
                            StoreField.Text = "";
                            infoField.Text = "";
                        }
                    }
                    else
                    {
                        infoField.Text = "A települést már eleme az útvonaltervnek";
                    }
                }
                else
                {
                    infoField.Text = "Nincs az állomás az adatbázisban.";
                }
            }
            else
            {
                infoField.Text = "A mező nem lehet üres";
            }
        }

        private void StoreField_Keypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(StoreField.Text))
                {
                    Tuple<int, string> storingStation;
                    string cleanedText = StoreField.Text.Trim();
                    storingStation = db_helper.RebuildNodedatas(StoreField.Text);
                    if (storingStation != null && storingStation.Item1 != 0)
                    {
                        int alpakaNr = storingStation.Item1;
                        string hotelPlace = storingStation.Item2;
                        if (!stationList.Any(s => string.Equals(s.Trim(), cleanedText, StringComparison.OrdinalIgnoreCase))) //útvonallista-duplikáció ellenőrzés
                        {
                            if (infoField.Text != "Nem található a település az adatbázisban.")
                            {
                                stationList.Add(StoreField.Text);
                                UpdateListBox();
                                // Mezők ürítése
                                StoreField.Text = "";
                                infoField.Text = "";
                            }
                        }
                        else
                        {
                            infoField.Text = "A települést már eleme az útvonaltervnek";
                        }
                    }
                    else
                    {
                        infoField.Text = "Nincs az állomás az adatbázisban.";
                    }
                }
                else
                {
                    infoField.Text = "A mező nem lehet üres";
                }
            }
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            string displayTour = "";
            Tuple<List<Node>, float> pathPlan = planner.FindShortestBruteForce(stationList);
            string sumResult = planner.GetFormattedResult(pathPlan);
            Console.WriteLine(sumResult);
            string pattern = @"'(.*?)'"; //Reguláris kifejezésminta, a tartalom egyeztetése az idézőjelek között
            MatchCollection matches = Regex.Matches(sumResult, pattern);

            sumGridView.Rows.Clear();

            for (int i = 0; i < matches.Count; i += 6) // Az adatok szerinti csoportosítás miatt 5-ösével lépünk 
            {
                string number = matches[i].Groups[1].Value;
                string name = matches[i + 1].Groups[1].Value;
                string weight = matches[i + 2].Groups[1].Value;
                string alpacaNr = matches[i + 3].Groups[1].Value;
                string hotel = matches[i + 4].Groups[1].Value;
                string totalD = matches[i + 5].Groups[1].Value;
                sumGridView.Rows.Add(number, name, weight, alpacaNr, hotel, totalD);    
            }

            //sum
            if (tripType == "Egy napos utazás")
            {
                displayTour = timeCalc.MeasureTimeForOneDayTravel(pathPlan);
            }else if(tripType == "Több napos utazás")
            {
                displayTour = timeCalc.MeasureTimeForHotelTravel(pathPlan);
            }
            
           //detailed
           detailedResultField.Text = displayTour;
        }

        private void newPlanButton_Clicked(object sender, EventArgs e)
        {
            // Listák törlése
            stationList.Clear();
            UpdateListBox();

            // Mezők ürítése
            StoreField.Text = "";
            infoField.Text = "";
            sumGridView.Rows.Clear();
            detailedResultField.Text = "";
        }

        private void deleteButton_Clicked(object sender, EventArgs e)
        {
            // Ellenőrizzük, hogy van-e elem a listában
            if (stationList.Count > 0)
            {
                // Az utolsó elem eltávolítása a listából
                string lastStation = stationList.Last();
                stationList.RemoveAt(stationList.Count - 1);

                // ListBox-ból az utolsó elem eltávolítása
                if (stationListField.Items.Contains(lastStation))
                {
                    stationListField.Items.Remove(lastStation);
                }

                // Ha a lista most üres, ürítsük a mezőket
                if (stationList.Count == 0)
                {
                    StoreField.Text = "";
                    infoField.Text = "";
                }
            }
        }




        private void storeField_TextChanged(object sender, EventArgs e)
        {

        }

        private void stationListField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        */

        public void UpdateListBox()
        {
            // Töröljük a ListBox összes elemét
            stationListField.Items.Clear();
            // Adjuk hozzá az összes elemet a stringList-ből a ListBox-hoz
            foreach (string item in stationList)
            {
                stationListField.Items.Add(item);
            }
        }

        private void HandleError(string errorMessage)
        {
            // A Db_Helper RebuildNodeData Hibaüzenet megjelenítése az InfoField-en 
            infoField.Text = errorMessage;
        }













        private void infoField_TextChanged(object sender, EventArgs e)
        {

        }

        private void StoreLabel_Clicked(object sender, EventArgs e)
        {

        }

        private void StoreField_Clicked(object sender, EventArgs e)
        {

        }

        private void infoLabel_Clicked(object sender, EventArgs e)
        {

        }

        private void sumResultLabel_Clicked(object sender, EventArgs e)
        {

        }

        private void detailedResultField_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxLabel_Clicked(object sender, EventArgs e)
        {

        }

        private void sumResultField_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }
    }
}
