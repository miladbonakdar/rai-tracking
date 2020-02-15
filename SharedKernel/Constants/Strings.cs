using System.Collections.Generic;

namespace SharedKernel.Constants
{
    public static class Constants
    {
        public static string StaticFilesBase = "";
        public const string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public static class CustomClaimTypes
        {
            public const string Fullname = nameof(CustomClaimTypes) + "." + nameof(Fullname);
            public const string PhoneNumber = nameof(CustomClaimTypes) + "." + nameof(PhoneNumber);
            public const string Number = nameof(CustomClaimTypes) + "." + nameof(Number);
            public const string Organization = nameof(CustomClaimTypes) + "." + nameof(Organization);
        }

        public static class AdminType
        {
            public const string SysAdmin = nameof(AdminType) + "." + nameof(SysAdmin);
            public const string RootAdmin = nameof(AdminType) + "." + nameof(RootAdmin);
            public const string OrganizationAdmin = nameof(AdminType) + "." + nameof(OrganizationAdmin);
            public const string Monitor = nameof(AdminType) + "." + nameof(Monitor);
            public const string OrganizationMonitor = nameof(AdminType) + "." + nameof(OrganizationMonitor);
            public const string Agent = nameof(AdminType) + "." + nameof(Agent);

            public static IEnumerable<string> All = new string[]
            {
                SysAdmin,
                Agent,
                Monitor,
                OrganizationAdmin,
                OrganizationMonitor,
                RootAdmin
            };
        }
    }
}