namespace projectEuler
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    class Prb22
    {
        public static string Run()
        {
            string path = @".\resources\p022_names.txt";
            List<string> nameList = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() > -1)
                {
                    char openingDuote = (char)sr.Read();
                    if (openingDuote != '"')
                    {
                        throw new Exception("Not first doble quote");
                    }
                    StringBuilder sb = new StringBuilder(1000);
                    while((char)sr.Peek() != '"')
                    {
                        sb.Append((char)sr.Read());
                    }
                    char closingDuote = (char)sr.Read();
                    if (closingDuote != '"')
                    {
                        throw new Exception("Not ending doble quote");
                    }
                    if (sr.Peek() == -1) break;
                    char comma = (char)sr.Read();
                    nameList.Add(sb.ToString());
                    Console.WriteLine(nameList[nameList.Count-1]);
                    if (comma != ',')
                    {
                        throw new Exception("Not ending comma");
                    }
                }
            }
            Console.WriteLine($"file contentes name count = {nameList.Count}");
            string result = "res";
            return result;
        }
    }
}