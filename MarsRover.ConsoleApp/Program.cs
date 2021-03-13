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
            try
            {
                ServiceProvider serviceProvider = new ServiceCollection()
                   .AddTransient<IRover, Rover>()
                   .BuildServiceProvider();
                Input input = new Input();

                SetInputsFromConsole(input);

                List<int> maxLimits = new List<int>() {
                    input.MaxX,input.MaxY
                };

                Coordinate coordinate = new Coordinate
                {
                    X = input.StartX,
                    Y = input.StartY,
                    Direction = (Directions)Enum.Parse(typeof(Directions), input.StartDirection)
                };
                IRover _rover = serviceProvider.GetService<IRover>();
                _rover.Move(maxLimits, input.Moves, coordinate);
                Console.WriteLine($"{coordinate.X} {coordinate.Y} {coordinate.Direction}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SetInputsFromConsole(Input input)
        {
            Console.WriteLine("X koordinatındaki Max Sınırı Giriniz..........:");
            input.MaxX = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine("Y koordinatındaki Max Sınırı Giriniz..........:");
            input.MaxY = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine("Başlangıç X koordinatını Giriniz........:");
            input.StartX = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine("Başlangıç Y koordinatını Giriniz........:");
            input.StartY = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine("Başlangıç Yönünü(N,S,W,E) Giriniz........:");
            input.StartDirection = Console.ReadLine().Trim();

            Console.WriteLine("Hareketleri(M,L,R) Giriniz........:");
            input.Moves = Console.ReadLine().Trim().ToUpper();
        }
    }
}
