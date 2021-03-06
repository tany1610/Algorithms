﻿namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetCover
    {
        public static void Main(string[] args)
        {
            var universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            var sets = new[]
            {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

            var selectedSets = ChooseSets(sets.ToList(), universe.ToList());
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> setsCollection = sets.ToList();
            List<int> universeList = universe.ToList();
            List<int[]> result = new List<int[]>();

            while (universeList.Count > 0)
            {
                int currentBest = 0;
                int bestIndex = 0;

                for (int i = 0; i < setsCollection.Count; i++)
                {
                    int sumOfEqual = 0;
                    int[] current = setsCollection[i];

                    for (int j = 0; j < current.Length; j++)
                    {
                        if (universeList.Contains(current[j]))
                        {
                            sumOfEqual++;
                        }
                    }

                    if (sumOfEqual > currentBest)
                    {
                        currentBest = sumOfEqual;
                        bestIndex = i;
                    }
                }

                int[] found = setsCollection[bestIndex];
                result.Add(found);

                for (int i = universeList.Count - 1; i >= 0; i--)
                {
                    if (found.Contains(universeList[i]))
                    {
                        universeList.RemoveAt(i);
                    }
                }
            }

            return result;
        }
    }
}
