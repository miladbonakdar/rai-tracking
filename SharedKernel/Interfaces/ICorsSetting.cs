using System.Collections.Generic;

namespace SharedKernel.Interfaces
{
    public interface ICorsSetting
    {
        string PolicyName { get; }
        IEnumerable<string> AllowOrigins { get; }
    }
}