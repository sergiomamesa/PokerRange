﻿using Poker.Extensions;
using Poker.Model;
using Poker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Logic
{
    public class VillainPositionDecider
    {
        private readonly List<ActionEvent> ActionEventList;
        private readonly PositionType HeroPosition;

        public VillainPositionDecider(List<ActionEvent> actionEventList, PositionType heroPosition)
        {
            ActionEventList = actionEventList;
            HeroPosition = heroPosition;
        }

        public PositionType CalculateVillainPosition()
        {
            var raisesList = ActionEventList.Where(i => i.Action == ActionType.Raise).Where(i => i.Position != HeroPosition);
            if (raisesList.IsOne())
                return raisesList.First().Position;

            return default(PositionType);
        }
    }
}
