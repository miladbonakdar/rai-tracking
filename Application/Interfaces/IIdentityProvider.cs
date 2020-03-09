using System.Security.Claims;

namespace Application.Interfaces
{
    public interface IIdentityProvider
    {
        void SetUser(ClaimsPrincipal user);
        public bool HasValue { get; }
        public bool Authenticated { get; }
        public bool IsAgent { get; }
        public bool IsAdmin { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string Role { get; }
        public int Id { get; }
        public int OrganizationId { get; }
        public string Fullname { get; }
    }
}