using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public interface ISituationRule
    {
       Func<List<ActionEvent>, PositionType, bool> Condition { get; set; }
       Func<List<ActionEvent>,PositionType, SituationDeciderResult> Result { get; set; }
    }
}
