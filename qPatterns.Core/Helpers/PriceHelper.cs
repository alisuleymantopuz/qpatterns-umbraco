﻿using System;

namespace qPatterns.Core.Helpers
{
    public static class PriceHelper
    {
        public static string FormatMoney(this decimal price)
        {
            return String.Format("${0}", price);
        }
    }
}
