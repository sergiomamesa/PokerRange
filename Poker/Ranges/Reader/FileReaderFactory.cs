using Poker.Model.Enums;
using Ranges.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Poker.Ranges.Reader
{
    public class FileReaderFactory
    {
        public FileReader CreateInstance(SituationType situation, PositionType heroPosition, PositionType villainPosition = PositionType.BigBlind)
        {
            var filesPath = ConfigurationManager.AppSettings["RANGES_FILES"];

            if (situation == SituationType.RaiseFirstIn)
                return new FileReader(String.Format("{0}\\RFI\\{1}.csv", filesPath, heroPosition.ToString()));

            if (situation == SituationType.FacingRaise)
                return new FileReader(String.Format("{0}\\FacingRaise\\{1}_{2}.csv", filesPath, heroPosition.ToString(), villainPosition.ToString()));

            if (situation == SituationType.RFIvs3Bet)
                return new FileReader(String.Format("{0}\\RFIvs3Bet\\{1}_{2}.csv", filesPath, heroPosition.ToString(), villainPosition.ToString()));

            throw new Exception("Not valid SituationType");
        }
    }
}
