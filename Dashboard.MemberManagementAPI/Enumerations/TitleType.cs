﻿using System.ComponentModel;

namespace Dashboard.MemberManagementAPI.Enumerations
{
    public enum TitleType
    {
        [Description("Mr.")]
        Mr = 1,
        [Description("Miss")]
        Miss = 2,
        [Description("Dr.")]
        Dr = 3,
        [Description("Mrs")]
        Mrs = 4
    }
}