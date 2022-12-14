// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantsAPI;

namespace RestaurantsAPI.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20220815111918_AddTableKitchen")]
    partial class AddTableKitchen
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("RestaurantsAPI.Migrations.Restaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CloseTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("KitchenID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OpenTime")
                        .HasColumnType("TEXT");

                    b.Property<double>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("REAL")
                        .HasDefaultValue(0.0);

                    b.HasKey("Id");

                    b.HasIndex("KitchenID");

                    b.ToTable("Restaurant");

                    b.HasCheckConstraint("Rating", "Rating >= 0.0 AND Rating <= 5.0");
                });

            modelBuilder.Entity("RestaurantsAPI.Models.Kitchen", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("NameKitchen")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Kitchen");
                });

            modelBuilder.Entity("RestaurantsAPI.Migrations.Restaurant", b =>
                {
                    b.HasOne("RestaurantsAPI.Models.Kitchen", "Kitchen")
                        .WithMany("Restaurant")
                        .HasForeignKey("KitchenID");

                    b.Navigation("Kitchen");
                });

            modelBuilder.Entity("RestaurantsAPI.Models.Kitchen", b =>
                {
                    b.Navigation("Restaurant");
                });
#pragma warning restore 612, 618
        }
    }
}
