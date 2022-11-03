using System;
using System.Text.Json;

namespace DataGenerator
{
    public class PriceHistoryDTO
    {
        public double price { get; set; }
        public DateTime date { get; set; }
        public string appraiser { get; set; }

        public override string ToString()
        {
            var json = JsonSerializer.Serialize(this);
            return json;
        }
    }
}