﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int initialDamagePoints = 120;
        private const int initialHealthPoitns = 5;

        public TrapCard(string name) : base(name, initialDamagePoints, initialHealthPoitns)
        {
        }
    }
}
