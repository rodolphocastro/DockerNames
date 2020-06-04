using System;

namespace DockerNames.CLI
{
    internal class Program
    {
        private static readonly DockerNameFactory _nameFactory = DockerNameFactory.Instance;

        private static void Main(string[] args)
        {
            Console.WriteLine("Generating 10 random docker names using the Element Property!");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i}:{_nameFactory.Element}");
            }

            Console.WriteLine("Generating 10 random docker names using the Build Method!");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i}:{_nameFactory.Build()}");
            }

            Console.WriteLine("Generating 10 random docker names using the Build Method with a custom separator!");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i}:{_nameFactory.Build(' ')}");
            }
        }
    }
}
