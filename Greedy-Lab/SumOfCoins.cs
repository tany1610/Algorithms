using System.Data;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {

        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

                Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
                foreach (var selectedCoin in selectedCoins)
                {
                    Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
                }         
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            Dictionary<int,int> result = new Dictionary<int, int>();
            List<int> sortedCoins = coins.ToList().OrderByDescending(a => a).ToList();
            int totalSum = 0;
            int i = 0;

            while (totalSum < targetSum && i < coins.Count)
            {
                int coinsCount = (targetSum - totalSum) / sortedCoins[i];

                if (coinsCount == 0)
                {
                    i++;
                    continue;
                }

                if (totalSum + coinsCount * sortedCoins[i] <= targetSum)
                {
                    totalSum += coinsCount * sortedCoins[i];

                    if (!result.ContainsKey(sortedCoins[i]))
                    {
                        result.Add(sortedCoins[i],0);
                    }

                    result[sortedCoins[i]] += coinsCount;
                }

                else
                {
                    i++;
                }
            }

            if (totalSum < targetSum)
            {
                throw new InvalidOperationException();
            }

            return result;
        }
    }