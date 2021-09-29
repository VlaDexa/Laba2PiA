using System;
using System.Linq;

namespace LabaTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 часть
            // Задание 10
            {
                Console.Write("Введите число - ");
                double x = double.Parse(Console.ReadLine());
                double y;
                if (x <= -1)
                {
                    y = 1;
                } else if (x < 1)
                {
                    y = -x;
                } else
                {
                    y = -1;
                }
                Console.WriteLine(y);
            }
            // Задание 1
            {
                double r = 2;
                (double, double)[] coords = { (0, 2), (1.5, 0.7), (1,1), (3,0) };
                foreach (var coord in coords)
                {
                    var (x, y) = coord;
                    bool placed = Math.Abs(x * x + y * y - r * r) <= Math.Pow(10,-3);
                    Console.WriteLine("Точка с координатой {0}{1} лежит на окружности", coord, placed ? "" : " не");
                }
            }
            // Задание 2
            {
                Console.Write("Введите координату x - ");
                double x = double.Parse(Console.ReadLine());
                Console.Write("Введите координату y - ");
                double y = double.Parse(Console.ReadLine());
                bool placed = y >= 0 && y + Math.Abs(x) <= 1;
                Console.WriteLine("Ваша точка{0} лежит внутри треугольника", placed ? "" : " не");
            }
            // 2 часть
            // Задание 10
            {
                Console.Write("Количество учеников - ");
                int n = int.Parse(Console.ReadLine());
                int good = 0;
                for (int i = 0; i < n; ++i)
                {
                    Console.Write("Введите 4 оценки через пробел - ");
                    foreach (var mark in Console.ReadLine().Split(" ")) 
                    {
                        if (mark == "2" || mark == "3")
                            goto Next;
                    };
                    ++good;
                Next:;
                }
                Console.WriteLine("Учеников без 2 или 3 - {0}", good);
            }
        }
    }
}
