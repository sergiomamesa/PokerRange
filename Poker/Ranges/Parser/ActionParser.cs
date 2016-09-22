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
        public ActionType Parse(string action)
        {
            if (action == "F")
                return ActionType.Fold;

            if (action == "L")
                return ActionType.Limp;

            if (action == "C")
                return ActionType.Call;

            if (action == "R")
                return ActionType.Raise;

            if (action == "RF")
                return ActionType.RaiseOrFold;

            if (action == "RC")
                return ActionType.RaiseOrCall;

            if (action == "RCF")
                return ActionType.RaiseOrCallOrFold;

            if (action == "CF")
                return ActionType.CallOrFold;

            throw new NotImplementedException();
        }
    }
}
