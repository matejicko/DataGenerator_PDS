using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace DataGenerator
{
    public class PropertyDTO
    {
        public long id { get; set; }
        public int id_building_type { get; set; }
        public long id_property_tax { get; set; }
        public long id_sale_status { get; set; }

        public string description { get; set; }
        public int number_of_building { get; set; }
        public int id_street { get; set; }

        public double latitude { get; set; }
        public double longitude { get; set; }

        public string accessories { get; set; }
        public int year_built { get; set; }
        public double property_area_size { get; set; }
        public double living_area_size { get; set; }
        public string price_history { get; set; }
        public string parking { get; set; }
        public int count_of_bedrooms { get; set; }
        public int count_of_bathrooms { get; set; }
        public int count_of_stories { get; set; }
    }

    public class PropertyMapper : ClassMap<PropertyDTO>
    {
        public PropertyMapper()
        {            
            Map(x => x.price_history.ToString()).Optional();
            Map(x => x.parking.ToString()).Optional();
            Map(x => x.price_history.ToString()).Optional();
        }
    }
}
