namespace priklad01;
class Program
{
    // helpers funct
    static bool MatrixIsSquare(long[,] matrix)
    {
        if (matrix.GetLength(0) == matrix.GetLength(1)) return true;
        else return false;
    }

    static void ConsoleWriteMatrix(long[,] matrix)
    {
        Console.Write("{ ");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write("{ ");
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write($"{matrix[i,j]} ");
            Console.Write("}");
        }
        Console.Write(" }\n");
    }

    // DU
    static long[,] CreateRandomMatrix(int row, int column)
    {
        long[,] matrix = new long[row, column];
        Random ran = new Random();

        for (int i = 0; i < row; i++)
            for (int j = 0; j < column; j++)
                matrix[i,j] = ran.Next(-4, 5);

        return matrix; 
    }

    static void SaveToMem(long[,] matrix, string fileName)
    {
        StreamWriter sw = new StreamWriter(fileName);
        sw.WriteLine($"{matrix.GetLength(0)} {matrix.GetLength(1)}");

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                sw.Write($"{matrix[i,j]} ");
            sw.WriteLine();
        }
        sw.Close();
    }

    static long[,] ReadFromMem(string fileName)
    {
        StreamReader sr = new StreamReader(fileName);

        // first line with matrix size
        string? s = sr.ReadLine();

        // Define matrix
        string[] sizeMatrix = new string[2];
        if(s != null) sizeMatrix = s.Split(" ");
        int row = Convert.ToInt32(sizeMatrix[0]);
        int col = Convert.ToInt32(sizeMatrix[1]);

        string[] tmpRow = new string[col];

        long[,] matrix = new long[row, col];

        int j = 0;
        while((s = sr.ReadLine()) != null && j < row)
        {
            // Pars
            tmpRow = s.Split(" ");
            // 
            for (int i = 0; i < col; i++)
                matrix[j,i] =  Convert.ToInt64(tmpRow[i]);
            j++;
        }

        sr.Close();
        return matrix;
    }

    static long[,] TransposeMatrix(long[,] matrix)
    {
        long[,] transMatrix = new long[matrix.GetLength(1), matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                transMatrix[j, i] = matrix[i, j];

        return transMatrix;
    }

    static bool MatrixIsSymmetric(long[,] matrix)
    {
        if (MatrixIsSquare(matrix))
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = i + 1; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] != matrix[j, i]) return false;
            return true;
        }
        else
            return false;
    }

    static long[] DiagonalOfMatrix(long[,] matrix)
    {
        long[] vector = new long[Math.Min(matrix.GetLength(0), matrix.GetLength(1))];

        for (int i = 0; i < vector.Length; i++)
            vector[i] = matrix[i,i];

        return vector;
    }

    static bool IsUpperTriangularMatrix(long[,] matrix)
    {
        for (int i = 1; i < matrix.GetLength(0); i++)
            for (int j = 0; j < i; j++)
                if(matrix[i, j] != 0) return false;
        return true;
    }

    static int CountZeroLeft(long[,] matrix, int index)
    {
        int counter = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
            if(matrix[index, i] == 0) counter++;
            else break;
        return counter;
    }

    static bool EchelonForm(long[,] matrix)
    {
        for (int i = 1; i < matrix.GetLength(0); i++)
            if(CountZeroLeft(matrix, i) <= CountZeroLeft(matrix, i-1)) return false;
        return true;
    }

    static bool IsMatrixIdentity(long[,] matrix)
    {
        if(MatrixIsSquare(matrix))
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if ((i != j && matrix[i,j] != 0) || (i == j && matrix[i,j] != 1)) return false;
                    else continue;
        else return false;
        return true;
    }


    static void Main(string[] args)
    {
        
    long[,] M1 = CreateRandomMatrix(2, 3); 
    ConsoleWriteMatrix(M1);
    SaveToMem(M1, "matice1.txt"); 
    long[,] M2 = ReadFromMem("matice1.txt"); 
    ConsoleWriteMatrix(M2);
    long[,] M3 = { { 2, 3, 1 }, { 7, 4, 6 } }; 
    ConsoleWriteMatrix(M3);
    long[,] M4 = TransposeMatrix(M3);     // { {2, 7 }, { 3, 4 }, { 1, 6 } } 
    ConsoleWriteMatrix(M4);
    long[,] M5 = { { 2, 6, 1 }, { 6, 4, 3 }, { 1, 3, 7 } }; 
    bool b1 = MatrixIsSymmetric(M5); // true 
    long[] v1 = DiagonalOfMatrix(M5); // 2, 4, 7 
    long[,] M6 = { { 4, 5, 2 }, { 0, 3, 6 }, { 0, 0, 9 } }; 
    bool b2 = IsUpperTriangularMatrix(M6); // true
    int i1 = CountZeroLeft(M6, 2); // 2 
    long[,] M7 = { { 7, 1, 2 }, { 0, 0, 6 } }; 
    bool b3 = EchelonForm(M7); // true 
    bool b4 = IsMatrixIdentity(M6); // false 
    }
}
