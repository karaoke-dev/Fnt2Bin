using SharpFNT;
using System;
using System.IO;

namespace Fnt2Bin
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(path, "*.fnt");
            foreach (var file in files)
            {
                var font = BitmapFont.FromFile(file);

                // This value is ignored for Unicode fonts, but serializing will fail
                // if this is empty so just set it to ANSI (0 in binary)
                if (font.Info.Charset == string.Empty)
                {
                    font.Info.Charset = "ANSI";
                }

                font.Save(Path.ChangeExtension(file, "bin"), FormatHint.Binary);

                Console.WriteLine($"Process file : {file} success.");
            }
            
        }
    }
}
