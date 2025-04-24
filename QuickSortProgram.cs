using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("숫자를 입력하세요. (빈 줄 입력 시 입력 종료): ");

        while (true)
        {
            string input = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            if(int.TryParse(input, out int num))
            {
                numbers.Add(num);
            }
            else
            {
                Console.WriteLine("유요한 입력이 아닙니다.");
            }
        }

        QuickSort(numbers, 0, numbers.Count - 1);

        Console.WriteLine("정렬 결과: ");
        foreach(int num in numbers)
        {
            Console.Write(num + " ");
        }
    }

    static void QuickSort(List<int> arr, int low, int high)
    {
        if(low < high)
        {
            int pivotIndex = Partition(arr, low, high);
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    static int Partition(List<int> arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for(int j = low; j < high; j++)
        {
            if(arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }
        Swap(arr, i+1, high);
        return i + 1;
    }

    static void Swap(List<int> arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

}