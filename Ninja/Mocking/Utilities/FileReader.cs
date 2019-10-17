using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ninja
{
    public class FileReader : IFileReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
