using Poker.Extensions;
using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    class RaiseFirstInVillainRule : ISituationRule
    {
        public Func<List<ActionEvent>, PositionType, bool> Condition { get; set; }
        public Func<List<ActionEvent>, PositionType, SituationDeciderResult> Result { get; set; }

        public RaiseFirstInVillainRule()
        {
            Condition = (list, position) => list.IsOne(a => a.Action == ActionType.Raise);
            Result = (list, position) => new SituationDeciderResult()
            {
                Situation = SituationType.RaiseFirstIn,
                Action = list.FirstOrDefault(a => a.Action == ActionType.Raise).Action,
                Position = list.FirstOrDefault(a => a.Action == ActionType.Raise).Position
            };
        }
    }
}
