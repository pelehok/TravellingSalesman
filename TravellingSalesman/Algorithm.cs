using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    class Algorithm
    {
        public double Result { get; set; }

        private Collection collection { get; set; }
        public Algorithm(List<Node> nodes,Edges edges)
        {
            collection = new Collection();
            collection.SetValue(new []{1},0,0);
            for (int s = 2; s < nodes.Count; s++)
            {
                List<int[]> allSubset = GetCollection(nodes.Count, s);
                foreach (var S in allSubset)
                {
                        collection.SetValue(S,1,Double.MaxValue);
                }


            }
        }

        private List<int[]> GetCollection(int n,int size)
        {
            int[] arr = new int[n - 1];
            for (int i = 1; i < n; i++)
            {
                arr[i - 1] = i;
            }

            GenerateCombine gen = new GenerateCombine(arr,arr.Length,size);
            List<int[]> res =gen.allcombine;
            List<int[]> resAll = new List<int[]>();
            for (int i = 0; i < res.Count; i++)
            {
                int[] combine = new int[res[i].Length+1];
                combine[0] = 1;
                for (int j = 1; j < res[i].Length + 1; j++)
                {
                    combine[j] = res[i][j - 1];
                }

                resAll.Add(combine);
            }

            return resAll;
        }
    }

    class Collection
    {
        public List<C> collection { get; set; }

        public void SetValue(int[] set, int j,double value)
        {
            collection.Add(new C()
            {
                NodeIndex = j,
                Set = set.ToList(),
                Value = value
            });
        }
        public double GetValue(List<int> set, int j)
        {
            var collectionJ = collection.FindAll(x => x.NodeIndex == j);
            double result = 0;
            for (int i = 0; i < collectionJ.Count; i++)
            {
                if (EqualCollection(collectionJ[i].Set, set))
                {
                    result = collectionJ[i].Value;
                    break;
                }
            }

            return result;
        }

        public bool EqualCollection(List<int> set1, List<int> set2)
        {
            if (set1.Count != set2.Count) return false;

            foreach (var i in set1)
            {
                if (set2.FirstOrDefault(x => x == i) == null)
                {
                    return false;
                }
            }

            return true;
        }
    }

    class C
    {
        public List<int> Set { get; set; }
        public int NodeIndex { get; set; }
        public double Value { get; set; }
    }
}
