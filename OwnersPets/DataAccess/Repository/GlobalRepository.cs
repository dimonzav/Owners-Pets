namespace DataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DataAccess.Entities;
    using DataAccess.Helpers;
    using Microsoft.EntityFrameworkCore;

    public class GlobalRepository
    {
        private OwnerPetsContext context;

        public GlobalRepository(OwnerPetsContext context)
        {
            this.context = context;
        }

        public async Task<ResponseResult<Owner>> GetOwnersAsync(int page, int itemsPerPage, bool isDesc)
        {
            int skip = this.Skip(page, itemsPerPage);

            var items = await this.context.Owners.OrderBy(o => o.Name.ToLower()).ToListAsync();

            if (isDesc)
            {
                items = items.OrderByDescending(o => o.Name.ToLower()).Skip(skip).Take(itemsPerPage).ToList();
            }
            else
            {
                items = items.Skip(skip).Take(itemsPerPage).ToList();
            }

            var totalItems = await this.context.Owners.CountAsync();

            return new ResponseResult<Owner> { Items = items, TotalCount = totalItems };
        }

        public async Task<Owner> GetOwnerByIdAsync(string ownerId)
        {
            return await this.context.Owners.FirstOrDefaultAsync(o => o.OwnerId == ownerId);
        }

        public async Task<Owner> AddOwnerAsync(Owner owner)
        {
            owner.OwnerId = Guid.NewGuid().ToString();

            this.context.Owners.Add(owner);

            await this.context.SaveChangesAsync();

            return await Task.FromResult(owner);
        }

        public async Task<bool> DeleteOwnerAsync(string ownerId)
        {
            var ownerToDelete = this.context.Owners.Where(o => o.OwnerId == ownerId).FirstOrDefault();

            if (ownerToDelete != null)
            {
                this.context.Owners.Remove(ownerToDelete);
            }

            var petsToDelete = this.context.Pets.Where(p => p.OwnerId == ownerId).ToList();

            this.context.Pets.RemoveRange(petsToDelete);

            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<List<Pet>> GetOwnerPetsAsync(string ownerId, int page, int itemsPerPage, bool isDesc)
        {
            int skip = this.Skip(page, itemsPerPage);

            var items = await this.context.Pets.Where(p => p.OwnerId == ownerId).OrderBy(o => o.Name.ToLower()).ToListAsync();

            if (isDesc)
            {
                items = items.OrderByDescending(o => o.Name.ToLower()).Skip(skip).Take(itemsPerPage).ToList();
            }
            else
            {
                items = items.Skip(skip).Take(itemsPerPage).ToList();
            }

            return items;
        }

        public async Task<Pet> AddOwnerPetAsync(Pet pet)
        {
            pet.PetId = Guid.NewGuid().ToString();

            this.context.Pets.Add(pet);

            var owner = await this.context.Owners.FirstOrDefaultAsync(o => o.OwnerId == pet.OwnerId);

            owner.PetsCount++;

            await this.context.SaveChangesAsync();

            return pet;
        }

        public async Task<bool> DeleteOwnerPetAsync(string petId)
        {
            var petToDelete = this.context.Pets.Where(p => p.PetId == petId).FirstOrDefault();

            this.context.Pets.Remove(petToDelete);

            var owner = await this.context.Owners.FirstOrDefaultAsync(o => o.OwnerId == petToDelete.OwnerId);

            owner.PetsCount--;

            return await this.context.SaveChangesAsync() > 0;
        }

        private int Skip(int page, int itemsPerPage)
        {
            return (page - 1) * itemsPerPage;
        }
    }
}
