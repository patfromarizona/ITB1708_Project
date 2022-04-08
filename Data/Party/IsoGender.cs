﻿using System.ComponentModel;

namespace TeamUP.Data.Party
{
    public enum IsoGender
    {
        [Description("Not Known")]NotKnown = 0,
        [Description("Male")] Male = 1,
        [Description("Female")] Female = 2,
        [Description("Not Applicable")] NotApplicable = 9,
    }
}
