using Poker.Model.Enums;
using Ranges.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Ranges.Reader
{
    public class FileReaderFactory
    {
        public FileReader CreateInstance(SituationType situation, PositionType hero, PositionType villain = PositionType.BigBlind)
        {
            if (situation == SituationType.RaiseFirstIn)
                return new FileReader("UTG/" + hero.ToString() + ".csv");

            throw new NotImplementedException();
        }
    }
}
