namespace DataAccess.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Business.Models;

    public class Owner
    {
        [Key]
        public string OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        public int PetsCount { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public static explicit operator Owner(OwnerModel model)
        {
            if (model != null)
            {
                return new Owner
                {
                    OwnerId = model.OwnerId,
                    Name = model.Name,
                    PetsCount = model.PetsCount
                };
            }
            else
            {
                return null;
            }
        }
    }
}
