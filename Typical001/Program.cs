using System;
using System.Linq;

namespace Typical001
{
    /**
     * [001 - Yokan Party（★4）](https://atcoder.jp/contests/typical90/tasks/typical90_a)
     */
    class Program
    {
        static void Main(string[] args)
        {
            var nl = Console.ReadLine().Split().Select(int.Parse).ToList();
            var n = nl[0];
            var l = nl[1];
            var k = int.Parse(Console.ReadLine());

            var a = Console.ReadLine().Split().Select(int.Parse).ToList();


            bool Solver(int length)
            {
                long cnt = 0;
                long pre = 0;

                for (int i = 0; i < n; i++)
                {
                    if (a[i] - pre >= length && l - a[i] >= length)
                    {
                        cnt++;
                        pre = a[i];
                    }
                }

                return cnt >= k;
            }

            // めぐる式二部探索
            int ok = 1;
            int ng = l + 1;

            while (Math.Abs(ok - ng) > 1)
            {
                int mid = (ok + ng) / 2;

                if (Solver(mid))
                {
                    ok = mid;
                }
                else
                {
                    ng = mid;
                }
            }

            Console.WriteLine(ok);
        }
    }
}