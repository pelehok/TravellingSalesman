using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    class Edges
    {
        private double[,] distanses { get; set; }
        public Edges(List<Node> nodes)
        {
            distanses = new double[nodes.Count,nodes.Count];

            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < nodes.Count; j++)
                {
                    distanses[i, j] = GetDistanse(nodes[i],nodes[j]);
                }
            }
        }

        public double GetDistanse(int i, int j)
        {
            return distanses[i, j];
        }

        private double GetDistanse(Node node1, Node node2)
        {
            double firstValue = Math.Pow(node1.X - node2.X, 2);
            double secondValue = Math.Pow(node1.Y - node2.Y, 2);

            return Math.Sqrt(firstValue + secondValue);
        }
    }
}
