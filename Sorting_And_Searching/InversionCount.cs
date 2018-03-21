using System;
using System.Linq;

internal class Program
{
    private static void Main()
    {
        var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int countInversion = MergeSort(arr, 0, arr.Length - 1);
        Console.WriteLine(countInversion);
    }

    public static int MergeSort(int[] a, int p, int r)
    {
        int countInversion = 0;
        if (p < r)
        {
            int q = (p + r) / 2;
            countInversion = MergeSort(a, p, q);
            countInversion += MergeSort(a, q + 1, r);
            countInversion += Merge(a, p, q, r);
        }
        return countInversion;
    }

    public static int Merge(int[] a, int p, int q, int r)
    {
        int countingInversion = 0;
        int n1 = q - p + 1;
        int n2 = r - q;
        int[] temp1 = new int[n1 + 1];
        int[] temp2 = new int[n2 + 1];
        for (int index0 = 0; index0 < n1; index0++) temp1[index0] = a[p + index0];
        for (int index0 = 0; index0 < n2; index0++) temp2[index0] = a[q + 1 + index0];

        temp1[n1] = Int32.MaxValue;
        temp2[n2] = Int32.MaxValue;
        int i = 0, j = 0;

        for (int k = p; k <= r; k++)
        {
            if (temp1[i] <= temp2[j])
            {
                a[k] = temp1[i];
                i++;
            }
            else
            {
                a[k] = temp2[j];
                j++;
                countingInversion = countingInversion + (n1 - i);
            }
        }
        return countingInversion;
    }
}