using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA.Persistence.Entities;

namespace TA.Persistence.Interfaces
{
    public interface IStationRepository
    {
        Task<Station> CreateStation(Station station);
        Task<Station> GetStation(int id);
        Task<IEnumerable<Station>> GetAllStations();
        Task<Station> UpdateStation(Station station, int id);
        Task DeleteStation(int id);
    }
}
