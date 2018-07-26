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
        private double[,] distansesTwo { get; set; }
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

            distansesTwo = new double[4,4]
            {
                { 0,10,15,20},
                {5,0,9,10 },
                {6,13,0,12 },
                {8,8,9,0}
            };
        }

        public double GetDistanse(int i, int j)
        {
            return distanses[i, j];
        }


        public double GetDistanceTwo(int i, int j)
        {
            return distansesTwo[i, j];
        } 

        private double GetDistanse(Node node1, Node node2)
        {
            double firstValue = Math.Pow(node1.X - node2.X, 2);
            double secondValue = Math.Pow(node1.Y - node2.Y, 2);

            return Math.Sqrt(firstValue + secondValue);
        }
    }
}
