using Poker.Model;
using Poker.Model.Enums;
using System;

namespace Poker.Logic
{
    public class TableFactory
    {
        public Table CreateInstance(TableType type)
        {
            if (type == TableType.SixMax)
                return new Table(6);

            if (type == TableType.FullRing)
                return new Table(9);

            if (type == TableType.HeadsUp)
                return new Table(2);

            throw new Exception("Invalid table type");
        }
    }
}
