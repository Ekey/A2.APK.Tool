using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace A2.Unpacker
{
    class ApkUnpack
    {
        static List<ApkEntry> m_EntryTable = new List<ApkEntry>();

        public static void iDoIt(String m_Archive, String m_DstFolder)
        {
            using (FileStream TApkStream = File.OpenRead(m_Archive))
            {
                var m_Header = new ApkHeader();

                m_Header.dwMagic = TApkStream.ReadUInt32();
                m_Header.dwArchiveSize = TApkStream.ReadInt32();
                m_Header.dwCompressedFlag = TApkStream.ReadInt32();
                m_Header.dwEncryptedFlag = TApkStream.ReadInt32();
                m_Header.dwTotalFiles = TApkStream.ReadInt32();
                m_Header.dwBaseOffset = TApkStream.ReadInt32();
                m_Header.dwTableOffset = TApkStream.ReadInt32();
                m_Header.dwTableSize = m_Header.dwArchiveSize - m_Header.dwTableOffset;

                if (m_Header.dwMagic != 0x4034B50)
                {
                    throw new Exception("[ERROR]: Invalid magic of APK archive file!");
                }

                if (m_Header.dwArchiveSize != TApkStream.Length)
                {
                    throw new Exception("[ERROR]: Invalid APK archive file!");
                }

                TApkStream.Seek(m_Header.dwTableOffset, SeekOrigin.Begin);
                var lpEntryTable = TApkStream.ReadBytes(m_Header.dwTableSize);

                if (m_Header.dwEncryptedFlag == 1)
                {
                    lpEntryTable = ApkCipher.iDecryptData(lpEntryTable);
                }

                if (m_Header.dwCompressedFlag == 1)
                {
                    var lpTemp = Zlib.iDecompress(lpEntryTable);

                    Array.Resize(ref lpEntryTable, lpTemp.Length);
                    Array.Copy(lpTemp, lpEntryTable, lpTemp.Length);
                }

                m_EntryTable.Clear();
                using (var TEntryReader = new MemoryStream(lpEntryTable))
                {
                    for (Int32 i = 0; i < m_Header.dwTotalFiles; i++)
                    {
                        var m_Entry = new ApkEntry();

                        m_Entry.m_FileName = Encoding.ASCII.GetString(TEntryReader.ReadBytes(128)).TrimEnd('\0');
                        m_Entry.dwDecompressedSize = TEntryReader.ReadInt32();
                        m_Entry.dwEncryptedFlag = TEntryReader.ReadInt32();
                        m_Entry.dwCRC32 = TEntryReader.ReadUInt32();
                        m_Entry.dwCompressedSize = TEntryReader.ReadInt32();
                        m_Entry.dwOffset = TEntryReader.ReadUInt32();

                        m_EntryTable.Add(m_Entry);
                    }

                    TEntryReader.Dispose();
                }

                foreach (var m_Entry in m_EntryTable)
                {
                    String m_FullPath = m_DstFolder + m_Entry.m_FileName;

                    Utils.iSetInfo("[UNPACKING]: " + m_Entry.m_FileName);
                    Utils.iCreateDirectory(m_FullPath);

                    TApkStream.Seek(m_Entry.dwOffset, SeekOrigin.Begin);
                    var lpTemp = TApkStream.ReadBytes(m_Entry.dwCompressedSize);

                    if (m_Entry.dwEncryptedFlag == 1)
                    {
                        lpTemp = ApkCipher.iDecryptData(lpTemp);
                    }

                    if (m_Entry.dwCompressedSize != m_Entry.dwDecompressedSize)
                    {
                        var lpBuffer = Zlib.iDecompress(lpTemp);
                        File.WriteAllBytes(m_FullPath, lpBuffer);
                    }
                    else
                    {
                        File.WriteAllBytes(m_FullPath, lpTemp);
                    }
                }

                TApkStream.Dispose();
            }
        }
    }
}
