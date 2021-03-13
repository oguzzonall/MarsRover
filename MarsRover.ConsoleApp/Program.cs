using MarsRover.Core.Enums;
using MarsRover.Domain.Model;
using MarsRover.Service.IService;
using MarsRover.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                   .AddTransient<IRover, Rover>()
                   .BuildServiceProvider();

            Console.WriteLine("X koordinatındaki Max Sınırı Giriniz..........:");
            int maxX = Convert.ToInt32(Console.ReadLine().Trim());
            Console.WriteLine("Y koordinatındaki Max Sınırı Giriniz..........:");
            int maxY = Convert.ToInt32(Console.ReadLine().Trim());
            Console.WriteLine("Başlangıç X koordinatını Giriniz........:");
            int startX = Convert.ToInt32(Console.ReadLine().Trim());
            Console.WriteLine("Başlangıç Y koordinatını Giriniz........:");
            int startY = Convert.ToInt32(Console.ReadLine().Trim());
            Console.WriteLine("Başlangıç Yönünü(N,S,W,E) Giriniz........:");
            string startDirection = Console.ReadLine().Trim();
            Console.WriteLine("Hareketleri(M,L,R) Giriniz........:");
            string moves = Console.ReadLine().Trim().ToUpper();
            List<int> maxLimits = new List<int>() {
                maxX,maxY
            };

            try
            {
                Coordinate coordinate = new Coordinate
                {
                    X = startX,
                    Y = startY,
                    Direction = (Directions)Enum.Parse(typeof(Directions), startDirection)
                };
                IRover _rover = serviceProvider.GetService<IRover>();
                _rover.Move(maxLimits, moves, coordinate);
                Console.WriteLine($"{coordinate.X} {coordinate.Y} {coordinate.Direction}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
