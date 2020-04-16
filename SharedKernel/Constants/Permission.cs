using JetBrains.Annotations;

namespace SharedKernel.Constants
{
    public class Permission
    {
        public AdminPermission Admin { get; }
        public AgentPermission Agent { get; }
        public DepoPermission Depo { get; }
        public MissionPermission Mission { get; }
        public StationPermission Station { get; }

        public Permission([NotNull] string userType)
        {
            Guard.ForValidRoleName(userType);
            Admin = new AdminPermission(userType);
            Agent = new AgentPermission(userType);
            Depo = new DepoPermission(userType);
            Mission = new MissionPermission(userType);
            Station = new StationPermission(userType);
        }

        public class AdminPermission
        {
            public AdminPermission(string userType)
            {
                Create = PermissionSet.Admin.Create.Contains(userType);
                Update = PermissionSet.Admin.Update.Contains(userType);
                UpdatePassword = PermissionSet.Admin.UpdatePassword.Contains(userType);
                Delete = PermissionSet.Admin.Delete.Contains(userType);
            }

            public bool Create { get; }
            public bool Update { get; }
            public bool UpdatePassword { get; }
            public bool Delete { get; }
        }

        public class MissionPermission
        {
            public MissionPermission(string userType)
            {
                Create = PermissionSet.Mission.Create.Contains(userType);
                Update = PermissionSet.Mission.Update.Contains(userType);
                Delete = PermissionSet.Mission.Delete.Contains(userType);
            }

            public bool Create { get; }
            public bool Update { get; }
            public bool Delete { get; }
        }

        public class DepoPermission
        {
            public DepoPermission(string userType)
            {
                Create = PermissionSet.Depo.Create.Contains(userType);
                Update = PermissionSet.Depo.Update.Contains(userType);
                UpdateLocation = PermissionSet.Depo.UpdateLocation.Contains(userType);
                Delete = PermissionSet.Depo.Delete.Contains(userType);
            }

            public bool Create { get; }
            public bool Update { get; }
            public bool UpdateLocation { get; }
            public bool Delete { get; }
        }

        public class AgentPermission
        {
            public AgentPermission(string userType)
            {
                Create = PermissionSet.Agent.Create.Contains(userType);
                Update = PermissionSet.Agent.Update.Contains(userType);
                ResetPassword = PermissionSet.Agent.ResetPassword.Contains(userType);
                UpdateSetting = PermissionSet.Agent.UpdateSetting.Contains(userType);
                Delete = PermissionSet.Agent.Delete.Contains(userType);
            }

            public bool Create { get; }
            public bool Update { get; }
            public bool ResetPassword { get; }
            public bool UpdateSetting { get; }
            public bool Delete { get; }
        }
        
        public class StationPermission
        {
            public StationPermission(string userType)
            {
                Create = PermissionSet.Station.Create.Contains(userType);
                Update = PermissionSet.Station.Update.Contains(userType);
                Delete = PermissionSet.Station.Delete.Contains(userType);
            }

            public bool Create { get; }
            public bool Update { get; }
            public bool Delete { get; }
        }
    }


    public static class PermissionSet
    {
        public static class Admin
        {
            public const string Create = Constants.UserGroup.AllMainAdmins;
            public const string Update = Constants.UserGroup.AllMainAdmins;
            public const string UpdatePassword = Constants.UserGroup.AllMainAdmins;
            public const string Delete = Constants.UserGroup.AllMainAdmins;
        }

        public static class Agent
        {
            public const string Create = Constants.UserGroup.AllMainAdmins;
            public const string Update = Constants.UserGroup.AllMainAdmins;
            public const string Delete = Constants.UserGroup.AllMainAdmins;
            public const string UpdateSetting = Constants.UserGroup.AllMainAdmins;
            public const string ResetPassword = Constants.UserGroup.AllMainAdmins;
        }

        public static class Depo
        {
            public const string Create = Constants.UserGroup.AllMainAdmins;
            public const string Update = Constants.UserGroup.AllMainAdmins;
            public const string Delete = Constants.UserGroup.AllMainAdmins;
            public const string UpdateLocation = Constants.UserGroup.AllMainAdmins;
        }
        
        public static class Station
        {
            public const string Create = Constants.UserGroup.AllMainAdmins;
            public const string Update = Constants.UserGroup.AllMainAdmins;
            public const string Delete = Constants.UserGroup.AllMainAdmins;
        }

        public static class Mission
        {
            public const string Create = Constants.UserGroup.AllMainAdmins;
            public const string Update = Constants.UserGroup.AllMainAdmins;
            public const string Delete = Constants.UserGroup.AllMainAdmins;
        }
    }
}