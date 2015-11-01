using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qPatterns.Core.Cryptography
{
    public interface IEncryptionManager
    {
        string Encrypt(string value);
        string Decrypt(string value);
    }
}
