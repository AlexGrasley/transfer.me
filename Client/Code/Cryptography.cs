using Org.BouncyCastle.Security;
using Client.Code.Crypto;
using Org.BouncyCastle.Crypto.Parameters;

namespace Client.Code
{
    public static class Cryptography
    {
        //Just for testing out crypto functions
        public static void Test()
        {
            string testStr = "This is a test string";
            SecureRandom random = new SecureRandom();
            KeyParameter key = AES.GenerateKey();
            (byte[] cipherText, ParametersWithIV keyParameters) = AES.EncryptString(testStr, key);
            string testStrDecrypted = AES.DecryptString(cipherText, keyParameters);
            bool verify = testStr.Equals(testStrDecrypted);
            Console.WriteLine($"StringCompare: <{testStr}> and <{testStrDecrypted}> are {(verify ? "equal." : "not equal.")}");
        }
    }
}
