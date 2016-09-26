using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;

namespace Poker.Logic
{
    public class TableFactory
    {
        public Dictionary<TableType, int> Map { get; set; }

        public TableFactory()
        {
            Map = new Dictionary<TableType, int>();
            Map.Add(TableType.SixMax, 6);
            Map.Add(TableType.FullRing, 9);
            Map.Add(TableType.HeadsUp, 2);
        }

        public Table CreateInstance(TableType type)
        {
            if (Map.ContainsKey(type))
                return new Table(Map[type]);

            throw new Exception("Invalid table type");
        }
    }
}
