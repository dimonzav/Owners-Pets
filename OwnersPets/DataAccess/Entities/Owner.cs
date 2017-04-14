namespace DataAccess.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Owner
    {
        [Key]
        public string OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        public int PetsCount { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
