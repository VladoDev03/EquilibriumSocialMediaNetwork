using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class EquilibriumDbContext : IdentityDbContext<User>
    {
        //string connectionString = "server=127.0.0.1;port=3306;user=root;password=Bibi3103.;database=aspnet-App-2C0D8167-A6B0-4849-AE32-4A55A302DB49";

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
<<<<<<< Updated upstream
                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=Bibicen3103.;database=aspnet-App-2C0D8167-A6B0-4849-AE32-4A55A302DB49");
       
=======
                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=Bibicen3103.;database=equilibrium;");
>>>>>>> Stashed changes
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
