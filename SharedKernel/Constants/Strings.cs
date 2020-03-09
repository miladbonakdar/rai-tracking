﻿using System.Collections.Generic;

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

        public static class UserType
        {
            public const string SysAdmin = nameof(UserType) + "." + nameof(SysAdmin);
            public const string RootAdmin = nameof(UserType) + "." + nameof(RootAdmin);
            public const string OrganizationAdmin = nameof(UserType) + "." + nameof(OrganizationAdmin);
            public const string Monitor = nameof(UserType) + "." + nameof(Monitor);
            public const string OrganizationMonitor = nameof(UserType) + "." + nameof(OrganizationMonitor);
            public const string Agent = nameof(UserType) + "." + nameof(Agent);

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