﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project1.app.Repository;

#nullable disable

namespace Project1.app.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project1.app.Repository.Entities.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountID"));

                    b.Property<double>("AAPL")
                        .HasColumnType("float");

                    b.Property<double>("AMZN")
                        .HasColumnType("float");

                    b.Property<double>("GOOG")
                        .HasColumnType("float");

                    b.Property<double>("MSFT")
                        .HasColumnType("float");

                    b.Property<double>("NVDA")
                        .HasColumnType("float");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountID");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountID = -1,
                            AAPL = 0.0,
                            AMZN = 0.0,
                            GOOG = 0.0,
                            MSFT = 0.0,
                            NVDA = 0.0,
                            Username = "test1"
                        },
                        new
                        {
                            AccountID = -2,
                            AAPL = 0.0,
                            AMZN = 0.0,
                            GOOG = 0.0,
                            MSFT = 0.0,
                            NVDA = 0.0,
                            Username = "test2"
                        });
                });

            modelBuilder.Entity("Project1.app.Repository.Entities.Password", b =>
                {
                    b.Property<int>("PasswordID")
                        .HasColumnType("int");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("PasswordID");

                    b.ToTable("Passwords");

                    b.HasData(
                        new
                        {
                            PasswordID = -1,
                            Hash = "5375D5C8A0B679DE9178212FA9A54E7FE564E3EEC479B9E61149E29487FC8F2D8D97224C7F8A3E7DF8997E9D1AA4D788C34CFD7937C401B8FCEB4BA91DB8A175",
                            Salt = new byte[] { 204, 105, 7, 67, 49, 248, 78, 236, 103, 220, 5, 189, 206, 244, 213, 131, 124, 170, 144, 215, 200, 73, 55, 206, 192, 160, 33, 88, 181, 88, 245, 66, 122, 171, 213, 219, 253, 230, 216, 71, 37, 204, 5, 232, 30, 110, 244, 236, 169, 239, 159, 159, 55, 95, 221, 94, 71, 107, 94, 158, 160, 229, 52, 189 }
                        },
                        new
                        {
                            PasswordID = -2,
                            Hash = "5D553F36FF17B4556D485940D5E5F5CD866319AD432A7548D8609B7B7F32953AD76D26432A6870B8E33240DF6E5923E3339B01B255269108B3A33860E853F07C",
                            Salt = new byte[] { 39, 123, 245, 70, 104, 222, 186, 142, 191, 124, 251, 31, 143, 166, 18, 20, 162, 194, 136, 180, 39, 46, 253, 229, 225, 190, 85, 129, 114, 136, 220, 205, 56, 80, 226, 130, 0, 217, 229, 103, 57, 10, 182, 121, 101, 57, 17, 43, 140, 23, 205, 93, 65, 58, 251, 154, 241, 79, 123, 213, 7, 131, 222, 202 }
                        });
                });

            modelBuilder.Entity("Project1.app.Repository.Entities.Password", b =>
                {
                    b.HasOne("Project1.app.Repository.Entities.Account", "Account")
                        .WithOne("Password")
                        .HasForeignKey("Project1.app.Repository.Entities.Password", "PasswordID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Project1.app.Repository.Entities.Account", b =>
                {
                    b.Navigation("Password")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
