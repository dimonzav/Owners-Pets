using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DataAccess;

namespace OwnersPets.WebApi.Migrations
{
    [DbContext(typeof(OwnerPetsContext))]
    partial class OwnerPetsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("DataAccess.Entities.Owner", b =>
                {
                    b.Property<string>("OwnerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PetsCount");

                    b.HasKey("OwnerId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("DataAccess.Entities.Pet", b =>
                {
                    b.Property<string>("PetId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("OwnerId");

                    b.HasKey("PetId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("DataAccess.Entities.Pet", b =>
                {
                    b.HasOne("DataAccess.Entities.Owner", "Owner")
                        .WithMany("Pets")
                        .HasForeignKey("OwnerId");
                });
        }
    }
}
