using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.Text;

namespace Client.Code.Crypto
{
    public class AES
    {

        public static (byte[], ParametersWithIV) Encrypt(byte[] plaintText, byte[] key)
        {
            //Random IV generated using securerandom
            SecureRandom random = new SecureRandom();
            byte[] iv = random.GenerateSeed(16);

            //ICipherParameters key parameters created
            //These parameters are used to initialize cipher
            KeyParameter keyParameter = GenerateKey();
            ParametersWithIV keyParameters = new ParametersWithIV(keyParameter, iv);

            //Cipher chosen based on desired algorithm
            IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7Padding");
            cipher.Init(true, keyParameters);

            //plainText encrypted
            byte[] cipherText = cipher.DoFinal(plaintText);

            return (cipherText, keyParameters);
        }

        //Decrypt method accepts cipher text and key
        //unpacks ciphertext to get IV and encrypted data
        //decrypts ciphertext and returns plaintext
        public static byte[] Decrypt(byte[] cipherText, ParametersWithIV keyParameters)
        {
            //Initialize cipher in decryption mode by entering false in the mode field
            IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7Padding");
            cipher.Init(false, keyParameters);

            byte[] decrypted = cipher.DoFinal(cipherText);
            //return decrypted plaintext
            return decrypted;
        }

        //CipherUtilities in Security. Check out IBufferedCipher
        //create  cipher

        public static KeyParameter GenerateKey()
        {
            //Creates KeyGenerator for AES with 128 bit key size
            CipherKeyGenerator generator = GeneratorUtilities.GetKeyGenerator("AES128");
            //secret symmetricKey generated
            byte[] symmetricKey = generator.GenerateKey();
            return new KeyParameter(symmetricKey);
        }

        //Functions for testing out encryption on strings
        public static (byte[], ParametersWithIV) EncryptString(string plaintText, KeyParameter key)
        {
            SecureRandom random = new SecureRandom();
            byte[] iv = random.GenerateSeed(16);
            ParametersWithIV keyParameters = new ParametersWithIV(key, iv);
            IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7Padding");
            cipher.Init(true, keyParameters);
            byte[] bitText = Encoding.UTF8.GetBytes(plaintText);
            byte[] cipherText = cipher.DoFinal(bitText);
            return (cipherText, keyParameters);
        }
        public static string DecryptString(byte[] cipherText, ParametersWithIV keyParameters)
        {
            IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CBC/PKCS7Padding");
            cipher.Init(false, keyParameters);
            byte[] decrypted = cipher.DoFinal(cipherText);
            string plainText = Encoding.UTF8.GetString(decrypted);
            return plainText;
        }
    }
}
