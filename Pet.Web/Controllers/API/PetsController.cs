using Microsoft.AspNet.Identity;
using Pet.Database;
using Pet.Services.Pet;
using System;
using System.Linq;
using System.Web.Http;

namespace Pet.Web.Controllers.API
{
    [Authorize]
    [RoutePrefix("api/pets")]
    public class PetsController : ApiController
    {
        private static UnitOfWorkFactory unitOfWorkFactory;
        private static IPetService petService;

        public PetsController()
        {
            unitOfWorkFactory = new UnitOfWorkFactory(new Config());
            petService = new PetService(unitOfWorkFactory);
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult GetAllPets(Guid? ownerId = null)
        {
            Database.Entities.Pet[] pets = petService.GetAllPets(ownerId).ToArray();
            return Ok(pets);
        }

        [Route("{petId}")]
        [HttpDelete]
        public IHttpActionResult DeletePet(Guid petId)
        {
            petService.Delete(petId);
            return Ok();
        }

        [Route("{petId}")]
        [HttpGet]
        public IHttpActionResult GetPet(Guid petId)
        {
            Database.Entities.Pet pet = petService.GetPet(petId);
            return Ok(pet);
        }


        [HttpPost]
        public IHttpActionResult Post(Models.Pet pet)
        {
            Database.Entities.Pet dbPet = new Database.Entities.Pet()
            {
                ID = Guid.NewGuid(),
                Adopted = pet.Adopted,
                Name = pet.Name,
                ImageUrl = pet.ImageUrl,
                Description = pet.Description,
                BirthDate = pet.BirthDate,
                Breed = pet.Breed,
                FurType = pet.FurType,
                Location = pet.Location,
                MainColour = pet.MainColour,
                PureBreed = pet.PureBreed,
                Size = pet.Size,
                Species = pet.Species,
                OwnerID = new Guid(User.Identity.GetUserId())
            };

            petService.Create(dbPet);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(Database.Entities.Pet pet)
        {
            petService.Update(pet);
            return Ok();
        }
    }
}