using System.ComponentModel.DataAnnotations;

namespace SpieleGlücksrad
{
    //Keyword das die Klasse Serializiert werden kann
    [Serializable]
    public class GrSettings
    {   
        //Beim erstellen wird die Klasse mit Standart werten gefüllt
        public GrSettings()
        {
            Color = new List<FarbeMitName>();
            speed = 15;
            MaxDuration = 10000;
            MinDuration = 5000;
            verzögerung = 1000;


        }

        public List<FarbeMitName> Color { get; set; }
        public int speed { get; set; }
        public int MaxDuration { get; set; }
        public int MinDuration { get; set; }
        public string Path { get; set; }
        public int verzögerung { get; set; }

    }
}