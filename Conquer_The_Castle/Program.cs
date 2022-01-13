using System;

namespace Conquer_The_Castle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter way length: ");
            int length = int.Parse(Console.ReadLine());
            Console.Write("Enter enemy amount: ");
            int enemy = int.Parse(Console.ReadLine());
            Game obj = new Game(length, enemy);

            obj.SetPosition();
            obj.Play();
        }
    }
}
