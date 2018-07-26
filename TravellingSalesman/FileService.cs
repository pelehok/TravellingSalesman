using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    class FileService
    {
        private static string FileName = "Cities.txt";

        public static List<Node> ReadFile()
        {
            string[] lines = System.IO.File.ReadAllLines(FileName);

            List<Node> nodes = new List<Node>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] node = lines[i].Split(' ');

                nodes.Add(new Node()
                {
                    X = Convert.ToDouble(node[0]),
                    Y = Convert.ToDouble(node[1])
                });
            }
            
            return nodes;
        }

        public static Edges ReadDectination()
        {
            return null;
        }
    }
}
