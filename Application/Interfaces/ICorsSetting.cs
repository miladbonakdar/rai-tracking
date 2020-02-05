using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ICorsSetting
    {
        string PolicyName { get; }
        IEnumerable<string> AllowOrigins { get; }
    }
}