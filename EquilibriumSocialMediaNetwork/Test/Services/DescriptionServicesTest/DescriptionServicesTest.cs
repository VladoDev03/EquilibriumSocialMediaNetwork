using System;
using System.Linq;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services;

namespace Test.Services.DescriptionServicesTest
{
    [TestFixture]
    public class DescriptionServicesTest
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
        public void AddDescription_Test()
        {
            DescriptionServices descriptionServices = new DescriptionServices(this.context);

            this.context.Descriptions.Add(new Description() { Id = "1" });

            this.context.SaveChanges();

            Assert.AreEqual(1, this.context.Descriptions.ToList().Count);

        }

        [Test]
        public void DeleteDescription_Test()
        {
            DescriptionServices descriptionServices = new DescriptionServices(this.context);

            this.context.Descriptions.Add(new Description() { Id = "1" });
            this.context.Descriptions.Add(new Description() { Id = "14" });


            this.context.SaveChanges();

            descriptionServices.DeleteDescription("14");

            Assert.AreEqual(1, this.context.Descriptions.ToList().Count);
        }
    }
}
