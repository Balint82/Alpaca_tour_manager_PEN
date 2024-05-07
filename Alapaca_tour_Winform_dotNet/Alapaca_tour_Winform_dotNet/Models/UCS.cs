using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alapaca_tour_Winform_dotNet.Models
{
    class UCS
    {
        public readonly Graph graph;
        public readonly Matrix wayMatrix;

        public UCS(Graph wayGraph, Matrix wayMatrix)
        {
            this.graph = wayGraph;
            this.wayMatrix = wayMatrix;
        }

        public void Dispose()
        {
            wayMatrix.DozerMatrix();
        }

        public Node UCSMakeWay(string incomingStarStr, string incomingDestStr)
        {
            Node inputStartNode = new Node();
            Node inputDestNode = new Node();
            Node destNode = new Node();
            Node min = new Node();
            int row = 0, col;
            List<Node> allNodeList = new List<Node>();
            List<Node> visited = new List<Node> ();
            List<Node> momentNodeList = new List<Node>();
            float[][] mapMatrix = wayMatrix.GetAdjMatrix();
            int mapMatrixSize = graph.AddNodeForNodeCounterAndCalc();
            float itemWeight;
            HashSet<Node> nodeSet = graph.GetNodeCounter();
            Node UCSresult = new Node();

            inputStartNode.Name = incomingStarStr;
            inputStartNode.Weight = 0.00f;

            inputDestNode.Name = incomingDestStr;

            try
            {
                int counter = 0;
                while (true)
                {
                    // sor keresés megadott kiinduló város alapján, a halmazban elfoglalt helye a sorindex
                    int index = 0;
                    foreach (var node in nodeSet)
                    {
                        if (node.Name.Equals(inputStartNode.Name))
                        {
                            row = index;
                            break;
                        }
                        index++;
                    }
                    
                    // oszlop választások és tárolások
                    for (col = 0; col < mapMatrixSize; col++) // iterálás adott sor oszlopszámán
                    {
                        itemWeight = mapMatrix[row][col]; // az érték ideiglenes tárolása

                        if (itemWeight > 0.00f) // ha nagyobb mint 0, akkor a kiindulóvároscsúcs súlyát, azaz távolsága legyen a kiinduló érték, ha a kiinduló város 0, ha többedik állomást számol akkor 0-nál nagyobb lesz.
                        {
                            var itColShowDestNode = nodeSet.ElementAt(col); // megadja a halmazban az adott állomásváros indexét a halmazban
                            destNode = itColShowDestNode; // célcsúcs elmentése
                            
                            if (!visited.Contains(destNode)) //ha bekerült a visited listába akkor ne vegye be mégegyszer-> ezzel elkerülendő hogy oda-vissza pattogjon a mátrixban két településközött
                            {
                                itemWeight = inputStartNode.Weight + mapMatrix[row][col];
                                destNode.Weight = itemWeight; // célcsúcs összsúlyának megadása
                           
                                momentNodeList.Add(destNode);
                            }

                            visited.Add(destNode);
                        }
                    }
    

                    // minimum súly keresés a legrövidebb össztávolsághoztávolsághoz
                    min = momentNodeList.First();
                    foreach (var item in momentNodeList)
                    {                   
                        if (item.Weight < min.Weight)
                        {
                            min = item;
                        }
                    }
                    
                    // ha a célváros megegyezik a minimum értékkel azaz az útvonal tervező abba fázisba ért, hogy az van a legközelebb, akkor tárolja az eredményt és álljon le
                    if (inputDestNode.Name == min.Name)
                    {
                        UCSresult.Name = min.Name;
                        UCSresult.Weight = min.Weight;
                        break;
                    }
                    else // különben állítsa be kezdővárosba, azaz legyen egy állomás és távolítsa el az ideiglenes Csúcslistából.
                    {
                        inputStartNode = min;
                        momentNodeList.Remove(min);
                    }
                    counter++;
                }
            }
            catch (Exception e)
            {
                // Hibakezelés (pl. nincs érvényes útvonal)
                UCSresult.Name = "HIBA";
                UCSresult.Weight = -1.0f; // vagy más érték
                Console.WriteLine("Hiba történt: " + e.Message);
            }

            return UCSresult;
        }
    }

}
