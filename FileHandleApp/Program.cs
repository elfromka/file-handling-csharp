using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHandleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileWriter();
            //FileReader();
            CheckForFile();
        }

        private static void CheckForFile()
        {
            if (File.Exists("numbers.txt"))
            {
                Console.WriteLine("The file with numbers exists!");
                FileReader();
            }
            else
            {
                throw new Exception("The file is missing!");
            }
        }

        // reading the file
        private static void FileReader(string fileName = "numbers.txt")
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                Console.ReadKey();
            }
           
        }

        // writing in the file
        private static void FileWriter()
        {
            var names = new string[] { "Orsi", "Csharp" };
            string fileName = "numbers.txt";

            // append true to not overwrite the existing data in the file
            // just for test
            using (StreamWriter sw = new StreamWriter(fileName, true))
            {
                foreach (var name in names)
                {
                    sw.WriteLine(name);
                }
            }
        }
    }
}

   
