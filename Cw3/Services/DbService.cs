using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services
{
    public class DbService : IDbService
    {
        private readonly efContext _dbContext;
        public DbService(efContext efContext)
        {
            _dbContext = _dbContext;
        }

        public async Task<IEnumerable<SomeSortOfTrip>> GetTrips()
        {
            return await _dbContext.Trips
                .Select(e => new SomeSortOfTrip
                {
                    Name = e.Name,
                    Description = e.Description,
                    MaxPeople = e.MaxPeople,
                    DateFrom = e.DateFrom,
                    DateTo = e.DateTo,
                    Countries = e.CountryTrips.Select(e => new SomeSortOfCountry { Name = e.IdCountryNavigation.Name }).ToList(),
                    Clients = e.ClientTrips.Select(e => new SomeSortOfClient { FirstName = e.IdClientNavigation.FirstName, LastName = e.IdClientNavigation.LastName }).ToList(),
                }).ToListAsync();

        }

        public async Task RemoveTrip(int id)
        {
            //var trip = await _dbContext.Trips.Where(e => e.IdTrip == id).FirstOrDefaultAsync();
            
            //dodawanie
            //var addTrip = new Trip { IdTrip = id, Name = "nazwa" };
            //_dbContext.Add(addTrip);

            //edycja
            //var editTrip = await _dbContext.Trips.Where(e => e.IdTrip == id).FirstOrDefaultAsync();
            //editTrip.Name = "aaa";


            var trip = new Trip() { IdTrip = id };

            _dbContext.Attach(trip);
            _dbContext.Remove(trip);

            await _dbContext.SaveChangesAsync();
        }
    }
}
