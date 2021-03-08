using System;
using System.Security.Cryptography;
using System.Text;

namespace dotdis.Util{
    public class Cryptor{
        public const int BUFFER_SIZE = 12;
        public static string GenerateSalt(){
            RNGCryptoServiceProvider rngCryp = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[BUFFER_SIZE];
            rngCryp.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }
        public static string GenerateHash(string source, string salt){
            byte[] bytes = Encoding.ASCII.GetBytes(source + salt);
            SHA256Managed managedStr = new SHA256Managed();
            byte[] hash = managedStr.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        
    }
}