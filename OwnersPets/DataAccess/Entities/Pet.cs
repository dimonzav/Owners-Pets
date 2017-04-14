namespace DataAccess.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Pet
    {
        [Key]
        public string PetId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
