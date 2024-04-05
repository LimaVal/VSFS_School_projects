namespace priklad04;
class Program
{
    // Helper Function Representing a Stack of Coins on a Scale
    static long MathSum(int[] array, int first, int last)
    {
        long sum = 0;
        for (int i = first; i < last + 1; i++)
            sum += array[i];
        return sum;
    }

    static int FindCoin(int[] coins, int firstIndex, int lastIndex)
    {
        int middleIndex = (firstIndex + lastIndex) / 2;
        long leftSum;
        long rightSum;

        // Even Number -> Sum of Indices is Odd.
        if((firstIndex + lastIndex) % 2 == 1)
            leftSum = MathSum(coins, firstIndex, middleIndex);
        // Odd Number -> Sum of Indices is Even. One Coin (represented by middleIndex) remains on the table.
        else
            leftSum = MathSum(coins, firstIndex, middleIndex - 1);

        rightSum = MathSum(coins, middleIndex + 1, lastIndex);

        if(leftSum != rightSum)
        {
            if(leftSum < rightSum)
                middleIndex = FindCoin(coins, firstIndex, middleIndex - 1);
            else
                middleIndex = FindCoin(coins, middleIndex + 1, lastIndex);
        }
        return middleIndex;

    }

    static int FalesnaMince(int[] coins)
    {
        return FindCoin(coins, 0, coins.Length - 1);
    }

    static void Main(string[] args)
    {
        int[] p = new int[1000];
        int i;
        for (i = 0; i < p.Length; i++)
            p[i] = 5;
        p[371] = 4;
        i = FalesnaMince(p); // 371 
        Console.WriteLine(i);

        for (i = 0; i < p.Length; i++)
            p[i] = 5;
        p[682] = 4;
        i = FalesnaMince(p); // 371
        Console.WriteLine(i);

    }
}