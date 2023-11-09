using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class Road
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public int NumberOfLanes { get; set; }
        public int TrafficLevel { get; set; }

        public Road(double length, double width, int numberOfLanes)
        {
            Length = length;
            Width = width;
            NumberOfLanes = numberOfLanes;
            TrafficLevel = 0;
        }






        public class Vehicle : IDriveable
        {
            public string Type { get; set; }
            public double Speed { get; set; }
            public double Size { get; set; }
            public Vehicle(string type, double speed, double size)
            {
                Type = type;
                Speed = speed;
                Size = size;
            }

            public void Move()
            {
                Console.WriteLine($"{Type} is moving at a speed of {Speed} km/h.");
            }

            public void Stop()
            {
                Console.WriteLine($"{Type} has stopped.");
            }
        }


        public interface IDriveable
        {
            void Move();
            void Stop();
        }


        public class TrafficSimulator
        {
            public static void SimulateTraffic(List<Vehicle> vehicles, Road road)
            {
                Console.WriteLine($"Simulating traffic on a road of length {road.Length} km with {road.NumberOfLanes} lanes.");

                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine($"Vehicle type: {vehicle.Type}, Size: {vehicle.Size}");
                    vehicle.Move();

                    double adjustedSpeed = CalculateAdjustedSpeed(vehicle.Speed, road.TrafficLevel);
                    Console.WriteLine($"Adjusted speed based on traffic level: {adjustedSpeed} km/h");


                    if (CanMoveOnRoad(vehicle.Size, road.Width))
                    {
                        Console.WriteLine("Vehicle can move on the road.");
                    }
                    else
                    {
                        Console.WriteLine("Vehicle cannot move on the road due to size constraints.");
                    }

                    vehicle.Stop();
                    Console.WriteLine();
                }
            }

            private static double CalculateAdjustedSpeed(double originalSpeed, int trafficLevel)
            {
                return originalSpeed - trafficLevel * 5;
            }

            private static bool CanMoveOnRoad(double vehicleSize, double roadWidth)
            {
                return vehicleSize <= roadWidth;
            }
        }

        class Program
        {
            static void Main()
            {
                Road cityRoad = new Road(length: 10, width: 2, numberOfLanes: 2);

                List<Vehicle> vehicles = new List<Vehicle>
        {
            new Vehicle("Car", speed: 60, size: 1.5),
            new Vehicle("Truck", speed: 40, size: 2.5),
            new Vehicle("Bus", speed: 50, size: 2)
        };

                TrafficSimulator.SimulateTraffic(vehicles, cityRoad);
            }
        }
    }
}