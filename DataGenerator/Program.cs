using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator();
            generator.Generate("properties");

            //Generator.GenerateDistincts("address/zipcode", "zip_codes");
            //Generator.GenerateDistincts("description", "descriptions");
            //Generator.GenerateDistincts("latitude", "latitudes");
            //Generator.GenerateDistincts("longitude", "longitudes");
        }
        
    }
}
