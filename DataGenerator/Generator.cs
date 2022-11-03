﻿using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    public class Generator
    {
        public List<string> Descriptions;

        public Generator()
        {
            Descriptions = new List<string>();
            Descriptions.Add("Description generated by software");
        }

        public void Generate(string path)
        {
            PropertyDTO property;
            var config = new CsvConfiguration(CultureInfo.CurrentCulture);
            using (var writer = new StreamWriter("../../../../../" + path + ".csv", false))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteHeader<PropertyDTO>();
                csv.NextRecord();

                for (int i = 0; i < 1000; i++)
                {
                    property = GenerateProperty(i);
                    csv.WriteRecord(property);
                    csv.NextRecord();
                }
            }
        }

        public PropertyDTO GenerateProperty(int id)
        {
            var random = new Random(DateTime.Now.Millisecond);

            var property = new PropertyDTO()
            {
                id = id,
                id_building_type =
                    random.Next(Constants.MaxNumberOfBuildingTypes),
                id_property_tax =
                    random.Next(Constants.MaxNumberOfPropertyTaxTypes),
                id_sale_status =
                    random.Next(Constants.MaxNumberOfSaleStatuses),

                description =
                    Descriptions[random.Next(Descriptions.Count)],
                number_of_building =
                    random.Next(Constants.MaxNumberOfBuilding),
                id_street =
                    random.Next(Constants.MaxNumberOfIdStreet),
                latitude =
                    Constants.MinimalLatitude +
                    (Constants.MaximalLatitude - Constants.MinimalLatitude)
                    * random.NextDouble(),

                longitude =
                    Constants.MinimalLongitude +
                    (Constants.MaximalLongitude - Constants.MinimalLongitude)
                    * random.NextDouble(),

                accessories = GeneraterAccessories().ToString(),

                year_built =
                    Constants.MinimalYearBuilt +
                    random.Next(Constants.MaximalYearBuilt - Constants.MinimalYearBuilt),

                property_area_size =
                    Constants.MinimalPropertyAreaSize +
                    (Constants.MaximalPropertyAreaSize - Constants.MinimalPropertyAreaSize)
                    * random.NextDouble(),

                living_area_size =
                    Constants.MinimalLivingAreaSize +
                    (Constants.MaximalLivingAreaSize - Constants.MinimalLivingAreaSize)
                    * random.NextDouble(),

                price_history = GeneratePriceHistory().ToString(),

                count_of_bedrooms =
                    Constants.MinimalCountOfBedrooms +
                    random.Next(Constants.MaximalCountOfBedrooms - Constants.MinimalCountOfBedrooms),

                count_of_bathrooms =
                    Constants.MinimalCountOfBathrooms +
                    random.Next(Constants.MaximalYearBuilt - Constants.MinimalYearBuilt),

                count_of_stories =
                    Constants.MinimalCountOfStories +
                    random.Next(Constants.MaximalCountOfStories - Constants.MinimalCountOfStories),

                parking = GenerateParking().ToString()

            };

            return property;
        }

        private object GenerateParking()
        {
            var random = new Random(DateTime.UtcNow.Millisecond);
            var parking = new ParkingDTO
            {
                number_of_garage_parking_places =
                    Constants.MinimalGarageParkingPlaces +
                    random.Next(Constants.MaximalGarageParkingPlaces-Constants.MinimalGarageParkingPlaces),

                number_of_other_parking_places =
                    Constants.MinimalOtherParkingPlaces +
                    random.Next(Constants.MaximalOtherParkingPlaces - Constants.MinimalOtherParkingPlaces)
            };

            return parking;
        }

        private PriceHistoryDTO GeneratePriceHistory()
        {
            var random = new Random(DateTime.UtcNow.Millisecond);
            var priceHistory = new PriceHistoryDTO
            {
                price =
                    Constants.MinimalPrice +
                    (Constants.MaximalPrice - Constants.MinimalPrice)
                    * random.NextDouble(),

                date =
                    Constants.MinimalDateOfPriceHistory
                    .AddDays(random.Next(Constants.MaximalDateOfPriceHistory.Day - Constants.MinimalDateOfPriceHistory.Day)),

                appraiser = "Random appraiser"
            };

            return priceHistory;
        }

        private AccessoriesDTO GeneraterAccessories()
        {
            var random = new Random(DateTime.UtcNow.Millisecond);
            var accessories = new AccessoriesDTO
            {
                hasAssociation = random.NextDouble() < 0.5,
                allowedAnimals = random.NextDouble() < 0.5,
                hasCooling = random.NextDouble() < 0.5,
                hasHeating = random.NextDouble() < 0.5,
                hasSpa = random.NextDouble() < 0.5
            };
            return accessories;
        }

        public static void GenerateDistincts(string key, string newFile)
        {
            var list = new LinkedList<string>();
            var addresses = new Dictionary<string, Record>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                BadDataFound = arg => list.AddFirst(arg.Context.Parser.RawRecord)
            };

            using (var reader = new StreamReader("../../../../../newyork_housing.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();
                for (int i = 0; i < 1000 && csv.Read(); i++)
                {
                    var address = csv.GetField(key);
                    var record = new Record
                    {
                        Value = address
                    };

                    try
                    {
                        addresses.Add(address, record);
                    }
                    catch (Exception)
                    {

                    }

                    csv.GetRecords<dynamic>();

                }
            }

            var config2 = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                BadDataFound = arg => list.AddFirst(arg.Context.Parser.RawRecord)
            };

            using (var writer = new StreamWriter("../../../../../" + newFile + ".csv", false))
            using (var csv = new CsvWriter(writer, config2))
            {

                foreach (var add in addresses)
                {
                    csv.WriteRecord<Record>(add.Value);
                    csv.NextRecord();
                }
            }
        }
    }

    public class Record
    {
        public string Value { get; set; }
    }
}
