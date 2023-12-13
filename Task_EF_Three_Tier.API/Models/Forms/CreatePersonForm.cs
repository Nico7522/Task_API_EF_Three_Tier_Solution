using System.ComponentModel.DataAnnotations;

namespace Task_EF_Three_Tier.API.Models.Forms
{
    public class CreatePersonForm
    {

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }
    }
}
