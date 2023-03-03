using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace HOI4MassStateEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfTags;
            string num;
            do
            {
                Console.WriteLine("Type a number of tags");
                num = Console.ReadLine();
            } while (!Int32.TryParse(num, out numOfTags));

            string[] tags = new string[numOfTags];
            for (int i = 0; i < numOfTags; i++)
            {
                string tag;
                do
                {
                    Console.WriteLine("Type tag no. " + (i + 1));
                    tag = Console.ReadLine();
                } while (tag.Length != 3);
                tags[i] = tag;
            }

            bool delOtherTags = false;
            Console.WriteLine("Delete other tags? Type anything for yes, press enter for no.");
            if (Console.ReadLine().Length > 0)
                delOtherTags = true;

            Console.WriteLine("Type a path to the folder with files");
            string pathToDir = Console.ReadLine();
            foreach (string file in Directory.EnumerateFiles(pathToDir, "*.txt"))
                EditFile(file, tags, delOtherTags);

            Console.WriteLine("Done! Press any key to exit...");
            Console.ReadKey();
        }

        private static void EditFile(string fileName, string[] tags, bool delOtherTags)
        {
            if (delOtherTags)
            {
                var stringsToRemove = File.ReadAllLines(fileName)
                    .Where(l => l.Contains("add_core_of = ") || l.Contains("owner = "));
                foreach (string stringToRemove in stringsToRemove)
                {
                    var tempFile = Path.GetTempFileName();
                    var linesToKeep = File.ReadLines(fileName).Where(l => l != stringToRemove);

                    File.WriteAllLines(tempFile, linesToKeep);
                    File.Delete(fileName);
                    File.Move(tempFile, fileName);
                }
            }

            var content = File.ReadAllLines(fileName);
            int lineNum = 0;
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i].Contains("history"))
                {
                    if (!content[i].Contains("{"))
                    {
                        lineNum = i + 2;
                        break;
                    }

                    lineNum = i + 1;
                    break;
                }
            }

            List<string> textToInsert = new List<string>();
            foreach(string tag in tags)
            {
                textToInsert.Add("\t\tadd_core_of = " + tag);
                textToInsert.Add("\t\towner = " + tag);
            }

            foreach (string t in textToInsert)
                InsertLine(t, fileName, lineNum);
        }

        private static void InsertLine(string textToInsert, string fileName, int lineNum)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            string[] arrToWrite = new string[arrLine.Length + 1];
            for (int i = 0; i < arrToWrite.Length; i++)
            {
                if (i < lineNum)
                    arrToWrite[i] = arrLine[i];
                else if (i == lineNum)
                    arrToWrite[i] = textToInsert;
                else
                    arrToWrite[i] = arrLine[i - 1];
            }
            File.WriteAllLines(fileName, arrToWrite);
        }
    }
}
