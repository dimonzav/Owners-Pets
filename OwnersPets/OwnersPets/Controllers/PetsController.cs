namespace OwnersPets.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Business.Models;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/Pets")]
    public class PetsController : Controller
    {
        // GET: api/Pets
        [HttpGet]
        public async Task<IActionResult> GetOwnerPets(string ownerId)
        {
            return await Task.FromResult(this.Ok(new List<PetModel>()
            {
                new PetModel { PetId = "sdcx", Name = "Dixi" },
                new PetModel { PetId = "cvcv", Name = "value2" }
            }));
        }

        // POST: api/Pets
        [HttpPost]
        public async Task<IActionResult> AddOwnerPet([FromBody]PetModel petModel)
        {
            return await Task.FromResult(this.Ok(true));
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwnerPet(string petId)
        {
            return await Task.FromResult(this.Ok(true));
        }
    }
}
