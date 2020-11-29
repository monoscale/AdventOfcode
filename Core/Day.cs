using System;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Timers;

namespace Core {
    public abstract class Day<FirstResultType, SecondResultType> {
        public abstract string Title { get; }

        protected abstract void ReadInput(StreamReader input);

        protected Day() {
            string year = GetType().Namespace.Substring(3,4);
            string day = GetType().Name;
            string filePath =
                Path.Combine(
                    Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName,
                    "Aoc" + year,
                    "Resources",
                    day + ".txt");

            ReadInput(new StreamReader(new FileStream(filePath,FileMode.Open)));
        }

        public void SolveDay() {
            Console.WriteLine(Title);
            Console.WriteLine(new string('-', Title.Length));
            Console.WriteLine($"Part One: [{SolvePartOne()}]");
            Console.WriteLine(new string('-', Title.Length));
            Console.WriteLine($"Part Two: [{SolvePartTwo()}]");
            Console.WriteLine(new string('-', Title.Length));
        }
        protected abstract FirstResultType SolvePartOne();
        protected abstract SecondResultType SolvePartTwo();

    }
}
