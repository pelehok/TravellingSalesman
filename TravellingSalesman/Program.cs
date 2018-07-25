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
            List<Node> nodes = FileService.ReadFile();

            Edges edges = new Edges(nodes);


        }
    }
}
