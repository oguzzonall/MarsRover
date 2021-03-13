using MarsRover.Core.Enums;
using MarsRover.Domain.Model;
using MarsRover.Service.IService;
using MarsRover.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MarsRover.Test
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestMethod]
        public void Test_Scenario_Max55_12N_LMLMLMLMM()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                               .AddTransient<IRover, Rover>()
                               .BuildServiceProvider();

            var maxLimits = new List<int>() { 5, 5 };
            Coordinate coordinate = new Coordinate
            {
                Direction = Directions.N,
                X = 1,
                Y = 2
            };
            string moves = "LMLMLMLMM";
            IRover _rover = serviceProvider.GetService<IRover>();
            var output = _rover.Move(maxLimits, moves, coordinate);

            var actual = $"{output.X} {output.Y} {output.Direction}";
            var expected = "1 3 N";
            Assert.AreEqual(expected, actual);
        }

        public void Test_Scenario_Max55_33E_MRRMMRMRRM()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                               .AddTransient<IRover, Rover>()
                               .BuildServiceProvider();

            var maxLimits = new List<int>() { 5, 5 };
            Coordinate coordinate = new Coordinate
            {
                Direction = Directions.E,
                X = 3,
                Y = 3
            };
            var moves = "MRRMMRMRRM";
            IRover _rover = serviceProvider.GetService<IRover>();
            var output = _rover.Move(maxLimits, moves, coordinate);

            var actual = $"{output.X} {output.Y} {output.Direction}";
            var expected = "2 3 S";
            Assert.AreEqual(expected, actual);
        }
    }
}
