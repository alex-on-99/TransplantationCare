using System.Security.Cryptography;
using System.Text;

namespace TransplantationCare.BusinessLogic.Extensions
{
    public static class TextEncryptor
    {
        public static string EncryptMd5(this string text)
        {
            var cryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] data = Encoding.ASCII.GetBytes(text);
            data = cryptoServiceProvider.ComputeHash(data);
            string md5Hash = Encoding.ASCII.GetString(data);

            return md5Hash;
        }
    }
}
