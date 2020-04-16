using SharedKernel.Constants;

namespace Application.DTO
{
    public class AuthorizedAdminDto
    {
        public AuthorizedAdminDto(AdminDto admin)
        {
            Admin = admin;
            Permission = new Permission(admin.AdminType);
        }

        public AdminDto Admin { get; }
        public Permission Permission { get; }
    }
}