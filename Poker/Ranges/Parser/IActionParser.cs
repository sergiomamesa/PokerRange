using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Ranges.Parser
{
    public interface IActionParser
    {
        ActionType Parse(string action);
    }
}
