using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Ranges.Parser
{
    public class ActionParser
    {
        private readonly Dictionary<string, ActionType> Map;

        public ActionParser()
        {
            Map = new Dictionary<string, ActionType>();
            Map.Add("F", ActionType.Fold);
            Map.Add("L", ActionType.Limp);
            Map.Add("C", ActionType.Call);
            Map.Add("R", ActionType.Raise);
            Map.Add("RF", ActionType.RaiseOrFold);
            Map.Add("RC", ActionType.RaiseOrCall);
            Map.Add("RCF", ActionType.RaiseOrCallOrFold);
            Map.Add("CF", ActionType.CallOrFold);
        }

        public ActionType Parse(string action)
        {
            if (Map.ContainsKey(action))
                return Map[action];

            throw new NotImplementedException();
        }
    }
}
