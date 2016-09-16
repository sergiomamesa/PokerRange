using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranges.Reader
{
    public class FileReader
    {
        public List<TableCell> Cells;

        public FileReader(string fileName)
        {
            var tableRange = new TableRange();

            var lines = File.ReadAllLines(fileName);

            var fileTable = new FileTable();
            var rowIterator = 0;
            foreach (var line in lines)
            {
                var columnIterator = 0;
                foreach (var value in line.Split(','))
                {
                    fileTable.Cells.Add(new FileTableCell((Enums.RankType)columnIterator, (Enums.RankType)rowIterator, value));
                    columnIterator++;
                }
                rowIterator++;
            }
        }
    }
}
