namespace Task_EF_Three_Tier.API.Models.DTO
{
    public class PersonDTO
    {
        public int PersonId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Role { get; set; }
    }
}
