using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Node> nodes = new List<Node>()
            {
                new Node(),
                new Node(),
                new Node(),
                new Node()
            }; 
            nodes = FileService.ReadFile();

            Edges edges = new Edges(nodes);
            Algorithm alg = new Algorithm(nodes,edges);

            Console.WriteLine(alg.Result);
            Console.ReadKey();
        }
    }
}
