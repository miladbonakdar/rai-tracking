using System;

namespace Domain.Interfaces
{
    public interface IMission
    {
        int MissionId { set; get; }
        Mission Mission { set; get; }
    }
}