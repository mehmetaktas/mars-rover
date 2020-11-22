using MarsRover.Core;
using System;

namespace MarsRover.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter commands:");

                var readWidthHeight = Console.ReadLine();
                var widthHeightSplit = readWidthHeight.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int width = Convert.ToInt32(widthHeightSplit[0]);
                int height = Convert.ToInt32(widthHeightSplit[1]);

                var location = Console.ReadLine();
                var commands = Console.ReadLine();

                RoverHandler rovers = new RoverHandler(width, height)
                {
                    { location, commands }
                };

                foreach (var rover in rovers)
                {
                    Console.WriteLine($"Result: {rover.XCoordinate} {rover.YCoordinate} {rover.Direction} {Environment.NewLine}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);

            }

            Console.ReadKey();
        }
    }
}