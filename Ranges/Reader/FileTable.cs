using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranges.Reader
{
    public class FileTable
    {
        public List<FileTableCell> Cells;

        public FileTable()
        {
            Cells = new List<FileTableCell>();
        }
    }
}
