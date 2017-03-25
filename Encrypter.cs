using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Encrypter
    {
        /// <summary>
        /// Key to decipher the string
        /// </summary>
        static private string mKey { get; set; }

        /// <summary>
        /// eXclusive-OR bitwise
        /// </summary>
        /// <param name="key"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        static private string[] XOR(string key, string[] inputArr)
        {
            string[] allLines = new string[inputArr.Length];
            for (int i = 0; i < inputArr.Length; ++i)
            {
                string input = inputArr[i];
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < input.Length; j++)
                    sb.Append((char)(input[j] ^ key[(j % key.Length)]));
                String result = sb.ToString();
                allLines[i] = result;
            }
            return allLines;
        }

        /// <summary>
        /// Load key into encrypter. Key is assumed to be valid
        /// </summary>
        static public void EnterKey(string newKey)
        {
            mKey = newKey;
        }

        /// <summary>
        /// Use key to encrypt string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static public string[] EncryptDecrypt(string[] str)
        {
            return XOR(mKey, str);
        }
    }
}
