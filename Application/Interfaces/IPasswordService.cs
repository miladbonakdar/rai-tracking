namespace Application.Interfaces
{
    public interface IPasswordService
    {
        string HashPassword(string password);
        bool Verify(string password, string hash);
    }
}