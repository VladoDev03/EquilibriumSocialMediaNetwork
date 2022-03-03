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
        public DbSet<Group> Groups { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<UserGroup> UsersGroups { get; set; }

        public EquilibriumDbContext(DbContextOptions<EquilibriumDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=Ann@492;database=equilibrium;");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
