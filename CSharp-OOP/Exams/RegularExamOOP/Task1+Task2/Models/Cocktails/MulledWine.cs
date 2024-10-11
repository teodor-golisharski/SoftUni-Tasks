﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        private const double largeMulledWine = 13.5;
        public MulledWine(string cocktailName, string size) : base(cocktailName, size, largeMulledWine)
        {
        }
    }
}
