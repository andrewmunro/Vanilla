namespace Milkshake.Tools.Cryptography
{
    public class VanillaCrypt
    {
        protected bool _initialized = false;
        public byte _send_i, _send_j, _recv_i, _recv_j;
        protected byte[] _key;

        public VanillaCrypt()
        {
        }

        public byte[] decrypt(byte[] data, int length)
        {
            if (!_initialized) return data;

            for (int t = 0; t < length; t++)
            {
                _recv_i %= (byte)_key.Length;
                byte x = (byte)((data[t] - _recv_j) ^ _key[_recv_i]);
                ++_recv_i;
                _recv_j = data[t];
                data[t] = x;
            }
            return data;
        }

        public byte[] encrypt(byte[] data)
        {
            if (!_initialized) return data;

            for (int t = 0; t < data.Length; t++)
            {
                _send_i %= (byte)_key.Length;
                byte x = (byte)((data[t] ^ _key[_send_i]) + _send_j);
                ++_send_i;
                data[t] = _send_j = x;
            }
            return data;
        }

        public void init(byte[] key)
        {
            _key = key;
            _send_i = _send_j = _recv_i = _recv_j = 0;
            _initialized = true;
        }
    }
}
