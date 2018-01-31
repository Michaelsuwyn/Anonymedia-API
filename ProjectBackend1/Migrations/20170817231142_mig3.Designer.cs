using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjectBackend1.Models;

namespace ProjectBackend1.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20170817231142_mig3")]
    partial class mig3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectBackend1.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("content");

                    b.Property<DateTime>("timeCreated");

                    b.Property<int>("userId");

                    b.HasKey("ID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("ProjectBackend1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("userPass");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
        }
    }
}
