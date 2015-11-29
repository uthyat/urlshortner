using System.Security.Cryptography;
using System.Text;

namespace UrlShortner.WorkerRole.App.Utility
{
    public class ComputeHash
    {
        public static string GetHashString(string input)
        {
            byte[] hashBytes = GetHash(input);

            StringBuilder builder = new StringBuilder();
            foreach (byte hashByte in hashBytes)
            {
                builder.Append(hashByte.ToString("X2"));
            }

            return builder.ToString();
        }

        private static byte[] GetHash(string input)
        {
            using (MD5 md5HashAlgorithm = MD5.Create())
            {
                return md5HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            }
        }
    }
}
