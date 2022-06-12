using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services
{
    interface IDbService
    {
        Task<IEnumerable<SomeSortOfTrip>> GetTrips();
        Task RemoveTrip(int id);
    }
}
