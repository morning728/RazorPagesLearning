using RazorPagesLearning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Services.LocationRepository
{
    public class SQLLocationRepository : ILocationRepository
    {
        private readonly AppDBContext _context;

        public SQLLocationRepository(AppDBContext context)
        {
            _context = context;
        }
        public void AddLocation(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _context.Locations;  
        }

        public Location? GetLocationByID(int id)
        {
            return _context.Locations.Find(id);
        }

        public void RemoveLocation(Location location)
        {
            Location Location = _context.Locations.Find(location.Id);
            if(Location != null)
            {
                _context.Locations.Remove(Location);
                _context.SaveChanges();
            }
        }
    }
}
