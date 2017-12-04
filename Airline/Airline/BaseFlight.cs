using System;

namespace Airline
{
    abstract class BaseFlight
    {
        public DateTime DateTime { get; set; }

        public string CityOrPort { get; set; }

        public Terminal Terminal { get; set; }

        public Gate Gate { get; set; }

        public override string ToString()
        {
            return $"City or Port: {CityOrPort}\n\tDate and time: {DateTime}\n\t{nameof(Gate)}: {Gate}\n\t{nameof(Terminal)}: {Terminal}";
        }
    }
}
