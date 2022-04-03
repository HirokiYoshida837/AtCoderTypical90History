using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Typical004
{
    class Program
    {
        static void Main(string[] args)
        {
            var hw = Console.ReadLine().Split().Select(int.Parse).ToList();
            var (h, w) = (hw[0], hw[1]);

            var a = Enumerable.Range(0, h)
                .Select(_ => Console.ReadLine().Split().Select(int.Parse).ToArray())
                .ToArray();


            var xSum = a.Select(x => x.Sum()).ToList();
            var ySum = new List<int>();

            for (int i = 0; i < w; i++)
            {
                var tmp = 0;
                for (int j = 0; j < h; j++)
                {
                    tmp += a[j][i];
                }

                ySum.Add(tmp);
            }

            for (int y = 0; y < h; y++)
            {
                var outputS = new StringBuilder();
                for (int x = 0; x < w; x++)
                {
                    var xVal = xSum[y];
                    var yVal = ySum[x];

                    var val = a[y][x];

                    var wv = xVal + yVal - val;

                    outputS.Append(wv).Append(" ");
                }

                Console.WriteLine(outputS.ToString());
            }
        }
    }
}