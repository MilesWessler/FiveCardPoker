using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{

    public class FileWriter
    {
        private string _fileName;
        public FileWriter(string filename)
        {
            this._fileName = filename;
        }

    
        public void WriteObjectToFile(object obj)
        {
            using (FileStream fs = new FileStream(_fileName, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(obj);
                }
            }
        }
    }
}