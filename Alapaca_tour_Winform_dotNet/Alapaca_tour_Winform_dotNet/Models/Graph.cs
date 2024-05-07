using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Alapaca_tour_Winform_dotNet.Models
{
     public class Graph
    {
        private Dictionary<Node, HashSet<Node>> allNodeMap = new Dictionary<Node, HashSet<Node>>();
        private HashSet<Node> nodeCounter = new HashSet<Node>();

        public Dictionary<Node, HashSet<Node>> GetAllNodeMap()
        {
            return allNodeMap;
        }

        public HashSet<Node> GetNodeCounter()
        {
            return nodeCounter;
        }

        public void AddNode(string sourceCity, string targetCity, float distance, int alpacaNr, string incomingHotel)
        {
            Node newCityNode = new Node { Name = targetCity, Weight = (float)distance, AlpacaNr = alpacaNr, Hotel = incomingHotel };

            // Ellenőrizzük, hogy az adott kiinduló város már szerepel-e a Dictionary-ben
            if (allNodeMap.Keys.Any(node => node.Name == sourceCity))
            {
                // Ha már szerepel, akkor csak adjuk hozzá az értékekhez az új várost
                allNodeMap.First(pair => pair.Key.Name == sourceCity).Value.Add(newCityNode);
            }
            else
            {
                // Ha még nem szerepel, akkor hozzáadjuk új kulcsként az adott kiinduló várost
                HashSet<Node> cityNodes = new HashSet<Node>();
                cityNodes.Add(newCityNode);
                allNodeMap.Add(new Node { Name = sourceCity, Weight = 0.00f }, cityNodes);
            }
        }

        public int AddNodeForNodeCounterAndCalc()
        {
            foreach (var pair in allNodeMap)
            {
                nodeCounter.Add(pair.Key);
            }
            return nodeCounter.Count;
        }

        public override string ToString()
        {
            string result = "";
            foreach (var pair in allNodeMap)
            {
                result += pair.Key.Name + " -> ";
                foreach (var node in pair.Value)
                {
                    result += "\t  " + node.Name + "\t" + node.Weight + " km";
                }
                result += Environment.NewLine;
            }
            return result;
        }
    }


 

    public class Node
    {
        public string Name { get; set; }
        public float Weight { get; set; }
        public int AlpacaNr { get; set; }
        public string Hotel { get; set; }
    }
}