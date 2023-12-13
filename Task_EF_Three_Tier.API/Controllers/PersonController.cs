using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_API_EF_Three_Tier.BLL.Interfaces;
using Task_EF_Three_Tier.API.Mappers;
using Task_EF_Three_Tier.API.Models.DTO;
using Task_EF_Three_Tier.API.Models.Forms;

namespace Task_EF_Three_Tier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonDTO>> GetAll()
        {
            return await _personRepository.GetAll().ContinueWith(t => t.Result.Select(t => t.ToPersonDTO()));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePersonForm form)
        {
            int id = await _personRepository.Create(form.ToPersonEntity());
            return (id > 0) ? Created($"https://localhost:7238/api/Person/{id}", form) : BadRequest();
        }
    }
}
