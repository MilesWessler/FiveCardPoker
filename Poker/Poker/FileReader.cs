using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class FileReader
    {
        private readonly string _fileName;

        public FileReader(string fileName)
        {
            _fileName = fileName;
        }

        public string ReadFromFile()
        {
            using (FileStream fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
