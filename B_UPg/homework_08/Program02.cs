using System.IO;

namespace priklad02;
class Program
{
    static void BinToText(string binFile, string txtFileName)
    {
        FileStream fs = new FileStream(binFile, FileMode.Open);
        BinaryReader br = new BinaryReader(fs);
        FileInfo fi = new FileInfo(binFile);
        StreamWriter sw = new StreamWriter(txtFileName);

        for (int i = 0; i < (fi.Length / 4); i++)
        {
            if (i % 10 == 0 && i != 0)
                sw.Write("\n");
            sw.Write($"{br.ReadInt32()} ");
        }

        sw.Close(); br.Close();
    }

    static void Main(string[] args)
    {
        BinToText("cisla.dat", "cisla.txt"); 
    }
}