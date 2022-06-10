using RazorPagesLearning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Services.LocationRepository
{
    public class MockLocationRepository : ILocationRepository
    {
        private List<Location> LocationList;
        public MockLocationRepository()
        {
            LocationList = new List<Location>() {};
        }
        public void AddLocation(Location location)
        {
            LocationList.Add(location);
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return LocationList;
        }

        public Location? GetLocationByID(int id)
        {
            foreach(var location in LocationList)
            {
                if(location.Id == id) return location;
            }
            return null;
        }

        public void RemoveLocation(Location location)
        {
            LocationList.Remove(location);
        }
    }
}
