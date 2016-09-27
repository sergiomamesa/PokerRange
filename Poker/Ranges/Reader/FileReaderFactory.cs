using Poker.Model.Enums;
using Ranges.Reader;
using System;
using System.Configuration;

namespace Poker.Ranges.Reader
{
    public class FileReaderFactory
    {
        public FileReader CreateInstance(FileReaderFactoryParams parameters)
        {
            var filesPath = ConfigurationManager.AppSettings["RANGES_FILES"];
            if (parameters.Situation== SituationType.RaiseFirstIn)
                return new FileReader(String.Format("{0}\\RFI\\{1}.csv", filesPath, parameters.HeroPosition.ToString()));

            if (parameters.Situation == SituationType.FacingRaise)
                return new FileReader(String.Format("{0}\\FacingRaise\\{2}\\{1}.csv", filesPath, parameters.HeroPosition.ToString(), parameters.VillainPosition.ToString()));

            if (parameters.Situation == SituationType.RFIvs3Bet)
                return new FileReader(String.Format("{0}\\RFIvs3Bet\\{1}\\{2}.csv", filesPath, parameters.HeroPosition.ToString(), parameters.VillainPosition.ToString()));

            throw new Exception("Not valid SituationType");
        }
    }
}
