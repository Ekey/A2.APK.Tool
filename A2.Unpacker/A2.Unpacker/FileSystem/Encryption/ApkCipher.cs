﻿using System;

namespace A2.Unpacker
{
    class ApkCipher
    {
        private static Byte[] lpKey = new Byte[] {
            0x03, 0x15, 0x7A, 0xA8, 0x5B, 0xA6, 0x6A, 0x49, 0xBF, 0x53, 0x35, 0xE5, 0x9E, 0x0E, 0xEC, 0xB8,
            0x5E, 0x15, 0x1F, 0xC1, 0x4F, 0xEC, 0x77, 0xE8, 0xB7, 0x4E, 0x87, 0xE6, 0xF5, 0x3C, 0xB3, 0x43,
            0xFF, 0x64, 0x0D, 0xAC, 0x5A, 0x77, 0xB8, 0xDD, 0x30, 0x74, 0x8C, 0x4A, 0x9A, 0x9B, 0xBC, 0x0A,
            0xA4, 0xAD, 0xBB, 0x13, 0x4B, 0x8C, 0xD4, 0x80, 0xCE, 0x65, 0x1D, 0x08, 0x5A, 0x6A, 0x6F, 0x25,
            0xCA, 0x08, 0xD4, 0x1B, 0xA4, 0x72, 0x14, 0xED, 0x97, 0x22, 0x4A, 0x2E, 0xB8, 0x96, 0x4B, 0x8E,
            0x96, 0x93, 0xF1, 0x28, 0xB2, 0x0B, 0x3C, 0xF8, 0x5D, 0xAA, 0xA9, 0x82, 0x13, 0x6E, 0xC1, 0xA9,
            0x13, 0x60, 0x89, 0x5B, 0x16, 0xCF, 0x9E, 0x5F, 0xD4, 0xCC, 0x2E, 0xF5, 0xC9, 0x4C, 0x1C, 0xEE,
            0xE3, 0x3F, 0x29, 0xB3, 0x06, 0x70, 0x43, 0x3D, 0xF5, 0x90, 0xA2, 0x42, 0x02, 0x98, 0x50, 0xFD,
            0x6E, 0x79, 0xA9, 0xAD, 0xAD, 0x7F, 0xAB, 0x60, 0x2C, 0xB8, 0x43, 0x76, 0x8F, 0x5F, 0xE6, 0xA7,
            0x19, 0xE0, 0xB9, 0xB5, 0x62, 0x6B, 0xD4, 0x47, 0x69, 0x34, 0x0E, 0x6D, 0xA4, 0x52, 0xE3, 0x64,
            0x79, 0x52, 0x7C, 0xF5, 0x3F, 0x53, 0x5E, 0x8B, 0x1B, 0xFD, 0x21, 0xF7, 0xBA, 0x68, 0xF9, 0xDF,
            0x68, 0xA8, 0x96, 0x0F, 0x8B, 0x01, 0x97, 0x58, 0x8C, 0x1E, 0xEF, 0xB3, 0x41, 0x44, 0x21, 0xDA,
            0xD3, 0xC3, 0xDB, 0x2D, 0xCD, 0x0B, 0xF0, 0x5C, 0x59, 0xD6, 0x99, 0xE7, 0x01, 0x15, 0x67, 0x32,
            0xE0, 0x12, 0x2F, 0xCD, 0xA2, 0xDE, 0x52, 0xCE, 0xEC, 0xEF, 0x77, 0x0E, 0xBC, 0x38, 0x64, 0x8D,
            0x87, 0xEC, 0x5C, 0xFF, 0xC8, 0x66, 0x0C, 0x8A, 0x60, 0xE1, 0x2E, 0x00, 0x43, 0xA9, 0x37, 0x9C,
            0x11, 0xAA, 0xB9, 0x98, 0xED, 0x21, 0x35, 0xD4, 0xC3, 0xDE, 0x65, 0x54, 0x9D, 0x1C, 0xB0, 0xA9
        };

        public static Byte[] iDecryptData(Byte[] lpBuffer)
        {
            for (Int32 i = 0; i < lpBuffer.Length; i++)
            {
                lpBuffer[i] ^= lpKey[i % lpKey.Length];
            }

            return lpBuffer;
        }
    }
}