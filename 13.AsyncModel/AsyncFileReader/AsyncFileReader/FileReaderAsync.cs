using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFileReader
{
    public class FileReaderAsync
    {
        private string _fileName { get; set; }

        public FileReaderAsync(string FileName)
        {
            _fileName = FileName;
        }
    }
}
