namespace Vanilla.World.Tools.Update
{
    public class UpdateMask
    {
        private int m_maxBlockCount;
        private uint[] m_blocks;

        protected internal int m_lowestIndex;
        protected internal int m_highestIndex;

        public UpdateMask(int blockcount)
        {
            m_maxBlockCount = blockcount;
            m_highestIndex = blockcount * 32;
            m_blocks = new uint[blockcount];
        }

        public int MaxBlockCount
        {
            get { return m_maxBlockCount; }
        }

        public uint[] Blocks
        {
            get { return m_blocks; }
        }

        public void SetBlock(uint i, uint x)
        {
            m_blocks[i] = x;
        }

        public int LowestIndex
        {
            get { return m_lowestIndex; }
        }

        public int HighestIndex
        {
            get
            {
                return m_highestIndex;
            }
        }

        public bool HasBitsSet
        {
            get
            {
                return m_highestIndex >= m_lowestIndex;
            }
        }

        public void UnsetBit(int index)
        {
            m_blocks[index >> 5] &= ~(uint)(1 << (index & 31));
        }

        public void SetAll()
        {
            for (int i = 0; i < m_maxBlockCount; i++)
            {
                m_blocks[i] = uint.MaxValue;
            }
        }

        public void SetBit(int index)
        {
            m_blocks[index >> 5] |= (uint)(1 << (index & 31));
            if (index > m_highestIndex)
            {
                m_highestIndex = index;
            }
            if (index < m_lowestIndex)
            {
                m_lowestIndex = index;
            }
        }

        public bool GetBit(int index)
        {
            return (m_blocks[index >> 5] & (uint)(1 << (index & 31))) != 0;
        }
    }
}
