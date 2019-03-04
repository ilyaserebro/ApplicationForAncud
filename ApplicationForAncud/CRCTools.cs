using System;
using System.Threading;

namespace ApplicationForAncud
{
    class CRCTools
    {
        static uint[] tableCRC32;

        static CRCTools()
        {
            InitTableCRC32();
        }

        static void InitTableCRC32()
        {
            tableCRC32 = new uint[256];
            const uint POLYNOMIAL = 0xEDB88320;
            uint crc32;

            for (int i = 0; i < 256; i++)
            {
                crc32 = (uint)i;

                for (int j = 8; j > 0; j--)
                {
                    if ((crc32 & 1) == 1)
                        crc32 = (crc32 >> 1) ^ POLYNOMIAL;
                    else
                        crc32 >>= 1;
                }

                tableCRC32[i] = crc32;
            }
        }

        public static uint CalculateCRC(string fileName, CancellationToken cancelToken)
        {
            const int bufferSize = 1024;
            byte[] buffer = new byte[bufferSize];
            uint result = 0xFFFFFFFF;
            System.IO.FileStream stream;
            stream = System.IO.File.OpenRead(fileName);
            
            int count = stream.Read(buffer, 0, bufferSize);

            while (count > 0)
            {
                cancelToken.ThrowIfCancellationRequested();

                for (int i = 0; i < count; i++)
                {
                    result = ((result) >> 8)
                        ^ tableCRC32[(buffer[i])
                        ^ ((result) & 0x000000FF)];
                }

                count = stream.Read(buffer, 0, bufferSize);
            }

            return ~result;
        }
    }
}
