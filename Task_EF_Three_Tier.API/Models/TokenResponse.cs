namespace Task_EF_Three_Tier.API.Models
{
    public class TokenResponse
    {
        private string? _token;

        public string? Token { get => _token;}

        public TokenResponse(string token)
        {
            _token = token;
        }
    }
}
