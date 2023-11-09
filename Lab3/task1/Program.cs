using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    

    
    class LivingOrganism
    {
        public double Energy { get; set; }
        public int Age { get; set; }
        public double Size { get; set; }

        public LivingOrganism(double energy, int age, double size)
        {
            Energy = energy;
            Age = age;
            Size = size;
        }
    }

    
    class Animal : LivingOrganism, IPredator, IReproducible
    {
        public int Speed { get; set; }
        public string Species { get; set; }

        public Animal(double energy, int age, double size, int speed, string species)
            : base(energy, age, size)
        {
            Speed = speed;
            Species = species;
        }

        public void Hunt(LivingOrganism prey)
        {
           
            Console.WriteLine($"{Species} полює на {prey.GetType().Name}");
        }

        public void Reproduce()
        {
            
            Console.WriteLine($"{Species} розмножується");
        }
    }

    class Plant : LivingOrganism, IReproducible
    {
        public string Type { get; set; }

        public Plant(double energy, int age, double size, string type)
            : base(energy, age, size)
        {
            Type = type;
        }

        public void Reproduce()
        {
            
            Console.WriteLine($"Рослина розмножується");
        }
    }

    class Microorganism : LivingOrganism, IReproducible
    {
        public string Name { get; set; }

        public Microorganism(double energy, int age, double size, string name)
            : base(energy, age, size)
        {
            Name = name;
        }

        public void Reproduce()
        {
            
            Console.WriteLine($"{Name} розмножується");
        }
    }

   
    interface IReproducible
    {
        void Reproduce();
    }

    interface IPredator
    {
        void Hunt(LivingOrganism prey);
    }

    
    class Ecosystem
    {
        private List<LivingOrganism> organisms = new List<LivingOrganism>();

        public void AddOrganism(LivingOrganism organism)
        {
            organisms.Add(organism);
        }

        public void SimulateEcosystem()
        {
            foreach (var organism in organisms)
            {
                if (organism is IPredator)
                {
                    var predators = organisms.OfType<IPredator>().Where(predator => predator != organism);
                    foreach (var prey in predators)
                    {
                        ((IPredator)organism).Hunt((LivingOrganism)prey);
                    }
                }

                if (organism is IReproducible)
                {
                    ((IReproducible)organism).Reproduce();
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Ecosystem ecosystem = new Ecosystem();

            Animal lion = new Animal(100, 5, 2, 30, "Лев");
            Animal cheetah = new Animal(90, 4, 2.2, 70, "Гепард");
            Plant oak = new Plant(50, 10, 4, "Дуб");
            Microorganism bacteria = new Microorganism(10, 1, 0.001, "Бактерія");

            ecosystem.AddOrganism(lion);
            ecosystem.AddOrganism(cheetah);
            ecosystem.AddOrganism(oak);
            ecosystem.AddOrganism(bacteria);

            ecosystem.SimulateEcosystem();
        }
    }
}
