using Application.Interfaces;

namespace Infrastructure
{
    public class PasswordService : IPasswordService, IHasher
    {
        public string HashPassword(string password)
            => BCrypt.Net.BCrypt.HashPassword(password);

        public bool Verify(string password, string hash)
            => BCrypt.Net.BCrypt.Verify(password, hash);

        public string Hash(string text)
        {
            var hashedValue = 3074457345618258791ul;
            foreach (var t in text)
            {
                hashedValue += t;
                hashedValue *= 3074457345618258799ul;
            }

            return hashedValue.ToString();
        }
    }
}