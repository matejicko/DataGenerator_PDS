using System.Text.Json;

namespace DataGenerator
{
    public class ParkingDTO
    {
        public int number_of_garage_parking_places { get; set; }
        public int number_of_other_parking_places { get; set; }

        public override string ToString()
        {
            var json = JsonSerializer.Serialize(this);
            return json;
        }
    }
}