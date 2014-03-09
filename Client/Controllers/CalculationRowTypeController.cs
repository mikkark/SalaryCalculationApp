using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using mikkark.SCA.Core.Model;

namespace mikkark.SCA.Client.Controllers
{
    public class CalculationRowTypeController : ApiController
    {
        private static readonly ConcurrentDictionary<string, CalculationRowType> _rowtypes =
            new ConcurrentDictionary<string, CalculationRowType>();

        static CalculationRowTypeController()
        {
            string id = Guid.NewGuid().ToString();
            _rowtypes.TryAdd(id, new CalculationRowType {Id = id, Name = "Gross salary", RowType = "plus"});

            id = Guid.NewGuid().ToString();
            _rowtypes.TryAdd(id, new CalculationRowType {Id = id, Name = "Vacation compensation", RowType = "plus"});

            id = Guid.NewGuid().ToString();
            _rowtypes.TryAdd(id,
                new CalculationRowType {Id = id, Name = "Eating at company restaurant", RowType = "minus"});
        }

        public IList<CalculationRowType> Get()
        {
            return _rowtypes.Values.ToList();
        }

        public CalculationRowType Get(string id)
        {
            return _rowtypes[id];
        }
    }
}