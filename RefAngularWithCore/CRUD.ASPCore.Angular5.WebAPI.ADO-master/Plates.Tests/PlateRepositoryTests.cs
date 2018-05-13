using System;
using ASPCoreWithAngular.Models.VPlates;
using Xunit;

namespace Plates.Tests
{
    public class PlateRepositoryTests
    {
        [Fact]
        public void AddPlate()
        {
            var repository = new PlateRepository();
            var plate = new Plate
            {
                Name = "Test Plate 4",
                MinCharacters = 3,
                MaxCharacters = 6
            };

            var identity = repository.AddPlate(plate);
            Assert.True(identity > 0);
        }

        [Fact]
        public void GetAll()
        {
            var repository = new PlateRepository();
            repository.GetAll();
        }
    }
}
