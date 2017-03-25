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
        static string[] encryptedStr;
        static int firstParameter = 0;

        static void Main(string[] args)
        {
                Initialise(ref args);

            // Help
            if (args[0] == "-h")
            {
                Console.WriteLine("\nOrder of paremeters should be: [-k]? \"[path to input file]\" \"[path to output file]\" [key]");
            }
            // Output key (optional)
            else if (args[0] == "-k")
                firstParameter = 1;
            else firstParameter = 0;

            Encrypter.EnterKey(args[firstParameter + 2]);
            encryptedStr = Encrypt(GetFileStrings(args[firstParameter]));
            OutputTo(args[firstParameter + 1]);
        }

        /// <summary>
        /// Initialise all variables to their default state
        /// </summary>
        static void Initialise(ref string[] args)
        {
            if (args.Length == 0)
            {
                List<string> argsList = new List<string>();
                Console.Write("Enter input file:");
                argsList.Add(Console.ReadLine());
                Console.Write("Enter output file:");
                argsList.Add(Console.ReadLine());
                Console.Write("Enter encryption key:");
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
            File.AppendAllLines(fileName, encryptedStr);
        }

        /// <summary>
        /// Format and output text
        /// </summary>
        /// <param name="fileName">Full path to output file</param>
        static string[] GetFileStrings(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        /// <summary>
        /// Encrypt string and return encrypted string. If impossible, return empty string
        /// </summary>
        /// <param name="toEncrypt">String to be encrypted</param>
        /// <returns></returns>
        static string[] Encrypt(string[] toEncrypt)
        {
            return Encrypter.EncryptDecrypt(toEncrypt);
        }
    }
}
