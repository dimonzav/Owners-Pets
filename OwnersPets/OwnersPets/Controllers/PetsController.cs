namespace OwnersPets.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Business.Models;
    using DataAccess.Entities;
    using DataAccess.Repository;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/Pets")]
    public class PetsController : Controller
    {
        private GlobalRepository globalRepository;

        public PetsController(GlobalRepository globalRepository)
        {
            this.globalRepository = globalRepository;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<IActionResult> GetOwnerPets(string ownerId)
        {
            var ownerWithPetsDb = await this.globalRepository.GetOwnerByIdAsync(ownerId);

            if (ownerWithPetsDb != null)
            {

                OwnerModel ownerModel = new OwnerModel
                {
                    OwnerId = ownerWithPetsDb.OwnerId,
                    Name = ownerWithPetsDb.Name,
                    PetsCount = ownerWithPetsDb.PetsCount
                };

                foreach (var pet in ownerWithPetsDb.Pets)
                {
                    PetModel petModel = new PetModel
                    {
                        PetId = pet.PetId,
                        Name = pet.Name
                    };

                    ownerModel.Pets.Add(petModel);
                }

                return this.Ok(ownerModel);
            }

            return this.BadRequest("Error retrieving owner's pets");
        }

        // POST: api/Pets
        [HttpPost]
        public async Task<IActionResult> AddOwnerPet([FromBody]PetModel petModel)
        {
            var petDb = (Pet)petModel;

            var result = await this.globalRepository.AddOwnerPetAsync(petDb);

            if (result)
            {
                return this.Ok();
            }

            return this.BadRequest("Error add owner's pet");
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwnerPet(string petId)
        {
            var result = await this.globalRepository.DeleteOwnerPetAsync(petId);

            if (result)
            {
                return this.Ok();
            }

            return this.BadRequest("Error delete owner's pet");
        }
    }
}
