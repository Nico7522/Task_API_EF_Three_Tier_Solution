using Task_EF_Three_Tier.API.Models.DTO;

namespace Task_EF_Three_Tier.API.Models
{
    public class AuthResponse
    {
        private string? _token;
        private PersonDTO _person;

        public string? Token { get => _token;}
        public PersonDTO Person { get => _person; set => _person = value; }

        public AuthResponse(string token, PersonDTO person)
        {
            _token = token;
            Person = person;
        }
    }
}
