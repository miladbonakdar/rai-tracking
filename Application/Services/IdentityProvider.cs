using System;
using System.Security.Claims;
using Application.Interfaces;
using SharedKernel.Constants;

namespace Application.Services
{
    class IdentityProvider : IIdentityProvider
    {
        private bool _configured;
        public bool HasValue { get; private set; }
        public bool Authenticated => HasValue;
        public bool IsAgent => Role == Constants.AdminType.Agent;
        public bool IsAdmin => !IsAgent;
        public string PhoneNumber { get; private set; }
        public string Number { get;  private set;}
        public string Email { get;  private set;}
        public string Role { get;  private set;}
        public int Id { get;  private set;}
        public int OrganizationId { get;  private set;}
        public string Fullname { get;  private set;}

        public void SetUser(ClaimsPrincipal user)
        {
            if (_configured) throw new Exception("you can only set the provider ones per request");
            _configured = true;
            
            HasValue = user.Identity.IsAuthenticated;
            if (!HasValue)
            {
                Fullname = "System";
                Id = -1;
                return;
            }
            Id = int.Parse(user.Identity.Name);
            
            foreach (var userClaim in user.Claims)
            {
                switch (userClaim.Type)
                {
                    case ClaimTypes.Role:
                        Role = userClaim.Value;
                        continue;
                    case ClaimTypes.Email:
                        Email = userClaim.Value;
                        continue;
                    case Constants.CustomClaimTypes.Fullname:
                        Fullname = userClaim.Value;
                        continue;
                    case Constants.CustomClaimTypes.Organization:
                        OrganizationId = int.Parse(userClaim.Value);
                        continue;
                    case Constants.CustomClaimTypes.PhoneNumber:
                        PhoneNumber = userClaim.Value;
                        continue;
                    case Constants.CustomClaimTypes.Number:
                        Number = userClaim.Value;
                        continue;
                }
            }
        }
    }
}