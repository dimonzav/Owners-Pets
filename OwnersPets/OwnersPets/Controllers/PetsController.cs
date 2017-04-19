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
        public async Task<IActionResult> GetOwnerPets(string ownerId, int page, int itemsPerPage, bool isDesc)
        {
            List<PetModel> petModels = new List<PetModel>();

            var ownerPetsDb = await this.globalRepository.GetOwnerPetsAsync(ownerId, page, itemsPerPage, isDesc);

            var owner = await this.globalRepository.GetOwnerByIdAsync(ownerId);

            if (owner != null)
            {
                OwnerModel ownerModel = new OwnerModel
                {
                    OwnerId = owner.OwnerId,
                    Name = owner.Name,
                    PetsCount = owner.PetsCount
                };

                if (ownerPetsDb.Count > 0)
                {
                    foreach (var pet in ownerPetsDb)
                    {
                        PetModel petModel = new PetModel
                        {
                            PetId = pet.PetId,
                            Name = pet.Name
                        };

                        ownerModel.Pets.Add(petModel);
                    }
                }

                return this.Ok(ownerModel);
            }
            else
            {
                return this.BadRequest("Error retrieving owner");
            }
        }

        // POST: api/Pets
        [HttpPost]
        public async Task<IActionResult> AddOwnerPet([FromBody]PetModel petModel)
        {
            var petDb = (Pet)petModel;

            petDb = await this.globalRepository.AddOwnerPetAsync(petDb);

            if (petDb != null)
            {
                PetModel model = new PetModel
                {
                    PetId = petDb.PetId,
                    Name = petDb.Name
                };

                return this.Ok(model);
            }

            return this.BadRequest("Error add owner's pet");
        }

        // DELETE: api/Pets/5
        [HttpDelete]
        [Route("DeleteOwnerPet")]
        public async Task<IActionResult> DeleteOwnerPet([FromQuery]string petId)
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
