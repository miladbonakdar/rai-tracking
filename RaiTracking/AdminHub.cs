using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace RaiTracking
{
    [Authorize]
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AdminHub : Hub
    {
        public static string Name => nameof(AdminHub);

        public override async Task OnConnectedAsync()
        {
            AddCurrentConnection();
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            RemoveCurrentConnection();
            await base.OnDisconnectedAsync(exception);
        }

        private void RemoveCurrentConnection()
        {
            var adminId = GetCurrentAdminId();
            if (adminId is null) return;

            SignalRAdmins.Admins.TryGetValue(adminId.Value, out var existingAdminConnectionIds);
            if (existingAdminConnectionIds is null) return;
            existingAdminConnectionIds.Remove(Context.ConnectionId);

            if (existingAdminConnectionIds.Count == 0)
                SignalRAdmins.Admins.Remove(adminId.Value);
        }

        private void AddCurrentConnection()
        {
            var adminId = GetCurrentAdminId();
            if (adminId is null) return;

            SignalRAdmins.Admins.TryGetValue(adminId.Value, out var existingAdminConnectionIds);

            if (existingAdminConnectionIds is null)
                existingAdminConnectionIds = new HashSet<string>();
            else if
                (existingAdminConnectionIds.Contains(Context.ConnectionId)) return;

            existingAdminConnectionIds.Add(Context.ConnectionId);
            SignalRAdmins.Admins.TryAdd(adminId.Value, existingAdminConnectionIds);
        }

        private int? GetCurrentAdminId()
        {
            //TODO check if it is admin or not
            if (!Context.User.Identity.IsAuthenticated
                || Context.User.Identity.Name == null
                || string.IsNullOrWhiteSpace(Context.User.Identity.Name))
                return null;

            return int.Parse(Context.User.Identity.Name);
        }
    }
}