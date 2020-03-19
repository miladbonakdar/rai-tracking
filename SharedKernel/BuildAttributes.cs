using System;
using System.ComponentModel;

namespace SharedKernel
{
    [Description("This section tested and it was fine.")]
    public class WasFineAttribute : Attribute
    {
        
    }
    
    [Obsolete("This section need test")]
    public class NeedTestAttribute : Attribute
    {
    }
}