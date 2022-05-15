using NUnit.Framework;
using Client.Crypto;
using System.Text;
using Org.BouncyCastle.Crypto.Parameters;
using System;

namespace TransferMeTests
{
    public class DecryptionTest
    {
        [Test]
        public void TestDecryption()
        {
            string TestString = "My Name is Davis and this is a unit test!";
            byte[] key = AES.KeyGen();
            ParametersWithIV keyParamsWithIV = AES.GenerateKeyWithIV(key);
            byte[] bytes = Encoding.ASCII.GetBytes(TestString);
            var EncString = AES.Encrypt(bytes, keyParamsWithIV);
            Assert.AreNotEqual(EncString, bytes);
            Assert.AreNotEqual(EncString.Length, bytes.Length);
            string keystring = Convert.ToBase64String(key);
            var DecBytes = AES.Decrypt(EncString, keystring);
            Assert.AreEqual(DecBytes, bytes);

        }
    }
}
