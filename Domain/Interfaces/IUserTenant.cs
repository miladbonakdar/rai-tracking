using System;

namespace Domain.Interfaces
{
    public interface IUserTenant
    {
        Guid UserId { set; get; }
        User User { set; get; }
    }
}