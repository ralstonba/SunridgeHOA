using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunridgeHOA.Models;

namespace SunridgeHOA.Data
{
    public class EventRepository : IEventRepository
    {
        public IQueryable<ScheduledEvent> Events => new List<ScheduledEvent>
        {
            new ScheduledEvent {Subject = "My first event", Description = "An event description", Start = DateTime.Today.AddDays(2), IsFullDay = false},
            new ScheduledEvent {Subject = "My second event", Description = "An event description", Start = System.DateTime.Today, IsFullDay = false},
            new ScheduledEvent {Subject = "My third event", Description = "An event description", Start = System.DateTime.Today.AddDays(4), IsFullDay = true}
        }.AsQueryable<ScheduledEvent>();
    }
}
