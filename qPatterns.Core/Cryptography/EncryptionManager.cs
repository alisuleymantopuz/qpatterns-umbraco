using System.Security.Cryptography;
using System;
using System.Text;

namespace qPatterns.Core.Cryptography
{
    public class EncryptionManager : IEncryptionManager
    {
        public CoreConfiguration CoreConfiguration { get; private set; }

        public EncryptionManager(CoreConfiguration coreConfiguration)
        {
            CoreConfiguration = coreConfiguration;
        }

        public string Encrypt(string value)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(value);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(this.CoreConfiguration.ApplicationKey);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);

        }

        public string Decrypt(string value)
        {
            byte[] inputArray = Convert.FromBase64String(value);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(this.CoreConfiguration.ApplicationKey);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
