namespace Vanilla.Core.Cryptography
{
    using System.Security.Cryptography;

    public class Authenticator
    {
        public byte[] SessionKey;

        public SRP6 SRP6;
        
        public Authenticator()
        {
            SRP6 = new SRP6(false);
        }

        public void CalculateX(byte[] userBytes, byte[] passBytes)
        {
            SRP6.CalculateX(userBytes, passBytes);
        }

        public void CalculateU(byte[] p)
        {
            SRP6.CalculateU(p);
        }

        public void CalculateM2(byte[] p)
        {
            SRP6.CalculateM2(p);
        }

        public void CalculateAccountHash()
        {
            SHA1 shaM1 = new SHA1CryptoServiceProvider();
            byte[] S = SRP6.S;
            var S1 = new byte[16];
            var S2 = new byte[16];

            for (int t = 0; t < 16; t++)
            {
                S1[t] = S[t * 2];
                S2[t] = S[(t * 2) + 1];
            }

            byte[] hashS1 = shaM1.ComputeHash(S1);
            byte[] hashS2 = shaM1.ComputeHash(S2);
            
            SessionKey = new byte[hashS1.Length + hashS2.Length];
            for (int t = 0; t < 20; t++)
            {
                SessionKey[t * 2] = hashS1[t];
                SessionKey[(t * 2) + 1] = hashS2[t];
            }

            var opad = new byte[64];
            var ipad = new byte[64];

            //Static 16 byte Key located at 0x0088FB3C
            var key = new byte[] { 56, 167, 131, 21, 248, 146, 37, 48, 113, 152, 103, 177, 140, 4, 226, 170 };

            //Fill 64 bytes of same value
            for (int i = 0; i <= 64 - 1; i++)
            {
                opad[i] = 0x05C;
                ipad[i] = 0x036;
            }

            //XOR Values
            for (int i = 0; i <= 16 - 1; i++)
            {
                opad[i] = (byte)(opad[i] ^ key[i]);
                ipad[i] = (byte)(ipad[i] ^ key[i]);
            }

            byte[] buffer1 = Concat(ipad, SessionKey);
            byte[] buffer2 = shaM1.ComputeHash(buffer1);

            buffer1 = Concat(opad, buffer2);
            SessionKey = shaM1.ComputeHash(buffer1);
        }

        private byte[] Concat(byte[] a, byte[] b)
        {
            var res = new byte[a.Length + b.Length];
            for (int t = 0; t < a.Length; t++)
            {
                res[t] = a[t];
            }
            for (int t = 0; t < b.Length; t++)
            {
                res[t + a.Length] = b[t];
            }
            return res;
        }
    }
}
