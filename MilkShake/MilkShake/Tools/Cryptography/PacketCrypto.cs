using System.Security.Cryptography;

namespace Milkshake.Tools.Cryptography
{
    public class PacketCrypto
    {
        // This is valid as HMAC-SHA1 transforms can be reused
        private static readonly HMACSHA1 DecryptClientDataHmac = new HMACSHA1(ServerDecryptionKey);
        private static readonly HMACSHA1 EncryptServerDataHmac = new HMACSHA1(ServerEncryptionKey);

        /// <summary>
        /// This is the key the client uses to encrypt its packets
        /// This is also the key the server uses to decrypt the packets
        /// </summary>
        private static readonly byte[] ServerDecryptionKey = {
                                                                 0xF4, 0x66, 0x31, 0x59, 0xFC, 0x83, 0x6E, 0x31, 0x31, 0x02
                                                                 , 0x51, 0xD5, 0x44, 0x31, 0x67, 0x98
                                                             };

        /// <summary>
        /// This is the key the client uses to decrypt server packets
        /// This is also the key the server uses to encrypt the packets
        /// </summary>
        private static readonly byte[] ServerEncryptionKey = {
                                                                 0x22, 0xBE, 0xE5, 0xCF, 0xBB, 0x07, 0x64, 0xD9, 0x00, 0x45
                                                                 , 0x1B, 0xD0, 0x24, 0xB8, 0xD5, 0x45
                                                             };

        /// <summary>
        /// Decrypts data sent from the client
        /// </summary>
        private readonly RC4 _decryptClientData;

        /// <summary>
        /// Encrypts data sent to the client
        /// </summary>
        private readonly RC4 _encryptServerData;

        public PacketCrypto(byte[] sessionKey)
        {
            byte[] encryptHash = EncryptServerDataHmac.ComputeHash(sessionKey);
            byte[] decryptHash = DecryptClientDataHmac.ComputeHash(sessionKey);

            // Client-side
            var decryptServerData = new RC4(encryptHash); // Used by the client to decrypt packets sent by the server

            // Client-side
            var encryptClientData = new RC4(decryptHash); // Used by the client to encrypt packets sent to the server

            // Server-side
            _decryptClientData = new RC4(decryptHash); // Used by the server to decrypt packets sent by the client

            // Server-side
            _encryptServerData = new RC4(encryptHash); // Used by the server to encrypt packets sent to the client

            // Use the 2 encryption objects to generate a common starting point
            var syncBuffer = new byte[1024];
            _encryptServerData.Hash(syncBuffer, 0, syncBuffer.Length);
            encryptClientData.Hash(syncBuffer, 0, syncBuffer.Length);

            // Use the 2 decryption objects to generate a common starting point
            syncBuffer = new byte[1024];
            decryptServerData.Hash(syncBuffer, 0, syncBuffer.Length);
            _decryptClientData.Hash(syncBuffer, 0, syncBuffer.Length);
        }

        public void Decrypt(byte[] data, int start, int count)
        {
            _decryptClientData.Hash(data, start, count);
        }

        public void Encrypt(byte[] data, int start, int count)
        {
            _encryptServerData.Hash(data, start, count);
        }
    }
}
