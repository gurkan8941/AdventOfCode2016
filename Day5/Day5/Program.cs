using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        private static string Input = "ojvtpuvg";
        private static HashAlgorithm _algorithm;

        static void Main(string[] args)
        {
            _algorithm = (HashAlgorithm)CryptoConfig.CreateFromName("MD5");

            var password1 = GetPart1Password();

            var password2 = GetPart2Password();

            Console.WriteLine($"Password 1 {password1}");
            Console.WriteLine($"Password 2 {password2}");
            Console.ReadLine();
            
            
        }

        private static string GetPart1Password()
        {
            var password = String.Empty;
            var index = 0;

            while (password.Length < 8)
            {
                var md5 = CreateMd5Hash(Input, index);
                var c = GetPasswordChar(md5);
                if (!String.IsNullOrEmpty(c))
                    password = String.Concat(password, c);

                index++;
            }

            return password;
        }

        private static string GetPart2Password()
        {
            var password = new List<Tuple<string, int>>();
            var index = 0;
            var usedPositions = new List<int>();

            while (password.Count < 8)
            {
                var md5 = CreateMd5Hash(Input, index);
                var c = GetPasswordCharTuple(md5, usedPositions);
                if (c != null)
                {
                    password.Add(c);
                    usedPositions.Add(c.Item2);
                }

                index++;
            }

            var p = String.Join("", password.OrderBy(t => t.Item2).Select(t => t.Item1).ToArray());

            return p;
        }


        private static Tuple<string, int> GetPasswordCharTuple(string md5Hash, IEnumerable<int> usedPositions)
        {
            if (md5Hash.StartsWith("00000"))
            {
                int pos = -1;
                var position = Int32.TryParse(md5Hash.Substring(5, 1), out pos);
                if (position && pos >= 0 && pos <= 7 && !usedPositions.Contains(pos))
                    return new Tuple<string, int>(md5Hash.Substring(6, 1), pos);
            }

            return null;
        }



        private static string GetPasswordChar(string md5Hash)
        {
            if(md5Hash.StartsWith("00000"))
            {
                return md5Hash.Substring(5, 1);
            }

            return null;
        }

        private static string CreateMd5Hash(string input, long index)
        {
            var encodedPassword = new UTF8Encoding().GetBytes(String.Concat(input, index));
            var md5 = _algorithm.ComputeHash(encodedPassword);
            var md5String = BitConverter.ToString(md5).Replace("-", String.Empty);
            return md5String;
        }
    }
}
