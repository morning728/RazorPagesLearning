using RazorPagesLearning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Services.LocationRepository
{
    public interface ILocationRepository
    {
        public IEnumerable<Location> GetAllLocations();

        public Location? GetLocationByID(int id);

        public void AddLocation(Location location);

        public void RemoveLocation(Location location);
    }
}
