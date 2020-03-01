using System;

namespace Domain.Interfaces
{
    public interface IMission
    {
        int MissionId {  get; }
        Mission Mission {  get; }
    }
}