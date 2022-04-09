using System;
using System.Collections.Generic;
using System.Linq;
using App.Areas.Identity.Pages.Account;
using App.Controllers;
using Data;
using Data.Entities;
using Data.ViewModels.Post;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Services;
using Services.Contracts;

namespace Test.Services.PostServicesTest
{
    [TestFixture]
    public class PostServicesTests
    {
        private EquilibriumDbContext context;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<EquilibriumDbContext>()
                .UseInMemoryDatabase("equilibrium_test").Options;


            this.context = new EquilibriumDbContext(options);
        }

        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }

        [Test]
        public void AddPost_Test()
        {
           // User user = new User();
            PostServices postServicesModel = new PostServices(this.context); 

            this.context.Posts.Add(new Post() { Id = "c1" });
            this.context.Posts.Add(new Post() { Id = "14" });

            this.context.SaveChanges();


            Assert.AreEqual(2, this.context.Posts.ToList().Count);
        }

        [Test]
        public void DeletePost_Test()
        {
            PostServices postServicesModel = new PostServices(this.context);

            this.context.Posts.Add(new Post() { Id = "c1" });
            this.context.Posts.Add(new Post() { Id = "14" });

            this.context.SaveChanges();

            postServicesModel.DeletePost("c1");

            Assert.AreEqual(1, this.context.Posts.ToList().Count);
        }

    }
}
