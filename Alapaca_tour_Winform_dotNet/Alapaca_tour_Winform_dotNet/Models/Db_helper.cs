using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Data;
using sqlite3 = System.IntPtr;
using sqlite3_stmt = System.IntPtr;

namespace Alapaca_tour_Winform_dotNet.Models
{ 
   public  class Db_helper
    {
        public SQLiteConnection conn;
        public Graph graph;

        public event Action<string> ErrorOccurred;

        public Db_helper(Graph graph) { 
            this.graph = graph;
            conn = new SQLiteConnection("Data Source=fountain.sqlite3");
            if (!File.Exists("./fountain.sqlite3"))
            {
                SQLiteConnection.CreateFile("fountain.sqlite3");
                Console.WriteLine("Az adatbázis létrejött.");       
            }else {
                Console.WriteLine("Az adatbázis korábban már létezett.");
            }
        }

        public void CreateDistanceTable()
        {
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE IF NOT EXISTS distances (id INTEGER PRIMARY KEY AUTOINCREMENT, kiindulo_varos VARCHAR(75), celvaros_city VARCHAR(75), tavolsag FLOAT, alpakaszam INTEGER, szallas VARCHAR(75))", conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a tábla létrehozása során: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }



        public void ImportDataFromCsv(string filePath)
        {
            conn.Open();
           
            bool isFirstLine = true;

            try
            {
                using (SQLiteCommand countCmd = new SQLiteCommand("SELECT COUNT(*) FROM distances", conn))
                {
                    int rowCount = Convert.ToInt32(countCmd.ExecuteScalar());

                    if (rowCount == 0)
                    {
                        Console.WriteLine("Adatok beolvasása a csv fájlból az adatbázisba.");
                        using (StreamReader reader = new StreamReader(filePath))

                            while (!reader.EndOfStream)
                            {
                                if (isFirstLine) { isFirstLine = false; reader.ReadLine(); } //első sor beolvasásának kihagyása
                                string line = reader.ReadLine();


                                var values = line.Split(';');
                                var sql = "INSERT INTO distances (kiindulo_varos, celvaros_city, tavolsag, alpakaszam, szallas) VALUES('" + values[1] + "','" + values[2] + "','" + values[3] + "','" + values[4] + "','" + values[5] + "')";

                                var cmd = new SQLiteCommand();
                                cmd.CommandText = sql;
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Connection = conn;
                                cmd.ExecuteNonQuery();
                            }
                        conn.Close();
                        Console.WriteLine("Az adatok beillesztése sikeresen megtörtént");
                    }
                    else { Console.WriteLine("Az adatbázisban már vannak rekordok"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt az adat importálása során: " + ex.Message);
            }
        }


        public void FetchDataFromDatabase()
        {
            conn = new SQLiteConnection("Data Source=fountain.sqlite3");
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("Az adatbáziskapcsolat sikeresen megnyitva.");
                }
                else
                {
                    Console.WriteLine("Az adatbáziskapcsolat nem sikerült megnyitni.");
                }

                string sql = "SELECT * FROM distances";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string citystartName = reader["kiindulo_varos"].ToString();
                            string citydestName = reader["celvaros_city"].ToString();
                            float dist = Convert.ToSingle(reader["tavolsag"]);
                            int alpakaNr = Convert.ToInt32(reader["alpakaszam"]);
                            string hotelPlace = reader["szallas"].ToString();

                            // Az adatok hozzáadása a Graph osztályhoz
                            graph.AddNode(citystartName, citydestName, dist, alpakaNr, hotelPlace);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt az adatok lekérése során: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public Tuple<int, string> RebuildNodedatas(string cityName)
        {
            try
            {
                conn.Open();
                string query = "SELECT alpakaszam, szallas FROM distances WHERE celvaros_city = @cityName";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@cityName", cityName);

                SQLiteDataReader reader = cmd.ExecuteReader();
                int alpakaNr = 0;
                string hotelPlace = "";


                if (reader.Read())
                {
                    alpakaNr = reader.GetInt32(0);
                    hotelPlace = reader.GetString(1);
                    reader.Close();
                    conn.Close();
                   
                    return Tuple.Create(alpakaNr, hotelPlace);
                }
                else
                {
                    throw new Exception("Nem található a település az adatbázisban.");
                }
            }
            catch (Exception e)
            {
                ErrorOccurred?.Invoke(e.Message);
                return Tuple.Create(0, ""); // hibás esetben üres értékkel térünk vissza
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close(); // Mindig lezárjuk az adatbáziskapcsolatot
                }
            }
        }


    }
}

/*
Az Action delegátum az eseménykezelő típusa, amelynek egyetlen paramétere van, azaz egy string. Az ErrorOccurred esemény erre az Action delegátumra van paraméterként beállítva. Az események azért használatosak, hogy egy osztály vagy modul más részei jelentsenek eseményeket más részeknek anélkül, hogy ismernék a fogadó részleteit vagy azok számát.

Az ErrorOccurred?.Invoke("SQL error: " + e.Message); kifejezés az esemény kiváltására szolgál. Az Invoke metódus hívja meg az eseményhez csatolt eseménykezelőket (vagyis a metódusokat vagy lambdafüggvényeket), és átadja nekik az esemény argumentumait (ez esetben a hibaüzenetet). Az ?. operátor egy biztonsági ellenőrzést jelent, hogy csak akkor hívjuk meg az Invoke metódust, ha az esemény nem null, vagyis ha van legalább egy eseménykezelő hozzárendelve az eseményhez. Ez megakadályozza a NullReferenceException dobását, ha nincs eseménykezelő hozzárendelve az eseményhez.

Összefoglalva, az Action ErrorOccurred delegátum az esemény típusa, amely egy hibaüzenetet fogad, az ErrorOccurred?.Invoke(...) kifejezés pedig kiváltja az eseményt, amikor hiba történik, és átadja neki a hibaüzenetet, hogy az eseménykezelők reagálhassanak rá.
*/