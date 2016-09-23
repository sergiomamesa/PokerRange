using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class SituationRule
    {
       public Func<List<ActionEvent>, PositionType, bool> Condition { get; set; }
       public SituationType Result { get; set; }
    }
}
