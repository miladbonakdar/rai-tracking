using System;
using System.ComponentModel;

namespace RaiTracking
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