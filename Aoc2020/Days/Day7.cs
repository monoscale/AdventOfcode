using Aoc2020.Airplane;
using Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aoc2020.Days {
    public class Day7 : Day<int, long> {
        public override string Title => "Handy Haversacks";

        IDictionary<string, Bag> nameToBag;
        private List<Bag> bags;

        protected override void ReadInput(StreamReader input) {
            nameToBag = new Dictionary<string, Bag>();
            string line;
            List<string> lines = new List<string>();
            while ((line = input.ReadLine()) != null) {
                lines.Add(line);
                string name = line.Split(" bags contain ")[0];
                Bag bag = new Bag(name);
                nameToBag[name] = bag;
            }

            lines.ForEach(l => {
                string[] parts = l.Trim().Split(" bags contain ");
                string currentBag = parts[0];
                IDictionary<Bag, int> containedBags = new Dictionary<Bag, int>();
                foreach (string part in parts[1].Trim().Split(',')) {
                    string[] bagparts = part.Trim().Split(' ');
                    if (!bagparts[0].Equals("no")) {
                        int number = int.Parse(bagparts[0]);
                        string name = bagparts[1] + " " + bagparts[2];
                        nameToBag[currentBag].ContainedBags[nameToBag[name]] = number;
                    }
                }
            });
            bags = new List<Bag>();
            bags.AddRange(nameToBag.Values);
        }

        protected override int SolvePartOne() {
            return bags.Where(b => b.ContainsAtLeastOneShinyGoldBag()).Count();
        }

        protected override long SolvePartTwo() {
            return nameToBag["shiny gold"].GetInnerBagCount();
        }
    }
}
