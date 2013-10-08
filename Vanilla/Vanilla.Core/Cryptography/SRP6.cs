using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Vanilla.Core.Cryptography
{
    /// <summary>
    /// Handles the secure remote password encryption.
    /// </summary>
    public class SRP6
    {
        private static readonly SHA1 HashAlgorithm = new SHA1Managed();
        public byte[] A;
        public byte[] b;
        public byte[] B;
        private IntPtr BNA;
        private IntPtr BNb;
        private IntPtr BNB;
        private IntPtr BNg;
        private IntPtr BNk;
        private IntPtr BNn;
        private IntPtr BNS;
        private IntPtr BNU;
        private IntPtr BNv;
        private IntPtr BNx;
        public byte[] g = new byte[] { 7 };
        public byte[] k;
        public byte[] K;
        public byte[] M2;
        public byte[] N;
        public byte[] Password;
        public byte[] S;
        public byte[] salt;
        public byte[] U;
        public byte[] Username;

        public SRP6(bool bc)
        {
            if (bc)
            {
                N = new byte[]
                        {
                            0xb7, 0x9b, 0x3e, 0x2a, 0x87, 130, 60, 0xab, 0x8f, 0x5e, 0xbf, 0xbf, 0x8e, 0xb1, 1, 8, 0x53, 80
                            , 6, 0x29, 0x8b, 0x5b, 0xad, 0xbd, 0x5b, 0x53, 0xe1, 0x89, 0x5e, 100, 0x4b, 0x89
                        };
                salt = new byte[]
                           {
                               0x53, 0x3f, 0x4d, 0xd0, 0x8a, 0x97, 0x53, 0x3d, 0x9b, 0x5f, 0xd0, 0xc9, 0x98, 0x2b, 0x6a,
                               0x25, 0x37, 0xb1, 0x98, 110, 0xb7, 230, 0x26, 0x4e, 0xe7, 0x11, 0xc3, 80, 0xef, 0xce, 0x84,
                               0xd1
                           };
            }
            else
            {
                N = new byte[]
                        {
                            0x89, 0x4b, 100, 0x5e, 0x89, 0xe1, 0x53, 0x5b, 0xbd, 0xad, 0x5b, 0x8b, 0x29, 6, 80, 0x53, 8, 1,
                            0xb1, 0x8e, 0xbf, 0xbf, 0x5e, 0x8f, 0xab, 60, 130, 0x87, 0x2a, 0x3e, 0x9b, 0xb7
                        };
                salt = new byte[]
                           {
                               0xad, 0xd0, 0x3a, 0x31, 210, 0x71, 20, 70, 0x75, 0xf2, 0x70, 0x7e, 80, 0x26, 0xb6, 210, 0xf1
                               , 0x86, 0x59, 0x99, 0x76, 2, 80, 170, 0xb9, 0x45, 0xe0, 0x9e, 0xdd, 0x2a, 0xa3, 0x45
                           };
            }
            k = new byte[] { 3 };
            B = new byte[0x20];
            b = new byte[40];
        }

        #region PInvokes

        [DllImport("LIBEAY32.DLL", CallingConvention = CallingConvention.Cdecl)]
        private static extern int BN_add(IntPtr r, IntPtr a, IntPtr b);

        [DllImport("LIBEAY32.DLL", EntryPoint = "BN_bin2bn", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr BN_Bin2BN(byte[] ByteArrayIn, int length, IntPtr to);

        [DllImport("LIBEAY32.DLL", CallingConvention = CallingConvention.Cdecl)]
        private static extern int BN_bn2bin(IntPtr a, byte[] to);

        [DllImport("LIBEAY32.DLL", EntryPoint = "BN_CTX_free", CallingConvention = CallingConvention.Cdecl)]
        private static extern int BN_ctx_free(IntPtr a);

        [DllImport("LIBEAY32.DLL", EntryPoint = "BN_CTX_new", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr BN_ctx_new();

        [DllImport("LIBEAY32.DLL", CallingConvention = CallingConvention.Cdecl)]
        private static extern int BN_div(IntPtr dv, IntPtr r, IntPtr a, IntPtr b, IntPtr ctx);

        [DllImport("LIBEAY32.DLL", EntryPoint = "BN_free", CallingConvention = CallingConvention.Cdecl)]
        private static extern void BN_Free(IntPtr r);

        [DllImport("LIBEAY32.DLL", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr BN_mod_exp(IntPtr res, IntPtr a, IntPtr p, IntPtr m, IntPtr ctx);

        [DllImport("LIBEAY32.DLL", CallingConvention = CallingConvention.Cdecl)]
        private static extern int BN_mul(IntPtr r, IntPtr a, IntPtr b, IntPtr ctx);

        [DllImport("LIBEAY32.DLL", EntryPoint = "BN_new", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr BN_New();

        [DllImport("LIBEAY32.DLL", CallingConvention = CallingConvention.Cdecl)]
        private static extern int RAND_bytes(byte[] buf, int num);

        #endregion

        public void CalculateB()
        {
            RAND_bytes(b, 40);
            IntPtr res = BN_New();
            IntPtr r = BN_New();
            IntPtr ptr3 = BN_New();
            BNB = BN_New();
            IntPtr ctx = BN_ctx_new();
            BNb = Bin2BN(ref b, true);
            //Array.Reverse(b);
            //BNb = BN_Bin2BN(b, b.Length, IntPtr.Zero);
            //Array.Reverse(b);
            BN_mod_exp(res, BNg, BNb, BNn, ctx);
            BN_mul(r, BNk, BNv, ctx);
            BN_add(ptr3, res, r);
            BN_div(IntPtr.Zero, BNB, ptr3, BNn, ctx);
            BN_bn2bin(BNB, B);
            Array.Reverse(B);
            BN_ctx_free(ctx);
            BN_Free(ptr3);
            BN_Free(r);
            BN_Free(res);
        }

        public void CalculateK()
        {
            List<byte[]> list = Split(S);
            list[0] = HashAlgorithm.ComputeHash(list[0]);
            list[1] = HashAlgorithm.ComputeHash(list[1]);
            K = Combine(list[0], list[1]);
        }

        public void CalculateM2(byte[] m1)
        {
            var dst = new byte[(A.Length + m1.Length) + K.Length];
            Buffer.BlockCopy(A, 0, dst, 0, A.Length);
            Buffer.BlockCopy(m1, 0, dst, A.Length, m1.Length);
            Buffer.BlockCopy(K, 0, dst, A.Length + m1.Length, K.Length);
            M2 = HashAlgorithm.ComputeHash(dst);
        }

        public void CalculateS()
        {
            IntPtr res = BN_New();
            IntPtr r = BN_New();
            BNS = BN_New();
            IntPtr ctx = BN_ctx_new();
            S = new byte[0x20];
            BN_mod_exp(res, BNv, BNU, BNn, ctx);
            BN_mul(r, BNA, res, ctx);
            BN_mod_exp(BNS, r, BNb, BNn, ctx);
            BN_bn2bin(BNS, S);
            Array.Reverse(S);
            CalculateK();
            BN_ctx_free(ctx);
            BN_Free(r);
            BN_Free(res);
        }

        public void CalculateU(byte[] a)
        {
            A = a;
            var dst = new byte[a.Length + B.Length];
            Buffer.BlockCopy(a, 0, dst, 0, a.Length);
            Buffer.BlockCopy(B, 0, dst, a.Length, B.Length);
            U = HashAlgorithm.ComputeHash(dst);
            BNU = Bin2BN(ref U, true);
            BNA = Bin2BN(ref A, true);

            //Array.Reverse(U);
            //BNU = BN_Bin2BN(U, U.Length, IntPtr.Zero);
            //Array.Reverse(U);
            //Array.Reverse(A);
            //BNA = BN_Bin2BN(A, A.Length, IntPtr.Zero);
            //Array.Reverse(A);

            CalculateS();
        }

        public void CalculateV()
        {
            BNv = BN_New();
            IntPtr ctx = BN_ctx_new();
            BN_mod_exp(BNv, BNg, BNx, BNn, ctx);
            CalculateB();
            BN_ctx_free(ctx);
        }

        public void CalculateX(byte[] username, byte[] password)
        {
            byte[] src = username;
            byte[] buffer2 = password;

            var dst = new byte[src.Length + buffer2.Length + 1];
            var buffer5 = new byte[salt.Length + 20];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);

            dst[src.Length] = 0x3a;

            Buffer.BlockCopy(buffer2, 0, dst, src.Length + 1, buffer2.Length);
            Buffer.BlockCopy(HashAlgorithm.ComputeHash(dst, 0, dst.Length), 0, buffer5, salt.Length, 20);
            Buffer.BlockCopy(salt, 0, buffer5, 0, salt.Length);

            byte[] array = HashAlgorithm.ComputeHash(buffer5);

            BNx = Bin2BN(ref array, false);
            BNg = Bin2BN(ref g, true);
            BNk = Bin2BN(ref k, true);
            BNn = Bin2BN(ref N, true);

            //Array.Reverse(array);
            //BNx = BN_Bin2BN(array, array.Length, IntPtr.Zero);
            //Array.Reverse(g);
            //BNg = BN_Bin2BN(g, g.Length, IntPtr.Zero);
            //Array.Reverse(g);
            //Array.Reverse(k);
            //BNk = BN_Bin2BN(k, k.Length, IntPtr.Zero);
            //Array.Reverse(k);
            //Array.Reverse(N);
            //BNn = BN_Bin2BN(N, N.Length, IntPtr.Zero);
            //Array.Reverse(N);

            CalculateV();
        }

        private static IntPtr Bin2BN(ref byte[] buffer, bool reverseAfter)
        {
            Array.Reverse(buffer);
            IntPtr ret = BN_Bin2BN(buffer, buffer.Length, IntPtr.Zero);
            if (reverseAfter)
            {
                Array.Reverse(buffer);
            }
            return ret;
        }

        private static byte[] Combine(byte[] b1, byte[] b2)
        {
            if (b1.Length != b2.Length)
            {
                return null;
            }

            var buffer = new byte[b1.Length + b2.Length];
            int index = 0;

            for (int i = 0; i < b1.Length; i++)
            {
                buffer[index] = b1[i];
                index += 2;
            }

            index = 1;

            for (int j = 0; j < b2.Length; j++)
            {
                buffer[index] = b2[j];
                index += 2;
            }
            return buffer;
        }

        ~SRP6()
        {
            BN_Free(BNA);
            BN_Free(BNb);
            BN_Free(BNB);
            BN_Free(BNg);
            BN_Free(BNk);
            BN_Free(BNn);
            BN_Free(BNS);
            BN_Free(BNU);
            BN_Free(BNv);
            BN_Free(BNx);
        }

        private static List<byte[]> Split(byte[] bo)
        {
            // CHANGE: Apoc - Use List<T>, not ArrayList
            // It provides better performance, and typesafety.

            var dst = new byte[bo.Length - 1];

            if (((bo.Length % 2) != 0) && (bo.Length > 2))
            {
                Buffer.BlockCopy(bo, 1, dst, 0, bo.Length);
            }

            var buffer2 = new byte[bo.Length / 2];
            var buffer3 = new byte[bo.Length / 2];

            int index = 0;
            for (int i = 0; i < buffer2.Length; i++)
            {
                buffer2[i] = bo[index];
                index += 2;
            }
            index = 1;
            for (int j = 0; j < buffer3.Length; j++)
            {
                buffer3[j] = bo[index];
                index += 2;
            }
            var list = new List<byte[]> { buffer2, buffer3 };
            return list;
        }
    }

    public class NewSRP6
    { }
}
