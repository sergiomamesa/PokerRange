using Poker.Model.Enums;
using Poker.Ranges.Parser;
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
        private string FileName { get; set; }

        internal FileReader(string fileName)
        {
            FileName = fileName;
        }

        public TableRange GetRange(IActionParser parser)
        {
            var table = new TableRange();

            var lines = File.ReadAllLines(FileName);
            var rowIterator = 0;
            foreach (var line in lines)
            {
                var columnIterator = 0;
                foreach (var value in line.Split(';'))
                {
                    var isSuited = columnIterator > rowIterator;
                    table.Cells.Add(new TableCell((RankType)columnIterator, (RankType)rowIterator, isSuited, parser.Parse(value)));
                    columnIterator++;
                }
                rowIterator++;
            }

            return table;
        }
    }
}
