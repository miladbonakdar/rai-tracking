using System.ComponentModel;
using SharedKernel.Constants;

namespace Domain.Enums
{
    public enum MissionPhase
    {
        [Description(Dic.ProjectPhases.Unknown)]
        NotStarted,
        [Description(Dic.ProjectPhases.Started)]
        Started,

        [Description(Dic.ProjectPhases.Finished)]
        Finished,

        [Description(Dic.ProjectPhases.Canceled)]
        Canceled,
    }
}