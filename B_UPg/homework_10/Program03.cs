namespace priklad03;
class Program
{
    static void WalkFolder(string path, StreamWriter sw)
    {
        // File
        string[] files = Directory.GetFiles(path);
        for (int i = 0; i < files.Length; i++)
            sw.WriteLine(Path.GetFullPath(files[i]));

        // Folder
        string[] dirs = Directory.GetDirectories(path);
        for (int i = 0; i < dirs.Length; i++)
            WalkFolder(dirs[i], sw);
    }

    static void ListOfFolder(string path, string file)
    {
        StreamWriter sw = new StreamWriter(file);
        WalkFolder(path, sw);
        sw.Close();
    }

    static void Main(string[] args)
    {
        ListOfFolder(@"./", "log.txt"); 
        // Kontrola Windows: dir /s 
        // Kontrola Unix: ls –R 
    }
}