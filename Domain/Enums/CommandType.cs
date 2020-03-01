using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SharedKernel.Constants;

namespace Domain.Enums
{
    public enum CommandType
    {
        [Description(Dic.CommandNames.UpdateStatus)]
        UpdateStatus,
        [Description(Dic.CommandNames.SetOtdrValue)]
        SetOtdrValue,
        [Description(Dic.CommandNames.NewProject)]
        NewMission,
        [Description(Dic.CommandNames.EditProject)]
        EditMission,
        [Description(Dic.CommandNames.FinishProject)]
        FinishMission,
        [Description(Dic.CommandNames.CancelProject)]
        CancelMission,
        [Description(Dic.CommandNames.SetSetting)]
        SetSetting
    }
}
