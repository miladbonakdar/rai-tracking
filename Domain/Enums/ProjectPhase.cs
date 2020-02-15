using System.ComponentModel;
using SharedKernel.Constants;

namespace Domain.Enums
{
    public enum ProjectPhase
    {
        [Description(Dic.ProjectPhases.Started)]
        Started,

        [Description(Dic.ProjectPhases.Finished)]
        Finished,

        [Description(Dic.ProjectPhases.Canceled)]
        Canceled,
    }
}