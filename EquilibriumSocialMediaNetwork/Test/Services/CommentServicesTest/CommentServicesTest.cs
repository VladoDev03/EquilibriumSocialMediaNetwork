using System;
using System.Linq;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;

namespace Test.Services
{
    [TestFixture]
    public class CommentServicesTest
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
        public void AddComment_Test()
        {
            
            CommentServices commentServices = new CommentServices(this.context);
            this.context.Comments.Add(new Comment() { Id = "2" });

            this.context.SaveChanges();

            Assert.AreEqual(1, this.context.Comments.ToList().Count);
        }

        [Test]
        public void DeleteComment_Test()
        {
            CommentServices commentServices = new CommentServices(this.context);
            this.context.Comments.Add(new Comment() { Id = "21" });
            this.context.Comments.Add(new Comment() { Id = "abc" });

            this.context.SaveChanges();

            commentServices.DeleteComment("21");

            Assert.AreEqual(1, this.context.Comments.ToList().Count);

        }
    }
    
}

