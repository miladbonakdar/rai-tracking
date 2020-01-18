using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    public enum CommandType
    {
        UpdateStatus,
        SetOtdrValue,
        NewMission,
        EditMission,
        FinishMission,
        CancelMission,
        SetSetting
    }
}
