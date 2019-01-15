using System;
using System.Linq;
 
public class Program
{
    public static void Main()
    {
        string[] size = Console.ReadLine().Split();
        int r = int.Parse(size[0]);
        int c = int.Parse(size[1]);
 
        int[][] parking = new int[r][];
 
        string input;
        while ((input = Console.ReadLine()) != "stop")
        {
            int carRow = int.Parse(input.Split()[0]);
            int parkRow = int.Parse(input.Split()[1]);
            int parkCol = int.Parse(input.Split()[2]);
 
            if (parking[parkRow] == null)
            {
                parking[parkRow] = new int[c];
            }
 
            if (parking[parkRow].Skip(1).All(x => x == 1))
            {
                Console.WriteLine($"Row {parkRow} full");
                continue;
            }
 
            if (parking[parkRow][parkCol] == 1)
            {
                parkCol = GetNearestFreeCol(parking, parkRow, parkCol);
            }
 
            parking[parkRow][parkCol] = 1;
 
            int distance = Math.Abs(carRow - parkRow) + parkCol + 1;
            Console.WriteLine(distance);
        }
    }
 
    private static int GetNearestFreeCol(int[][] parking, int parkRow, int parkCol)
    {
        for (int i = 1; i < parking[parkRow].Length; i++)
        {
            if (parkCol > i && parking[parkRow][parkCol - i] != 1)
                return parkCol - i;
            if (parkCol + i < parking[parkRow].Length && parking[parkRow][parkCol + i] != 1)
                return parkCol + i;
        }
        return -1; // It's just needed. Will never be returned
    }
}