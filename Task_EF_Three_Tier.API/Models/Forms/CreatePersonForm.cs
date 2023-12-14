using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Task_EF_Three_Tier.API.Models.Forms
{
    public class CreatePersonForm
    {

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        [DefaultValue("email")]
        public string? Email { get; set; }

        [Required]
        [MinLength(7)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{7,}$")]
        [DefaultValue("password")]

        public string? Password { get; set; }
    }
}
