namespace DataAccess.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;

    public class GlobalRepository
    {
        private OwnerPetsContext context;

        public GlobalRepository(OwnerPetsContext context)
        {
            this.context = context;
        }

        public async Task<List<Owner>> GetOwnersAsync()
        {
            return await this.context.Owners.ToListAsync();
        }

        public async Task<bool> AddOwnerASync(Owner owner)
        {
            owner.OwnerId = Guid.NewGuid().ToString();
            this.context.Owners.Add(owner);

            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOwnerAsync(string ownerId)
        {
            var ownerToDelete = this.context.Owners.Where(o => o.OwnerId == ownerId).FirstOrDefault();
            this.context.Owners.Remove(ownerToDelete);
            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<List<Pet>> GetOwnerPetsAsync(string ownerId)
        {
            return await this.context.Pets.Where(p => p.OwnerId == ownerId).ToListAsync();
        }

        public async Task<bool> AddOwnerPetAsync(Pet pet)
        {
            pet.PetId = Guid.NewGuid().ToString();
            this.context.Pets.Add(pet);
            return await this.context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOwnerPetAsync(string petId)
        {
            var petToDelete = this.context.Pets.Where(p => p.PetId == petId).FirstOrDefault();
            this.context.Pets.Remove(petToDelete);
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}
