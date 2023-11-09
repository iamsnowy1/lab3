using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Computer
    {
        public string IPAddress { get; set; }
        public int Power { get; set; }
        public string OperatingSystem { get; set; }
    }

   
    public class Server : Computer, IConnectable
    {
        public void Connect(Computer target)
        {
            Console.WriteLine($"Server {IPAddress} is connecting to {target.IPAddress}.");
        }

        public void Disconnect(Computer target)
        {
            Console.WriteLine($"Server {IPAddress} is disconnecting from {target.IPAddress}.");
        }

        public void TransmitData(string data, Computer target)
        {
            Console.WriteLine($"Server {IPAddress} is transmitting data to {target.IPAddress}: {data}");
        }
    }

    public class Workstation : Computer, IConnectable
    {
        public void Connect(Computer target)
        {
            Console.WriteLine($"Workstation {IPAddress} is connecting to {target.IPAddress}.");
        }

        public void Disconnect(Computer target)
        {
            Console.WriteLine($"Workstation {IPAddress} is disconnecting from {target.IPAddress}.");
        }

        public void TransmitData(string data, Computer target)
        {
            Console.WriteLine($"Workstation {IPAddress} is transmitting data to {target.IPAddress}: {data}");
        }
    }

    public class Router : Computer, IConnectable
    {
        public void Connect(Computer target)
        {
            Console.WriteLine($"Router {IPAddress} is connecting to {target.IPAddress}.");
        }

        public void Disconnect(Computer target)
        {
            Console.WriteLine($"Router {IPAddress} is disconnecting from {target.IPAddress}.");
        }

        public void TransmitData(string data, Computer target)
        {
            Console.WriteLine($"Router {IPAddress} is transmitting data to {target.IPAddress}: {data}");
        }
    }

  
    public interface IConnectable
    {
        void Connect(Computer target);
        void Disconnect(Computer target);
        void TransmitData(string data, Computer target);
    }

   
    public class Network
    {
        private List<Computer> computers;

        public Network()
        {
            computers = new List<Computer>();
        }

        public void AddComputer(Computer computer)
        {
            computers.Add(computer);
        }

        public void SimulateConnection()
        {
            Random random = new Random();

            foreach (var computer in computers)
            {
                int targetIndex = random.Next(computers.Count);
                Computer targetComputer = computers[targetIndex];

                if (computer is IConnectable connectableComputer)
                {
                    connectableComputer.Connect(targetComputer);
                    connectableComputer.TransmitData("Hello, world!", targetComputer);
                    connectableComputer.Disconnect(targetComputer);
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Network network = new Network();

            Server server = new Server { IPAddress = "192.168.1.1", Power = 100, OperatingSystem = "Windows Server" };
            Workstation workstation = new Workstation { IPAddress = "192.168.1.2", Power = 50, OperatingSystem = "Windows 10" };
            Router router = new Router { IPAddress = "192.168.1.3", Power = 75, OperatingSystem = "RouterOS" };

            network.AddComputer(server);
            network.AddComputer(workstation);
            network.AddComputer(router);

            network.SimulateConnection();

        }
    }
}
