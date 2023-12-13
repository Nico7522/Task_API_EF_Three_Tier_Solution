using Task_API_EF_Three_Tier.DAL.Entities;
using Task_EF_Three_Tier.API.Models.DTO;
using Task_EF_Three_Tier.API.Models.Forms;

namespace Task_EF_Three_Tier.API.Mappers
{
    public static class PersonMappers
    {
        public static PersonEntity ToPersonEntity(this CreatePersonForm form)
        {
            return new PersonEntity()
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
            };
        }

        public static PersonDTO ToPersonDTO(this PersonEntity entity)
        {
            return new PersonDTO()
            {
                PersonId = entity.PersonId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
            };
        }
    }
}
