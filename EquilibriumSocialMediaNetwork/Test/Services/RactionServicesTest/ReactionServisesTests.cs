using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;

namespace Test.Services.RactionServicesTest
{
    [TestFixture]
    public class ReactionServisesTests
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
        public void AddReaction_Test()
        {
            ReactionServices reactionServices = new ReactionServices(this.context);

            this.context.Reactions.Add(new Reaction() { Id = "1" });
            this.context.Reactions.Add(new Reaction() { Id = "2" });
            this.context.Reactions.Add(new Reaction() { Id = "3" });

            this.context.SaveChanges();

            Assert.AreEqual(3, this.context.Reactions.ToList().Count);
        }

        [Test]
        public void GetPostReaction_Test()
        {
            ReactionServices reactionServices = new ReactionServices(this.context);

            this.context.Reactions.Add(new Reaction() { Id = "1" });
            this.context.Reactions.Add(new Reaction() { Id = "12" });
            this.context.Reactions.Add(new Reaction() { Id = "14" });
            this.context.Reactions.Add(new Reaction() { Id = "16" });

            this.context.SaveChanges();

          
            reactionServices.GetPostReactions("1");



        }
    }
}
