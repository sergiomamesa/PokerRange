using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Ranges.Reader
{
    public class FileReaderFactoryParams
    {
        public SituationType Situation { get; set; }
        public PositionType HeroPosition { get; set; }
        public PositionType VillainPosition { get; set; }
    }
}
