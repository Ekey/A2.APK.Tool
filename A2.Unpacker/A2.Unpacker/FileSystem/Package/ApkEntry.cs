using System;

namespace A2.Unpacker
{
    class ApkEntry
    {
        public String m_FileName { get; set; } // 128 bytes
        public Int32 dwDecompressedSize { get; set; }
        public Int32 dwEncryptedFlag { get; set; }
        public UInt32 dwCRC32 { get; set; }
        public Int32 dwCompressedSize { get; set; }
        public UInt32 dwOffset { get; set; }
    }
}
