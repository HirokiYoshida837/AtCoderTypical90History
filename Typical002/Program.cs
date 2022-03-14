using System;
using System.Collections.Generic;
using System.Linq;

namespace Typical002
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int bit = 0; bit < (1 << n); bit++)
            {
                // Console.Write(bit + "\t");
                // Console.WriteLine(Convert.ToString(bit, 2).PadLeft(n, '0'));

                var bitS = Convert.ToString(bit, 2).PadLeft(n, '0')
                    .ToList()
                    .Select(x => x == '0' ? '(' : ')')
                    .ToList();

                var sum = new List<int>();
                sum.Add(0);

                var flg = true;

                for (var i1 = 0; i1 < bitS.Count; i1++)
                {
                    if (bitS[i1] == '(')
                    {
                        sum.Add(sum[sum.Count - 1] + 1);
                    }
                    else
                    {
                        sum.Add(sum[sum.Count - 1] - 1);

                        if (sum[sum.Count -1] < 0)
                        {
                            flg = false;
                        }
                    }
                }

                if (sum[sum.Count - 1] == 0 && flg)
                {
                    Console.WriteLine(new string(bitS.ToArray()));
                }
            }
        }
    }
}