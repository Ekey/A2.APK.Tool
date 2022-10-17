using System;

namespace A2.Unpacker
{
    class ApkHeader
    {
        public UInt32 dwMagic { get; set; } // 0x4034B50
        public Int32 dwArchiveSize { get; set; }
        public Int32 dwCompressedFlag { get; set; } // 1
        public Int32 dwEncryptedFlag { get; set; } // 1
        public Int32 dwTotalFiles { get; set; }
        public Int32 dwBaseOffset { get; set; } // 0x1C (28)
        public Int32 dwTableOffset { get; set; }
        public Int32 dwTableSize { get; set; }
    }
}
