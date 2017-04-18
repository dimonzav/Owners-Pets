namespace DataAccess.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Business.Models;

    public class Pet
    {
        [Key]
        public string PetId { get; set; }

        [Required]
        public string Name { get; set; }

        public string OwnerId { get; set; }

        public virtual Owner Owner { get; set; }

        public static explicit operator Pet(PetModel model)
        {
            if (model != null)
            {
                return new Pet
                {
                    PetId = model.PetId,
                    OwnerId = model.PetId,
                    Name = model.Name
                };
            }
            else
            {
                return null;
            }
        }
    }
}
