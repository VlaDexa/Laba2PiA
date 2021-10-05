using System;
using System.Collections.Generic;
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
                }
                else if (x < 1)
                {
                    y = -x;
                }
                else
                {
                    y = -1;
                }
                Console.WriteLine(y);
            }
            Console.WriteLine();
            // Задание 1
            {
                double r = 2;
                (double, double)[] coords = { (0, 2), (1.5, 0.7), (1, 1), (3, 0) };
                foreach (var coord in coords)
                {
                    var (x, y) = coord;
                    bool placed = Math.Abs(x * x + y * y - r * r) <= Math.Pow(10, -3);
                    Console.WriteLine("Точка с координатой {0}{1} лежит на окружности", coord, placed ? "" : " не");
                }
            }
            Console.WriteLine();
            // Задание 2
            {
                Console.Write("Введите координату x - ");
                double x = double.Parse(Console.ReadLine());
                Console.Write("Введите координату y - ");
                double y = double.Parse(Console.ReadLine());
                bool placed = y >= 0 && y + Math.Abs(x) <= 1;
                Console.WriteLine("Ваша точка{0} лежит внутри треугольника", placed ? "" : " не");
            }
            Console.WriteLine();
            // 2 часть
            // Задание 10
            {
                int n = 5;
                string[][] marks = { new string[4] { "3", "4", "5", "4" }, new string[4] { "4", "5", "4", "5" }, new string[4] { "2", "3", "5", "3" }, new string[4] { "5", "4", "5", "5" }, new string[4] { "3", "3", "4", "3" } };
                int good = 0;
                for (int i = 0; i < n; ++i)
                {
                    foreach (string mark in marks[i])
                    {
                        if (mark == "2" || mark == "3")
                            goto Next;
                    };
                    ++good;
                Next:;
                }
                Console.WriteLine("Учеников без 2 или 3 - {0}", good);
            }
            Console.WriteLine();
            // Задание 11
            {
                int n = 5;
                string[][] init_marks = { new string[4] { "3", "4", "5", "4" }, new string[4] { "4", "5", "4", "5" }, new string[4] { "2", "3", "5", "3" }, new string[4] { "5", "4", "5", "5" }, new string[4] { "3", "3", "4", "3" } };
                int bad = 0;
                List<int> marks = new List<int>(n * 4);
                for (int i = 0; i < n; ++i)
                {
                    foreach (string mark in init_marks[i])
                    {
                        marks.Add(int.Parse(mark));
                        if (mark == "2" || mark == "3")
                        {
                            ++bad;
                            break;
                        }
                    }
                }
                Console.WriteLine("Количество неуспевающих студентов - {0}", bad);
                Console.WriteLine("Средний балл группы - {0}", marks.Sum() / ((double)n * 4));
            }
            Console.WriteLine();
            // Задание 12
            {
                int n = 5;
                double[] rads = { 3.5, 5.75, 3.56, 6, 2.25 };
                int[] modes = { 1, 2, 3, 2, 1 };
                for (int i = 0; i < n; ++i)
                {
                    double r = rads[i];
                    int mode = modes[i];
                    double answer = mode switch
                    {
                        1 => AreaCalculator.Square(r),
                        2 => AreaCalculator.Circle(r),
                        3 => AreaCalculator.EqualSidesTriangle(r),
                    };
                    Console.WriteLine("Ваш ответ - {0}", answer);
                }
            }
            Console.WriteLine();
            // 3 часть
            // Задание 10
            {
                Console.Write("Количество учеников - ");
                int n = int.Parse(Console.ReadLine());
                int good = 0;
                for (int i = 0; i < n; ++i)
                {
                    Console.Write("Введите 4 оценки через пробел - ");
                    foreach (string mark in Console.ReadLine().Split(" "))
                    {
                        if (mark == "2" || mark == "3")
                            goto Next;
                    };
                    ++good;
                Next:;
                }
                Console.WriteLine("Учеников без 2 или 3 - {0}", good);
            }
            Console.WriteLine();
            // Задание 11
            {
                Console.Write("Количество учеников - ");
                int n = int.Parse(Console.ReadLine());
                int bad = 0;
                List<int> marks = new List<int>(n * 4);
                for (int i = 0; i < n; ++i)
                {
                    Console.Write("Введите 4 оценки через пробел - ");
                    List<string> inp = Console.ReadLine().Split(" ").ToList();
                    inp.ForEach((mark) => { marks.Add(int.Parse(mark)); });
                    foreach (string mark in inp)
                        if (mark == "2" || mark == "3")
                        {
                            ++bad;
                            break;
                        }
                }
                Console.WriteLine("Количество неуспевающих студентов - {0}", bad);
                Console.WriteLine("Средний балл группы - {0}", marks.Sum() / ((double)n * 4));
            }
            Console.WriteLine();
            // Задание 12
            {
                Console.Write("Количество значений - ");
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; ++i)
                {
                    Console.Write("Введите значение r - ");
                    double r = double.Parse(Console.ReadLine());
                    Console.Write("Введите 1, чтобы получить площадь квадрата со стороной r, 2 - чтобы получить площадь круга радиусом r, 3 - чтобы получить площадь равностороннего треугольника - ");
                    int mode = int.Parse(Console.ReadLine());
                    double answer = mode switch
                    {
                        1 => AreaCalculator.Square(r),
                        2 => AreaCalculator.Circle(r),
                        3 => AreaCalculator.EqualSidesTriangle(r),
                        _ => throw new ArgumentOutOfRangeException("Нет такого действия"),
                    };
                    Console.WriteLine("Ваш ответ - {0}", answer);
                }
            }
        }
    }

    /**
     *<summary>Считает площади разных фигур</summary> 
     */
    class AreaCalculator
    {
        /**
         * <summary>Считает площадь квадрата</summary>
         * <param name="r">Длина стороны квадрата</param>
         * <returns>Площадь треугольника с радиусом r</returns>
         */
        public static double Square(double r)
        {
            return r * r;
        }

        /**
         * <summary>Считает площадь круга</summary>
         * <param name="r">Радиус круга</param>
         * <returns>Площадь круга с радиусом r</returns>
         */
        public static double Circle(double r)
        {
            return Math.PI * r * r;
        }

        /**
         * <summary>Считает площадь равностороннего треугольника</summary>
         * <param name="r">Длина стороны треугольника</param>
         * <returns>Площадь равносторонего треугольника с радиусом r</returns>
         */
        public static double EqualSidesTriangle(double r)
        {
            return (Math.Sqrt(3) / 4) * r * r;
        }
    }
}
