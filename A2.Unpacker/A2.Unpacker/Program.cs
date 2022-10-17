using System;
using System.IO;

namespace A2.Unpacker
{
    class Program
    {
        private static String m_Title = "Archlord 2 APK Unpacker";

        static void Main(String[] args)
        {
            Console.Title = m_Title;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(m_Title);
            Console.WriteLine("(c) 2022 Ekey (h4x0r) / v{0}\n", Utils.iGetApplicationVersion());
            Console.ResetColor();

            if (args.Length != 2)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[Usage]");
                Console.WriteLine("    A2.Unpacker <m_File> <m_Directory>\n");
                Console.WriteLine("    m_File - Source of APK file");
                Console.WriteLine("    m_Directory - Destination directory\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[Examples]");
                Console.WriteLine("    A2.Unpacker E:\\Games\\A2\\Data\\Table.apk D:\\Unpacked");
                Console.ResetColor();
                return;
            }

            String m_ApkFile = args[0];
            String m_Output = Utils.iCheckArgumentsPath(args[1]);

            if (!File.Exists(m_ApkFile))
            {
                Utils.iSetError("[ERROR]: Input Apk file -> " + m_ApkFile + " <- does not exist");
                return;
            }

            ApkUnpack.iDoIt(m_ApkFile, m_Output);
        }
    }
}
