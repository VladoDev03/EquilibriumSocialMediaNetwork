﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.Migrations
{
    [DbContext(typeof(EquilibriumDbContext))]
    [Migration("20220409161801_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Data.Entities.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("PostId")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeCommented")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Data.Entities.Conversation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("UserOneId")
                        .HasColumnType("text");

                    b.Property<string>("UserTwoId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("Data.Entities.Cover", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Covers");
                });

            modelBuilder.Entity("Data.Entities.Description", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Descriptions");
                });

            modelBuilder.Entity("Data.Entities.Email", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.Property<string>("To")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("Data.Entities.FriendRequest", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("RequestStatus")
                        .HasColumnType("text");

                    b.Property<string>("RequestedFromId")
                        .HasColumnType("text");

                    b.Property<string>("RequestedToId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RequestedFromId");

                    b.HasIndex("RequestedToId");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("Data.Entities.Group", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Data.Entities.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("ConversationId")
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeSent")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserOneId")
                        .HasColumnType("text");

                    b.Property<string>("UserTwoId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("UserOneId");

                    b.HasIndex("UserTwoId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Data.Entities.Post", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("ImageDownloadUrl")
                        .HasColumnType("text");

                    b.Property<string>("ImagePublicId")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<bool>("IsDownloadable")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("TimePosted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Data.Entities.ProfilePicture", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ImageDownloadUrl")
                        .HasColumnType("text");

                    b.Property<string>("ImagePublicId")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<bool>("IsDownloadable")
                        .HasColumnType("boolean");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ProfilePictures");
                });

            modelBuilder.Entity("Data.Entities.QrCode", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ImageDownloadUrl")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("PublicId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("QrCodes");
                });

            modelBuilder.Entity("Data.Entities.Reaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PostId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("Data.Entities.Reply", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CommentId")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("UserId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("Data.Entities.Report", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("PostId")
                        .HasColumnType("text");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Data.Entities.Status", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("ProfilePictureId")
                        .HasColumnType("text");

                    b.Property<string>("QrCodeId")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Data.Entities.UserFriend", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("FriendId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "FriendId")
                        .HasName("PRIMARY");

                    b.HasIndex("FriendId");

                    b.ToTable("UsersFriends");
                });

            modelBuilder.Entity("Data.Entities.UserGroup", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<string>("GroupId1")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId1")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GroupId1");

                    b.HasIndex("UserId1");

                    b.ToTable("UsersGroups");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Data.Entities.Comment", b =>
                {
                    b.HasOne("Data.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId");

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Cover", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Description", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.FriendRequest", b =>
                {
                    b.HasOne("Data.Entities.User", "RequestedFrom")
                        .WithMany()
                        .HasForeignKey("RequestedFromId");

                    b.HasOne("Data.Entities.User", "RequestedTo")
                        .WithMany()
                        .HasForeignKey("RequestedToId");

                    b.Navigation("RequestedFrom");

                    b.Navigation("RequestedTo");
                });

            modelBuilder.Entity("Data.Entities.Message", b =>
                {
                    b.HasOne("Data.Entities.Conversation", "Conversation")
                        .WithMany("Messages")
                        .HasForeignKey("ConversationId");

                    b.HasOne("Data.Entities.User", "UserOne")
                        .WithMany()
                        .HasForeignKey("UserOneId");

                    b.HasOne("Data.Entities.User", "UserTwo")
                        .WithMany()
                        .HasForeignKey("UserTwoId");

                    b.Navigation("Conversation");

                    b.Navigation("UserOne");

                    b.Navigation("UserTwo");
                });

            modelBuilder.Entity("Data.Entities.Post", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.ProfilePicture", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithOne("ProfilePicture")
                        .HasForeignKey("Data.Entities.ProfilePicture", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.QrCode", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithOne("QrCode")
                        .HasForeignKey("Data.Entities.QrCode", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Reaction", b =>
                {
                    b.HasOne("Data.Entities.Post", "Post")
                        .WithMany("Reactions")
                        .HasForeignKey("PostId");

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Reply", b =>
                {
                    b.HasOne("Data.Entities.Comment", "Comment")
                        .WithMany("Replies")
                        .HasForeignKey("CommentId");

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Comment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Report", b =>
                {
                    b.HasOne("Data.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Status", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.UserFriend", b =>
                {
                    b.HasOne("Data.Entities.User", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Friend");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.UserGroup", b =>
                {
                    b.HasOne("Data.Entities.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId1");

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Comment", b =>
                {
                    b.Navigation("Replies");
                });

            modelBuilder.Entity("Data.Entities.Conversation", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Data.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Navigation("ProfilePicture");

                    b.Navigation("QrCode");
                });
#pragma warning restore 612, 618
        }
    }
}