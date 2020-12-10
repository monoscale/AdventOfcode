using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core {
    public static class StreamReaderExtensions {

        public static IList<int> ReadNumbers(this StreamReader input) {
            return input.ReadToEnd().Split('\n').Select(i => int.Parse(i)).ToList();
        }
    }
}
