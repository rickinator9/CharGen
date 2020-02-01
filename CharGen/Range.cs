using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharGen
{
    /// <summary>
    /// Helper class that manages a range between two integers.
    /// </summary>
    public class Range
    {
        public int Minimum { get; private set; }

        public int Maximum { get; private set; }

        /// <summary>
        /// Finds a random value between the minimum and the maximum.
        /// </summary>
        public int Random
        {
            get {
                if (_random == null) _random = new Random();
                return _random.Next(Minimum, Maximum);
            }
        }

        /// <summary>
        /// Random generator. This is lazy-loaded when the Random property is accessed.
        /// </summary>
        private Random _random;

        public Range(int min, int max)
        {
            Minimum = min;
            Maximum = max;
        }
    }
}
