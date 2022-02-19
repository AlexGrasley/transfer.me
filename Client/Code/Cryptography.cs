using Org.BouncyCastle.Security;
using Client.Code.Crypto;
using Org.BouncyCastle.Crypto.Parameters;

namespace Client.Code
{
    public static class Cryptography
    {
        //Just for testing out crypto functions
        public static void Init()
        {
            string testStr = "This is a test string";
            KeyParameter key = AES.GenerateKey();
            (byte[] cipherText, ParametersWithIV keyParameters) = AES.EncryptString(testStr, key);
            string testStrDecrypted = AES.DecryptString(cipherText, keyParameters);
        }
    }
}
