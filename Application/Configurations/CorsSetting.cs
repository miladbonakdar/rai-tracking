using System.Collections.Generic;
using Application.Interfaces;

namespace Application.Configurations
{
    public class CorsSetting : ICorsSetting
    {
        public string PolicyName { get; set; }
        public IEnumerable<string> AllowOrigins { get; set; }
    }
}
