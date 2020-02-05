namespace Application.DTO
{
    public class AuthenticatedClientDto
    {
        public AuthenticatedClientDto(PersonDto client, string token)
        {
            Client = client;
            Token = token;
        }

        public PersonDto Client { get; }
        public string Token { get; }
    }
}