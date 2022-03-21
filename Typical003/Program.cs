using System;
using System.Collections.Generic;
using System.Linq;

namespace Typical003
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            List<(int A, int B)> ab = Enumerable.Repeat(0, n - 1)
                .Select(_ => Console.ReadLine().Split().Select(int.Parse).ToList())
                .Select(x => (x[0], x[1]))
                .ToList();

            var graph = Enumerable.Range(0, n + 1)
                .Select(_ => new List<int>())
                .ToArray();

            foreach (var item in ab)
            {
                graph[item.A].Add(item.B);
                graph[item.B].Add(item.A);
            }


            var dist = getDist(1);

            var max = dist.Where(x => x != int.MaxValue)
                .Max();
            var maxIndex = dist.ToList().FindIndex(x => x == max);

            var dist1 = getDist(maxIndex);

            var max1 = dist1
                .Where(x => x != int.MaxValue)
                .Max();
            Console.WriteLine(max1 + 1);


            int[] getDist(int start)
            {
                var dist = new int[n + 1];
                for (int i = 1; i < n + 1; i++)
                {
                    dist[i] = int.MaxValue;
                }

                // 幅優先探索(BFS)する。
                var queue = new Queue<int>();
                queue.Enqueue(start);

                dist[start] = 0;

                while (queue.Count > 0)
                {
                    int val = queue.Dequeue();

                    foreach (var to in graph[val])
                    {
                        // int.maxvalue の場合、未探索
                        if (dist[to] == int.MaxValue)
                        {
                            dist[to] = dist[val] + 1;
                            queue.Enqueue(to);
                        }
                    }
                }

                return dist;
            }
        }
    }
}