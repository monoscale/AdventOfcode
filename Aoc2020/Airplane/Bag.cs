using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc2020.Airplane {
    public class Bag {

        public string Name { get; private set; }
        public IDictionary<Bag, int> ContainedBags { get; private set; }


        public Bag(string name) {
            Name = name;
            ContainedBags = new Dictionary<Bag, int>();
        }

        public bool ContainsAtLeastOneShinyGoldBag() {
            return ContainedBags.Keys.Any(bag => bag.Name == "shiny gold") || 
                ContainedBags.Keys.Any(bag => bag.ContainsAtLeastOneShinyGoldBag());
        }

        public long GetInnerBagCount() {
            if(ContainedBags.Count == 0) {
                return 1;
            }
            return ContainedBags.Keys.Sum(bag => {
                Console.WriteLine($"{bag.Name} : {bag.GetInnerBagCount()} * {ContainedBags[bag]} = {bag.GetInnerBagCount() * ContainedBags[bag]} ");
                return bag.GetInnerBagCount() * ContainedBags[bag];
            });
        }

    }
}
