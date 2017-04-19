namespace Business.Models
{
    using Business.Models;

    public class PetModel
    {
        public string PetId { get; set; }

        public string Name { get; set; }

        public string OwnerId { get; set; }

        public virtual OwnerModel Owner { get; set; }
    }
}
