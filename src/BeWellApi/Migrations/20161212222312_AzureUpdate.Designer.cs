using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BeWellApi.Data;

namespace BeWellApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161212222312_AzureUpdate")]
    partial class AzureUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeWellApi.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AWSUrl");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<bool>("IsMeditation");

                    b.Property<double?>("Minutes");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("PhysicalMax");

                    b.Property<int>("PhysicalMin");

                    b.Property<int>("PointValue");

                    b.Property<bool>("UserAdded");

                    b.Property<string>("UserId");

                    b.HasKey("ActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("BeWellApi.Models.ActivityProgress", b =>
                {
                    b.Property<int>("ActivityProgressId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityId");

                    b.Property<DateTime>("DateCompleted")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<double?>("Minutes");

                    b.Property<int>("PointValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("ActivityProgressId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("ActivityProgress");
                });

            modelBuilder.Entity("BeWellApi.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BeWellApi.Models.Emotion", b =>
                {
                    b.Property<int>("EmotionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EmotionCategoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("Value");

                    b.HasKey("EmotionId");

                    b.HasIndex("EmotionCategoryId");

                    b.ToTable("Emotion");
                });

            modelBuilder.Entity("BeWellApi.Models.EmotionActivity", b =>
                {
                    b.Property<int>("EmotionActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityId");

                    b.Property<int>("EmotionId");

                    b.HasKey("EmotionActivityId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("EmotionId");

                    b.ToTable("EmotionActivity");
                });

            modelBuilder.Entity("BeWellApi.Models.EmotionCategory", b =>
                {
                    b.Property<int>("EmotionCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("EmotionCategoryId");

                    b.ToTable("EmotionCategory");
                });

            modelBuilder.Entity("BeWellApi.Models.SavedActivity", b =>
                {
                    b.Property<int>("SavedActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("SavedActivityId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("SavedActivity");
                });

            modelBuilder.Entity("BeWellApi.Models.UserAssessment", b =>
                {
                    b.Property<int>("UserAssessmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssessmentValue");

                    b.Property<bool>("IsPhysical");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("UserAssessmentId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAssessment");
                });

            modelBuilder.Entity("BeWellApi.Models.UserEmotion", b =>
                {
                    b.Property<int>("UserEmotionId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateLogged")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("EmotionId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("UserEmotionId");

                    b.HasIndex("EmotionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserEmotion");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BeWellApi.Models.Activity", b =>
                {
                    b.HasOne("BeWellApi.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BeWellApi.Models.ActivityProgress", b =>
                {
                    b.HasOne("BeWellApi.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeWellApi.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeWellApi.Models.Emotion", b =>
                {
                    b.HasOne("BeWellApi.Models.EmotionCategory", "EmotionCategory")
                        .WithMany()
                        .HasForeignKey("EmotionCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeWellApi.Models.EmotionActivity", b =>
                {
                    b.HasOne("BeWellApi.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeWellApi.Models.Emotion", "Emotion")
                        .WithMany()
                        .HasForeignKey("EmotionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeWellApi.Models.SavedActivity", b =>
                {
                    b.HasOne("BeWellApi.Models.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeWellApi.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeWellApi.Models.UserAssessment", b =>
                {
                    b.HasOne("BeWellApi.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeWellApi.Models.UserEmotion", b =>
                {
                    b.HasOne("BeWellApi.Models.Emotion", "Emotion")
                        .WithMany()
                        .HasForeignKey("EmotionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeWellApi.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BeWellApi.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BeWellApi.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeWellApi.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
