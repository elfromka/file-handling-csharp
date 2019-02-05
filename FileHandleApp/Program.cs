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
            Catching();
            Console.ReadLine();
        }

        // should be implemented...
        static bool MyTryParseMethod(string data)
        {
            // converting the data into ascii code
            // between 48-57 included are numbers
            // 32 is space
            Console.WriteLine(data);

            byte[] asciiBytes = Encoding.ASCII.GetBytes(data);
            foreach (int asciibyte in asciiBytes)
            {
                if (asciibyte != 32 && (asciibyte >=48 && asciibyte <=57))
                {
                    Console.WriteLine("FOREACH ITEM: " + asciibyte);
                }

            }
            return false;
        }

        static void Catching()
        {
            try
            {
                CheckForFile();
            }
            catch (NoFileFoundException e)
            {
                Console.WriteLine("NoFileFoundException: {0}", e.Message);
            }
        }

        public class NoFileFoundException : Exception
        {
            public NoFileFoundException(string message) : base(message)
            {
            }
        }

        private static void CheckForTwoFiles()
        {
            if (File.Exists("correctNumbers.txt"))
            {
                Console.WriteLine("correctNumbers.txt exists!");
            }
            else
            {
                using (StreamWriter correctNumbers = File.AppendText("correctNumbers.txt"));
            }

            if (File.Exists("incorrectNumbers.txt"))
            {
                Console.WriteLine("incorrectNumbers.txt exists!");
            }
            else
            {
                using (StreamWriter incorrectNumbers = File.AppendText("incorrectNumbers.txt"));
            }
        }

        private static void CheckForFile()
        {
            if (File.Exists("numbers.txt"))
            {
                Console.WriteLine("The file with numbers exists!");
                CheckForTwoFiles();
                Console.WriteLine();
                Console.WriteLine("These are the numbers from the file: ");
                FileReadAndDisplay();
            }
            else
            {
                throw (new NoFileFoundException("ERROR! The file is missing!"));
            }
        }

        // reading the file
        private static void FileReadAndDisplay(string fileName = "numbers.txt")
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    MyTryParseMethod(line);
                }
            }
        }

        private static void VerifyNumber(string fileName = "numbers.txt")
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;

                List<int> correctNumbersList = new List<int>();
                List<int> incorrectNumbersList = new List<int>();

                while ((line = sr.ReadLine()) != null)
                {
                    int result = 0;
                    if (int.TryParse(line, out result))
                    {
                        correctNumbersList.Add(result);
                    }
                    else
                    {
                        incorrectNumbersList.Add(result);
                    }

                    correctNumbersList.ForEach(Console.WriteLine);
                    incorrectNumbersList.ForEach(Console.WriteLine);
                    Console.ReadKey();
                }
            }

        }

        // writing in the file
        // append true to not overwrite the existing data in the file
        // just for test !!!
        private static void FileWriter()
        {
            var names = new string[] { "Orsi", "Csharp" };
            string fileName = "numbers.txt";

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

   
