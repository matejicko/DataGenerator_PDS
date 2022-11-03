using System.Text.Json;

namespace DataGenerator
{
    public class AccessoriesDTO
    {
        public bool hasAssociation { get; set; }
        public bool hasCooling { get; set; }
        public bool hasHeating { get; set; }
        public bool hasSpa { get; set; }
        public bool allowedAnimals { get; set; }

        public override string ToString()
        {
            var json = JsonSerializer.Serialize(this);
            return json;
        }
    }

    
}