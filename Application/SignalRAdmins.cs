using System.Collections.Generic;

namespace Application
{
    public static class SignalRAdmins
    {
        public static Dictionary<int, HashSet<string>> Users { get; }
            = new Dictionary<int, HashSet<string>>();
    }
}