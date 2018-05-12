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
                Name = "3 X 3",
                MinCharacters = 3,
                MaxCharacters = 6
            };

            var status = repository.AddPlate(plate);
            Assert.True(status);
        }

        [Fact]
        public void GetAll()
        {
            var repository = new PlateRepository();
            repository.GetAll();
        }
    }
}
