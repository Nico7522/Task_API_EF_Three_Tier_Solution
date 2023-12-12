using System.ComponentModel.DataAnnotations;

namespace Task_EF_Three_Tier.API.Models.Forms
{
    public class CreateTaskForm
    {

        [Required]
        public string Title { get; set;  }

        [Required]
        public string Description { get; set; }


    }
}
