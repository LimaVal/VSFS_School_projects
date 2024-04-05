using System.IO;

namespace priklad01;
class Program
{
    static void CreateBinaryFile(string name, int lenght)
    {
        FileStream fs = new FileStream(name, FileMode.Create);
        BinaryWriter sw = new BinaryWriter(fs);
        Random rand = new Random();

        for (int i = lenght; i > 0; i--)
            sw.Write(rand.Next());


        sw.Close();

        FileInfo fi = new FileInfo(name);
        Console.WriteLine($"File {fi.Name} with {fi.Length} bytes was created.");
    }

    static void Main(string[] args)
    {
        CreateBinaryFile("cisla.dat", 27);
    }
}