using System;
using System.Diagnostics;
using System.IO;


namespace Core {
    public abstract class Day<FirstResultType, SecondResultType> {
        public abstract string Title { get; }

        protected abstract void ReadInput(StreamReader input);

        protected Day() {
            string year = GetType().Namespace.Substring(3, 4);
            string day = GetType().Name;
            string filePath =
                Path.Combine(
                    Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName,
                    "Aoc" + year,
                    "Resources",
                    day + ".txt");

            ReadInput(new StreamReader(new FileStream(filePath, FileMode.Open)));
        }

        public void SolveDay() {
            Stopwatch stopWatch = new Stopwatch();
            Console.WriteLine(Title);

            Console.WriteLine(new string('-', Title.Length));
            stopWatch.Start();
            Console.WriteLine($"Part One: [{SolvePartOne()}]");
            stopWatch.Stop();
            Console.WriteLine("Elapsed time is {0} ms", stopWatch.ElapsedMilliseconds);


            Console.WriteLine(new string('-', Title.Length));
            stopWatch.Start();
            Console.WriteLine($"Part Two: [{SolvePartTwo()}]");
            stopWatch.Stop();
            Console.WriteLine("Elapsed time is {0} ms", stopWatch.ElapsedMilliseconds);
            Console.WriteLine(new string('-', Title.Length));
        }
        protected abstract FirstResultType SolvePartOne();
        protected abstract SecondResultType SolvePartTwo();

    }
}
