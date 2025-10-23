using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA.Persistence.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int? id = null, string? message = null)
            : base(message ?? $"Entity with id '{(id.HasValue ? id.ToString() : "unknown")}' not found.") { }
    }

    public class KlantNotFoundException : EntityNotFoundException
    {
        public KlantNotFoundException() : base() { }
        public KlantNotFoundException(int id) : base(id: null, message: $"Klant Entity '{id}' not found.") { }
        public KlantNotFoundException(int id, string message) : base(id, message) { }
    }

    public class StationNotFoundException : EntityNotFoundException
    {
        public StationNotFoundException() : base() { }
        public StationNotFoundException(int id) : base(id: null, message: $"Station Entity '{id}' not found.") { }
        public StationNotFoundException(int id, string message) : base(id, message) { }
    }

    public class AbonnementNotFoundException : EntityNotFoundException
    {
        public AbonnementNotFoundException() : base() { }
        public AbonnementNotFoundException(int id) : base(id: null, message: $"Abonnement Entity '{id}' not found.") { }
        public AbonnementNotFoundException(int id, string message) : base(id, message) { }
    }
}
