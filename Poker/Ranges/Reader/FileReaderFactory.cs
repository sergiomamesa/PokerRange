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
        public FileReader CreateInstance(SituationType situation, PositionType heroPosition, PositionType villainPosition = PositionType.BigBlind)
        {
            if (situation == SituationType.RaiseFirstIn)
                return new FileReader(String.Format("RFI/{0}.csv", heroPosition.ToString()));

            if (situation == SituationType.FacingRaise)
                throw new NotImplementedException();

            if (situation == SituationType.RFIvs3Bet)
                throw new NotImplementedException();

            throw new NotImplementedException();
        }
    }
}
