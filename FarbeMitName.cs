using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpieleGlücksrad
{
    [Serializable]
    public class FarbeMitName
    {
        public Color Color { get; set; }
        public string Name { get; set; }

        public FarbeMitName(Color color, string name)
        {
            Color = color;
            Name = name;
        }
    }
}
