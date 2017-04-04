using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Encryption
{

    // Sometimes, decrypted string gets broken... Further investigation needed
    class Program
    {
        static string encryptedStr;
        static int firstParameter;

        static void Main(string[] args)
        {
            Initialise(ref args);

            // Help
            if (args[0] == "-h")
            {
                Console.WriteLine("\nOrder of paremeters should be: [-k]? [-e/-d] \"[path to input file]\" \"[path to output file]\" [key]");
            }
            else
            {
                // Output key (optional)
                if (args[0] == "-k")
                    firstParameter = 1;
                else firstParameter = 0;

                if (args[firstParameter] == "-e")
                    encryptedStr = Encrypter.Encrypt(File.ReadAllText(args[firstParameter + 1]), args[firstParameter + 3]);
                else if (args[firstParameter] == "-d")
                    encryptedStr = Encrypter.Decrypt(File.ReadAllText(args[firstParameter + 1]), args[firstParameter + 3]);

                OutputTo(args[firstParameter + 2]);
            }
        }

        /// <summary>
        /// Initialise all variables to their default state
        /// </summary>
        /// <param name="args">List of arguments from command line</param>
        static void Initialise(ref string[] args)
        {
            if (args.Length == 0)
            {
                List<string> argsList = new List<string>();
                Console.Write("-e/-d?");
                argsList.Add(Console.ReadLine());
                Console.Write("Enter input file:");
                argsList.Add(Console.ReadLine());
                Console.Write("Enter output file:");
                argsList.Add(Console.ReadLine());
                Console.Write("Enter key:");
                argsList.Add(Console.ReadLine());

                args = argsList.ToArray();
            }
        }

        /// <summary>
        /// Format and output text
        /// </summary>
        /// <param name="fileName">Full path to output file</param>
        static void OutputTo(string fileName)
        {
            File.Delete(fileName);
            File.AppendAllText(fileName, encryptedStr);
        }
    }
}
