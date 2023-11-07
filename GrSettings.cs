using System.ComponentModel.DataAnnotations;

namespace SpieleGlücksrad
{
    [Serializable()]
    public class GrSettings
    {
        public GrSettings()
        {
            Color = new List<FarbeMitName>();
            speed = 15;
            MaxDuration = 10000;
            MinDuration = 5000;

        }

        public List<FarbeMitName> Color { get; set; }
        public int speed { get; set; }
        public int MaxDuration { get; set; }
        public int MinDuration { get; set; }
        public string Path { get; set; }

    }
}