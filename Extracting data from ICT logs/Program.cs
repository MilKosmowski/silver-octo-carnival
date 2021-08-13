using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"C:/Users/hjtb7l/Desktop/surowe dane GR ze stycznia 2021");
            if (File.Exists(@"C:/Users/hjtb7l/Desktop/surowe dane GR ze stycznia 2021/surowe dane.txt"))
            {
                File.Delete(@"C:/Users/hjtb7l/Desktop/surowe dane GR ze stycznia 2021/surowe dane.txt");
                using (StreamWriter sw = File.AppendText(@"C:/Users/hjtb7l/Desktop/surowe dane GR ze stycznia 2021/surowe dane.txt"))
                {
                    sw.WriteLine($"tester,board serial,data YYYYMMDDHHmmss,r141 value");
                }
            }
            int z = 0;
            foreach (var file in d.GetFiles())
            {
                Console.WriteLine(z++);
                List<string> FileData = new List<string>(File.ReadAllLines(file.ToString()));
                //Console.WriteLine(FileData.Count);
                for (int i = 0; i < FileData.Count; i++)
                {
                    //Console.WriteLine(FileData[i]);
                    if (FileData[i].Contains("r141"))
                    {
                        using (StreamWriter sw = File.AppendText(@"C:/Users/hjtb7l/Desktop/surowe dane GR ze stycznia 2021/surowe dane.txt"))
                        {
                            sw.WriteLine($"{FileData[0].Substring(54, 10)},{FileData[1].Substring(8, 7)},{FileData[1].Substring(19, 12)},{FileData[i + 1].Substring(11, 12)}");
                            
                        }
                    }
                }
            }
        }
    }
}
