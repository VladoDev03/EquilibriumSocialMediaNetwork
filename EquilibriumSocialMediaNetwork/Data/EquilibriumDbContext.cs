﻿using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class EquilibriumDbContext : IdentityDbContext<User>
    {
        public EquilibriumDbContext()
        {

        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<UserFriend> UsersFriends { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<UserGroup> UsersGroups { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        public DbSet<QrCode> QrCodes { get; set; }

        public EquilibriumDbContext(DbContextOptions<EquilibriumDbContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=Bibicen3103.;database=equilibrium;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserFriend>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FriendId })
                    .HasName("PRIMARY");
            });

            builder.Entity<User>()
                .HasOne(u => u.ProfilePicture).WithOne(i => i.User)
                .HasForeignKey<ProfilePicture>(x => x.UserId);

            builder.Entity<User>()
                .HasOne(u => u.QrCode).WithOne(q => q.User)
                .HasForeignKey<QrCode>(x => x.UserId);
        }
    }
}
