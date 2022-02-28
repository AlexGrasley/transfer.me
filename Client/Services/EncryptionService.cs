using Org.BouncyCastle.Security;
using Client.Crypto;
using Org.BouncyCastle.Crypto.Parameters;

namespace Client.Services
{
    public static class EncryptionService
    {
        //Just for testing out crypto functions
        public static void Test()
        {
            string testStr = "This is a test string";
            SecureRandom random = new SecureRandom();
            KeyParameter key = AES.GenerateKeyWithIV();
            (byte[] cipherText, ParametersWithIV keyParameters) = AES.EncryptString(testStr, key);
            string testStrDecrypted = AES.DecryptString(cipherText, keyParameters);
            bool verify = testStr.Equals(testStrDecrypted);
            Console.WriteLine($"StringCompare: <{testStr}> and <{testStrDecrypted}> are {(verify ? "equal." : "not equal.")}");
        }
    }
}
