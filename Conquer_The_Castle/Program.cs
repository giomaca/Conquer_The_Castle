using System;

namespace Conquer_The_Castle
{
    class Program
    {
        static void Main(string[] args)
        {
            int length, enemy;
            while (true)
            {
                try
                {
                    Console.Write("Enter way length: ");
                    length = int.Parse(Console.ReadLine());
                    Console.Write("Enter enemy amount: ");
                    enemy = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Enter valid input!");
                }
            }

            Game obj = new Game(length, enemy);
            obj.SetPosition();
            obj.Play();
        }
    }
}
