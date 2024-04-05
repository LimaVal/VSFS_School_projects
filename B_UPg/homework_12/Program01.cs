namespace priklad01;
class Program
{
    static void WrLn(int[,] square, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write($"{square[i, j]}\t");
            Console.WriteLine();
        }
    }

    // is uniq in square
    static bool IsUniq(int[,] square, int num, int n, int row, int col)
    {
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                if (square[i, j] == num) return false;
        return true;
    }

    // checko collumn sum
    static bool ColCheck(int[,] square, int n, int col)
    {
        int sum = 0;
        for (int i = 0; i < n; i++)
            sum += square[i, col];

        if (sum > n * (n * n + 1) / 2)
            return false;
        return true;
    }

    // check in two diagonals
    static bool DiagonalCheck(int[,] square, int n)
    {
        int sum1 = 0;
        int sum2 = 0;
        for (int i = 0; i < n; i++)
        {
            sum1 += square[i, i];
            sum2 += square[n - 1 - i, i];
        }
        return sum1 == n * (n * n + 1) / 2 && sum2 == n * (n * n + 1) / 2;
    }


    static bool GenerateSquare(int[,] square, int n, int row, int col, int sum)
    {
        int magicSum = n * (n * n + 1) / 2;

        if (row == n)
            return true;

        if (col == 0) sum = 0;

        for (int num = 1; num <= n * n; num++)
        {
            if (IsUniq(square, num, n, row, col))
            {
                square[row, col] = num;
                // row sum check
                if (!ColCheck(square, n, col))
                    continue;
                if (col == n - 1 && row == n - 1 && !DiagonalCheck(square, n))
                {
                    square[row, col] = 0;
                    return false;
                }
                if ((sum + num < magicSum && col != n - 1) || (col == n - 1 && sum + num == magicSum))
                {


                    col++;
                    if (col == n)
                    {
                        col = 0;
                        row++;
                    }

                    if (GenerateSquare(square, n, row, col, sum + num))
                        return true;
                    else
                    {
                        if (col == 0)
                        {
                            row--;
                            col = n - 1;
                        }
                        else
                            col--;
                    }
                }
            }
        }
        square[row, col] = 0;
        return false;
    }

    static void MagicSquare(string fileName, int n)
    {
        StreamWriter sw = new StreamWriter(fileName);
        int[,] square = new int[n, n];
        int row = 0;
        int col = 0;
        int sum = 0;

        if (GenerateSquare(square, n, row, col, sum))
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    sw.Write($"{square[i, j]} ");
                sw.WriteLine();
            }
            sw.Close();
        }
        else
            Console.WriteLine("Not solved");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Magic square:");
        MagicSquare("MagickyCtverec.txt", 4);

    }
}