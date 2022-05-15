using NUnit.Framework;
using Client.Crypto;
using System.Text;
using Org.BouncyCastle.Crypto.Parameters;

namespace TransferMeTests
{
    public class EncryptionTest
    {
        [Test]
        public void TestEncryption()
        {
            //setup
            string TestString = "My Name is Davis and this is a unit test!";
            byte[] key = AES.KeyGen();
            ParametersWithIV keyParameters = AES.GenerateKeyWithIV(key);
            byte[] bytes = Encoding.ASCII.GetBytes(TestString);
            var EncString = AES.Encrypt(bytes, keyParameters);
            Assert.AreNotEqual(EncString, bytes);
            Assert.AreNotEqual(EncString.Length, bytes.Length);
        }
    }
}
