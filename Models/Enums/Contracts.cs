﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models.Enums
{
    public enum Contracts
    {
        [Description("HirePurchase")]
        HirePurchase = 1,
        [Description("ContinuedOwnership")]
        ContinuedOwnership = 2
    }
}
