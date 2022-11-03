using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
    internal class Constants
    {
        //----------------------PROPERTY LIMITS----------------------
        public static int MaxNumberOfBuildingTypes = 10;
        public static int MaxNumberOfPropertyTaxTypes = 10;
        public static int MaxNumberOfSaleStatuses = 10;

        public static int MaxNumberOfBuilding = 10;
        public static int MaxNumberOfIdStreet = 10;

        public static float MinimalLongitude = 10;
        public static float MinimalLatitude = 10;
        public static float MaximalLongitude = 10;
        public static float MaximalLatitude = 10;

        public static int MinimalYearBuilt = 1900;
        public static int MaximalYearBuilt = 2022;

        public static float MinimalPropertyAreaSize = 10;
        public static float MaximalPropertyAreaSize = 10;
        public static float MinimalLivingAreaSize = 10;
        public static float MaximalLivingAreaSize = 10;

        public static int MinimalCountOfBedrooms = 0;
        public static int MaximalCountOfBedrooms = 10;
        public static int MinimalCountOfBathrooms = 1;
        public static int MaximalCountOfBathrooms = 10;
        public static int MinimalCountOfStories = 1;
        public static int MaximalCountOfStories = 15;

        //----------------------PARKING LIMITS----------------------
        public static int MinimalGarageParkingPlaces = 0;
        public static int MaximalGarageParkingPlaces = 6;
        public static int MinimalOtherParkingPlaces = 0;
        public static int MaximalOtherParkingPlaces = 8;

        //----------------------PRICE HISTORY----------------------
        public static DateTime MinimalDateOfPriceHistory = new DateTime(1900, 1, 1);
        public static DateTime MaximalDateOfPriceHistory = DateTime.Now;
        public static float MinimalPrice = 10000;
        public static float MaximalPrice = 100000000;
    }
}
