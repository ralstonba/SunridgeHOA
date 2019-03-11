using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunridgeHOA.Models;

namespace SunridgeHOA.Data
{
    public interface IEventRepository
    {
        IQueryable<ScheduledEvent> Events { get; }
    }
}
