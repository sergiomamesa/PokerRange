using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Model.Enums;

namespace Poker.Ranges.Parser
{
    public class ActionFilterParser : IActionParser
    {
        private ActionType Action;
        private IActionParser ActionParser;

        public ActionFilterParser(ActionType action)
        {
            Action = action;
            ActionParser = new ActionParser();
        }

        public ActionType Parse(string action)
        {
            var result = ActionParser.Parse(action);
            if (result.ToString().Contains(Action.ToString()))
                return result;

            return ActionType.Fold;
        }
    }
}
