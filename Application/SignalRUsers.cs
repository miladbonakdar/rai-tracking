using System.Collections.Generic;

namespace Application
{
    public static class SignalRUsers
    {
        public static Dictionary<int, HashSet<string>> Users { get; }
            = new Dictionary<int, HashSet<string>>();
    }
}