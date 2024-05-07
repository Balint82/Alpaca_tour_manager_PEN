using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Alapaca_tour_Winform_dotNet.Models
{
    public class Matrix
    {
        private float[][] adjacencyMatrix;
        private int n;

        public Matrix(Graph incomingNodes)
        {
            n = incomingNodes.AddNodeForNodeCounterAndCalc();
            adjacencyMatrix = new float[n][];

            for (int i = 0; i < n; i++)
            {
                adjacencyMatrix[i] = new float[n];
                for (int j = 0; j < n; j++)
                {
                    adjacencyMatrix[i][j] = 0;
                }
            }
        }

        public void MakeMatrix(Graph incomingNodes)
        {
            int i, j;
            i = j = 0;
 
            HashSet<Node> counterList = incomingNodes.GetNodeCounter(); //településhalmaz
            List<string> matrixClassNodeCounter = counterList.Select(node => node.Name).ToList(); 
            Dictionary<Node, HashSet<Node>> matrixClassNodeMap;

            matrixClassNodeMap = incomingNodes.GetAllNodeMap();

            foreach (string setItem in matrixClassNodeCounter)
            {
                foreach (KeyValuePair<Node, HashSet<Node>> pair in matrixClassNodeMap)
                {
                    
                    if (setItem == pair.Key.Name)
                    {
              
                        foreach (Node mapValue in pair.Value)
                        {
                            foreach (string item in matrixClassNodeCounter){
                                if (item == mapValue.Name)
                                {     
                                    j = matrixClassNodeCounter.IndexOf(mapValue.Name);
                                    adjacencyMatrix[i][j] = mapValue.Weight;                     
                                }
                            }
                        }
                    }
                }
                i++;
            }
        }

        
        public float[][] GetAdjMatrix()
        {
            return adjacencyMatrix;
        }

        public void DozerMatrix()
        {
            for (int k = 0; k < n; k++)
            {
                Array.Clear(adjacencyMatrix[k], 0, n);
            }
            adjacencyMatrix = null;
        }

        public float[] this[int row]
        {
            get { return adjacencyMatrix[row]; }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result += $"{adjacencyMatrix[i][j]:F2}\t";
                }
                result += Environment.NewLine;
            }
            return result;
        }
    }
}
