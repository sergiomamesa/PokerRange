using Poker.Model;
using Poker.Model.Enums;
using System.Collections.Generic;

namespace Poker.Logic
{
    interface ISituationDecider
    {
        List<ActionEvent> ActionEventList { get; set; }
        PositionType Position { get; set; }
        List<SituationRule> SituationRules { get; set; }
    }
}
