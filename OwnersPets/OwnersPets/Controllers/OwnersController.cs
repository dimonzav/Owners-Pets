namespace OwnersPets.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Business.Models;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/Owners")]
    public class OwnersController : Controller
    {
        // GET: api/Owners
        [HttpGet]
        public async Task<IActionResult> GetOwners()
        {
            return await Task.FromResult(this.Ok(new List<OwnerModel>()
            {
                new OwnerModel { OwnerId = "ssds", Name = "John", PetsCount = 3 },
                new OwnerModel { OwnerId = "sdwe", Name = "value2", PetsCount = 5 }
            }));
        }

        // POST: api/Owners
        [HttpPost]
        public async Task<IActionResult> AddOwner([FromBody]OwnerModel ownerModel)
        {
            return await Task.FromResult(this.Ok(true));
        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(string ownerId)
        {
            return await Task.FromResult(this.Ok(true));
        }
    }
}
