namespace OwnersPets.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Business.Models;
    using DataAccess.Entities;
    using DataAccess.Repository;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/Owners")]
    public class OwnersController : Controller
    {
        private GlobalRepository globalRepository;

        public OwnersController(GlobalRepository globalRepository)
        {
            this.globalRepository = globalRepository;
        }

        // GET: api/Owners
        [HttpGet]
        public async Task<IActionResult> GetOwners(int page, int itemsPerPage)
        {
            List<OwnerModel> ownerModels = new List<OwnerModel>();

            var ownersDb = await this.globalRepository.GetOwnersAsync(page, itemsPerPage);

            if (ownersDb.Items.Count > 0)
            {
                foreach (var owner in ownersDb.Items)
                {
                    OwnerModel model = new OwnerModel
                    {
                        OwnerId = owner.OwnerId,
                        Name = owner.Name,
                        PetsCount = owner.PetsCount
                    };

                    ownerModels.Add(model);
                }

                return this.Ok(new { Owners = ownerModels, TotalItems = ownersDb.TotalCount });
            }

            return this.BadRequest("There are any owners");
        }

        // POST: api/Owners
        [HttpPost]
        public async Task<IActionResult> AddOwner([FromBody]OwnerModel ownerModel)
        {
            var ownerDb = (Owner)ownerModel;

            var result = await this.globalRepository.AddOwnerAsync(ownerDb);

            if (result)
            {
                return this.Ok(ownerModel);
            }

            return this.BadRequest("Error add owner");
        }

        // DELETE: api/Owners/5
        [HttpDelete]
        [Route("DeleteOwner")]
        public async Task<IActionResult> DeleteOwner([FromQuery]string ownerId)
        {
            var result = await this.globalRepository.DeleteOwnerAsync(ownerId);

            if (result)
            {
                return this.Ok();
            }

            return this.BadRequest("Error delete owner");
        }
    }
}
