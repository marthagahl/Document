using System;
using System.IO;

namespace Document
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string name;
            string content;
            int count;
            string answer;

            start:
            Console.WriteLine("Document\n");
            Console.WriteLine("Name your document:\n");

            name = Console.ReadLine();
            if (name.Length > 4 && name.Contains(".txt") is false){
                name = name + ".txt";
            }
            if (name.Length <= 4)
            {
                name = name + ".txt";
            }

            Console.WriteLine("Provide content for your document:\n");
            content = Console.ReadLine();

            count = content.Length;

            FileStream F = new FileStream(name, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);

            try
            {
                using (StreamWriter sw = new StreamWriter(name))
                {
                    sw.WriteLine(content);
                }
                Console.WriteLine("{0} was successfully saved. The document contains {1} characters.", name, count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (F != null)
                {
                    F.Close();
                }
            }


            again:
            Console.WriteLine("Would you like to save another document? (Y/N)");
            answer = Console.ReadLine();

            switch (answer)
            {
                case "Y":
                    goto start;
                case "N":
                    break;
                default:
                    Console.WriteLine("You made an invalid choice.\n");
                    goto again;
            }

        }
    }
}
