using System.Security.Cryptography;

namespace Magxe
{
    internal class TemporaryRsaKey
    {
        public string KeyId { get; set; }
        public RSAParameters Parameters { get; set; }
    }
}