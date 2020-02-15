using System.Collections.Generic;

namespace Application
{
    public static class SignalRAdmins
    {
        public static Dictionary<int, HashSet<string>> Admins { get; }
            = new Dictionary<int, HashSet<string>>();
    }
}