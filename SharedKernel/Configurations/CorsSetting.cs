using System.Collections.Generic;
using SharedKernel.Interfaces;

namespace Application.Configurations
{
    public class CorsSetting : ICorsSetting
    {
        public string PolicyName { get; set; }
        public IEnumerable<string> AllowOrigins { get; set; }
    }
}