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
        Station CreateStation(Station station);
        Station GetStation(int id);
        IEnumerable<Station> GetAllStations();
        Station UpdateStation(Station station, int id);
        void DeleteStation(int id);
    }
}
