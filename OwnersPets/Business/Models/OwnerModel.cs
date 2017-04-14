namespace Business.Models
{
    using System.Collections.Generic;

    public class OwnerModel
    {
        public string OwnerId { get; set; }

        public string Name { get; set; }

        public int PetsCount { get; set; }

        public virtual ICollection<PetModel> Pets { get; set; } 
    }
}
