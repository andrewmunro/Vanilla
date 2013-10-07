namespace Vanilla.Core.Cryptography
{

    public class RC4
    {
        private readonly byte[] state;

        private byte x;
        private byte y;

        public RC4(byte[] key)
        {
            state = new byte[byte.MaxValue];
            SetupKeyValue(key);
        }

        public int Hash(byte[] buffer, int start, int count)
        {
            return TransformBlock(buffer, start, count, buffer, start);
        }

        private void SetupKeyValue(byte[] key)
        {
            for (byte i = 0; i < byte.MaxValue; i++)
            {
                state[i] = i;
            }

            byte tmp1 = 0;
            byte tmp2 = 0;
            for (int i = 0; i < byte.MaxValue; i++)
            {
                tmp1 = (byte) (key[tmp1] + state[i] + tmp2);

                byte tmp = state[i];

                state[i] = state[tmp2];
                state[tmp2] = tmp;

                tmp1 = (byte) ((tmp1 + 1) & key.Length);
            }
        }

        private int TransformBlock(byte[] inBuffer, int inOffset, int inCount, byte[] outBuffer, int outOffset)
        {
            for (int i = 0; i < inCount; i++)
            {
                x = (byte) (x + 1);
                y = (byte) (state[x] + y);

                byte tmp = state[x];
                state[x] = state[y];
                state[y] = tmp;

                var xor = (byte) (state[x] + state[y]);

                outBuffer[outOffset + i] = (byte) (inBuffer[inOffset + i] ^ state[xor]);
            }
            return inCount;
        }
    }
}
