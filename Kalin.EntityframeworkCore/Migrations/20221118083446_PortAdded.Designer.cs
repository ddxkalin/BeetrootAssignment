// <auto-generated />
using System;
using Kalin.EntityframeworkCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kalin.EntityframeworkCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221118083446_PortAdded")]
    partial class PortAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Kalin.EntityframeworkCore.Models.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Kalin.EntityframeworkCore.Models.Request", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Port")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MessageId")
                        .IsUnique();

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Kalin.EntityframeworkCore.Models.Request", b =>
                {
                    b.HasOne("Kalin.EntityframeworkCore.Models.Message", "Message")
                        .WithOne("Request")
                        .HasForeignKey("Kalin.EntityframeworkCore.Models.Request", "MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Kalin.EntityframeworkCore.Models.Message", b =>
                {
                    b.Navigation("Request")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
