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

        public Algorithm(List<Node> nodes, Edges edges)
        {
            collection = new Collection();
            for (int i = 1; i < nodes.Count; i++)
            {
                collection.SetValue(new[] {i}, i, edges.GetDistanse(i, 0));
            }

            for (int s = 2; s < nodes.Count; s++)
            {
                List<int[]> allSubset = GetCollection(nodes.Count, s);
                //S=2
                for (int i = 0; i < allSubset.Count; i++)
                {
                    for (int k = 0; k < allSubset[i].Length; k++) //j
                    {
                        int indexJ = allSubset[i][k];
                        if (indexJ != 0)
                        {
                            List<double> min = new List<double>();
                            for (int l = 0; l < allSubset[i].Length; l++) //i
                            {
                                int indexI = allSubset[i][l];
                                if (indexI != indexJ)
                                {
                                    var firstValue =
                                        collection.GetValue(SMinusJ(allSubset[i].ToList(), indexJ), indexI);
                                    var secondValue = edges.GetDistanse(indexJ, indexI);
                                    min.Add(firstValue + secondValue);
                                }
                            }

                            collection.SetValue(allSubset[i], indexJ, min.Min());
                        }
                    }
                }
            }

            List<double> min2 = new List<double>();
            var mainVar = GetCollection(nodes.Count, nodes.Count);
            int indexJ1 = 0;

            for (int l = 0; l < mainVar[0].Length; l++) //i
            {
                int indexI = mainVar[0][l];
                if (indexI != indexJ1)
                {
                    var firstValue = collection.GetValue(SMinusJ(mainVar[0].ToList(), indexJ1), indexI);
                    var secondValue = edges.GetDistanse(indexJ1, indexI);
                    min2.Add(firstValue + secondValue);
                }
            }

            Result = min2.Min();
        }

        public List<int> SMinusJ(List<int> s, int j)
        {
            List<int> res = new List<int>(s);
            res.Remove(j);
            return res;
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
                combine[0] = 0;
                for (int j = 1; j < res[i].Length + 1; j++)
                {
                    combine[j] = res[i][j - 1];
                }

                resAll.Add(combine);
            }

            if (size == n)
            {
                int[] arr1 = new int[n];
                for (int i = 0; i < n; i++)
                {
                    arr1[i] = i;
                }

                return new List<int[]>() {arr1};
            }

            return res;
        }
    }

    class Collection
    {
        public List<C> collection { get; set; }

        public Collection()
        {
            collection = new List<C>();
        }

        public void SetValue(int[] set, int j,double value)
        {
            if (set == null)
            {
                collection.Add(new C()
                {
                    NodeIndex = j,
                    Set = null,
                    Value = value
                });
                return;
            }
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
                if (set2.FindIndex(x =>x==i) ==-1)
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
