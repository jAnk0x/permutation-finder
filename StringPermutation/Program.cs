using System;
using System.Collections.Generic;
using System.Linq;

namespace StringPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter something to permutate: ");
            string s = Console.ReadLine();
            
            PrintPermutations(Permutate(s));
        }

        private static List<char[]> Permutate(string s)
        {
            var final = new List<char[]>();

            var numOfEachChar = new Dictionary<char, int>();
            foreach(char c in s)
            {
                if (numOfEachChar.ContainsKey(c))
                    numOfEachChar[c] += 1;
                else
                    numOfEachChar.Add(c, 1);
            }

            var str = new char[numOfEachChar.Count];
            var num = new int[numOfEachChar.Count];
            for(int i = 0; i < numOfEachChar.Count; i++)
            {
                str[i] = numOfEachChar.ElementAt(i).Key;
                num[i] = numOfEachChar.ElementAt(i).Value;
            }

            PermutateUtil(num, str, new char[s.Length], 0, final);
            return final;
        }

        private static void PermutateUtil(int[] num, char[] str, char[] result, int depth, List<char[]> final)
        {
            if (depth == result.Length)
            {
                final.Add(result);
                return;
            }

            for(int i = 0; i < str.Length; i++)
            {
                if (num[i] == 0)
                    continue;

                result[depth] = str[i];
                num[i] -= 1;
                var numN = new int[num.Length];
                Array.Copy(num, numN, num.Length);
                var strN = new char[str.Length];
                Array.Copy(str, strN, str.Length);
                var resultN = new char[result.Length];
                Array.Copy(result, resultN, result.Length);

                PermutateUtil(numN, strN, resultN, depth + 1, final);
                num[i] += 1;
            }
        }

        private static void PrintPermutations(List<char[]> permutations)
        {
            foreach(char[] permutation in permutations)
            {
                foreach (char c in permutation)
                    Console.Write(c);
                Console.WriteLine();
            }
        }
    }
}
