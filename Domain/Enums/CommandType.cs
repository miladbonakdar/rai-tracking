using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    public enum CommandType
    {
        UpdateStatus,
        SetOtdrValue,
        NewProject,
        EditProject,
        FinishProject,
        CancelProject,
        SetSetting
    }
}
