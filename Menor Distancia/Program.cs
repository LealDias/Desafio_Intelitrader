using System;

public class Program
{
    public static void Main()
    {
        int[] array1 = { -1, 5, 8, 15, 21, 34, 55, 89, 144, 233 };
        int[] array2 = { 26, 3, 45, 78, 101, 121, 154, 180, 200, 222 };
        
        // Ordenar ambos os arrays
        MergeSort(array1, 0, array1.Length - 1);
        MergeSort(array2, 0, array2.Length - 1);

        int minDistance = FindMinimumDistance(array1, array2);
        Console.WriteLine("A menor distância é: " + minDistance);
    }

    public static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MergeSort(array, left, middle);
            MergeSort(array, middle + 1, right);
            Merge(array, left, middle, right);
        }
    }

    public static void Merge(int[] array, int left, int middle, int right)
    {
        int leftSize = middle - left + 1;
        int rightSize = right - middle;

        int[] leftArray = new int[leftSize];
        int[] rightArray = new int[rightSize];

        Array.Copy(array, left, leftArray, 0, leftSize);
        Array.Copy(array, middle + 1, rightArray, 0, rightSize);

        int i = 0, j = 0, k = left;
        while (i < leftSize && j < rightSize)
        {
            if (leftArray[i] <= rightArray[j])
            {
                array[k++] = leftArray[i++];
            }
            else
            {
                array[k++] = rightArray[j++];
            }
        }

        while (i < leftSize)
        {
            array[k++] = leftArray[i++];
        }

        while (j < rightSize)
        {
            array[k++] = rightArray[j++];
        }
    }

    public static int FindMinimumDistance(int[] array1, int[] array2)
    {
        int i = 0, j = 0;
        int minDistance = int.MaxValue;

        while (i < array1.Length && j < array2.Length)
        {
            int distance = Math.Abs(array1[i] - array2[j]);
            minDistance = Math.Min(minDistance, distance);

            if (array1[i] < array2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return minDistance;
    }
}