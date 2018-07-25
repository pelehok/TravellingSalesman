using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman
{
    class GenerateCombine
    {
        public List<int[]> allcombine { get; set; }

        public GenerateCombine(int[] arr, int n, int r)
        {
            allcombine = new List<int[]>();

            int[] data = new int[r];
            CombineUtil(arr, n, r,0, data, 0);
        }
        private void CombineUtil(int[] arr, int n, int r, int index, int[] data, int i)
        {
            if (index == r)
            {
                allcombine.Add(data.ToArray());
                return;
            }

            if (i >= n)
                return;

            data[index] = arr[i];
            CombineUtil(arr, n, r, index + 1,
                data, i + 1);

            CombineUtil(arr, n, r, index,
                data, i + 1);
        }
    }
}
