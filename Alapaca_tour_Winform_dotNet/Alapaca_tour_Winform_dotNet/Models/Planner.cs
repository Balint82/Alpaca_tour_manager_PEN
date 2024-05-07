using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

namespace Alapaca_tour_Winform_dotNet.Models
{
    class Planner
    {
        private readonly UCS ucsEngine;
        private readonly Db_helper dbManager;

        public Planner(UCS ucsEngine, Graph graph)
        {
            this.ucsEngine = ucsEngine;
            dbManager = new Db_helper(graph);
        }
       
        public Tuple<List<Node>, float> FindShortestBruteForce(List<string> stations)
        {
            float totalDistance = 0.0f;     
            Node startNode = new Node();
            startNode.Name = stations[0];
            startNode.Weight = 0.0f;
            startNode.AlpacaNr = 0;
            startNode.Hotel = "Induló állomás";
            Node final;
            List<Node> finalShortestPath = new List<Node>();
            Tuple<List<Node>, float> thePath;
            
            
            //1. elemtől ABC sorrendbe rendezi a listát.
            stations.Sort(1, stations.Count - 1, null);
            CreatePermutations(stations);
            
            List<Tuple<string, List<float>>> result = CreatePermutations(stations); //legrövidebb útvonal visszadása
            

            //vektorelemek alapján Node újraalkotás
            foreach (var station in result)
            {
                final = new Node();
                final.Name = station.Item1;
                final.Weight = station.Item2[0];
                var alpacaNrAndHotel = dbManager.RebuildNodedatas(station.Item1);
                final.AlpacaNr = alpacaNrAndHotel.Item1;
                final.Hotel = alpacaNrAndHotel.Item2;
                finalShortestPath.Add(final);
            }

            finalShortestPath.Insert(0, startNode); //kiinduló állomás visszehelyezése a listába
            thePath = Tuple.Create(finalShortestPath, totalDistance);
            
            foreach(var item in thePath.Item1)
            {
                Console.WriteLine(item.Name + " "+item.Weight + " " + totalDistance);
            }

            return thePath;
        }


        //Permutations
        public List<Tuple<string, List<float>>> CreatePermutations(List<string> incoming) //Permutációk létrehozása, a többi az alfüggvénye
        {
            float totalDistance = 0.0f;
            Tuple<string, List<float>> stationPair;
            List<Tuple<string, List<float>>> currentStations = new List<Tuple<string, List<float>>>();
            float shortestPath = float.MaxValue; //lehetséges legnagyobb távolság
            List<Tuple<string, List<float>>> shortestPathList = new List<Tuple<string, List<float>>>();

            List<List<string>> permutations = GeneratePermutations(incoming);


            foreach (var permutation in permutations)
            {
                currentStations.Clear();
                totalDistance = 0.0f;
                //lista elemek távolságainak és az össztávolság kinyerése
                for (int i = 0; i < permutation.Count - 1; i++)
                {
                    var ucsResult = ucsEngine.UCSMakeWay(permutation[i], permutation[i + 1]);                   
                    totalDistance += (float)ucsResult.Weight;
                    stationPair = Tuple.Create(permutation[i + 1], new List<float> { (float)ucsResult.Weight, totalDistance }); //a pair első eleme a célállomás neve string, a második eleme egy List<float> aminek a 0. eleme a célállomás súlya, és az első eleme az addig megtett össztávolság 
                    
                    currentStations.Add(stationPair);
                }
                
                if(totalDistance < shortestPath)
                {
                    shortestPath = totalDistance;
                    shortestPathList.Clear();
                    shortestPathList = currentStations;
                }
                
            }
           
            
            return shortestPathList;
        }
        

        static List<List<string>> GeneratePermutations(List<string> inputList)
        {
            List<List<string>> permutations = new List<List<string>>();

            // Rekurzív permutáció generálás
            GeneratePermutationsRecursive(inputList, 1, permutations);

            return permutations;
        }

        static void GeneratePermutationsRecursive(List<string> inputList, int startIndex, List<List<string>> permutations)
        {
            if (startIndex == inputList.Count - 1)//a kettőnél több elem ellenőrzése ha kevesebb visszatér
            {
                permutations.Add(new List<string>(inputList));
                return;
            }

            for (int i = startIndex; i < inputList.Count; i++) //minden elemitertációban a következő elemet cseréli és így létrehoz egy újabbpermutációs lehetőséget, egészen addig míg a lista utolsó eleméig nem ér.
            {                                                                          
                // Elemek cseréje
                Swap(inputList, startIndex, i);

                // Rekurzív hívás a következő elemmel
                GeneratePermutationsRecursive(inputList, startIndex + 1, permutations);

                // Visszacserélés a későbbi iterációkhoz
                Swap(inputList, startIndex, i);
            }
            //GeneratePermutations függvény adja vissza a listát
        }

        static void Swap(List<string> list, int index1, int index2)
        {
            string temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }


        public string GetFormattedResult(Tuple<List<Node>, float> pathPlan)
        {
            StringBuilder resultBuilder = new StringBuilder();
            float totalDistance = 0.0f;
     
            // Az útvonal részleteinek összegyűjtése
            int psn = 0;
            foreach (var item in pathPlan.Item1)
            {           
                totalDistance += (float)item.Weight;
                resultBuilder.AppendLine("'"+psn+"'.,'"+item.Name + "','"+ item.Weight + " km','" + item.AlpacaNr + "','" + item.Hotel+"','" + totalDistance+"'");
                psn++;
            }

            // Össztávolság hozzáadása
            resultBuilder.AppendLine($"Össztavolsag: {totalDistance} km\n\n");
            return resultBuilder.ToString();
        }
    }
}
