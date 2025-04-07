using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns1.structural
{
    class DonutType
    {
        public string Glaze { get; private set; }
        public string Filling { get; private set; }

        public DonutType( string glaze, string filling)
        {
            Glaze = glaze;
            Filling = filling;
        }

        public void ShowDetails(string location)
        {
            Console.WriteLine($"A donut with {Glaze} glaze and {Filling} filling is located in {location}");
        }
    }

    class Donut
    {
        private DonutType _type;
        private string _location; 

        public Donut(DonutType type, string location)
        {
            _type = type;
            _location = location;
        }

        public void Display()
        {
            _type.ShowDetails(_location);
        }
    }

    class DonutFactory
    {
        private Dictionary<string, DonutType> _types = new Dictionary<string, DonutType>();

        public DonutType GetDonutType( string glaze, string filling)
        {
            string key = $"{glaze}_{filling}";

            if (!_types.ContainsKey(key))
            {
                _types[key] = new DonutType( glaze, filling);
                Console.WriteLine($"A new type of donut has been created: {key}");
            }
            return _types[key];
        }
    }
}