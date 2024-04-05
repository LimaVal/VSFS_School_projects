using System.IO;

namespace priklad03;
class Program
{
    static void SumOfNumber(string nameTxt, string nameSum)
    {
        StreamReader fs = new StreamReader(nameTxt);
        StreamWriter sw = new StreamWriter(nameSum);
        
        string? line;
        string num = "";
        long sum = 0;

        while ((line = fs.ReadLine()) != null)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsWhiteSpace(line[i]))
                {
                    sum += Convert.ToInt64(num);
                    num = "";
                }
                else
                    num += line[i];
            }
            sw.Write($"{sum}\n");
            sum = 0;
        }
        fs.Close(); sw.Close();
    }


    static void Main(string[] args)
    {
        SumOfNumber("cisla.txt", "soucet.txt"); 
    }
}